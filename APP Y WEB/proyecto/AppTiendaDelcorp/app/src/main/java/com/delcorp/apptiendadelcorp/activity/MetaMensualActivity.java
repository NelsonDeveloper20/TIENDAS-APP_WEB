package com.delcorp.apptiendadelcorp.activity;

import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.PointF;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.animation.OvershootInterpolator;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.ReporteMeta;
import com.delcorp.apptiendadelcorp.webservice.WebService;
import com.hookedonplay.decoviewlib.DecoView;
import com.hookedonplay.decoviewlib.charts.EdgeDetail;
import com.hookedonplay.decoviewlib.charts.SeriesItem;
import com.hookedonplay.decoviewlib.charts.SeriesLabel;
import com.hookedonplay.decoviewlib.events.DecoEvent;

import org.w3c.dom.DOMImplementation;

public class MetaMensualActivity extends AppCompatActivity {

    ImageView imgAtras;
    ReporteMeta objReporteMeta;
    DecoView arcView ;
    Dialog progress;
    TextView txt,txtVentasRealizadas,txtMontoRecaudado,txtMeta,txtMes,txtMontoFaltante;
    String idUsuario;
    SharedPreferences pref;
    TextView txtTitulo;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_meta_mensual);
        pref =   getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;

        txtTitulo=findViewById(R.id.txtTitulo);
        txtMeta=findViewById(R.id.txtMeta);
        txtMes=findViewById(R.id.txtMes);
        txtVentasRealizadas=findViewById(R.id.txtVentasRealizadas);
        txtMontoRecaudado=findViewById(R.id.txtMontoRecaudado);
        idUsuario = pref.getString("idUsuarioVenta","0");
        imgAtras=findViewById(R.id.imgAtras);
        txtMontoFaltante=findViewById(R.id.txtMontoFaltante);
        arcView = findViewById(R.id.dynamicArcView);
        imgAtras.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });

        progress = new Dialog(MetaMensualActivity.this);
        progress.requestWindowFeature(Window.FEATURE_NO_TITLE);
        progress.setCancelable(false);
        progress.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
        progress.setContentView(R.layout.dialog_procesando);

        txt = progress.findViewById(R.id.txt);
        txt.setText("Obteniendo Datos...");
       // progress.show();

        if(getIntent().getExtras().getString("reporte").equals("1")){
            idUsuario= pref.getString("idUsuarioVenta","0");
            txtTitulo.setText("Mi Meta Mensual");
        }else if(getIntent().getExtras().getString("reporte").equals("2")){
            idUsuario= pref.getString("idUsuarioCliente","0");
            txtTitulo.setText("Meta del Cliente");
        }

        new ListarData().execute();

    }


    private class ListarData extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            objReporteMeta = new WebService().reporteMeta(idUsuario);
            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            if(  objReporteMeta==null){
                progress.dismiss();
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(MetaMensualActivity.this);

                builder.setTitle("Ocurrio un error") ;
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        new  ListarData().execute();

                    }
                });
                builder.setNegativeButton("Salir", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        finish();
                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();
           /* }else  if(objReporteMeta.getIdMetaMensual().equals("null")) {
                finish();
                Toast.makeText(getApplicationContext(),"USTED NO TIENE ASIGNADA UNA META MENSUAL , CONSULTE CON EL ADMINISTRADOR DEL SISTEMA",Toast.LENGTH_LONG).show();

            */
            }else{
                progress.dismiss();
                cargaChart(Integer.parseInt(objReporteMeta.getPorcenActual()),  0 , 100-(Integer.parseInt(objReporteMeta.getPorcenActual())),objReporteMeta);
            }

        }
    }


    public void cargaChart(Integer pATiempo,Integer pFalta, Integer pTarde ,ReporteMeta obj) {


        txtVentasRealizadas.setText(obj.getCantVentas());
        txtMontoRecaudado.setText("S/. " + obj.getMontoHastaHoy());
        txtMeta.setText("S/. " + obj.getMeta());

        Double v = (Double.parseDouble(obj.getMeta().replace(",",".") + "") - Double.parseDouble(obj.getMontoHastaHoy().replace(",",".") + ""));

        if (!obj.getMeta().equals("0")){
            txtMontoFaltante.setText("S/. " + (Math.round(v * 100.0) / 100.0));
            }
        txtMes.setText(obj.getFecha());

        String por =  (Math.round( (Double.parseDouble(obj.getMontoHastaHoy().replace(",","."))*100)/Double.parseDouble(obj.getMeta().replace(",",".")) * 100.0 )/ 100.0 ) +"";

        arcView.addSeries(new SeriesItem.Builder(Color.argb(255, 218, 218, 218))
                .setRange(0, 100, 100)
                .setInitialVisibility(false)
                .setLineWidth(30f)
                .setInset(new PointF(5f, 5f))
                .build());

        Integer color = 0 ;
        if(Double.parseDouble(obj.getMetaHastaHoy().replace(",","."))<= Double.parseDouble(obj.getMontoHastaHoy().replace(",","."))){
            color = getResources().getColor(R.color.coloVerde);
        }else{
            color = getResources().getColor(R.color.colorAmbar);
        }

        SeriesItem rATiempo = new SeriesItem.Builder(color)
                .setRange(0, 100, 0)
                .setInitialVisibility(true)
                .setLineWidth(30f)
                .addEdgeDetail(new EdgeDetail(EdgeDetail.EdgeType.EDGE_OUTER, Color.parseColor("#22000000"), 0.4f))
                .setSeriesLabel(new SeriesLabel.Builder("Ventas \n"+por+" %%  " ).build())
                .setInterpolator(new OvershootInterpolator())
                .setShowPointWhenEmpty(false)
                .setCapRounded(true)
                .setInset(new PointF(5f, 5f))
                .setDrawAsPoint(false)
                .setSpinClockwise(true)
                .setSpinDuration(6000)
                .setChartStyle(SeriesItem.ChartStyle.STYLE_DONUT)
                .build();

        int seriesATiempo = arcView.addSeries(rATiempo);


        arcView.addEvent(new DecoEvent.Builder(DecoEvent.EventType.EVENT_SHOW, true)
                .setDelay(100)
                .setDuration(300)
                .build());

        if(pATiempo+pFalta+pTarde<100){
            pATiempo = pATiempo + (100 - (pATiempo+pFalta+pTarde));
        }

        if(!obj.getMeta().equals("0")) {
            arcView.addEvent(new DecoEvent.Builder(pATiempo).setIndex(seriesATiempo).setDelay(750).build());
        }
    }
}
