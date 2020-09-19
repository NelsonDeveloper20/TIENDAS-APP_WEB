package com.delcorp.apptiendadelcorp.activity;

import android.app.ActionBar;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.CardView;
import android.support.v7.widget.DefaultItemAnimator;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.StaggeredGridLayoutManager;
import android.view.View;
import android.view.Window;
import android.view.animation.AnimationUtils;
import android.view.animation.LayoutAnimationController;
import android.view.animation.TranslateAnimation;
import android.widget.DatePicker;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.daimajia.androidanimations.library.Techniques;
import com.daimajia.androidanimations.library.YoYo;
import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Cliente;
import com.delcorp.apptiendadelcorp.bean.Pedido;
import com.delcorp.apptiendadelcorp.bean.PedidoO;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCliente;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePedido;
import com.delcorp.apptiendadelcorp.webservice.WebService;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

public class ListaPedidosActivity extends AppCompatActivity {

    RecyclerView rc;
    Dialog dialog;
    TextView msj;
    CustomListPedidos adapter;
    SharedPreferences pref;
    ArrayList<PedidoO> arrayPedidos ;
    String idUsuario;
    ImageView imgAtras;
    TextView txtTitulo,txtInicio,txtFinal;
    Calendar fechaInicio = Calendar.getInstance();
    String fecInicio,fecFinal;
    LinearLayout linearVacio;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_lista_pedidos);
        pref =   getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;
        setTitle("Lista de Pedidos");

        linearVacio=findViewById(R.id.linearVacio);
        txtInicio=findViewById(R.id.txtInicio);
        txtFinal = findViewById(R.id.txtFinal);

        txtTitulo =findViewById(R.id.txtTitulo);
        rc = findViewById(R.id.rc);
        dialog = new Dialog(ListaPedidosActivity.this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setCancelable(false);
        dialog.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
        dialog.setContentView(R.layout.dialog_procesando);

        msj = dialog.findViewById(R.id.txt);

        RecyclerView.ItemAnimator itemAnimator = new DefaultItemAnimator();
        itemAnimator.setAddDuration(1000);
        itemAnimator.setRemoveDuration(1000);
        rc.setItemAnimator(itemAnimator);
        msj.setText("Obteniendo Datos..");


        if(getIntent().getExtras().getString("reporte").equals("1")){
            idUsuario= pref.getString("idUsuarioVenta","0");
            txtTitulo.setText("Lista Ventas");
        }else if(getIntent().getExtras().getString("reporte").equals("2")){
            idUsuario= pref.getString("idUsuarioCliente","0");
            txtTitulo.setText("Lista de Pedidos");
        }


        imgAtras=findViewById(R.id.imgAtras);
        imgAtras.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });

        txtInicio.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                muestraCalendarioInicio();
            }
        });

        txtFinal.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                muestraCalendarioFinal();
            }
        });

        Calendar cal = Calendar.getInstance();
        String hoy = new SimpleDateFormat("dd/MM/yyyy").format(cal.getTime());
        txtInicio.setText(hoy);
        txtFinal.setText(hoy);
        fecInicio=hoy;
        fecFinal=hoy;


        dialog.show();
        new ListarPedidos().execute();
    }


    public void listarPedidos( ArrayList<PedidoO> lstPedido){

        //SqlitePedido sql = new SqlitePedido();
        //ArrayList<Pedido> lstPedido = sql.listarPedidos(getApplicationContext(), cod);
        if(lstPedido.size()==0){
            linearVacio.setVisibility(View.VISIBLE);
            rc.setVisibility(View.GONE);
        }else if (lstPedido.size()>0){
            linearVacio.setVisibility(View.GONE);
            rc.setVisibility(View.VISIBLE);
        }

        adapter = new CustomListPedidos( this,lstPedido);
        adapter.notifyDataSetChanged();

        /*crear controlador de animacion*/
        LayoutAnimationController controller = null;
        controller = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

        rc.setLayoutManager(new StaggeredGridLayoutManager(  1, StaggeredGridLayoutManager.VERTICAL));
        rc.setItemViewCacheSize(lstPedido.size());
        /*setear controlador de animacion*/
        rc.setLayoutAnimation(controller);
        /*setear adaptador con datos*/
        rc.setAdapter(adapter);
        /*setear manejador de animacion*/
        rc.scheduleLayoutAnimation();
        //extender(i,true);
        dialog.dismiss();
    }


    private class ListarPedidos extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            arrayPedidos = new WebService().ListaPedidoO(idUsuario,fecInicio,fecFinal);
            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            if(  arrayPedidos==null){
                dialog.dismiss();
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(ListaPedidosActivity.this);

                builder.setTitle("Ocurrio un error de red") ;
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        dialog.show();
                        new  ListarPedidos().execute();

                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();
            }else{

                listarPedidos(arrayPedidos);
            }



        }
    }


    public  void muestraCalendarioInicio(){
        final Calendar c = Calendar.getInstance();
        int mYear = c.get(Calendar.YEAR);
        int mMonth = c.get(Calendar.MONTH);
        int mDay = c.get(Calendar.DAY_OF_MONTH);

        DatePickerDialog datePickerDialog = new DatePickerDialog(ListaPedidosActivity.this,R.style.TimePicker,
                new DatePickerDialog.OnDateSetListener() {

                    @Override
                    public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
                        String mes,dia;
                        if(String.valueOf(monthOfYear+1).length()==1){
                            mes= "0"+ (monthOfYear+1);
                        }else{
                            mes = monthOfYear+1+"";
                        }
                        if(String.valueOf(dayOfMonth).length()==1){
                            dia= "0"+ dayOfMonth;
                        }else{
                            dia = dayOfMonth+"";
                        }
                        txtInicio.setText(dia+"/"+mes+"/"+year);
                        fecInicio= dia+"/"+mes+"/"+year;
                        txtFinal.setText("Selecciona Fecha ");
                        YoYo.with(Techniques.Shake)
                                .duration(500)
                                .repeat(2)
                                .playOn(findViewById(R.id.txtFinal));

                        SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy");
                        Date date = null;
                        try {
                            date = sdf.parse(dia+"/"+mes+"/"+year);
                        } catch (ParseException e) {
                            e.printStackTrace();
                        }
                        Calendar cal = Calendar.getInstance();
                        cal.setTime(date);

                        fechaInicio=cal;

                    }
                }, mYear, mMonth, mDay);
        datePickerDialog.getDatePicker().setMinDate(Calendar.getInstance().getTimeInMillis());
        Calendar endDate = Calendar.getInstance();
        endDate.add(Calendar.DAY_OF_MONTH, + 0);
        Calendar iniDate = Calendar.getInstance();
        iniDate.add(Calendar.YEAR, - 2);

        datePickerDialog.getDatePicker().setMinDate(iniDate.getTimeInMillis());
         datePickerDialog.getDatePicker().setMaxDate(endDate.getTimeInMillis());
        LinearLayout linearLayout = new LinearLayout(getApplicationContext());
        datePickerDialog.setCustomTitle(linearLayout);
        datePickerDialog.show();
    }
    public  void muestraCalendarioFinal(){
          Calendar c = fechaInicio;
        int mYear = c.get(Calendar.YEAR);
        int mMonth = c.get(Calendar.MONTH);
        int mDay = c.get(Calendar.DAY_OF_MONTH);

        DatePickerDialog datePickerDialog = new DatePickerDialog(ListaPedidosActivity.this,R.style.TimePicker,
                new DatePickerDialog.OnDateSetListener() {

                    @Override
                    public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
                        String mes,dia;
                        if(String.valueOf(monthOfYear+1).length()==1){
                            mes= "0"+ (monthOfYear+1);
                        }else{
                            mes = monthOfYear+1+"";
                        }
                        if(String.valueOf(dayOfMonth).length()==1){
                            dia= "0"+ dayOfMonth;
                        }else{
                            dia = dayOfMonth+"";
                        }
                        txtFinal.setText(dia+"/"+mes+"/"+year);
                        fecFinal= dia+"/"+mes+"/"+year;

                        dialog.show();
                        new ListarPedidos().execute();
                    }
                }, mYear, mMonth, mDay);


        Calendar iniDate = fechaInicio;
        iniDate.add(Calendar.DAY_OF_MONTH, - 0);

        datePickerDialog.getDatePicker().setMinDate(iniDate.getTimeInMillis());

        Calendar endDate = Calendar.getInstance();
        endDate.add(Calendar.DAY_OF_MONTH, + 180);

        if(endDate.compareTo(Calendar.getInstance())>0){ //end date es mayor instance
            endDate = Calendar.getInstance();
        }

        datePickerDialog.getDatePicker().setMaxDate(endDate.getTimeInMillis());

        LinearLayout linearLayout = new LinearLayout(getApplicationContext());
        datePickerDialog.setCustomTitle(linearLayout);
        datePickerDialog.show();
    }

}
