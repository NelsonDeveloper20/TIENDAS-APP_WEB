package com.delcorp.apptiendadelcorp.activity;

import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.icu.text.UnicodeSetSpanner;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.view.Window;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.ParametrosSalida;
import com.delcorp.apptiendadelcorp.sqlite.SqliteVisita;
import com.delcorp.apptiendadelcorp.webservice.WebService;

import java.text.SimpleDateFormat;
import java.util.Calendar;

public class DetalleClienteActivity extends AppCompatActivity {

    String Codigo, Nombre, Paterno, Materno, Direccion;
    TextView txtCodigo, txtNombre, txtPaterno, txtMaterno, txtDireccion;
    SharedPreferences pref;
    LinearLayout btnPedido, btnVisitado;
    Dialog dialog,progress;
    TextView txt;
    Integer flagClear=0;
    SqliteVisita sql = new SqliteVisita();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_detalle_cliente);
        pref = getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE);
        setTitle("Detalle de Cliente");

        Codigo = getIntent().getExtras().getString("idCliente");
        Nombre = getIntent().getExtras().getString("Nombre");
        Paterno = getIntent().getExtras().getString("Paterno");
        Materno = getIntent().getExtras().getString("Materno");
        Direccion = getIntent().getExtras().getString("Direccion");

        txtCodigo = findViewById(R.id.txtCodigo);
        txtCodigo.setText(Codigo);
        txtNombre = findViewById(R.id.txtNombre);
        txtNombre.setText(Nombre);
        txtPaterno = findViewById(R.id.txtPaterno);
        txtPaterno.setText(Paterno);
        txtMaterno = findViewById(R.id.txtMaterno);
        txtMaterno.setText(Materno);
        txtDireccion = findViewById(R.id.txtDireccion);
        txtDireccion.setText(Direccion);

        btnPedido = findViewById(R.id.btnPedido);
        btnPedido.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                SharedPreferences.Editor editor = pref.edit();
                editor.putString("idUsuarioCliente", txtCodigo.getText().toString());
                editor.putString("nomCliente", txtNombre.getText() + " " + txtPaterno.getText() + " " + txtMaterno.getText());
                editor.putString("origen","0");
                editor.commit();

                Intent i = new Intent(DetalleClienteActivity.this, MainActivity.class);
                i.putExtra("muestra","2");
                i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                startActivity(i);
            }
        });
        btnVisitado = findViewById(R.id.btnVisitado);
        btnVisitado.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                progress = new Dialog(DetalleClienteActivity.this);
                progress.requestWindowFeature(Window.FEATURE_NO_TITLE);
                progress.setCancelable(false);
                progress.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
                progress.setContentView(R.layout.dialog_procesando);

                txt = progress.findViewById(R.id.txt);
                txt.setText("Procesando...");
                progress.show();
                new ListarData().execute();

            }
        });

     //   getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home:
                if(flagClear==0){
                    finish();
                }else if (flagClear==1){
                    Intent i = new Intent(DetalleClienteActivity.this,ListaClienteActivity.class);
                    i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP|Intent.FLAG_ACTIVITY_CLEAR_TASK);
                    startActivity(i);
                }
                return true;
        }
        return super.onOptionsItemSelected(item);
    }

    private class ListarData extends AsyncTask<String, Void, Object> {

        ParametrosSalida objparametros;

        @Override
        protected Object doInBackground(String... strings) {

            objparametros = new WebService().InsertaVisita(pref.getString("idUsuarioCliente", ""), pref.getString("idUsuarioVenta", ""));
            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            progress.dismiss();
            if(objparametros.getFlagIndicador()==9){
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(DetalleClienteActivity.this);

                builder.setTitle("Ocurrio un error de red") ;
                builder.setMessage("No se pudo conectar a la red");
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        new ListarData().execute();

                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();
            }else if (objparametros.getFlagIndicador()==1){
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(DetalleClienteActivity.this);
                builder.setTitle("Ocurrio un error al registrar la visita") ;
                builder.setMessage("¿ Desea intentarlo nuevamente ?");
                builder.setPositiveButton("Reintentar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        new ListarData().execute();

                    }
                });
                builder.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                         dialogInterface.dismiss();
                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();

            }else if (objparametros.getFlagIndicador()==0){
                Calendar cal = Calendar.getInstance();
                String hoy = new SimpleDateFormat("dd/MM/yyyy").format(cal.getTime());
                sql.insertarVisita(getApplicationContext(), pref.getString("idUsuarioCliente", ""), pref.getString("idUsuarioVenta", ""), hoy, "0");

                flagClear=1;
                Toast.makeText(getApplicationContext(), "Visita Registrada", Toast.LENGTH_SHORT).show();
            }


        }
    }

    @Override
    public void onBackPressed() {

        if(flagClear==0){
            finish();
        }else if (flagClear==1){
            Intent i = new Intent(DetalleClienteActivity.this,ListaClienteActivity.class);
            i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP|Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(i);
        }
    }
}