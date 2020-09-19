package com.delcorp.apptiendadelcorp.activity;

import android.Manifest;
import android.app.Dialog;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.graphics.drawable.ColorDrawable;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Build;
import android.os.PowerManager;
import android.os.StrictMode;
import android.provider.Settings;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.CardView;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.RegistroUserActivity;
import com.delcorp.apptiendadelcorp.bean.Categoria;
import com.delcorp.apptiendadelcorp.bean.Cliente;
import com.delcorp.apptiendadelcorp.bean.ParametrosSalida;
import com.delcorp.apptiendadelcorp.bean.Producto;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCategoria;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCliente;
import com.delcorp.apptiendadelcorp.sqlite.SqliteProducto;
import com.delcorp.apptiendadelcorp.webservice.WebService;

import org.apache.commons.io.IOUtils;

import java.io.ByteArrayOutputStream;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;

public class LoginActivity extends AppCompatActivity {

    CardView btnIngresar,btnRegistrar ;
    SharedPreferences pref;
    EditText txtContra,txtUsuario;
    String user,clave;
    ArrayList<Categoria> arrayCategoria;
    ArrayList<Producto> arrayProducto;
    ArrayList<Cliente> arrayCliente;
    String idUsuario,CodigoTxt;
    Dialog dialog,progress;
    TextView msj,txt;
    String token ="NO DEFINIDO";
    Dialog dialog2;
    PowerManager powerManager;
    String packageName;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        pref = getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;
        dialog = new Dialog(LoginActivity.this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setCancelable(false);
        dialog.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
        dialog.setContentView(R.layout.dialog_personalizado);

        msj = dialog.findViewById(R.id.txt);

        txtContra = findViewById(R.id.txtContra);
        txtUsuario = findViewById(R.id.txtUsuario);
        btnIngresar = findViewById(R.id.btnIngresar);
        btnIngresar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                user = txtUsuario.getText().toString().trim();
                clave = txtContra.getText().toString().trim();
        if(!user.trim().equals("") && !clave.trim().equals("")){
            progress = new Dialog(LoginActivity.this);
            progress.requestWindowFeature(Window.FEATURE_NO_TITLE);
            progress.setCancelable(false);
            progress.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
            progress.setContentView(R.layout.dialog_procesando);

            txt = progress.findViewById(R.id.txt);
            txt.setText("Validando Acceso...");
            token = pref.getString("token","NO DEFINIDO");
            progress.show();
            new validaUsuario().execute();
        }else{
                    Toast.makeText(getApplicationContext(),"VERIFIQUE LA INFORMACION INGRESADA",Toast.LENGTH_SHORT).show();
        }

            }
        });
        btnRegistrar=findViewById(R.id.btnRegistrar);
        btnRegistrar.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view){
                Intent i = new Intent(LoginActivity.this, RegistroUserActivity.class);
                startActivity(i);
            }
        });
        powerManager = (PowerManager) getApplicationContext().getSystemService(POWER_SERVICE);
        packageName = "com.delcorp.apptiendadelcorp";
    }

    private class validaUsuario extends AsyncTask<String,Void,Object> {

        ParametrosSalida objparametros;

        @Override
        protected Object doInBackground(String... strings) {
            objparametros = new WebService().ValidarUsuario(user,clave,token);
            return null;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            progress.dismiss();
            SharedPreferences.Editor editor = pref.edit();
            if (objparametros.getFlagIndicador()==0) {

                CodigoTxt = objparametros.getParam2();
                idUsuario = objparametros.getParam1();

                editor.putString("idUsuario", objparametros.getParam1());
                editor.putString("CodigoTxt", objparametros.getParam2());
                editor.putString("nombre", objparametros.getParam3());
                editor.putString("idTipoUsuario", objparametros.getParam4());
                editor.putString("idTipoAcceso", objparametros.getParam5());
                editor.putString("sesion", "1");
                editor.putString("validaDatos",objparametros.getParam6());


                if (objparametros.getParam5().equals("1")) {
                    editor.putString("idUsuarioCliente", "");
                    editor.putString("nomCliente", "");
                    editor.putString("idUsuarioVenta", objparametros.getParam2());
                }else if (objparametros.getParam5().equals("2")  ) {
                    editor.putString("idUsuarioCliente", objparametros.getParam2());
                    editor.putString("nomCliente", objparametros.getParam3());
                    editor.putString("idUsuarioVenta", objparametros.getParam2());
                }else{

                }

                editor.commit();
                if(pref.getString("idTipoAcceso","").equals("1")){

                    //Intent i = new Intent(LoginActivity.this,ListaClienteActivity.class);
                    Intent i = new Intent(LoginActivity.this,MainVendedor.class);
                    LoginActivity.this.startActivity(i);
                    LoginActivity.this.finish();
                }else if ( pref.getString("idTipoAcceso","").equals("2")){
                    Intent i = new Intent(LoginActivity.this,MainActivity.class);
                    LoginActivity.this.startActivity(i);
                    LoginActivity.this.finish();
                }else{
                    Toast.makeText(getApplicationContext(),"NO SE IDENTIFICO SU TIPO DE ACCESO CONTACTE AL AREA DE SISTEMAS",Toast.LENGTH_SHORT).show();
                }


            } else if (objparametros.getFlagIndicador()==1){
                Toast.makeText(getApplicationContext(),   objparametros.getMsgValidacion() + "", Toast.LENGTH_SHORT).show();
            } else if ( objparametros.getFlagIndicador()==9){
                Toast.makeText(getApplicationContext(),"VERIFIQUE EL INTERNET",Toast.LENGTH_SHORT).show();

            }
        }
    }


    private class ListarData extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            arrayCategoria = new WebService().ListaCategoria(idUsuario,CodigoTxt);
            arrayProducto = new WebService().ListaProducto(idUsuario,CodigoTxt);
            arrayCliente = new WebService().ListaCliente(idUsuario,CodigoTxt);
            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
             if(arrayCategoria==null || arrayProducto == null || arrayCliente==null){
                 progress.dismiss();
                 Toast.makeText(getApplicationContext(),"OCURRIO UN ERROR EN LA DESCARGA VUELVA SINCRONIZAR",Toast.LENGTH_LONG).show();
             }else{

                 new cargarData().execute();
             }


        }
    }



    private class cargarData extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            final SqliteProducto sql = new SqliteProducto();
            final SqliteCategoria sql2 = new SqliteCategoria();
            final SqliteCliente sql3 = new SqliteCliente();

            sql.eliminarProducto(getApplicationContext());


            for (int i = 0; i < arrayProducto.size(); i++) {

                sql.insertarProducto(getApplicationContext(),
                        arrayProducto.get(i).getIdProductoCategoria(),
                        arrayProducto.get(i).getIdProductoTxt(),
                        arrayProducto.get(i).getIdCategoria(),
                        arrayProducto.get(i).getIdCategoriaPadre(),
                        arrayProducto.get(i).getIdFabricante(),
                        arrayProducto.get(i).getNombrePro(),
                        arrayProducto.get(i).getDescripcion(),
                        arrayProducto.get(i).getPrecio(),
                        arrayProducto.get(i).getPeso(),
                        arrayProducto.get(i).getImagen(),
                        arrayProducto.get(i).getIdAlmacen(),
                        arrayProducto.get(i).getStock(),
                        getByte(arrayProducto.get(i).getImagen()),
                        arrayProducto.get(i).getVisible());

            }

            sql2.eliminarCategoria(getApplicationContext());


            for (int i = 0; i < arrayCategoria.size(); i++) {

                sql2.insertarCategoria(getApplicationContext(),
                        arrayCategoria.get(i).getIdCategoria(),
                        arrayCategoria.get(i).getIdUp(),
                        arrayCategoria.get(i).getStock(),
                        arrayCategoria.get(i).getNombre(),
                        arrayCategoria.get(i).getDescripcion(),
                        arrayCategoria.get(i).getPrecio(),
                        arrayCategoria.get(i).getPeso(),
                        arrayCategoria.get(i).getImagen(),
                        getByte(arrayCategoria.get(i).getImagen()));

            }

            sql3.eliminarClientexId(getApplicationContext(),CodigoTxt);


            for (int i = 0; i < arrayCliente.size(); i++) {

                sql3.insertarCliente(getApplicationContext(),
                        arrayCliente.get(i).getCodigoTxt(),
                        CodigoTxt,
                        arrayCliente.get(i).getNombre(),
                        arrayCliente.get(i).getPaterno(),
                        arrayCliente.get(i).getMaterno(),
                        arrayCliente.get(i).getDireccion(),
                        arrayCliente.get(i).getLatitud(),
                        arrayCliente.get(i).getLongitud(),
                        arrayCliente.get(i).getDiasVisita(),
                        arrayCliente.get(i).getActivaTotalClientes(),
                        arrayCliente.get(i).getVisitadoHoy());

            }

            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            progress.dismiss();


            if(pref.getString("idTipoAcceso","").equals("1")){
                Toast.makeText(getApplicationContext(),"VENDEDOR",Toast.LENGTH_SHORT).show();
                //Intent i = new Intent(LoginActivity.this,ListaClienteActivity.class);
                Intent i = new Intent(LoginActivity.this,MainVendedor.class);
                LoginActivity.this.startActivity(i);
                LoginActivity.this.finish();
            }else if ( pref.getString("idTipoAcceso","").equals("2")){
                Toast.makeText(getApplicationContext(),"CLIENTE",Toast.LENGTH_SHORT).show();
                Intent i = new Intent(LoginActivity.this,MainActivity.class);
                LoginActivity.this.startActivity(i);
                LoginActivity.this.finish();
            }else{
                Toast.makeText(getApplicationContext(),"NO SE IDENTIFICO SU TIPO DE ACCESO CONTACTE AL AREA DE SISTEMAS",Toast.LENGTH_SHORT).show();
            }


        }
    }

    @Override
    protected void onResume() {
        super.onResume();
        if(Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            Intent i = new Intent();
            if (!powerManager.isIgnoringBatteryOptimizations(packageName)) {
                i.setAction(Settings.ACTION_REQUEST_IGNORE_BATTERY_OPTIMIZATIONS);
                i.setData(Uri.parse("package:" + packageName));
                startActivity(i);
            }
        }

    }

    private static byte[] getByte(String u) {

        try {
            StrictMode.ThreadPolicy policy = new     StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);
            URL url = new URL(u);
            URLConnection conn = url.openConnection();
            conn.setConnectTimeout(5000);
            conn.setReadTimeout(5000);
            conn.connect();

            ByteArrayOutputStream baos = new ByteArrayOutputStream();
            IOUtils.copy(conn.getInputStream(), baos);

            return baos.toByteArray();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }


}
