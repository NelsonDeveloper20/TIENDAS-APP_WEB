package com.delcorp.apptiendadelcorp.activity;

import android.app.Dialog;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.CardView;
import android.view.View;
import android.view.Window;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.ParametrosSalida;
import com.delcorp.apptiendadelcorp.webservice.WebService;

public class ContactoActivity extends AppCompatActivity {

    CardView btnLlamanos;
    SharedPreferences pref;
    String idUsuarioCliente;
    TextView msj;
    ImageView imgAtras;
    Dialog dialog;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_contacto);

        imgAtras=findViewById(R.id.imgAtras);
        imgAtras.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });

        pref =   getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;
        idUsuarioCliente = pref.getString("idUsuarioCliente","");


        dialog = new Dialog(ContactoActivity.this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setCancelable(false);
        dialog.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
        dialog.setContentView(R.layout.dialog_procesando);

        msj = dialog.findViewById(R.id.txt);

        btnLlamanos=findViewById(R.id.btnLlamanos);
        btnLlamanos.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                msj.setText("Cancelando...");
                dialog.dismiss();
                 new obtenNumero().execute();

            }
        });
    }


    private class obtenNumero extends AsyncTask<String,Void,Object> {

        ParametrosSalida objparametros;

        @Override
        protected Object doInBackground(String... strings) {
            objparametros = new WebService().obtenNumeroVendedor(idUsuarioCliente );
            return null;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            dialog.dismiss();

            if (objparametros.getFlagIndicador()==0) {

                Intent callIntent = new Intent(Intent.ACTION_DIAL);
                callIntent.setData(Uri.parse("tel:"+objparametros.getParam2()));
                startActivity(callIntent);

            } else if (objparametros.getFlagIndicador()==1){
                Toast.makeText(getApplicationContext(),   objparametros.getMsgValidacion() + "", Toast.LENGTH_SHORT).show();
            } else if ( objparametros.getFlagIndicador()==9){
                Toast.makeText(getApplicationContext(),"VERIFIQUE EL INTERNET",Toast.LENGTH_SHORT).show();

            }
        }
    }


}
