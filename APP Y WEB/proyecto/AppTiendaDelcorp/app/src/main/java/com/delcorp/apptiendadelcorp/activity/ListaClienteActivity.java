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
import android.support.v7.widget.DefaultItemAnimator;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.StaggeredGridLayoutManager;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.view.Window;
import android.view.animation.AnimationUtils;
import android.view.animation.LayoutAnimationController;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.TextView;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Cliente;
import com.delcorp.apptiendadelcorp.bean.ParametrosSalida;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCategoria;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCliente;
import com.delcorp.apptiendadelcorp.sqlite.SqliteProducto;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePromocionVista;
import com.delcorp.apptiendadelcorp.webservice.WebService;

import java.util.ArrayList;
import java.util.Calendar;

public class ListaClienteActivity extends AppCompatActivity {

    RecyclerView rc;
    TextView msj;
    String idUsuario,CodigoTxt,dia,diaSemana;
    SharedPreferences pref;
    RadioButton rdbFecha,rdbNombre;
    CustomListCliente adapter;
    EditText txtBuscar;
    ArrayList<Cliente>arrayCliente;
    Dialog progress;
    TextView txt;
    ImageView imgSincronizar;
    ImageView btnCerrar;
    SqliteCliente sql = new SqliteCliente();
    String token="NO DEFINIDO";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_lista_cliente);

        setTitle("Lista de Clientes");
        pref =   getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;
        dia = pref.getString("dia","");

        diaSemana = pref.getString("diaSemana","");
        rc = findViewById(R.id.rc);
        idUsuario = pref.getString("CodigoTxt","");
        rdbFecha = findViewById(R.id.rdbFecha);
        rdbNombre = findViewById(R.id.rdbNombre);
        imgSincronizar = findViewById(R.id.imgSincronizar);

        rdbFecha.setChecked(true);


        rdbNombre.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                if(rdbNombre.isChecked()){
                    rdbFecha.setChecked(false);
                    ArrayList<Cliente> arrayTra  ;
                    SqliteCliente sql = new SqliteCliente();
                    arrayTra= sql.BuscarTrabajador(getApplicationContext(), txtBuscar.getText().toString(),CodigoTxt);

                    cargar(arrayTra);
                }
            }
        });

        rdbFecha.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                if(rdbFecha.isChecked()){
                    rdbNombre.setChecked(false);
                    ArrayList<Cliente> arrayTra  ;
                    SqliteCliente sql = new SqliteCliente();
                    arrayTra= sql.BuscarTrabajador2(getApplicationContext(), txtBuscar.getText().toString(),CodigoTxt,dia);

                    cargar(arrayTra);
                }
            }
        });


        CodigoTxt = pref.getString("idUsuarioVenta","0");


        btnCerrar=findViewById(R.id.btnCerrar);
        btnCerrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                SqlitePromocionVista sql = new SqlitePromocionVista();
                sql.eliminarvistos(ListaClienteActivity.this);
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(ListaClienteActivity.this);
                builder.setMessage("¿Desea Cerrar Sesion?");
                builder.setTitle("Cerrar") ;
                builder.setPositiveButton("Si", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        progress = new Dialog(ListaClienteActivity.this);
                        progress.requestWindowFeature(Window.FEATURE_NO_TITLE);
                        progress.setCancelable(false);
                        progress.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
                        progress.setContentView(R.layout.dialog_procesando);

                        txt = progress.findViewById(R.id.txt);
                        txt.setText("Cerrando sesion...");
                        progress.show();
                        new cerrarSesion().execute();

                    }
                });
                builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        dialogInterface.cancel();
                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();
            }
        });


        txtBuscar = findViewById(R.id.txtBuscar);
        txtBuscar.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {

                progress = new Dialog(ListaClienteActivity.this);
                progress.requestWindowFeature(Window.FEATURE_NO_TITLE);
                progress.setCancelable(false);
                progress.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
                progress.setContentView(R.layout.dialog_procesando);

                txt = progress.findViewById(R.id.txt);
                txt.setText("Buscando Coincidencia...");
                progress.show();


                ArrayList<Cliente> arrayTra  ;

                SqliteCliente sql = new SqliteCliente();
                if(rdbNombre.isChecked()){
                    arrayTra= sql.BuscarTrabajador(getApplicationContext(),charSequence+"",CodigoTxt);
                }else{
                    arrayTra= sql.BuscarTrabajador2(getApplicationContext(),charSequence+"",CodigoTxt,dia);
                }


                cargar(arrayTra);

            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });
        progress = new Dialog(ListaClienteActivity.this);
        progress.requestWindowFeature(Window.FEATURE_NO_TITLE);
        progress.setCancelable(false);
        progress.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
        progress.setContentView(R.layout.dialog_procesando);

        RecyclerView.ItemAnimator itemAnimator = new DefaultItemAnimator();
        itemAnimator.setAddDuration(1000);
        itemAnimator.setRemoveDuration(1000);
        rc.setItemAnimator(itemAnimator);

        txt = progress.findViewById(R.id.txt);

        ArrayList<Cliente> lstCliente = sql.listarCliente(getApplicationContext(), CodigoTxt);

        if(lstCliente.size()==0){
            txt.setText("Listando Data...");
            progress.show();
            new ListarData().execute();
        }else{
            txt.setText("Listando Data...");
            progress.show();

            if(rdbFecha.isChecked()){
                rdbNombre.setChecked(false);
                ArrayList<Cliente> arrayTra  ;
                SqliteCliente sql = new SqliteCliente();
                arrayTra= sql.BuscarTrabajador2(getApplicationContext(), txtBuscar.getText().toString(),CodigoTxt,dia);

                cargar(arrayTra);
            }else{
                listarclientes(CodigoTxt);
            }
        }


        imgSincronizar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                progress.show();
                new ListarData().execute();
            }
        });

        token = pref.getString("token","NO DEFINIDO");
    }

    public  void cargar(ArrayList<Cliente> lst){
        adapter = new CustomListCliente( this,lst);
        adapter.notifyDataSetChanged();

        /*crear controlador de animacion*/
        LayoutAnimationController controller = null;
        controller = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

         rc.setLayoutManager(new StaggeredGridLayoutManager(  1, StaggeredGridLayoutManager.VERTICAL));
        rc.setItemViewCacheSize(lst.size());
        /*setear controlador de animacion*/
        rc.setLayoutAnimation(controller);
        /*setear adaptador con datos*/
        rc.setAdapter(adapter);
        /*setear manejador de animacion*/
        rc.scheduleLayoutAnimation();
        //extender(i,true);
        progress.dismiss();
    }


    public void activaRadio(Boolean ok ){
        rdbNombre.setEnabled(ok);
        if(!ok){
            if(rdbNombre.isChecked()){
                rdbFecha.setChecked(true);
            }
        }
    }


    private class ListarData extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            arrayCliente = new WebService().ListaCliente(idUsuario,CodigoTxt);
            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            if(  arrayCliente==null){
                progress.dismiss();
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(ListaClienteActivity.this);

                builder.setTitle("Ocurrio un error de red") ;
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                new ListarData().execute();

                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();
            }else{

                new eliminaData().execute();
            }

        }
    }


    private class eliminaData extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            final SqliteCliente sql3 = new SqliteCliente();
            sql3.eliminarClientexId(getApplicationContext(), CodigoTxt);

            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);

                new cargaData().execute();

        }
    }


    private class cargaData extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            final SqliteCliente sql3 = new SqliteCliente();


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

            if(rdbFecha.isChecked()){
                rdbNombre.setChecked(false);
                ArrayList<Cliente> arrayTra  ;
                SqliteCliente sql = new SqliteCliente();
                arrayTra= sql.BuscarTrabajador2(getApplicationContext(), txtBuscar.getText().toString(),CodigoTxt,dia);

                cargar(arrayTra);
            }else{
                listarclientes(CodigoTxt);
            }

        }
    }

    @Override
    public void onBackPressed() {
        Toast.makeText(getApplicationContext(),"Seleccione un Usuario",Toast.LENGTH_SHORT).show();
    }

    public void  cargarData (ArrayList<Cliente> arrayClient) {

        final SqliteCliente sql3 = new SqliteCliente();


        for (int i = 0; i < arrayClient.size(); i++) {

            sql3.insertarCliente(getApplicationContext(),
                    arrayClient.get(i).getCodigoTxt(),
                    CodigoTxt,
                    arrayClient.get(i).getNombre(),
                    arrayClient.get(i).getPaterno(),
                    arrayClient.get(i).getMaterno(),
                    arrayClient.get(i).getDireccion(),
                    arrayClient.get(i).getLatitud(),
                    arrayClient.get(i).getLongitud(),
                    arrayClient.get(i).getDiasVisita(),
                    arrayCliente.get(i).getActivaTotalClientes(),
                    arrayCliente.get(i).getVisitadoHoy());
        }



    }


    public void listarclientes( String cod){


        ArrayList<Cliente> lstCliente = sql.listarCliente(getApplicationContext(), cod);



        adapter = new CustomListCliente( this,lstCliente);
        adapter.notifyDataSetChanged();

        /*crear controlador de animacion*/
        LayoutAnimationController controller = null;
        controller = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

         rc.setLayoutManager(new StaggeredGridLayoutManager(  1, StaggeredGridLayoutManager.VERTICAL));
        rc.setItemViewCacheSize(lstCliente.size());
        /*setear controlador de animacion*/
        rc.setLayoutAnimation(controller);
        /*setear adaptador con datos*/
        rc.setAdapter(adapter);
        /*setear manejador de animacion*/
        rc.scheduleLayoutAnimation();
        //extender(i,true);
        progress.dismiss();
    }

    @Override
    protected void onResume() {
        super.onResume();


        obtendia();

        if(pref.getString("validaDatos","1").equals("0")){


        }

        ArrayList<Cliente> arrayTra  ;

        SqliteCliente sql = new SqliteCliente();
        if(rdbNombre.isChecked()){
            arrayTra= sql.BuscarTrabajador(getApplicationContext(),"",CodigoTxt);
        }else{
            arrayTra= sql.BuscarTrabajador2(getApplicationContext(),"",CodigoTxt,dia);
        }

    }

    private class cerrarSesion extends AsyncTask<String,Void,Object> {

        ParametrosSalida objparametros;

        @Override
        protected Object doInBackground(String... strings) {
            objparametros = new WebService().cerrarSesion(idUsuario,token);
            return null;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);

            progress.dismiss();
            if (objparametros.getFlagIndicador()==0) {
                SharedPreferences.Editor editor = pref.edit();
                editor.putString("sesion", "");
                editor.putString("idTipoUsuario", "");
                editor.putString("idUsuarioCliente", "");
                editor.putString("nomCliente", "");
                editor.putString("idUsuarioVenta", "");
                editor.commit();

                Intent is = new Intent(ListaClienteActivity.this,LoginActivity.class);
                startActivity(is);
                finish();
                Toast.makeText(getApplicationContext(),objparametros.getMsgValidacion(),Toast.LENGTH_LONG).show();
            }else if (objparametros.getFlagIndicador()==1) {
                Toast.makeText(getApplicationContext(),objparametros.getMsgValidacion(),Toast.LENGTH_LONG).show();
            }else{
                Toast.makeText(getApplicationContext(),objparametros.getMsgValidacion(),Toast.LENGTH_LONG).show();
            }



        }
    }


    private  void obtendia(){
        SharedPreferences.Editor edit = pref.edit();
        Calendar calendar = Calendar.getInstance();
        int day = calendar.get(Calendar.DAY_OF_WEEK);

        Integer i = 0;

        switch (day) {
            case Calendar.MONDAY:
                i = 1 ;
                break;
            case Calendar.TUESDAY:
                i = 2 ;
                break;
            case Calendar.WEDNESDAY:
                i = 3 ;
                break;
            case Calendar.THURSDAY:
                i = 4 ;
                break;
            case Calendar.FRIDAY:
                i = 5 ;
                break;
            case Calendar.SATURDAY:
                i = 6 ;
                break;
            case Calendar.SUNDAY:
                i = 7 ;
                break;
        }



        if(!pref.getString("dia","9").equals(i+"")){
            edit.putString("pedidoComp","0");
        }


        switch (day) {
            case Calendar.MONDAY:
                // LUNES
                //Toast.makeText(getApplicationContext(),"HOY EL LUNES",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","LUNES");
                edit.putString("dia","1");
                break;
            case Calendar.TUESDAY:
                // MARTES
                //Toast.makeText(getApplicationContext(),"HOY EL MARTES",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","MARTES");
                edit.putString("dia","2");
                break;
            case Calendar.WEDNESDAY:
                // MIERCOLES
                //Toast.makeText(getApplicationContext(),"HOY EL MIERCOLES",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","MIERCOLES");
                edit.putString("dia","3");
                break;
            case Calendar.THURSDAY:
                // JUEVES
                //Toast.makeText(getApplicationContext(),"HOY EL JUEVES",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","JUEVES");
                edit.putString("dia","4");
                break;
            case Calendar.FRIDAY:
                // VIERNES
                //Toast.makeText(getApplicationContext(),"HOY EL VIERNES",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","VIERNES");
                edit.putString("dia","5");
                break;
            case Calendar.SATURDAY:
                // SABADO
                //Toast.makeText(getApplicationContext(),"HOY EL SABADO",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","SABADO");
                edit.putString("dia","6");
                break;
            case Calendar.SUNDAY:
                // DOMINGO
                //Toast.makeText(getApplicationContext(),"HOY EL DOMINGO",Toast.LENGTH_SHORT).show();
                edit.putString("diaSemana","DOMINGO");
                edit.putString("dia","7");
                break;
        }





        edit.commit();
    }

}
