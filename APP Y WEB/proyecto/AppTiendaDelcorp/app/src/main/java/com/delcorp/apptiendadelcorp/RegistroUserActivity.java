package com.delcorp.apptiendadelcorp;

import android.app.Dialog;
import android.content.SharedPreferences;
import android.location.Address;
import android.location.Geocoder;
import android.os.Handler;
import android.os.Message;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.CardView;
import android.view.View;
import android.view.Window;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.activity.Location_Cliente;
import com.delcorp.apptiendadelcorp.activity.MainVendedor;
import com.delcorp.apptiendadelcorp.activity.location;
import com.delcorp.apptiendadelcorp.bean.ParametrosSalida;
import com.delcorp.apptiendadelcorp.webservice.WebService;
import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.GooglePlayServicesNotAvailableException;
import com.google.android.gms.common.GooglePlayServicesRepairableException;
import com.google.android.gms.common.api.GoogleApiClient;


import android.annotation.TargetApi;
import android.app.Activity;
import android.app.ProgressDialog;
import android.content.ComponentName;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.graphics.Bitmap;
import android.graphics.Matrix;
import android.media.ExifInterface;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Parcelable;
import android.provider.MediaStore;
import android.support.annotation.NonNull;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Base64;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.concurrent.ExecutionException;


import com.google.android.gms.location.places.*;
import com.google.android.gms.location.places.ui.PlacePicker;
import com.google.android.gms.maps.model.LatLng;

public class RegistroUserActivity extends AppCompatActivity implements GoogleApiClient.OnConnectionFailedListener{

    TextView TxtUbiacionActual,TxtLongitud,TxtLatitutd;

    TextView msj;
    String codigVendedor;
    SharedPreferences pref;
    private SharedPreferences prefs;
    //GPS
    String numeroTelefono;
    private GoogleApiClient mGoogleApiClient;
    private int PLACE_PICKER_REQUEST = 1;
    private  EditText Direccion;
    private  TextView Longitud;
    private  TextView Latitud;
    private ImageButton fabPickPlace;
    private  CardView btnRegistar;
    EditText txtNombres;
    EditText txtPaterno;
    EditText txtMaterno;
    EditText txtCelular;
    EditText txtTelefono;
    EditText txtDni;
    EditText txtRuc;
    EditText txtRazon;
    EditText txtDireccion;
    EditText TxtReferencia;


    ProgressDialog progressDoalog,dialog_save;
    //END GPS
    Dialog dialog;
    CardView btnCancelar;
    TextView Latid,Longit;
 String  Nombres="",Paterno,Materno,Celular,Telefono,Dni,Ruc,Razon,Direccion__,Referencia,LaitudClie,LongiClie;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registro_user);
        btnCancelar=findViewById(R.id.btnCancelar);
        btnRegistar=findViewById(R.id.btnRegistro);
        fabPickPlace = (ImageButton) findViewById(R.id.Btnfabmapa);
        Direccion = (EditText) findViewById(R.id.txtDireccion);
        Longitud=(TextView)findViewById(R.id.TxtLongitud);
        Latitud=(TextView)findViewById(R.id.TxtLatitud);
            txtNombres = (EditText)findViewById(R.id.txtNombres);
            txtPaterno = (EditText)findViewById(R.id.txtPaterno);
            txtMaterno = (EditText)findViewById(R.id.txtMaterno);
            txtCelular = (EditText)findViewById(R.id.txtCelular);
            txtTelefono = (EditText)findViewById(R.id.txtTelefono);
            txtDni  = (EditText)findViewById(R.id.txtDni);
            txtRuc   = (EditText) findViewById(R.id.txtRuc);
            txtRazon  = (EditText) findViewById(R.id.txtRazon);
            txtDireccion  = (EditText)findViewById(R.id.txtDireccion);
            TxtReferencia = (EditText) findViewById(R.id.TxtReferencia);

            Latid=(TextView) findViewById(R.id.TxtLatitud);
            Longit=(TextView)findViewById(R.id.TxtLongitud);





        // initViews();
        pref =   getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;
        dialog = new  Dialog(RegistroUserActivity.this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setCancelable(false);
        dialog.getWindow().setBackgroundDrawableResource(android.R.color.holo_blue_bright);
        dialog.setContentView(R.layout.dialog_procesando);
        msj = dialog.findViewById(R.id.txt);
         codigVendedor=pref.getString("CodigoTxt","").toString();
        mGoogleApiClient = new GoogleApiClient
                .Builder(this)
                .addApi(Places.GEO_DATA_API)
                .addApi(Places.PLACE_DETECTION_API)
                .enableAutoManage(this, this)
                .build();







        fabPickPlace.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
  /*              ProgressDialog progressdialog = new ProgressDialog(getApplicationContext());
                progressdialog.setMessage("Please Wait....");
                progressdialog.show();
*/
                progressDoalog = new ProgressDialog(RegistroUserActivity.this);
                progressDoalog.requestWindowFeature(Window.FEATURE_NO_TITLE);
                progressDoalog.setMax(100);
                progressDoalog.setMessage("Cargando Mapa");
                //progressDoalog.setTitle("ProgressDialog bar example");
                progressDoalog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
                //progressDoalog.getWindow().setBackgroundDrawableResource(android.R.color.holo_blue_dark);
                //progressDoalog.setContentView(R.layout.dialog_procesando);




                progressDoalog.show();
                new Thread(new Runnable() {
                    @Override
                    public void run() {
                        try {
                            while (progressDoalog.getProgress() <= progressDoalog
                                    .getMax()) {
                                Thread.sleep(200);
                                handle.sendMessage(handle.obtainMessage());
                                if (progressDoalog.getProgress() == progressDoalog
                                        .getMax()) {
                                    progressDoalog.dismiss();
                                }
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                }).start();

               // dialog.show();
                msj.setText("Abriendo Mapa");


                PlacePicker.IntentBuilder builder = new PlacePicker.IntentBuilder();
                Toast.makeText(getApplicationContext(),"ABRIENDO MAPA",Toast.LENGTH_LONG).show();
                try {
                    startActivityForResult(builder.build(RegistroUserActivity.this), PLACE_PICKER_REQUEST);
                    //dialog.dismiss();
                    progressDoalog.dismiss();
                } catch (GooglePlayServicesRepairableException | GooglePlayServicesNotAvailableException e) {
                    e.printStackTrace();
                    //dialog.dismiss();
                    progressDoalog.dismiss();
                }
            }

            Handler handle = new Handler() {
                @Override
                public void handleMessage(Message msg) {
                    super.handleMessage(msg);
                    progressDoalog.incrementProgressBy(50);
                }
            };
        });

        btnCancelar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });


        btnRegistar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {


                dialog_save = new ProgressDialog(RegistroUserActivity.this);
                dialog_save.setMax(100);
                dialog_save.setProgressStyle(ProgressDialog.STYLE_SPINNER);
                dialog_save.setMessage("Enviando Datos....");
                //dialog_save.setTitle("ProgressDialog bar example");
                dialog_save.setContentView(R.layout.dialog_procesando);
                dialog_save.show();
                new Thread(new Runnable() {
                    @Override
                    public void run() {
                        try {
                            while (dialog_save.getProgress() <= dialog_save
                                    .getMax()) {
                                Thread.sleep(200);
                                handle.sendMessage(handle.obtainMessage());
                                if (dialog_save.getProgress() == dialog_save
                                        .getMax()) {
                                    dialog_save.dismiss();
                                }
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                }).start();
                /*
                Intent i = new Intent(RegistroUserActivity.this, Location_Cliente.class);
                startActivity(i);*/
                //msj.setText("Enviando Datos");
                //dialog.show();


                Integer paso =0;
                if(txtNombres.getText().toString().trim().equals("")){
                    txtNombres.setError("Ingresa Nombres");
                    paso=1;
                }
                if(txtPaterno.getText().toString().trim().equals("")){
                    txtPaterno.setError("Ingresa Apellido Paterno");
                    paso=1;
                }
                if(txtMaterno.getText().toString().trim().equals("")){
                    txtMaterno.setError("Ingresa Apellido Materno");
                    paso=1;
                }
                if(txtDireccion.getText().toString().trim().equals("")){
                    txtDireccion.setError("Seleccione Gps");
                    paso=1;
                }
                if(Latid.getText().toString().trim().equals("")){
                    txtDireccion.setError("Gps no fue localizado");
                    paso=1;
                }
                if(paso==0) {
                    msj.setText("Obteniendo Datos..");

                    Nombres = txtNombres.getText().toString();
                    Paterno = txtPaterno.getText().toString();
                    Materno = txtMaterno.getText().toString();
                    Celular = txtCelular.getText().toString();
                    Telefono = txtTelefono.getText().toString();
                    Dni = txtDni.getText().toString();
                    Ruc = txtRuc.getText().toString();
                    Razon = txtRazon.getText().toString();
                    Direccion__ = txtDireccion.getText().toString();
                    Referencia = TxtReferencia.getText().toString();
                    LaitudClie = Latid.getText().toString();
                    LongiClie = Longit.getText().toString();

                    ParametrosSalida obj = null;
                    try {
                        obj= (ParametrosSalida)  new insertarCliente().execute().get();
                    } catch (InterruptedException e) {

                        e.printStackTrace();
                    } catch (ExecutionException e) {

                        e.printStackTrace();
                    }
                    if(obj.getFlagIndicador()==0){

                        Toast.makeText(getApplicationContext(),obj.getMsgValidacion().toString(),Toast.LENGTH_LONG).show();
                        SharedPreferences.Editor edit = pref.edit();
                        edit.putString("validaDatos","1");
                        Intent i = new Intent(RegistroUserActivity.this, MainVendedor.class);
                        i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        startActivity(i);
                        //if(pref.getString("idTipoAcceso","2").equals("2")){
                          //  edit.putString("nomCliente", vNombre+" "+vPaterno+" "+vMaterno);
                        //}

                        edit.commit();
                        edit.commit();

                    }else if(obj.getFlagIndicador()==1){
                        dialog_save.dismiss();
                        Toast.makeText(getApplicationContext(),obj.getMsgValidacion().toString(),Toast.LENGTH_LONG).show();
                    }else if(obj.getFlagIndicador()==9){
                        dialog_save.dismiss();
                        Toast.makeText(getApplicationContext(),"ERROR DE RED",Toast.LENGTH_LONG).show();
                    }


                }else{
                    dialog_save.dismiss();
                }

            }
            Handler handle = new Handler() {
                @Override
                public void handleMessage(Message msg) {
                    super.handleMessage(msg);
                    dialog_save.incrementProgressBy(1);
                }
            };
        });
    }
    //region INSERTAR CLIENTE
    private class insertarCliente extends AsyncTask<String,Void,Object> {
        ParametrosSalida obj;

        @Override
        protected Object doInBackground(String... strings) {


                    /*,
            String Correo,
            String usuario,
            String clave */

            obj = new WebService().insertarCliente(Nombres,
                    Paterno,
                    Materno,
                    Celular,
                    Telefono,
                    Dni,
                    Ruc,
                    Razon,
                    Direccion__,
                    Referencia,
                    LaitudClie,
                    LongiClie,"","","",codigVendedor);
            return obj;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
          //  dialog.dismiss();

        }
    }
    //endregion
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {


        if (requestCode == PLACE_PICKER_REQUEST) {
            if (resultCode == RESULT_OK) {

             //  Place place = PlacePicker.getPlace(data, this);

                Place place = PlacePicker.getPlace(RegistroUserActivity.this, data);

                double latitude = place.getLatLng().latitude;
                double longitude = place.getLatLng().longitude;
                String PlaceLatLng = String.valueOf(latitude)+" , "+String.valueOf(longitude);
                String Nombre=String.format("%s", place.getName());
                String address = String.format("%s", place.getAddress());
                Longitud.setText(String.valueOf(longitude));
                Latitud.setText(String.valueOf(latitude));


                /*
                tv_MyLocation.setText(PlaceLatLng);


                Place place = PlacePicker.getPlace(RegistroUserActivity.this, data);

                StringBuilder stBuilder = new StringBuilder();
                String placename = String.format("%s", place.getName());
                String latitude = String.valueOf(place.getLatLng().latitude);
                String longitude = String.valueOf(place.getLatLng().longitude);
                String address = String.format("%s", place.getAddress());
               // Ubicacion.setText(placename.toString()+ " "+address.toString());
                //Ubicacion.setText(address.toString());
                Longitud.setText(stBuilder.append(longitude));
                Latitud.setText(stBuilder.append(latitude));
                stBuilder.append("Name: ");
                stBuilder.append(placename);
                stBuilder.append("\n");
                stBuilder.append("Latitude: ");
                stBuilder.append(latitude);
                stBuilder.append("\n");
                stBuilder.append("Logitude: ");
                stBuilder.append(longitude);
                stBuilder.append("\n");
                stBuilder.append("Address: ");
                stBuilder.append(address);
                Direccion.setText(address.toString());
*/
                /*  List<Address> list = null;
                try {
                    list = geocoder.getFromLocation(latitude1, longitude1, 1);
                } catch (IOException e) {
                    e.printStackTrace();
                }
                if (!list.isEmpty()) {
                    Address DirCalle = list.get(0);
                    TxtUbicacion.setText("Mi direccion es: \n"
                            + DirCalle.getAddressLine(0));
                }*/
                Geocoder geocoder=new Geocoder(RegistroUserActivity.this, Locale.getDefault());
                try {
                    List<Address> addresses=geocoder.getFromLocation(latitude,longitude,1);
                    String direcion=addresses.get(0).getAddressLine(0);
                    Direccion.setText(direcion);
                } catch (IOException e) {
                    e.printStackTrace();
                }

            }
        }


    }

    @Override
    protected void onStart() {
        super.onStart();
        mGoogleApiClient.connect();
    }

    @Override
    protected void onStop() {
        mGoogleApiClient.disconnect();
        super.onStop();
    }

    @Override
    public void onConnectionFailed(@NonNull ConnectionResult connectionResult) {
        Snackbar.make(fabPickPlace, connectionResult.getErrorMessage() + "", Snackbar.LENGTH_LONG).show();
    }


}
