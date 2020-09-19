package com.delcorp.apptiendadelcorp.activity;

import android.app.Dialog;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.ParametrosSalida;
import com.delcorp.apptiendadelcorp.webservice.WebService;

public class AvanceDiarioActivity extends AppCompatActivity {

    ImageView imgAtras;
    SharedPreferences pref ;
    String id;
Dialog progress;
ImageView btnRefres;
TextView txt,txtVendedor,txtTotalClientes,txtClienteVisitado,txtClienteConPedido,txtPedidosVendedor,txtPedidoBodega,txtAvanceRuta,txtMontoTotalVenta,txtCantidadTotalItem,txtUltimoPedido;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_avance_diario);

        pref =   getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;
        id = pref.getString("idUsuarioVenta","0");

        btnRefres=findViewById(R.id.btnRefres);
        btnRefres.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                progress = new Dialog(AvanceDiarioActivity.this);
                progress.requestWindowFeature(Window.FEATURE_NO_TITLE);
                progress.setCancelable(false);
                progress.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
                progress.setContentView(R.layout.dialog_procesando);

                txt = progress.findViewById(R.id.txt);
                txt.setText("Obteniendo Datos...");
                progress.show();
                new validaUsuario().execute();
            }
        });
        txtVendedor=findViewById(R.id.txtVendedor);
        txtVendedor.setText(pref.getString("nombre",""));
        txtTotalClientes =findViewById(R.id.txtTotalClientes);
        txtClienteVisitado =findViewById(R.id.txtClienteVisitado);
        txtClienteConPedido =findViewById(R.id.txtClienteConPedido);
        txtPedidosVendedor =findViewById(R.id.txtPedidosVendedor);
        txtPedidoBodega =findViewById(R.id.txtPedidoBodega);
        txtAvanceRuta =findViewById(R.id.txtAvanceRuta);
        txtMontoTotalVenta =findViewById(R.id.txtMontoTotalVenta);
        txtCantidadTotalItem =findViewById(R.id.txtCantidadTotalItem);
        txtUltimoPedido =findViewById(R.id.txtUltimoPedido);

        imgAtras=findViewById(R.id.imgAtras);
        imgAtras.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });


        progress = new Dialog(AvanceDiarioActivity.this);
        progress.requestWindowFeature(Window.FEATURE_NO_TITLE);
        progress.setCancelable(false);
        progress.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
        progress.setContentView(R.layout.dialog_procesando);

        txt = progress.findViewById(R.id.txt);
        txt.setText("Obteniendo Datos...");
        progress.show();
        new validaUsuario().execute();

    }


    private class validaUsuario extends AsyncTask<String,Void,Object> {

        ParametrosSalida objparametros;

        @Override
        protected Object doInBackground(String... strings) {
            objparametros = new WebService().reporteEficiencia(id);
            return null;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            progress.dismiss();
            if (objparametros.getFlagIndicador()==0) {

                txtTotalClientes.setText(objparametros.getParam1());
                txtClienteVisitado.setText(objparametros.getParam2());
                txtClienteConPedido.setText(objparametros.getParam3());
                txtPedidosVendedor.setText(objparametros.getParam4());
                txtPedidoBodega.setText(objparametros.getParam5());
                txtAvanceRuta.setText(objparametros.getParam6());
                txtMontoTotalVenta.setText(objparametros.getParam7());
                txtCantidadTotalItem.setText(objparametros.getParam8());
                txtUltimoPedido.setText(objparametros.getParam9() + " "+objparametros.getParam10());


            } else if (objparametros.getFlagIndicador()==1){
                Toast.makeText(getApplicationContext(),   objparametros.getMsgValidacion() + "", Toast.LENGTH_SHORT).show();
            } else if ( objparametros.getFlagIndicador()==9){
                Toast.makeText(getApplicationContext(),"VERIFIQUE EL INTERNET",Toast.LENGTH_SHORT).show();

            }
        }
    }


}
