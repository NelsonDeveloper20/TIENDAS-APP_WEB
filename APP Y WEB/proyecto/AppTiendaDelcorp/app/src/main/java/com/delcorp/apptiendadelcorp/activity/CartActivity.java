package com.delcorp.apptiendadelcorp.activity;

import android.Manifest;
import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.location.Location;
import android.location.LocationManager;
import android.os.AsyncTask;
import android.os.Handler;
import android.support.annotation.NonNull;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.CardView;
import android.support.v7.widget.DefaultItemAnimator;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.StaggeredGridLayoutManager;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.view.animation.AnimationUtils;
import android.view.animation.LayoutAnimationController;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.daimajia.androidanimations.library.Techniques;
import com.daimajia.androidanimations.library.YoYo;
import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Bonificacion;
import com.delcorp.apptiendadelcorp.bean.Carrito;
import com.delcorp.apptiendadelcorp.bean.Categoria;
import com.delcorp.apptiendadelcorp.bean.Condicion;
import com.delcorp.apptiendadelcorp.bean.DiasVisita;
import com.delcorp.apptiendadelcorp.bean.ParametrosSalida;
import com.delcorp.apptiendadelcorp.bean.PedidoDetalle;
import com.delcorp.apptiendadelcorp.bean.PedidoDetalleRespuesta;
import com.delcorp.apptiendadelcorp.bean.Producto;
import com.delcorp.apptiendadelcorp.bean.ProductoSugerido;
import com.delcorp.apptiendadelcorp.bean.Promocion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteBonificacion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCarrito;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCondicion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteHistorico;
import com.delcorp.apptiendadelcorp.sqlite.SqliteProducto;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePromocionVista;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePromociones;
import com.delcorp.apptiendadelcorp.sqlite.SqliteSugerido;
import com.delcorp.apptiendadelcorp.sqlite.SqliteVisita;
import com.delcorp.apptiendadelcorp.util.AppConstants;
import com.delcorp.apptiendadelcorp.util.GpsUtils;
import com.delcorp.apptiendadelcorp.webservice.WebService;
import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationCallback;
import com.google.android.gms.location.LocationRequest;
import com.google.android.gms.location.LocationResult;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.tasks.OnSuccessListener;

import java.lang.reflect.Array;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Collections;
import java.util.Locale;

public class CartActivity extends AppCompatActivity {

    String origen="0";
    LinearLayout bottom_sheet ,linearTotal,linCancela;
    RecyclerView rc,rcBoni;
    String idUsuario,idUsuarioVenta,idUsuarioCliente,total,totalPro,totalItem,latitud="",longitud="",nomCliente ,IdPed;
    SharedPreferences pref;
    CustomListCarrito adapter;
    CustomListBoni adapter2;
    ListView lst;
    Toolbar toolbar;
    Dialog dialog;
    ArrayList<DiasVisita> arrDiasVisita;
    ArrayList<Carrito> lstCarrito ;
    ArrayList<Carrito> lstCarritoBoni ;
    ArrayList<PedidoDetalle> lstPedidoDetalle = new ArrayList<>();
    TextView txtPro,txtItem,txtTotal,txtLat,txtLon,txtCliente;
    ImageView imgAtras,imgBorrarTodo;
    CardView btnTerminarPedido,btnCancelarPedido,btnEliminarBono;
    LinearLayout linearBoni;
    TextView txtBoni,txtEntrega;
    Integer accionTerminar=0;
    ArrayList<ProductoSugerido>arraProductoSugerido;
    Dialog dialog2  ;
    TextView msj;
    ArrayList<Condicion> arayPromoCondiMostrar=new ArrayList<>();
    ArrayList<Condicion> arayPromoObtenida = new ArrayList<>();
    CustomListPromoGanada adapterGanada;
    CustomListObservaciones adapterObservadas;

    SqliteCarrito sqCarrito = new SqliteCarrito();
    SqliteHistorico sqHistorico = new SqliteHistorico();
    SqlitePromociones sqPromo = new SqlitePromociones();
    SqliteCondicion sqCondi = new SqliteCondicion();
    SqliteBonificacion sqBoni = new SqliteBonificacion();
    SqliteProducto sqp = new SqliteProducto();

    private FusedLocationProviderClient mFusedLocationClient;

    private double wayLatitude = 0.0, wayLongitude = 0.0;
    private LocationRequest locationRequest;
    private LocationCallback locationCallback;
    private boolean isContinue = false;
    private boolean isGPS = false;
    CustomListPromos ad;
    private static final String BROADCAST_ACTION = "android.location.PROVIDERS_CHANGED";
    private ProgressDialog progress2;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cart);

        pref =   getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;

         origen= pref.getString("origen","0");

        linCancela=findViewById(R.id.linCancela);
        btnCancelarPedido=findViewById(R.id.btnCancelarPedido);
        btnCancelarPedido.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                msj.setText("Cancelando...");
                dialog.dismiss();
                new cancelaPedidoComp().execute();
            }
        });

        if(!origen.equals("0")){
            btnCancelarPedido.setVisibility(View.VISIBLE);
            linCancela.setVisibility(View.VISIBLE);
        }else{
            btnCancelarPedido.setVisibility(View.GONE);
            linCancela.setVisibility(View.GONE);
        }

        lst = findViewById(R.id.lst);
        linearTotal=findViewById(R.id.linearTotal);
        bottom_sheet = findViewById(R.id.bottom_sheet);
        imgBorrarTodo = findViewById(R.id.imgBorrarTodo);

        btnEliminarBono=findViewById(R.id.btnEliminarBono);
        txtEntrega=findViewById(R.id.txtEntrega);
        linearBoni = findViewById(R.id.linearBoni);
        txtBoni= findViewById(R.id.txtBoni);
        YoYo.with(Techniques.Shake)
                .duration(2500)
                .repeat(5)
                .playOn(findViewById(R.id.txtBoni));

        txtCliente=findViewById(R.id.txtCliente);
        imgAtras= findViewById(R.id.imgAtras);
        imgAtras.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                eliminAbONIxCategoria();
                Intent i= new Intent(CartActivity.this,MainActivity.class);
                i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP|Intent.FLAG_ACTIVITY_CLEAR_TASK);
                startActivity(i);
            }
        });
        txtPro = findViewById(R.id.txtPro);
        txtItem = findViewById(R.id.txtItem);
        txtTotal = findViewById(R.id.txtTotal);
        txtLat = findViewById(R.id.txtLat);
        txtLon = findViewById(R.id.txtLon);

        idUsuario = pref.getString("idUsuario","");
        idUsuarioCliente = pref.getString("idUsuarioCliente","");
        idUsuarioVenta    = pref.getString("idUsuarioVenta","");

        nomCliente = pref.getString("nomCliente","");
        txtCliente.setText(nomCliente);

        rcBoni = findViewById(R.id.rcBoni);
        rc = findViewById(R.id.rc);
        rc.setLayoutManager(new StaggeredGridLayoutManager(  2, StaggeredGridLayoutManager.VERTICAL));
        RecyclerView.ItemAnimator itemAnimator = new DefaultItemAnimator();
        itemAnimator.setAddDuration(1000);
        itemAnimator.setRemoveDuration(1000);
        rc.setItemAnimator(itemAnimator);
/************************** CREAMOS EL LISTENER DEL GPS******************************/

        progress2 = new ProgressDialog(CartActivity.this);
        progress2.setMessage("Esperando Señal Gps..");
        progress2.setProgressStyle(ProgressDialog.STYLE_SPINNER);
        progress2.setIndeterminate(true);
        progress2.setCancelable(false);
        progress2.setProgress(0);

        mFusedLocationClient = LocationServices.getFusedLocationProviderClient(this);

        locationRequest = LocationRequest.create();
        locationRequest.setPriority(LocationRequest.PRIORITY_HIGH_ACCURACY);
        locationRequest.setInterval(10 * 1000); // 10 seconds
        locationRequest.setFastestInterval(5 * 1000); // 5 seconds

        new GpsUtils(this).turnGPSOn(new GpsUtils.onGpsListener() {
            @Override
            public void gpsStatus(boolean isGPSEnable) {
                // turn on GPS
                isGPS = isGPSEnable;
            }
        });

        locationCallback = new LocationCallback() {
            @Override
            public void onLocationResult(LocationResult locationResult) {
                if (locationResult == null) {
                    return;
                }
                for (Location location : locationResult.getLocations()) {
                    if (location != null) {
                        wayLatitude = location.getLatitude();
                        wayLongitude = location.getLongitude();
                        if (!isContinue) {
                            //Toast.makeText(getApplicationContext(),location.getLatitude()+" - "+location.getLongitude(),Toast.LENGTH_SHORT).show();
                            txtLat.setText(location.getLatitude()+"");
                            txtLon.setText(location.getLongitude()+"");
                        } else {
                            //Toast.makeText(getApplicationContext(),location.getLatitude()+" - "+location.getLongitude(),Toast.LENGTH_SHORT).show();
                            txtLat.setText(location.getLatitude()+"");
                            txtLon.setText(location.getLongitude()+"");
                        }
                        if (!isContinue && mFusedLocationClient != null) {
                            mFusedLocationClient.removeLocationUpdates(locationCallback);
                        }
                    }
                }

            }
        };
        new ListarDiasVisita().execute();
/*****************************************************/

        btnTerminarPedido= findViewById(R.id.btnTerminarPedido);
        btnTerminarPedido.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(accionTerminar==0){
                    accionTerminar = 1;

                    if(arayPromoCondiMostrar.size()>0) {
                        dialog2 = new Dialog(CartActivity.this);
                        dialog2.requestWindowFeature(Window.FEATURE_NO_TITLE);
                        dialog2.setCancelable(true);
                        dialog2.setContentView(R.layout.layout_list_promos);
                        dialog2.getWindow().setBackgroundDrawable(new ColorDrawable(android.graphics.Color.TRANSPARENT));

                        CardView mDialogok = dialog2.findViewById(R.id.frmyess);
                        RecyclerView rcc = dialog2.findViewById(R.id.rc);

                        ad = new CustomListPromos(CartActivity.this, arayPromoCondiMostrar);
                        ad.notifyDataSetChanged();

                        rcc.setLayoutManager(new StaggeredGridLayoutManager(1, StaggeredGridLayoutManager.VERTICAL));
                        rcc.setItemViewCacheSize(arayPromoCondiMostrar.size());
                        rcc.setAdapter(ad);
                        /*setear manejador de animacion*/
                        rcc.scheduleLayoutAnimation();

                        mDialogok.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {

                                dialog2.cancel();
                            }
                        });
                        if (arayPromoCondiMostrar.size() > 0) {
                            dialog2.show();
                        }
                    }else{
                        registraPedido();
                    }

                }else if ( accionTerminar==1){

                    msj.setText("Procesando Pedido...");
                    dialog.show();
                    btnTerminarPedido.setClickable(false);

                    registraPedido();

                }
            }
        });

        isContinue=true;
        getLocation();

        dialog = new  Dialog(CartActivity.this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setCancelable(false);
        dialog.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
        dialog.setContentView(R.layout.dialog_procesando);

        msj = dialog.findViewById(R.id.txt);
        msj.setText("Obteniendo informacion...");
        dialog.show();
        new ListarProductoSugerido().execute();

        imgBorrarTodo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(CartActivity.this);

                builder.setTitle("Desea vaciar el carrito") ;
                builder.setPositiveButton("Confirmar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int x) {

                        SharedPreferences.Editor  edit = pref.edit();
                        edit.putString("origen","0");
                        edit.commit();


                        SqliteCarrito sql3 = new SqliteCarrito();
                        sql3.eliminarCarritoxIdUsuarioCiente(CartActivity.this,pref.getString("idUsuarioCliente",""),
                                pref.getString("idUsuarioVenta",""));

                        Intent i = new Intent(CartActivity.this,MainActivity.class);
                        i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP|Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        startActivity(i);

                        SqlitePromocionVista s = new SqlitePromocionVista();
                        s.eliminarvistos(CartActivity.this);


                        SqliteSugerido sql = new SqliteSugerido();
                        String value = sql.buscarFlagSugerido(CartActivity.this,idUsuarioCliente,idUsuarioVenta);

                        if(value.equals("2")){
                            sql.insertarSugerido(CartActivity.this,idUsuarioCliente,idUsuarioVenta,"0");
                        }else if ( value.equals("0")){

                        }else if (value.equals("1")){
                            sql.actualizaSugerido(CartActivity.this,idUsuarioCliente,idUsuarioVenta,"0");
                        }


                    }
                });
                builder.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        dialog.dismiss();
                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();


            }
        });
        btnEliminarBono.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(CartActivity.this);

                builder.setTitle("Desea quitar bonificaciones") ;
                builder.setPositiveButton("Aceptar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        sqCarrito.eliminarBonificacionesCarrito(CartActivity.this);
                        lstCarritoBoni.clear();
                        adapter2.notifyDataSetChanged();

                        linearBoni.setVisibility(View.GONE);
                    }
                });
                builder.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        dialog.dismiss();
                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();


            }
        });

    }
    private int getHeightOfView(View contentview) {
        contentview.measure(View.MeasureSpec.UNSPECIFIED, View.MeasureSpec.UNSPECIFIED);
        //contentview.getMeasuredWidth();
        return contentview.getMeasuredHeight();
    }
    public void registraPedido(){
        SqliteCarrito sq = new SqliteCarrito();
        ArrayList<Carrito> lstcarro = sq.listarTodoCarro(getApplicationContext(),idUsuarioCliente,idUsuarioVenta);

        if(lstPedidoDetalle!=null){
            lstPedidoDetalle.clear() ;
        }

        for(Carrito c : lstcarro){
            PedidoDetalle   p = new PedidoDetalle ();
            p.setIdProductoTxt(c.getIdProductoTxt());
            p.setNombrePro(c.getNombrePro());
            p.setPrecio(c.getPrecio());
            p.setCantidad(c.getCant());
            p.setSubTotal( (Math.round( Double.parseDouble(c.getPrecio().replace(",","."))*Integer.parseInt(c.getCant()) * 100.0 )/ 100.0 ) +"");
            p.setIdPromocion(c.getIdPromocion());
            p.setIdCondicion(c.getIdCondicion());
            p.setIdBonificacion(c.getIdBonificacion());
            p.setImagen(c.getImagen());
            lstPedidoDetalle.add(p);
        }

        Integer p =0;
        Double t =0.0;

        for (int x=0; x<lstcarro.size();x++){
            p = p+Integer.parseInt(lstcarro.get(x).getCant());
            t = t + (  Double.parseDouble(lstcarro.get(x).getPrecio().replace(",","."))*Integer.parseInt(lstcarro.get(x).getCant()));
        }

        total = (Math.round(t * 100.0) / 100.0 )+"";
        totalPro = p+"";
        latitud = txtLat.getText().toString();
        longitud = txtLon.getText().toString();

        if(latitud.equals("")){
            final android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(CartActivity.this);
            builder.setMessage("¿Desea registrar de todos modos?");
            builder.setTitle("NO SE ENCONTRO GPS") ;
            builder.setPositiveButton("Confirmar", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialogInterface, int i) {

                    new insertarPedido().execute();

                }
            });
            builder.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialogInterface, int i) {
                    dialogInterface.dismiss();
                    dialog.dismiss();
                    accionTerminar=1;
                    btnTerminarPedido.setClickable(true);

                }
            });
            android.app.AlertDialog dialogd=builder.create();
            dialogd.show();
        }else{

            if(pref.getString("origen","0").equals("0")){
                new insertarPedido().execute();
            }else{
                IdPed= lstcarro.get(0).getIdPedido();
                new insertarPedidoComp().execute();
            }
        }
    }


    private class ListarProductoSugerido extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            arraProductoSugerido = new WebService().ListaProductoSugerido(idUsuarioCliente);

            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            if(arraProductoSugerido==null ){
                dialog.dismiss();
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(CartActivity.this);

                builder.setTitle("Error en la red ") ;
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        new ListarProductoSugerido().execute();

                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();

            }else{
                SqliteHistorico sql  = new SqliteHistorico();
                sql.eliminarhistorico(CartActivity.this);
                for (int i = 0;i < arraProductoSugerido.size();i++){

                    Integer x =  sql.insertarHistorico(getApplicationContext(), pref.getString("idUsuarioCliente",""),
                            pref.getString("idUsuarioVenta",""),arraProductoSugerido.get(i).getIdProducto()+"",
                            arraProductoSugerido.get(i).getIdCategoria()+"" ,arraProductoSugerido.get(i).getIdCategoriaPadre()+"" ,
                            arraProductoSugerido.get(i).getIdFabricante()+"",arraProductoSugerido.get(i).getNombrePro()+"",
                            arraProductoSugerido.get(i).getDescripcion()+"",arraProductoSugerido.get(i).getPrecio()+"",
                            arraProductoSugerido.get(i).getPeso()+"",arraProductoSugerido.get(i).getImagen()+"",
                            arraProductoSugerido.get(i).getIdAlmacen()+"",arraProductoSugerido.get(i).getStock()+"",
                            (Integer.parseInt(arraProductoSugerido.get(i).getCantidadSugerida())+ Integer.parseInt(arraProductoSugerido.get(i).getPorcentajeAdicional()))+"",
                            null,
                            "",
                            "",
                            "",
                            "");

                }

                //calculaBoniMontoxcantidadCatgoria();
                calculaBonificaciones();
                listarCarrito();
                muestraBonisGanadas();
            }
        }
    }


    public void muestraBonisGanadas(){
        dialog2 = new Dialog(CartActivity.this);
        dialog2.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog2.setCancelable(true);
        dialog2.setContentView(R.layout.layout_promos_obtenidas);
        dialog2.getWindow().setBackgroundDrawable(new ColorDrawable(android.graphics.Color.TRANSPARENT));

        CardView mDialogok = dialog2.findViewById(R.id.frmyess);
        RecyclerView rccg = dialog2.findViewById(R.id.rcganadas);

         adapterGanada= new CustomListPromoGanada(CartActivity.this, arayPromoObtenida);
        adapterGanada.notifyDataSetChanged();

        rccg.setLayoutManager(new StaggeredGridLayoutManager(1, StaggeredGridLayoutManager.VERTICAL));
        rccg.setItemViewCacheSize(arayPromoObtenida.size());
        rccg.setAdapter(adapterGanada);
        /*setear manejador de animacion*/
        rccg.scheduleLayoutAnimation();

        mDialogok.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                dialog2.cancel();
            }
        });
        if (arayPromoObtenida.size() > 0) {
            dialog2.show();
        }
    }


    @Override
    public void onBackPressed() {
        eliminAbONIxCategoria();
        Intent i= new Intent(CartActivity.this,MainActivity.class);
        i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP|Intent.FLAG_ACTIVITY_CLEAR_TASK);
        startActivity(i);

    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        if (gpsLocationReceiver != null)
            unregisterReceiver(gpsLocationReceiver);
    }

    public void eliminAbONIxCategoria(){
         SqliteCarrito sq = new SqliteCarrito();
        sq.eliminarBoniXIdCategoria(CartActivity.this );

    }


    public void calculaBonificaciones(){
        if(arayPromoCondiMostrar!=null) {
            arayPromoCondiMostrar.clear();
        }
        calculaBoniMontoxcantidadCatgoria();
        calculaBonixUniProducto();

    }

    public void calculaBoniMontoxcantidadCatgoria(){

        eliminAbONIxCategoria();
        ArrayList<Promocion> arrPromoCat = sqPromo.listaPromosMontoCategoria(CartActivity.this);

        for ( int i=0; i<arrPromoCat.size();i++){
            Log.d("===============","==============================================================================");
            Log.e("IdPromocion x cate   ", arrPromoCat.get(i).getIdPromocion());


            //SI EL MONTO CONDICION ES == 0
            if(Double.parseDouble(arrPromoCat.get(i).getIdTipoPromocion()) ==2) {

                ArrayList<Condicion> arrCondis = sqCondi.listaCondicionesXIdPromocion(CartActivity.this, arrPromoCat.get(i).getIdPromocion());

                Integer juntas = 0;
                if (arrCondis.size() > 1) { //evaluo si las condiciones son del mismo grupo o diferente
                    if (arrCondis.get(0).getIdGrupo().equals(arrCondis.get(1).getIdGrupo())) {//si es igual todos son iguales se aplican en conjunto
                        juntas = 1;
                    } else {//si es diferente quiere decir que se aplican por separado

                    }
                }

                Log.e("JUNTAS  ", juntas + "");
                if (juntas == 1) {//todas las condiciones se aplican juntoas

                    Log.e("PROMOCIONES JUNTAS ", "LAS PROMOS SE APLICAN JUNTAS");

                    Double monto = 0.0;
                    for (int x = 0; x < arrCondis.size(); x++) {
                        Log.e("condis " + x, arrCondis.get(x).getDescripcion());
                        //MONTO QUE COMPRASTE POR CATEGORIA EN EL CARRITO ACTUAL
                        Double valorCarrito = sqCarrito.MontoxCatCarrito(
                                CartActivity.this, pref.getString("idUsuarioCliente", ""),
                                pref.getString("idUsuarioVenta", ""), arrCondis.get(x).getIdCategoria());
                        monto = monto + valorCarrito;

                    }

                    Log.e("suma del monto ", monto + "");

                    if (monto >= Double.parseDouble(arrCondis.get(0).getCantidad())) {

                        double value = monto / Double.parseDouble(arrCondis.get(0).getCantidad());

                        if (value > 2) {
                            value = 2;
                        }

                        ArrayList<Bonificacion> arrBonis = sqBoni.listaBonificacionXIdPromocionIdGrupo(CartActivity.this, arrCondis.get(0).getIdPromocion(), arrCondis.get(0).getIdGrupo());

                        for (int j = 0; j < arrBonis.size(); j++) {

                            Integer cant = 0;

                            for (Integer h = 1; h <= (int) value; h++) {
                                cant = cant + Integer.parseInt(arrBonis.get(j).getCantidad());

                                if (cant > Integer.parseInt(sqp.obtenerStock(this, arrBonis.get(j).getIdProducto()))) {
                                    cant = cant - Integer.parseInt(arrBonis.get(j).getCantidad());
                                }
                                Log.e("CAN", cant + "  / " + sqp.obtenerStock(this, arrBonis.get(j).getIdProducto()));

                            }

                            if (arrPromoCat.get(i).getFlagPrimeraCompra().equals("1")) {
                                if (Integer.parseInt(arrBonis.get(j).getCantidad()) <= Integer.parseInt(sqp.obtenerStock(this, arrBonis.get(j).getIdProducto()))) {
                                    insertarBonificacion(arrBonis.get(j).getIdProducto(), arrBonis.get(j).getCantidad(),
                                            arrBonis.get(j).getIdPromocion(), "0", "0");
                                } else {
                                    insertarBonificacion(arrBonis.get(j).getIdProducto(), sqp.obtenerStock(this, arrBonis.get(j).getIdProducto()),
                                            arrBonis.get(j).getIdPromocion(), "0", "0");
                                }


                            } else {
                                insertarBonificacion(arrBonis.get(j).getIdProducto(), cant + "",
                                        arrBonis.get(j).getIdPromocion(), "0", "0");
                            }


                        }

                        Condicion obj = new Condicion(arrCondis.get(0).getIdPromocionCondicion() + ""
                                , arrCondis.get(0).getIdPromocion() + ""
                                , arrCondis.get(0).getIdProducto() + ""
                                , arrCondis.get(0).getIdCategoria() + ""
                                , arrCondis.get(0).getIdGrupo() + ""
                                , arrCondis.get(0).getCantidad() + ""
                                , arrCondis.get(0).getDescripcion() + "");

                        if (obj != null) {
                            arayPromoObtenida.add(obj);
                        }

                        break;
                    } else {

                        Condicion obj = new Condicion(arrCondis.get(0).getIdPromocionCondicion() + ""
                                , arrCondis.get(0).getIdPromocion() + ""
                                , arrCondis.get(0).getIdProducto() + ""
                                , arrCondis.get(0).getIdCategoria() + ""
                                , arrCondis.get(0).getIdGrupo() + ""
                                , arrCondis.get(0).getCantidad() + ""
                                , arrCondis.get(0).getDescripcion() + "");

                        if (obj != null) {
                            arayPromoCondiMostrar.add(obj);
                        }

                        Log.e("valorCarrito : ", monto + "  , no se bonifica se muestra poppup");

                    }

                } else if (juntas == 0) {//se aplican por separado por rangos
                    for (int x = 0; x < arrCondis.size(); x++) {
                        Log.d("**********************", "**********************************************************************************************");

                        Log.e("condicion " + x + "   ", arrCondis.get(x).getDescripcion());

                        String monto = "0";

                        if (arrPromoCat.get(i).getFlagHistorico().equals("1")) {
                            monto = sqHistorico.MontoxCategoriaHistorico(CartActivity.this, arrCondis.get(x).getIdCategoria());
                        }

                        Log.e("monto historico   ", monto + " , categoria = " + arrCondis.get(x).getIdCategoria());

                        if (Double.parseDouble(arrCondis.get(x).getCantidad()) >= Double.parseDouble(monto)) {// cuando era asc (>=), ahora desc (<=)

                            if (arrPromoCat.get(i).getIdTipoCondicion().equals("2")) { //por cada

                                //MONTO QUE COMPRASTE POR CATEGORIA EN EL CARRITO ACTUAL
                                Double valorCarrito = sqCarrito.MontoxCatCarrito(CartActivity.this, pref.getString("idUsuarioCliente", ""),
                                        pref.getString("idUsuarioVenta", ""), arrCondis.get(x).getIdCategoria());

                                Log.e("valorCarrito : ", valorCarrito + "  , cantidad condicion  : " + arrCondis.get(x).getCantidad());

                                if (Double.parseDouble(arrCondis.get(x).getCantidad()) <= valorCarrito) {
                                    Log.e("valorCarrito : ", valorCarrito + "  , se bonifica ");

                                    double value = valorCarrito / Double.parseDouble(arrCondis.get(x).getCantidad());

                                    if (value > 2) {
                                        value = 2;
                                    }

                                    ArrayList<Bonificacion> arrBonis = sqBoni.listaBonificacionXIdPromocionIdGrupo(CartActivity.this, arrCondis.get(x).getIdPromocion(), arrCondis.get(x).getIdGrupo());

                                    for (int j = 0; j < arrBonis.size(); j++) {

                                        Integer cant = 0;

                                        for (Integer h = 1; h <= (int) value; h++) {
                                            cant = cant + Integer.parseInt(arrBonis.get(j).getCantidad());

                                            if (cant > Integer.parseInt(sqp.obtenerStock(this, arrBonis.get(j).getIdProducto()))) {
                                                cant = cant - Integer.parseInt(arrBonis.get(j).getCantidad());
                                            }
                                            Log.e("CAN", cant + "  / " + sqp.obtenerStock(this, arrBonis.get(j).getIdProducto()));

                                        }

                                        if (arrPromoCat.get(i).getFlagPrimeraCompra().equals("1")) {
                                            if (Integer.parseInt(arrBonis.get(j).getCantidad()) <= Integer.parseInt(sqp.obtenerStock(this, arrBonis.get(j).getIdProducto()))) {
                                                insertarBonificacion(arrBonis.get(j).getIdProducto(), arrBonis.get(j).getCantidad(),
                                                        arrBonis.get(j).getIdPromocion(), "0", "0");
                                            } else {
                                                insertarBonificacion(arrBonis.get(j).getIdProducto(), sqp.obtenerStock(this, arrBonis.get(j).getIdProducto()),
                                                        arrBonis.get(j).getIdPromocion(), "0", "0");
                                            }
                                        } else {
                                            insertarBonificacion(arrBonis.get(j).getIdProducto(), cant + "",
                                                    arrBonis.get(j).getIdPromocion(), "0", "0");
                                        }


                                    }

                                    Condicion obj = new Condicion(arrCondis.get(x).getIdPromocionCondicion() + ""
                                            , arrCondis.get(x).getIdPromocion() + ""
                                            , arrCondis.get(x).getIdProducto() + ""
                                            , arrCondis.get(x).getIdCategoria() + ""
                                            , arrCondis.get(x).getIdGrupo() + ""
                                            , arrCondis.get(x).getCantidad() + ""
                                            , arrCondis.get(x).getDescripcion() + "");

                                    if (obj != null) {
                                        arayPromoObtenida.add(obj);
                                    }

                                    break;
                                } else {

                                    Condicion obj = new Condicion(arrCondis.get(x).getIdPromocionCondicion() + ""
                                            , arrCondis.get(x).getIdPromocion() + ""
                                            , arrCondis.get(x).getIdProducto() + ""
                                            , arrCondis.get(x).getIdCategoria() + ""
                                            , arrCondis.get(x).getIdGrupo() + ""
                                            , arrCondis.get(x).getCantidad() + ""
                                            , arrCondis.get(x).getDescripcion() + "");

                                    if (obj != null) {
                                        arayPromoCondiMostrar.add(obj);
                                    }

                                    Log.e("valorCarrito : ", valorCarrito + "  , no se bonifica se muestra poppup");

                                }


                            } else if (arrPromoCat.get(i).getIdTipoCondicion().equals("1")) {//mayor o igual

                            }


                        } else if (Double.parseDouble(arrCondis.get(x).getCantidad()) < Double.parseDouble(monto)) {

                            Log.e("NO SE BONIFICA ", " NO SE MUESTRA POPUP");
                            break;
                        }
                    }
                }


                //
            }else{

            }




        }
    }


    public void calculaBonixUniProducto(){

    ArrayList<Promocion> arrPromos = sqPromo.listaPromosUnidaCategoria(CartActivity.this);

    for(int i=0;i<arrPromos.size();i++){

        //CUANDO EL MONTO CONDICION ES 0
        if(Integer.parseInt(arrPromos.get(i).getIdTipoPromocion()) ==1) {
            Log.d("+++++++++++++++++++++++","+++++++++++++++++++++++++++++BONIS POR UNIDA PRODUCTO+++++++++++++++++++++++++++++++++++++++++++++++++");
            Log.e("IdPromocion x PROD   ", arrPromos.get(i).getIdPromocion());

            ArrayList<Condicion> arrCondis = sqCondi.listaCondicionesXIdPromocion(CartActivity.this, arrPromos.get(i).getIdPromocion());

            Integer juntas = 1;

            if (arrCondis.size() > 1) {//evaluo si las condiciones son del mismo grupo o diferente
                if (!arrCondis.get(0).getIdGrupo().equals(arrCondis.get(1).getIdGrupo())) {//si es igual todos son iguales se aplican en conjunto
                    juntas = 0;
                }
            }

            Log.e("JUNTAS  ", juntas + "");

            if (arrPromos.get(i).getIdTipoCondicion().equals("2")) {//POR CADA

                if (juntas == 0) {//se aplican por separado por rangos


                } else if (juntas == 1) {//todas las condiciones se aplican juntoas
                    Log.d("//////////////////// ", "/////////////////////////////////////////////////////////");

                    ArrayList<Integer> vecesCumplidas = new ArrayList<>();

                    //valido los historicos
                    Integer evaluaPromo = 1;
                    for (int x = 0; x < arrCondis.size(); x++) {
                        Log.e("condicion  numero " + x, arrCondis.get(x).getCantidad() + " _ " + arrCondis.get(x).getIdProducto());
                        Double uniHis = 0.0;

                        if (arrPromos.get(i).getFlagHistorico().equals("1")) {
                            uniHis = Double.parseDouble(sqHistorico.UnidadesxProductoHistorico(CartActivity.this, arrCondis.get(x).getIdProducto()));
                            Log.e("uni historico", uniHis + "");
                        }
                        if (uniHis > Double.parseDouble(arrCondis.get(x).getCantidad())) {
                            evaluaPromo = 0;
                            Log.e("HIST  MAYOR A CONDICION", "historico : " + uniHis + " - cantidadCondi" + arrCondis.get(x).getCantidad());
                            break;
                        }

                    }

                    if (evaluaPromo == 1) {
                        Log.e("SI EVALUA PROMO", "SI EVALUARA LA PROMO");

                        for (int x = 0; x < arrCondis.size(); x++) {
                            Integer compra = sqCarrito.UnixProdCarrito(CartActivity.this, pref.getString("idUsuarioCliente", ""), pref.getString("idUsuarioVenta", "")
                                    , arrCondis.get(x).getIdProducto());

                            Integer valor = compra / Integer.parseInt(arrCondis.get(x).getCantidad());
                            vecesCumplidas.add(valor);
                            Log.e(" VECES CUMPLIDAS PROM", "PROD : " + arrCondis.get(x).getIdProducto() + " , VALOR " + valor);
                        }


                        if (vecesCumplidas.size() > 0) {
                            Collections.sort(vecesCumplidas);
                            Integer veces = vecesCumplidas.get(0);

                            if (veces > 2) {
                                veces = 2;
                            }

                            Log.e("VECES QUE SE BONIFICA ", veces + "  VECES");

                            if (veces != 0) {
                                ArrayList<Bonificacion> arrBonis = sqBoni.listaBonificacionXIdPromocionIdGrupo(CartActivity.this, arrCondis.get(0).getIdPromocion(), arrCondis.get(0).getIdGrupo());

                                for (int j = 0; j < arrBonis.size(); j++) {

                                    Integer cant = 0;

                                    for (Integer h = 1; h <= (int) veces; h++) {
                                        cant = cant + Integer.parseInt(arrBonis.get(j).getCantidad());

                                        if (cant > Integer.parseInt(sqp.obtenerStock(this, arrBonis.get(j).getIdProducto()))) {
                                            cant = cant - Integer.parseInt(arrBonis.get(j).getCantidad());
                                        }
                                        Log.e("CAN", cant + "  / " + sqp.obtenerStock(this, arrBonis.get(j).getIdProducto()));

                                    }

                                    insertarBonificacion(arrBonis.get(j).getIdProducto(), cant + "",
                                            arrBonis.get(j).getIdPromocion(), "0", "0");

                                }


                                Condicion obj = new Condicion(arrCondis.get(0).getIdPromocionCondicion() + ""
                                        , arrCondis.get(0).getIdPromocion() + ""
                                        , arrCondis.get(0).getIdProducto() + ""
                                        , arrCondis.get(0).getIdCategoria() + ""
                                        , arrCondis.get(0).getIdGrupo() + ""
                                        , arrCondis.get(0).getCantidad() + ""
                                        , arrCondis.get(0).getDescripcion() + "");

                                if (obj != null) {
                                    arayPromoObtenida.add(obj);
                                }

                            } else {
                                Condicion obj = new Condicion(arrCondis.get(0).getIdPromocionCondicion() + ""
                                        , arrCondis.get(0).getIdPromocion() + ""
                                        , arrCondis.get(0).getIdProducto() + ""
                                        , arrCondis.get(0).getIdCategoria() + ""
                                        , arrCondis.get(0).getIdGrupo() + ""
                                        , arrCondis.get(0).getCantidad() + ""
                                        , arrCondis.get(0).getDescripcion() + "");

                                if (obj != null) {
                                    arayPromoCondiMostrar.add(obj);
                                }

                                Log.e("valorCarrito : ", veces + "  , no se bonifica se muestra poppup");

                            }
                        }
                    }
                }

            } else if (arrPromos.get(i).getIdTipoCondicion().equals("1")) { // MAYOR O IGUAL

            }

            //CUANDO EL MONTO CONDICION ES MAS QUE 0
        }else if (Integer.parseInt(arrPromos.get(i).getIdTipoPromocion()) ==3){

            Log.d(">>>>>>>>>>>>>>>>>>>>",">>>>>>>>>>>>>>>>>>>>>>BONIS UNIDAD MONTO CONDICION>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>+");
            Log.e("IdPromocion x PROD   ", arrPromos.get(i).getIdPromocion());

              ArrayList<Condicion> arrCondis2 = sqCondi.listaCondiciones3xIdPromocionGroupBy(CartActivity.this, arrPromos.get(i).getIdPromocion());

            for(int o=0;o<arrCondis2.size();o++){
                Log.e(">>>>>>>>>>>>>>>>>>>>",">>>>>>>>>>>>>>>>>>>>>>"+arrCondis2.get(o).getDescripcion()+">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>+");
                Log.e("monto requerido", arrCondis2.get(o).getCantidad()+"");
                Log.e("grupo", arrCondis2.get(o).getIdGrupo()+"");

                ArrayList<Condicion> arrCondisProd =sqCondi.listaCondiciones3xIdGrupoIdPromo(CartActivity.this, arrPromos.get(i).getIdPromocion(),arrCondis2.get(o).getIdGrupo());

                Integer montorecaudado = 0;
                for(int x=0;x<arrCondisProd.size();x++){
                    Log.e(" Prod "+x, arrCondisProd.get(x).getIdProducto()+"");
                    montorecaudado=montorecaudado+sqCarrito.UnixProdCarrito(CartActivity.this, pref.getString("idUsuarioCliente", ""), pref.getString("idUsuarioVenta", "")
                            , arrCondisProd.get(x).getIdProducto());
                }

                Log.e("montorecaudado", montorecaudado+"");


                if(Integer.parseInt(arrCondis2.get(o).getCantidad())<=montorecaudado){
                    Log.e("SE BONIFICA", "SE BONIFICAA   VECES: "+(montorecaudado/Integer.parseInt(arrCondis2.get(o).getCantidad())));

                    ArrayList<Bonificacion> arrBonis = sqBoni.listaBonificacionXIdPromocionIdGrupo(CartActivity.this, arrCondis2.get(o).getIdPromocion(), arrCondis2.get(o).getIdGrupo());


                    for (int j = 0; j < arrBonis.size(); j++) {

                        Integer cant = 0;

                        for (Integer h = 1; h <= (int) (montorecaudado/Integer.parseInt(arrCondis2.get(o).getCantidad())); h++) {
                            cant = cant + Integer.parseInt(arrBonis.get(j).getCantidad());

                            if (cant > Integer.parseInt(sqp.obtenerStock(this, arrBonis.get(j).getIdProducto()))) {
                                cant = cant - Integer.parseInt(arrBonis.get(j).getCantidad());
                            }
                            Log.e("CAN", cant + "  / " + sqp.obtenerStock(this, arrBonis.get(j).getIdProducto()));

                        }

                        insertarBonificacion(arrBonis.get(j).getIdProducto(), cant + "",
                                arrBonis.get(j).getIdPromocion(), "0", "0");

                    }


                    Condicion obj = new Condicion(arrCondis2.get(o).getIdPromocionCondicion() + ""
                            , arrCondis2.get(o).getIdPromocion() + ""
                            , arrCondis2.get(o).getIdProducto() + ""
                            , arrCondis2.get(o).getIdCategoria() + ""
                            , arrCondis2.get(o).getIdGrupo() + ""
                            , arrCondis2.get(o).getCantidad() + ""
                            , arrCondis2.get(o).getDescripcion() + "");

                    if (obj != null) {
                        arayPromoObtenida.add(obj);
                    }



                    break;
                }else{
                    Condicion obj = new Condicion(arrCondis2.get(o).getIdPromocionCondicion() + ""
                            , arrCondis2.get(o).getIdPromocion() + ""
                            , arrCondis2.get(o).getIdProducto() + ""
                            , arrCondis2.get(o).getIdCategoria() + ""
                            , arrCondis2.get(o).getIdGrupo() + ""
                            , arrCondis2.get(o).getCantidad() + ""
                            , arrCondis2.get(o).getDescripcion() + "");

                    if (obj != null) {
                        arayPromoCondiMostrar.add(obj);
                    }
                    Log.e("NO SE BONIFICA",  "NO SE BONIFICA");
                }


            }


        }
    }
    }

    public void insertarBonificacion (String IdProductoTxt,String cantidad,String IdPromocion,String IdPromocionCondicion,String IdPromocionBonificacion){
        SqliteProducto sql = new SqliteProducto();
         Producto  arrProd = sql.BuscarProductoxid(CartActivity.this,IdProductoTxt);

        if(arrProd!=null){
            sqCarrito.insertarCarrito(CartActivity.this, pref.getString("idUsuarioCliente",""),
                    pref.getString("idUsuarioVenta",""),
                    arrProd .getIdProductoTxt()  +"",
                    "" ,
                    "",
                    "",
                    arrProd .getNombrePro()+"",
                    "",
                    "0",
                    "0",
                    arrProd .getImagen()+"",
                    "0",
                    arrProd.getStock()+"",
                    cantidad,
                    null,
                    "",
                    IdPromocion,
                    IdPromocionCondicion,
                    IdPromocionBonificacion,"0","0");
        }
    }

    //Run on UI
    private Runnable sendUpdatesToUI = new Runnable() {
        public void run() {
            // showSettingDialog();
            progress2.show();
        }
    };

    private BroadcastReceiver gpsLocationReceiver = new BroadcastReceiver() {

        @Override
        public void onReceive(Context context, Intent intent) {

            //If Action is Location
            if (intent.getAction().matches(BROADCAST_ACTION)) {
                LocationManager locationManager = (LocationManager) context.getSystemService(Context.LOCATION_SERVICE);
                //Check if GPS is turned ON or OFF
                if (locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER)) {
                    Log.e("About GPS", "GPS is Enabled in your device");

                    progress2.dismiss();
                } else {
                    //If GPS turned OFF show Location Dialog
                    new Handler().postDelayed(sendUpdatesToUI, 10);
                    // showSettingDialog();
                    Log.e("About GPS", "GPS is Disabled in your device");
                }

            }
        }
    };

    private class cancelaPedidoComp extends AsyncTask<String,Void,Object>{

        ParametrosSalida objParametros;

        @Override
        protected Object doInBackground(String... strings) {
            objParametros = new WebService().cancelaPedidoComp(idUsuarioVenta,lstCarrito.get(0).getIdPedido());
            return null;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            dialog.dismiss();
            if(objParametros.getFlagIndicador()==0) {

                Toast.makeText(getApplicationContext(),objParametros.getMsgValidacion(),Toast.LENGTH_LONG).show();


                Integer pedidoComp=0;
                if(!pref.getString("pedidoComp","0").equals("0")){
                    try {
                        pedidoComp = Integer.parseInt(pref.getString("pedidoComp","0"))-1;
                    }catch (Exception e){

                    }finally {

                    }
                }

                SharedPreferences.Editor  edit = pref.edit();
                edit.putString("origen","0");
                edit.putString("pedidoComp",pedidoComp+"");
                edit.commit();

                SqliteCarrito sql3 = new SqliteCarrito();
                sql3.eliminarCarritoxIdUsuarioCiente(CartActivity.this,pref.getString("idUsuarioCliente",""),
                        pref.getString("idUsuarioVenta",""));


                SqlitePromocionVista s = new SqlitePromocionVista();
                s.eliminarvistos(CartActivity.this);

                SqliteSugerido sql = new SqliteSugerido();
                String value = sql.buscarFlagSugerido(CartActivity.this,idUsuarioCliente,idUsuarioVenta);

                if(value.equals("2")){
                    sql.insertarSugerido(CartActivity.this,idUsuarioCliente,idUsuarioVenta,"0");
                }else if ( value.equals("0")){

                }else if (value.equals("1")){
                    sql.actualizaSugerido(CartActivity.this,idUsuarioCliente,idUsuarioVenta,"0");
                }

                Intent i = new Intent(CartActivity.this, MainActivity.class);
                i.putExtra("muestra", "9");
                i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                startActivity(i);
            }else{
                Toast.makeText(getApplicationContext(),objParametros.getMsgValidacion(),Toast.LENGTH_LONG).show();
            }

        }
    }

    @Override
    protected void onResume() {
        super.onResume();
        registerReceiver(gpsLocationReceiver, new IntentFilter(BROADCAST_ACTION));//Register broadcast receiver to check the status of GPS


    }

    private class ListarDiasVisita extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            arrDiasVisita = new WebService().ListaDiaVisita(idUsuarioCliente);
            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            Log.e("LISTAR DIA VISITA","SE EJECUTO");
            if(  arrDiasVisita==null){
                Log.e("DIAS ","DIAS SIZE ES IGUAL A NULL");
            }else  if(arrDiasVisita.size()==0) {
                Log.e("DIAS ","DIAS SIZE ES IGUAL A 0");
            }else if (arrDiasVisita.size()>0){
                Integer dia =  Integer.parseInt(pref.getString("dia",""));

                ArrayList<Integer>days = new ArrayList<>();

                 for (int i=0;i<arrDiasVisita.get(0).getDiasVisita().length();i++){
                     if(arrDiasVisita.get(0).getDiasVisita().substring(i,i+1).equals("1")){
                         days.add((i+1) );
                     }
                 }

                for (int x = 0;x<days.size();x++){

                }

                Collections.sort(days);

                for(int j =0;j<days.size();j++){
                    if(days.get(j) > dia && days.get(j) !=7 ){

                        pintaDiaEntrega(days.get(j));
                        txtEntrega.setVisibility(View.VISIBLE);
                        break;
                    }

                }


                    if(days.size()>0){
                        pintaDiaEntrega(days.get(0));
                        Log.e("DIAS ",days.get(0).toString());
                        txtEntrega.setVisibility(View.VISIBLE);
                    }


            }
        }
    }


    public void pintaDiaEntrega(Integer v){

        switch (v) {
            case 1:
                // LUNES

                txtEntrega.setText("Día entrega : LUNES");
                break;
            case 2:
                // MARTES
                txtEntrega.setText("Día entrega : MARTES");
                break;
            case 3:
                // MIERCOLES
                txtEntrega.setText("Día entrega : MIERCOLES");
                break;
            case 4:
                // JUEVES
                txtEntrega.setText("Día entrega : JUEVES");
                break;
            case 5:
                // VIERNES
                txtEntrega.setText("Día entrega : VIERNES");
                break;
            case 6:
                // SABADO
                txtEntrega.setText("Día entrega : SABADO");
                break;
            case 7:
                // DOMINGO
                txtEntrega.setText("Día entrega : DOMINGO");
                break;
        }
    }


    private class insertarPedidoComp extends AsyncTask<String,Void,Object> {

        ArrayList<PedidoDetalleRespuesta> ar;

        @Override
        protected Object doInBackground(String... strings) {

            Calendar cal = Calendar.getInstance();

            ar = new WebService().EnviarPedidoComp(getApplicationContext(),IdPed,idUsuarioCliente,nomCliente,"","1",idUsuarioVenta,total
                    ,totalPro,latitud,longitud,"1",new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").format(cal.getTime())
                    ,lstPedidoDetalle);
            return null;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);

            dialog.dismiss();

            if(ar!=null) {

                if (ar.size() == 1 &&(ar.get(0).getIdProductoTxt().equals("0")||ar.get(0).getIdProductoTxt().equals("2"))) {
                    Toast.makeText(getApplicationContext(), ar.get(0).getNombrePro() , Toast.LENGTH_LONG).show();

                    Integer pedidoComp=0;
                    if(!pref.getString("pedidoComp","0").equals("0")){
                        try {
                            pedidoComp = Integer.parseInt(pref.getString("pedidoComp","0"))-1;
                        }catch (Exception e){

                        }finally {

                        }
                    }

                    SharedPreferences.Editor  edit = pref.edit();
                    edit.putString("origen","0");
                    edit.putString("pedidoComp",pedidoComp+"");
                    edit.commit();


                    Intent i = new Intent(CartActivity.this, MainActivity.class);
                    i.putExtra("muestra", "2");
                    i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                    startActivity(i);

                    SqlitePromocionVista s = new SqlitePromocionVista();
                    s.eliminarvistos(CartActivity.this);

                    SqliteSugerido sql = new SqliteSugerido();
                    String value = sql.buscarFlagSugerido(CartActivity.this, idUsuarioCliente, idUsuarioVenta);

                    if (value.equals("2")) {
                        sql.insertarSugerido(CartActivity.this, idUsuarioCliente, idUsuarioVenta, "0");
                    } else if (value.equals("0")) {

                    } else if (value.equals("1")) {
                        sql.actualizaSugerido(CartActivity.this, idUsuarioCliente, idUsuarioVenta, "0");
                    }
                    SqliteVisita sq = new SqliteVisita();
                    Calendar cal = Calendar.getInstance();
                    String hoy = new SimpleDateFormat("dd/MM/yyyy").format(cal.getTime());
                    sq.insertarVisita(getApplicationContext(), pref.getString("idUsuarioCliente", ""), pref.getString("idUsuarioVenta", ""), hoy, "0");
                    sqCarrito.eliminarCarritoxIdUsuarioCiente(getApplicationContext(), pref.getString("idUsuarioCliente", ""), pref.getString("idUsuarioVenta", ""));

                }else if(ar.size() == 1 && ar.get(0).getIdProductoTxt().equals("1")){

                    Toast.makeText(getApplicationContext(),ar.get(0).getNombrePro(),Toast.LENGTH_LONG).show();
                    btnTerminarPedido.setClickable(true);

                }else  {
                    btnTerminarPedido.setClickable(true);

                    dialog2 = new Dialog(CartActivity.this);
                    dialog2.requestWindowFeature(Window.FEATURE_NO_TITLE);
                    dialog2.setCancelable(false);
                    dialog2.setContentView(R.layout.popup_observaciones);
                    dialog2.getWindow().setBackgroundDrawable(new ColorDrawable(android.graphics.Color.TRANSPARENT));

                    CardView mDialogok = dialog2.findViewById(R.id.frmyess);
                    RecyclerView rx = dialog2.findViewById(R.id.rxobservadas);

                    adapterObservadas= new CustomListObservaciones( ar,CartActivity.this);
                    adapterObservadas.notifyDataSetChanged();

                    rx.setLayoutManager(new StaggeredGridLayoutManager(1, StaggeredGridLayoutManager.VERTICAL));
                    rx.setItemViewCacheSize(ar.size());
                    rx.setAdapter(adapterObservadas);
                    rx.scheduleLayoutAnimation();

                    mDialogok.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {

                            dialog2.cancel();
                            calculaBonificaciones();
                            listarCarrito2();
                        }
                    });


                    dialog2.show();

                }

            }else  {
                Toast.makeText(getApplicationContext(),"Error de red",Toast.LENGTH_LONG).show();
            }
        }
    }

    private class insertarPedido extends AsyncTask<String,Void,Object> {

        ArrayList<PedidoDetalleRespuesta> ar;

        @Override
        protected Object doInBackground(String... strings) {

            Calendar cal = Calendar.getInstance();

            ar = new WebService().EnviarPedido(getApplicationContext(),idUsuarioCliente,nomCliente,"","1",idUsuarioVenta,total
                                                        ,totalPro,latitud,longitud,"1",new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").format(cal.getTime())
                                                        ,pref.getString("idTipoUsuario","1"),lstPedidoDetalle);
            return null;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);

            dialog.dismiss();

                 if(ar!=null) {

                     if (ar.size() == 1 &&(ar.get(0).getIdProductoTxt().equals("0")||ar.get(0).getIdProductoTxt().equals("2"))) {
                         Toast.makeText(getApplicationContext(), ar.get(0).getNombrePro() , Toast.LENGTH_LONG).show();

                         SharedPreferences.Editor  edit = pref.edit();
                         edit.putString("origen","0");
                         edit.commit();
                         Intent i = new Intent(CartActivity.this, MainActivity.class);
                         i.putExtra("muestra", "2");
                         i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                         startActivity(i);

                         SqlitePromocionVista s = new SqlitePromocionVista();
                         s.eliminarvistos(CartActivity.this);

                         SqliteSugerido sql = new SqliteSugerido();
                         String value = sql.buscarFlagSugerido(CartActivity.this, idUsuarioCliente, idUsuarioVenta);

                         if (value.equals("2")) {
                             sql.insertarSugerido(CartActivity.this, idUsuarioCliente, idUsuarioVenta, "0");
                         } else if (value.equals("0")) {

                         } else if (value.equals("1")) {
                             sql.actualizaSugerido(CartActivity.this, idUsuarioCliente, idUsuarioVenta, "0");
                         }
                         SqliteVisita sq = new SqliteVisita();
                         Calendar cal = Calendar.getInstance();
                         String hoy = new SimpleDateFormat("dd/MM/yyyy").format(cal.getTime());
                         sq.insertarVisita(getApplicationContext(), pref.getString("idUsuarioCliente", ""), pref.getString("idUsuarioVenta", ""), hoy, "0");
                         sqCarrito.eliminarCarritoxIdUsuarioCiente(getApplicationContext(), pref.getString("idUsuarioCliente", ""), pref.getString("idUsuarioVenta", ""));
                     }else if(ar.size() == 1 && ar.get(0).getIdProductoTxt().equals("1")){
                         Toast.makeText(getApplicationContext(),ar.get(0).getNombrePro(),Toast.LENGTH_LONG).show();
                         btnTerminarPedido.setClickable(true);
                     }else  {

                    btnTerminarPedido.setClickable(true);
                    dialog2 = new Dialog(CartActivity.this);
                    dialog2.requestWindowFeature(Window.FEATURE_NO_TITLE);
                    dialog2.setCancelable(false);
                    dialog2.setContentView(R.layout.popup_observaciones);
                    dialog2.getWindow().setBackgroundDrawable(new ColorDrawable(android.graphics.Color.TRANSPARENT));

                    CardView mDialogok = dialog2.findViewById(R.id.frmyess);
                    RecyclerView rx = dialog2.findViewById(R.id.rxobservadas);

                    adapterObservadas= new CustomListObservaciones( ar,CartActivity.this);
                    adapterObservadas.notifyDataSetChanged();

                    rx.setLayoutManager(new StaggeredGridLayoutManager(1, StaggeredGridLayoutManager.VERTICAL));
                    rx.setItemViewCacheSize(ar.size());
                    rx.setAdapter(adapterObservadas);
                    rx.scheduleLayoutAnimation();

                    mDialogok.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {

                            dialog2.cancel();
                            calculaBonificaciones();
                            listarCarrito2();
                        }
                    });


                   dialog2.show();

                }

            }else  {
                Toast.makeText(getApplicationContext(),"Error de red",Toast.LENGTH_LONG).show();
            }
        }
    }

    public void listarCarrito( ){

        SqliteCarrito sql = new SqliteCarrito();
        lstCarrito = sql.listarCarrito(getApplicationContext(),idUsuarioCliente,idUsuarioVenta);

        adapter = new CustomListCarrito( this,lstCarrito);
        adapter.notifyDataSetChanged();

        /*crear controlador de animacion*/
        LayoutAnimationController controller = null;
        controller = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

        rc.setLayoutManager(new StaggeredGridLayoutManager(  1, StaggeredGridLayoutManager.VERTICAL));
        rc.setItemViewCacheSize(lstCarrito.size());
        /*setear controlador de animacion*/
        rc.setLayoutAnimation(controller);
        /*setear adaptador con datos*/
        rc.setAdapter(adapter);
        /*setear manejador de animacion*/
        rc.scheduleLayoutAnimation();
        //extender(i,true);


        SqliteCarrito sql2 = new SqliteCarrito();
        lstCarritoBoni = sql2.listarBoni(getApplicationContext(),idUsuarioCliente,idUsuarioVenta);

        if(lstCarritoBoni.size()>0) {
            linearBoni.setVisibility(View.VISIBLE);
            adapter2 = new CustomListBoni(this, lstCarritoBoni);
            adapter2.notifyDataSetChanged();

            LayoutAnimationController controllerr = null;
            controllerr = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

            rcBoni.setLayoutManager(new StaggeredGridLayoutManager(2, StaggeredGridLayoutManager.VERTICAL));
            rcBoni.setItemViewCacheSize(lstCarritoBoni.size());
            /*setear controlador de animacion*/
            rcBoni.setLayoutAnimation(controllerr);
            /*setear adaptador con datos*/
            rcBoni.setAdapter(adapter2);
            /*setear manejador de animacion*/
            rcBoni.scheduleLayoutAnimation();
        }else{
            linearBoni.setVisibility(View.GONE);
        }
        dialog.dismiss();
        calcular();
    }

    public void calcular(){
        Integer i =0;
        Integer p =0;
        Double t =0.0;



        for (int x=0; x<lstCarrito.size();x++){
            p = p+Integer.parseInt(lstCarrito.get(x).getCant());
            t = t + (  Double.parseDouble(lstCarrito.get(x).getPrecio().replace(",","."))*Integer.parseInt(lstCarrito.get(x).getCant()));
        }
        txtItem.setText("Items : " +lstCarrito.size()+"");
        txtPro.setText("Productos : "+p );
        txtTotal.setText("Total a Pagar : S/. "+ Math.round(t * 100.0) / 100.0  );

        ArrayList<String> values= new ArrayList<>();

        ArrayList<Categoria> lstCat = sqCarrito.listarSubtotales(CartActivity.this,pref.getString("idUsuarioCliente",""),
                pref.getString("idUsuarioVenta",""));

        for(int e=0;e<lstCat.size();e++){
            values.add(lstCat.get(e).getNombre()+" : S/. "+lstCat.get(e).getStock());
        }


        ArrayAdapter <String> adaptador = new ArrayAdapter <String> (this,
                R.layout.layout_cat_subtotal,  R.id.txttt, values);

        lst.setAdapter(adaptador);
    }


    public void listarCarrito2( ) {


        SqliteCarrito sql = new SqliteCarrito();
        lstCarrito = sql.listarCarrito(getApplicationContext(), idUsuarioCliente,idUsuarioVenta);


        if(lstCarrito.size()>0) {

            adapter = new CustomListCarrito(this, lstCarrito);
            adapter.notifyDataSetChanged();

            /*crear controlador de animacion*/
            LayoutAnimationController controller = null;
            controller = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

            rc.setLayoutManager(new StaggeredGridLayoutManager(1, StaggeredGridLayoutManager.VERTICAL));
            rc.setItemViewCacheSize(lstCarrito.size());
            /*setear controlador de animacion*/
            //rc.setLayoutAnimation(controller);
            /*setear adaptador con datos*/
            rc.setAdapter(adapter);
            /*setear manejador de animacion*/
            //rc.scheduleLayoutAnimation();


            SqliteCarrito sql2 = new SqliteCarrito();
            lstCarritoBoni = sql2.listarBoni(getApplicationContext(),idUsuarioCliente,idUsuarioVenta);

            if(lstCarritoBoni.size()>0) {
                linearBoni.setVisibility(View.VISIBLE);
                adapter2 = new CustomListBoni(this, lstCarritoBoni);
                adapter2.notifyDataSetChanged();

                LayoutAnimationController controllerr = null;
                controllerr = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

                rcBoni.setLayoutManager(new StaggeredGridLayoutManager(2, StaggeredGridLayoutManager.VERTICAL));
                rcBoni.setItemViewCacheSize(lstCarritoBoni.size());
                /*setear controlador de animacion*/
                //rcBoni.setLayoutAnimation(controllerr);
                /*setear adaptador con datos*/
                rcBoni.setAdapter(adapter2);
                /*setear manejador de animacion*/
                rcBoni.scheduleLayoutAnimation();

            }else{
                linearBoni.setVisibility(View.GONE);
            }

            calcular();
        }else{
            eliminAbONIxCategoria();
            Intent i= new Intent(CartActivity.this,MainActivity.class);
            i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP|Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(i);
        }
    }




    /*******************************************************************************************************************************/

    private void getLocation() {
        if (ActivityCompat.checkSelfPermission(CartActivity.this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED
                && ActivityCompat.checkSelfPermission(CartActivity.this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            ActivityCompat.requestPermissions(CartActivity.this, new String[]{Manifest.permission.ACCESS_FINE_LOCATION, Manifest.permission.ACCESS_COARSE_LOCATION},
                    AppConstants.LOCATION_REQUEST);

        } else {
            if (isContinue) {
                mFusedLocationClient.requestLocationUpdates(locationRequest, locationCallback, null);
            } else {
                mFusedLocationClient.getLastLocation().addOnSuccessListener(new OnSuccessListener<Location>() {
                    @Override
                    public void onSuccess(Location location) {
                        if(location!=null){
                            //Toast.makeText(getApplicationContext(),location.getLatitude()+" - "+location.getLongitude(),Toast.LENGTH_SHORT).show();
                            txtLat.setText(location.getLatitude()+"");
                            txtLon.setText(location.getLongitude()+"");
                        }
                    }
                });
            }
        }
    }

    @SuppressLint("MissingPermission")
    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        switch (requestCode) {
            case 1000: {
                // If request is cancelled, the result arrays are empty.
                if (grantResults.length > 0
                        && grantResults[0] == PackageManager.PERMISSION_GRANTED) {

                    if (isContinue) {
                        mFusedLocationClient.requestLocationUpdates(locationRequest, locationCallback, null);
                    } else {
                        mFusedLocationClient.getLastLocation().addOnSuccessListener(new OnSuccessListener<Location>() {
                            @Override
                            public void onSuccess(Location location) {
                                //Toast.makeText(getApplicationContext(),location.getLatitude()+" - "+location.getLongitude(),Toast.LENGTH_SHORT).show();
                                txtLat.setText(location.getLatitude()+"");
                                txtLon.setText(location.getLongitude()+"");
                            }
                        });
                    }
                } else {
                    Toast.makeText(this, "Permission denied", Toast.LENGTH_SHORT).show();
                }
                break;
            }
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (resultCode == Activity.RESULT_OK) {
            if (requestCode == AppConstants.GPS_REQUEST) {
                isGPS = true; // flag maintain before get location
            }
        }
    }
}
