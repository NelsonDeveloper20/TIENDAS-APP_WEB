package com.delcorp.apptiendadelcorp.activity;

import android.animation.ValueAnimator;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.PointF;
import android.graphics.Typeface;
import android.graphics.drawable.ColorDrawable;
import android.icu.text.UnicodeSetSpanner;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.os.StrictMode;
import android.support.design.widget.AppBarLayout;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.view.MenuItemCompat;
import android.support.v4.view.PagerAdapter;
import android.support.v7.widget.CardView;
import android.support.v7.widget.DefaultItemAnimator;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.StaggeredGridLayoutManager;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.DragEvent;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.MotionEvent;
import android.view.View;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.ViewGroup;
import android.view.Window;
import android.view.WindowManager;
import android.view.animation.AnimationUtils;
import android.view.animation.DecelerateInterpolator;
import android.view.animation.LayoutAnimationController;
import android.view.animation.OvershootInterpolator;
import android.view.inputmethod.InputMethodManager;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.RegistroUserActivity;
import com.delcorp.apptiendadelcorp.bean.Carrito;
import com.delcorp.apptiendadelcorp.bean.Categoria;
import com.delcorp.apptiendadelcorp.bean.Cliente;
import com.delcorp.apptiendadelcorp.bean.Condicion;
import com.delcorp.apptiendadelcorp.bean.CondicionBonificacion;
import com.delcorp.apptiendadelcorp.bean.ParametrosSalida;
import com.delcorp.apptiendadelcorp.bean.Producto;
import com.delcorp.apptiendadelcorp.bean.ProductoSugerido;
import com.delcorp.apptiendadelcorp.bean.Promocion;
import com.delcorp.apptiendadelcorp.bean.ReporteMeta;
import com.delcorp.apptiendadelcorp.sqlite.SqliteBonificacion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCarrito;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCategoria;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCategoria;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCliente;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCondicion;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePedido;
import com.delcorp.apptiendadelcorp.sqlite.SqliteProducto;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePromocionVista;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePromociones;
import com.delcorp.apptiendadelcorp.sqlite.SqliteSugerido;
import com.delcorp.apptiendadelcorp.util.AutoScrollViewPager;
import com.delcorp.apptiendadelcorp.webservice.WebService;
import com.hookedonplay.decoviewlib.DecoView;
import com.hookedonplay.decoviewlib.charts.EdgeDetail;
import com.hookedonplay.decoviewlib.charts.SeriesItem;
import com.hookedonplay.decoviewlib.charts.SeriesLabel;
import com.hookedonplay.decoviewlib.events.DecoEvent;


import org.apache.commons.io.IOUtils;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.net.URL;
import java.net.URLConnection;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.concurrent.ExecutionException;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {

    ArrayList<Categoria> arrayCategoria;
    ArrayList<Producto> arrayProducto;
    ArrayList<Promocion> arrayPromocion;
    ArrayList<CondicionBonificacion> arrayCondicionBonificacion;

    SqliteCarrito sqlcarrito = new SqliteCarrito();
    ArrayList<ProductoSugerido> arraProductoSugerido;
    String idUsuarioVenta,idUsuarioCliente ,CodigoTxt;
    RecyclerView rc,rcBoni;
    CustomListCategoria adapter;
    CardView card;
    CustomListProducto adapter2;
    SharedPreferences pref;
    Dialog dialog;
    TextView msj,txtCantidadPedido;
    FloatingActionButton fabb,fabbb,fabbus,fabSug;
    AppBarLayout appb;
    Toolbar toolbar;
    Integer i =0,j=0;
    LinearLayout viewOne,linearpromo;
    AutoScrollViewPager viewPager ;
    EditText txtProducto;
    String textoBusqueda="";
    LinearLayout linearvacia;
    Dialog dialog2,dialog3  ;
    String idUsuario,idTipoAcceso;
    ReporteMeta objReporteMeta;
    TextView txtVentasRealizadas,txtMontoRecaudado,txtMeta,txtMes,txtPor,txtMontoFaltante;
    DecoView arcView ;
    EditText txtNombres,txtPaterno,txtMaterno,txtCelular,txtTelefono,txtDni,txtRuc,
            txtRazon,txtDireccion,txtCorreo;
    TextView txtter,txtpol;
    CardView btnRegistro;

    String  vNombre="",vPaterno="",vMaterno="",vCelular="",vTelefono="",
                    vdni="",vruc="",vRazonSocial="",vDireccion="",vCorreo="",token="NO DEFINIDO";
    CheckBox chkter,chkpol;
    TextView txtCantPedComp;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        dialog3 = new Dialog(MainActivity.this);
        dialog2 = new Dialog(MainActivity.this);
        dialog2.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog2.setCancelable(false);
        dialog2.setContentView(R.layout.activity_meta_mensual_dialog);
        dialog2.getWindow().setBackgroundDrawable(new ColorDrawable(android.graphics.Color.TRANSPARENT));

        FrameLayout mDialogNo = dialog2.findViewById(R.id.frmNo);

        txtVentasRealizadas = dialog2.findViewById(R.id.txtVentasRealizadas);
        txtMontoRecaudado= dialog2.findViewById(R.id.txtMontoRecaudado);
        txtMeta= dialog2.findViewById(R.id.txtMeta);
        txtPor = dialog2.findViewById(R.id.txtPor);
        txtMes= dialog2.findViewById(R.id.txtMes);
        txtMontoFaltante=dialog2.findViewById(R.id.txtMontoFaltante);
        arcView = dialog2.findViewById(R.id.arcView2);
        card = dialog2.findViewById(R.id.card);

        mDialogNo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                dialog2.cancel();
            }
        });
        pref =   getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;
        idUsuario = pref.getString("idUsuarioVenta","0");
        idTipoAcceso = pref.getString("idTipoAcceso","0");

        Calendar cal = Calendar.getInstance();
        String a = new SimpleDateFormat("dd/MM/yyyy").format(cal.getTime());


        SharedPreferences.Editor e = pref.edit();
        e.putString("fecharep",a);
        e.commit();

        linearvacia = findViewById(R.id.linervacio);
        appb = findViewById(R.id.appb);
        linearpromo = findViewById(R.id.linearpromo);
        txtCantidadPedido = findViewById(R.id.txtCantidadPedido);
        txtProducto = findViewById(R.id.txtProducto);
        txtProducto.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                textoBusqueda = txtProducto.getText().toString();

                ArrayList<Categoria> arrayTra;

                SqliteCategoria sql = new SqliteCategoria();
                /*arrayTra= sql.BuscarTrabajador(context,charSequence+"",idTrabajador);
                cargarLista(arrayTra);*/
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });
        fabb = findViewById(R.id.fabb);
        fabbb=findViewById(R.id.fabbb);
        fabbus = findViewById(R.id.fabbus);
        viewOne = findViewById(R.id.viewOne);

        viewPager= findViewById(R.id.viewPager);
        viewPager.startAutoScroll();
        viewPager.setInterval(3000);
        viewPager.setCycle(true);
        viewPager.setStopScrollWhenTouch(true);

        PagerAdapter adapter = new ViewPagerAdapter(MainActivity.this);
        viewPager.setAdapter(adapter);

        rc = findViewById(R.id.MyRecycler);

        dialog = new  Dialog(MainActivity.this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setCancelable(false);
        dialog.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
        dialog.setContentView(R.layout.dialog_procesando);

        msj = dialog.findViewById(R.id.txt);

        RecyclerView.ItemAnimator itemAnimator = new DefaultItemAnimator();
        itemAnimator.setAddDuration(1000);
        itemAnimator.setRemoveDuration(1000);
        rc.setItemAnimator(itemAnimator);

        toolbar = findViewById(R.id.toolbar);
        toolbar.setBackgroundColor(Color.TRANSPARENT);
        toolbar.setTitle("Bienvenido");
        setSupportActionBar(toolbar);


        if (Build.VERSION.SDK_INT >= 19 && Build.VERSION.SDK_INT < 21) {
            setWindowFlag(this, WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS, true);
        }
        if (Build.VERSION.SDK_INT >= 19) {
            getWindow().getDecorView().setSystemUiVisibility(View.SYSTEM_UI_FLAG_LAYOUT_STABLE | View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN);
        }
        //make fully Android Transparent Status bar
        if (Build.VERSION.SDK_INT >= 21) {
            setWindowFlag(this, WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS, true);
            getWindow().setStatusBarColor(Color.TRANSPARENT);
        }

        DrawerLayout drawer = findViewById(R.id.drawer_layout);
        final ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);

        drawer.addDrawerListener(toggle);
        toggle.syncState();


        NavigationView navigationView = findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

        txtCantPedComp = (TextView) navigationView.getMenu().findItem(R.id.nav_menores).getActionView().findViewById(R.id.txtBallon);
        toolbar.setNavigationOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Toast.makeText(getApplicationContext(),"nooooooooooooooooooooooo", Toast.LENGTH_LONG).show();
                DrawerLayout drawer = findViewById(R.id.drawer_layout);
                if (drawer.isDrawerOpen(GravityCompat.START)) {
                    drawer.closeDrawer(GravityCompat.START);
                } else {
                    drawer.openDrawer(GravityCompat.START);
                }

                if(!pref.getString("pedidoComp","0").equals("0")){
                    txtCantPedComp.setVisibility(View.VISIBLE);
                    txtCantPedComp.setText(pref.getString("pedidoComp","0"));
                }else{
                    txtCantPedComp.setVisibility(View.INVISIBLE);
                }
            }
        });


        fabbus.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(txtProducto.getVisibility()==View.GONE){

                    txtProducto.setText("");
                    scaleView(txtProducto,1f,1f);
                    txtProducto.setVisibility(View.VISIBLE);
                    scaleView(viewPager,0f,0f);
                    viewPager.setVisibility(View.GONE);
                    scaleView(linearpromo,0f,0f);
                    linearpromo.setVisibility(View.GONE);

                    fabbus.setImageDrawable(getResources().getDrawable(R.drawable.ic_arrow_back_black_24dp));

                }else{
                    if(fabbb.getVisibility()==View.VISIBLE){

                         txtProducto.setText("");
                        scaleView(txtProducto,0f,0f);
                        txtProducto.setVisibility(View.GONE);
                        scaleView(viewPager,0f,0f);
                        viewPager.setVisibility(View.GONE);

                         InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
                         imm.hideSoftInputFromWindow(txtProducto.getWindowToken(), 0);
                         fabbus.setImageDrawable(getResources().getDrawable(R.drawable.ic_search_black_24dp));
                    }else{
                        fabbus.setImageDrawable(getResources().getDrawable(R.drawable.ic_search_black_24dp));

                        viewPager.setVisibility(View.VISIBLE);
                        scaleView(viewPager,1f,1f);
                        txtProducto.setText("");
                        InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
                        imm.hideSoftInputFromWindow(txtProducto.getWindowToken(), 0);
                        scaleView(linearpromo,1f,1f);
                        linearpromo.setVisibility(View.VISIBLE);
                        scaleView(txtProducto,0f,0f);
                        txtProducto.setVisibility(View.GONE);
                        scaleView(fabbb,0f,0f);
                        fabbb.setVisibility(View.GONE);
                    }
                }

            }
        });
        fabb.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(!txtCantidadPedido.getText().equals("0")){
                    Intent i = new Intent(MainActivity.this,CartActivity.class);
                    i.putExtra("origen","0");
                    i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP|Intent.FLAG_ACTIVITY_CLEAR_TASK);
                    startActivity(i);
                }else{
                    Toast.makeText(getApplicationContext(),"EL CARRITO ESTA VACIO",Toast.LENGTH_SHORT).show();
                }

            }
        });
        fabbb.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                viewPager.setVisibility(View.VISIBLE);
                scaleView(viewPager,1f,1f);

                linearpromo.setVisibility(View.VISIBLE);
                scaleView(linearpromo,1f,1f);

                scaleView(txtProducto,0f,0f);
                txtProducto.setVisibility(View.GONE);

                listarSoloCategorias();

                scaleView(fabbb,0f,0f);
                fabbb.setVisibility(View.GONE);

                fabbus.setImageDrawable(getResources().getDrawable(R.drawable.ic_search_black_24dp));
                InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
                imm.hideSoftInputFromWindow(txtProducto.getWindowToken(), 0);
            }
        });
        fabSug= findViewById(R.id.fabSug);

        fabSug.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                new ListarProductoSugerido().execute();
            }
        });

        idUsuarioVenta = pref.getString("idUsuarioVenta","0");
        idUsuarioCliente = pref.getString("idUsuarioCliente","0");

        if(i==0){
            i=getHeightOfView(appb) ;
        }
        if(j==0){
            j=getHeightOfView(txtProducto) +(getHeightOfView(txtProducto)/2) ;
        }
       //  extender(i  ,true);

        txtProducto.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {

                if(!(charSequence+"").equals("")) {
                    cargarBusquedaProducto(charSequence + "");
                }else{
                    listarSoloCategorias();
                }
            }
            @Override
            public void afterTextChanged(Editable editable) {
            }
        });

        msj.setText("Obteniendo Datos..");
        dialog.show();

        SqliteProducto sql = new SqliteProducto();
        ArrayList<Producto> p = sql.listarProductosTodos(MainActivity.this,idTipoAcceso);

        if(p.size()==0){
            new ListarData().execute();
        }else{
            listarSoloCategorias();
        }


        if(pref.getString("idTipoAcceso","0").equals("1")){
            Menu nav_Menu = navigationView.getMenu();
            nav_Menu.findItem(R.id.nav_ventas).setVisible(true);
            nav_Menu.findItem(R.id.nav_clientes).setVisible(true);
            nav_Menu.findItem(R.id.nav_meta_cliente).setVisible(true);
            nav_Menu.findItem(R.id.nav_nuevocliente).setVisible(true);
            nav_Menu.findItem(R.id.nav_promos).setVisible(true);
            nav_Menu.findItem(R.id.nav_menores).setVisible(true);
            nav_Menu.findItem(R.id.nav_avance).setVisible(true);
            nav_Menu.findItem(R.id.nav_soporte).setVisible(false);
            nav_Menu.findItem(R.id.nav_cart).setVisible(false);
            nav_Menu.findItem(R.id.nav_inicio).setVisible(true);
        }else{
            Menu nav_Menu = navigationView.getMenu();
            nav_Menu.findItem(R.id.nav_ventas).setVisible(false);
            nav_Menu.findItem(R.id.nav_clientes).setVisible(false);
            nav_Menu.findItem(R.id.nav_nuevocliente).setVisible(false);
            nav_Menu.findItem(R.id.nav_meta_cliente).setVisible(false);
            nav_Menu.findItem(R.id.nav_promos).setVisible(false);
            nav_Menu.findItem(R.id.nav_menores).setVisible(false);
            nav_Menu.findItem(R.id.nav_avance).setVisible(false);
            nav_Menu.findItem(R.id.nav_soporte).setVisible(true);
            nav_Menu.findItem(R.id.nav_inicio).setVisible(false);
        }

          rc.setOnTouchListener(new View.OnTouchListener() {
              @Override
              public boolean onTouch(View view, MotionEvent motionEvent) {

                  ocultarTeclado();
                  return false;
              }
          });


        Integer mostrar =0;
        try {
            mostrar = Integer.parseInt(getIntent().getExtras().getString("muestra","0"));
        }catch (Exception es){
            Log.e("el error es"," ERRROR: "+es.getMessage());
            es.printStackTrace();
        }finally {

        }


        Log.e("ENTRO EN MUESTRA",mostrar+"  dddddddddddd");

        if(mostrar==1){

            new ListarReporte().execute();
            Log.e("ENTRO EN MUESTRA","MUESTRA 1");
        }else if ( mostrar==2){
             new ListarReporte().execute();
            msj.setText("REFRESCANDO DATOS..");
             dialog.show();
            Log.e("ENTRO EN MUESTRA","MUESTRA 2");
             new ListarData().execute();
        }
      //  token = pref.getString("token","NO DEFINIDO");

        String nelson_data="nm";
        //Toast.makeText(getApplicationContext(),"PASÓ :"+nelson_data,Toast.LENGTH_LONG).show();

    }

    public void ocultarTeclado(){
        InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
        imm.hideSoftInputFromWindow(txtProducto.getWindowToken(), 0);
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
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(MainActivity.this);

                builder.setTitle("Error en la red ") ;
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        new  ListarProductoSugerido().execute();

                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();

            }else{
                SqliteCarrito sqlc  = new SqliteCarrito();
                for (int i = 0;i < arraProductoSugerido.size();i++){


                    InsertaAlCarrito(new Carrito(1,
                            pref.getString("idUsuarioCliente",""),
                            pref.getString("idUsuarioVenta",""),
                            arraProductoSugerido.get(i).getIdProducto()+"",
                            arraProductoSugerido.get(i).getIdCategoria()+"" ,
                            arraProductoSugerido.get(i).getIdCategoriaPadre()+"" ,
                            arraProductoSugerido.get(i).getIdFabricante()+"",
                            arraProductoSugerido.get(i).getNombrePro()+"",
                            arraProductoSugerido.get(i).getDescripcion()+"",
                            arraProductoSugerido.get(i).getPrecio()+"",
                            arraProductoSugerido.get(i).getPeso()+"",
                            arraProductoSugerido.get(i).getImagen()+"",
                            arraProductoSugerido.get(i).getIdAlmacen()+"",
                            arraProductoSugerido.get(i).getStock()+"",
                            (Integer.parseInt(arraProductoSugerido.get(i).getCantidadSugerida())+ Integer.parseInt(arraProductoSugerido.get(i).getPorcentajeAdicional()))+"",
                            null,
                            "",
                            "",
                            "",
                            "",
                            "0","0"));

                    muestraCantidad();

                }


                if(arraProductoSugerido.size()>0){
                    Intent in = new Intent(MainActivity.this,CartActivity.class);
                    in.putExtra("origen","0");
                    in.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP|Intent.FLAG_ACTIVITY_CLEAR_TASK);
                    startActivity(in);


                }else{
                    Toast.makeText(getApplicationContext(),"NO EXITEN PRODUCTOS SUGERIDOS",Toast.LENGTH_LONG).show();
                }

                scaleView(fabSug,0f,0f);

                SqliteSugerido sql = new SqliteSugerido();

                String value = sql.buscarFlagSugerido(MainActivity.this,idUsuarioCliente,idUsuarioVenta);

                if(value.equals("2")){
                    sql.insertarSugerido(MainActivity.this,idUsuarioCliente,idUsuarioVenta,"1");
                }else if ( value.equals("0")){
                    sql.actualizaSugerido(MainActivity.this,idUsuarioCliente,idUsuarioVenta,"1");
                }else if (value.equals("1")){
                    sql.actualizaSugerido(MainActivity.this,idUsuarioCliente,idUsuarioVenta,"0");
                }


                fabSug.setVisibility(View.GONE);
            }
        }
    }


    private class ListarReporte extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            objReporteMeta = new WebService().reporteMeta(idUsuario);
            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            if(  objReporteMeta==null){

            }else  if(objReporteMeta.getIdMetaMensual().equals("null")) {

            }else{

                cargaChart(Integer.parseInt(objReporteMeta.getPorcenActual()),  0 , 100-(Integer.parseInt(objReporteMeta.getPorcenActual())),objReporteMeta);
                dialog2.show();

                scaleView(card,1.0f,1.0f);

            }

        }
    }


    public void cargaChart(Integer pATiempo, Integer pFalta, Integer pTarde , ReporteMeta obj){

        txtVentasRealizadas.setText(obj.getCantVentas());
        txtMontoRecaudado.setText("S/. "+obj.getMontoHastaHoy());
        Double v=0.0;
        try{
            v = (Double.parseDouble(obj.getMeta()+"")-Double.parseDouble(obj.getMontoHastaHoy()+""));



        txtMes.setText(obj.getFecha());

        String por =  (Math.round( (Double.parseDouble(obj.getMontoHastaHoy())*100)/Double.parseDouble(obj.getMeta()) * 100.0 )/ 100.0 ) +"";

        arcView.addSeries(new SeriesItem.Builder(Color.argb(255, 218, 218, 218))
                .setRange(0, 100, 100)
                .setInitialVisibility(false)
                .setLineWidth(30f)
                .setInset(new PointF(5f, 5f))
                .build());

        Integer color = 0 ;
        if(Double.parseDouble(obj.getMetaHastaHoy())<= Double.parseDouble(obj.getMontoHastaHoy())){
            color = getResources().getColor(R.color.coloVerde);
        }else{
            color = getResources().getColor(R.color.colorAmbar);
        }

        SeriesItem rATiempo = new SeriesItem.Builder(color)
                .setRange(0, 100, 0)
                .setInitialVisibility(true)
                .setLineWidth(30f)
                .addEdgeDetail(new EdgeDetail(EdgeDetail.EdgeType.EDGE_OUTER, Color.parseColor("#22000000"), 0.4f))
                .setSeriesLabel(new SeriesLabel.Builder( por+" %%  " ).setFontSize(10f).setVisible(false).build())
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
        if(!obj.getMeta().equals("0")){
            txtMeta.setText("S/. "+obj.getMeta());
            txtPor.setText(por+"%");
            txtMontoFaltante.setText("S/. "+ (Math.round(v* 100.0) / 100.0)) ;
            arcView.addEvent(new DecoEvent.Builder(pATiempo).setIndex(seriesATiempo ).setDelay(750).build());
        }
        }catch (Exception es){

        }

    }
    /**************************************************************************************************************************/
    public  void setTextToolbar(String nombre){
        toolbar.setTitle(nombre);
    }


    public void cargarBusquedaProducto ( String nombre){
        SqliteProducto sql2 = new SqliteProducto();
        ArrayList<Producto>  lstProducto = sql2.BuscarProducto(getApplicationContext(),nombre+"" ,idTipoAcceso);

        if(lstProducto.size()>0){

            linearvacia.setVisibility(View.GONE);
            rc.setVisibility(View.VISIBLE);

            adapter2 = new CustomListProducto( this,lstProducto);
            adapter2.notifyDataSetChanged();

            /*crear controlador de animacion*/
            LayoutAnimationController controller = null;
            controller = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

            rc.setLayoutManager(new StaggeredGridLayoutManager(  1, StaggeredGridLayoutManager.VERTICAL));
            rc.setItemViewCacheSize(lstProducto.size());
            /*setear controlador de animacion*/
            rc.setLayoutAnimation(controller);
            /*setear adaptador con datos*/
            rc.setAdapter(adapter2);
            /*setear manejador de animacion*/
            rc.scheduleLayoutAnimation();
            dialog.dismiss();
        }else{
            linearvacia.setVisibility(View.VISIBLE);
            rc.setVisibility(View.GONE);
        }
    }


    public void scaleView(View view, float x, float y) {
        view.animate()
                .setDuration(300)
                .alpha(1)
                .scaleX(x)
                .scaleY(y)
                .start();
    }

    public void extender(Integer s,boolean expandir){

       // if(expandir && appb.getHeight()!=(s*3 + (s/2))){
            //appb.setLayoutParams(new AppBarLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT,i ));
   //         expand(appb,500,s*3+(s/2) );
           // scaleView(fabb,1.0f,1.0f);
           // scaleView(fabbb,0.0f,0.0f);
   //     }else{
     //       collapse(appb,500,s );
           // scaleView(fabb,0.0f,0.0f);
            //scaleView(fabbb,1.0f,1.0f);
            // appb.setLayoutParams(new AppBarLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT,toolbar.getHeight()+(toolbar.getHeight()/2)-(toolbar.getHeight()/10) ));
       // }
    }

    private int getHeightOfView(View contentview) {
        contentview.measure(View.MeasureSpec.UNSPECIFIED, View.MeasureSpec.UNSPECIFIED);
        //contentview.getMeasuredWidth();
        return contentview.getMeasuredHeight();
    }

    public static void expand(final View v, int duration, int targetHeight) {

        int prevHeight  = v.getHeight();

        v.setVisibility(View.VISIBLE);
        ValueAnimator valueAnimator = ValueAnimator.ofInt(prevHeight, targetHeight);
        valueAnimator.addUpdateListener(new ValueAnimator.AnimatorUpdateListener() {
            @Override
            public void onAnimationUpdate(ValueAnimator animation) {
                v.getLayoutParams().height = (int) animation.getAnimatedValue();
                v.requestLayout();
            }
        });
        valueAnimator.setInterpolator(new DecelerateInterpolator());
        valueAnimator.setDuration(duration);
        valueAnimator.start();
    }

    public static void collapse(final View v, int duration, int targetHeight) {
        int prevHeight  = v.getHeight();
        ValueAnimator valueAnimator = ValueAnimator.ofInt(prevHeight, targetHeight);
        valueAnimator.setInterpolator(new DecelerateInterpolator());
        valueAnimator.addUpdateListener(new ValueAnimator.AnimatorUpdateListener() {
            @Override
            public void onAnimationUpdate(ValueAnimator animation) {
                v.getLayoutParams().height = (int) animation.getAnimatedValue();
                v.requestLayout();
            }
        });
        valueAnimator.setInterpolator(new DecelerateInterpolator());
        valueAnimator.setDuration(duration);
        valueAnimator.start();
    }

    public void muestraCantidad(){
        SqliteCarrito sql2 = new SqliteCarrito();

        Integer i  = sql2.cantidadCarrito(getApplicationContext(),idUsuarioCliente,idUsuarioVenta);
        txtCantidadPedido.setText(i+"");


        if(i!=0){
            scaleView(txtCantidadPedido,1.0f,1.0f);
        }else{
            scaleView(txtCantidadPedido,0.0f,0.0f);
        }

    }
    private class modificaDatos extends AsyncTask<String,Void,Object> {
        ParametrosSalida obj;

        @Override
        protected Object doInBackground(String... strings) {

            obj = new WebService().modificaDatos(pref.getString("idUsuarioVenta", "0"),
                    vNombre ,vPaterno ,vMaterno ,vCelular ,vTelefono ,
                    vdni ,vruc ,vRazonSocial ,vDireccion ,vCorreo);
            return obj;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            dialog.dismiss();

        }
    }


    private class obtenDatos extends AsyncTask<String,Void,Object> {
        ParametrosSalida obj;
        @Override
        protected Object doInBackground(String... strings) {

            obj = new WebService().obtenDatos(pref.getString("idUsuarioVenta","0"));
            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);


        if(obj.getFlagIndicador()!=9 || obj.getFlagIndicador()==1) {
            dialog3.requestWindowFeature(Window.FEATURE_NO_TITLE);
            dialog3.setCancelable(false);
            dialog3.setContentView(R.layout.popup_confirma_datos);
            dialog3.getWindow().setBackgroundDrawable(new ColorDrawable(android.graphics.Color.TRANSPARENT));

            txtNombres = dialog3.findViewById(R.id.txtNombres);
            txtPaterno = dialog3.findViewById(R.id.txtPaterno);
            txtMaterno = dialog3.findViewById(R.id.txtMaterno);
            txtCelular = dialog3.findViewById(R.id.txtCelular);
            txtTelefono = dialog3.findViewById(R.id.txtTelefono);
            txtDni = dialog3.findViewById(R.id.txtDni);
            txtRuc = dialog3.findViewById(R.id.txtRuc);
            txtRazon = dialog3.findViewById(R.id.txtRazon);
            txtDireccion = dialog3.findViewById(R.id.txtDireccion);
            txtCorreo = dialog3.findViewById(R.id.txtCorreo);
            btnRegistro = dialog3.findViewById(R.id.btnRegistro);
            txtter= dialog3.findViewById(R.id.txtter);
            txtpol= dialog3.findViewById(R.id.txtpol);
            chkter= dialog3.findViewById(R.id.chkter);
            chkpol= dialog3.findViewById(R.id.chkpol);
            txtter.setPaintFlags(txtter.getPaintFlags() | Paint.UNDERLINE_TEXT_FLAG);
            txtpol.setPaintFlags(txtpol.getPaintFlags() | Paint.UNDERLINE_TEXT_FLAG);
            txtter.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    String url = "http://3.19.108.54/nestle/Terminos_y_condiciones.html  ";

                    Intent i = new Intent(Intent.ACTION_VIEW);
                    i.setData(Uri.parse(url));
                    startActivity(i);
                }
            });
            txtpol.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    String url = "http://3.19.108.54/nestle/politica_Xmarket.html";

                    Intent i = new Intent(Intent.ACTION_VIEW);
                    i.setData(Uri.parse(url));
                    startActivity(i);
                }
            });

            txtNombres.setText(obj.getParam1());
            txtPaterno.setText(obj.getParam2());
            txtMaterno.setText(obj.getParam3());
            txtCelular.setText(obj.getParam4());
            txtTelefono.setText(obj.getParam5());
            txtDni.setText(obj.getParam6());
            txtRuc.setText(obj.getParam7());
            txtRazon.setText(obj.getParam8());
            txtDireccion.setText(obj.getParam9());
            txtCorreo.setText(obj.getParam10());
            btnRegistro.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    msj.setText("Actualizando Datos");
                    dialog.show();

                    Integer paso =0;
                    if(txtNombres.getText().toString().trim().equals("")){
                        txtNombres.setError("Ingresa Nombres");
                        paso=1;
                    }else{
                        vNombre = txtNombres.getText().toString();
                    }
                    if(txtPaterno.getText().toString().trim().equals("")){
                        txtPaterno.setError("Ingresa Apellido");
                        paso=1;
                    }else{
                        vPaterno  = txtPaterno.getText().toString();
                    }
                    if(txtMaterno.getText().toString().trim().equals("")){
                        txtMaterno.setError("Ingresa Apellido");
                        paso=1;
                    }else{
                        vMaterno = txtMaterno.getText().toString();
                    }
                    if(txtCelular.getText().toString().trim().equals("")){
                        txtCelular.setError("Ingresa celular");
                        paso=1;
                    }else{
                        vCelular = txtCelular.getText().toString();
                    }
                    if(txtDni.getText().toString().trim().equals("")){
                        txtDni.setError("Ingresa Dni");
                        paso=1;
                    }else{
                        vdni=txtDni.getText().toString();
                    }
                    if(txtRuc.getText().toString().trim().equals("")){
                        txtRuc.setError("Ingresa Ruc");
                        paso=1;
                    }else{
                        vruc=txtRuc.getText().toString();
                    }
                    if(txtRazon.getText().toString().trim().equals("")){
                        txtRazon.setError("Ingresa Razon Social");
                        paso=1;
                    }else{
                        vRazonSocial=txtRazon.getText().toString();
                    }
                    if(txtDireccion.getText().toString().trim().equals("")){
                        txtDireccion.setError("Ingresa Direccion");
                        paso=1;
                    }else{
                        vDireccion=txtDireccion.getText().toString();
                    }
                    if(txtCorreo.getText().toString().trim().equals("")){
                        txtCorreo.setError("Ingresa Correo");
                        paso=1;
                    }else{
                        vCorreo=txtCorreo.getText().toString();
                    }

                    if(!chkpol.isChecked()){
                        paso=1;
                        chkpol.setError("*");
                    }else{
                        chkpol.setError(null);
                    }
                    if(!chkter.isChecked()){
                        paso=1;
                        chkter.setError("*");
                    }else{
                        chkter.setError(null);
                    }

                    if(paso==0){


                        ParametrosSalida obj = null;
                        try {
                            obj= (ParametrosSalida)  new modificaDatos().execute().get();
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        } catch (ExecutionException e) {
                            e.printStackTrace();
                        }


                        if(obj.getFlagIndicador()==0){
                            dialog3.dismiss();
                            Toast.makeText(getApplicationContext(),obj.getMsgValidacion().toString(),Toast.LENGTH_LONG).show();
                            SharedPreferences.Editor edit = pref.edit();
                            edit.putString("validaDatos","1");

                            if(pref.getString("idTipoAcceso","2").equals("2")){
                                edit.putString("nomCliente", vNombre+" "+vPaterno+" "+vMaterno);
                            }

                            edit.commit();

                        }else if(obj.getFlagIndicador()==1){
                            Toast.makeText(getApplicationContext(),obj.getMsgValidacion().toString(),Toast.LENGTH_LONG).show();
                        }else if(obj.getFlagIndicador()==9){
                            Toast.makeText(getApplicationContext(),"ERROR DE RED",Toast.LENGTH_LONG).show();
                        }

                    }else{
                        dialog.dismiss();
                    }
                }
            });

            dialog3.show();
            dialog.dismiss();
        }else{
            dialog.dismiss();
        }
        }
    }
    @Override
    protected void onResume() {
        super.onResume();

        if(!pref.getString("pedidoComp","0").equals("0")){
            txtCantPedComp.setVisibility(View.VISIBLE);
            txtCantPedComp.setText(pref.getString("pedidoComp","0"));
        }else{
            txtCantPedComp.setVisibility(View.INVISIBLE);
        }


        if(pref.getString("validaDatos","1").equals("0") && !dialog3.isShowing()){
            msj.setText("Validando Datos..");
            dialog.show();
            new obtenDatos().execute();
        }

        SqliteSugerido sql = new SqliteSugerido();

        String value = sql.buscarFlagSugerido(MainActivity.this,idUsuarioCliente,idUsuarioVenta);

        if(value.equals("2")){
            sql.insertarSugerido(MainActivity.this,idUsuarioCliente,idUsuarioVenta,"0");
        }else if ( value.equals("0")){
            fabSug.setVisibility(View.VISIBLE);
            scaleView(fabSug,1.0f,1.0f);

        }else if (value.equals("1")){
            fabSug.setVisibility(View.GONE);
        }else{
            sql.insertarSugerido(MainActivity.this,idUsuarioCliente,idUsuarioVenta,"0");
        }

        if(pref.getString("origen","0").equals("0")){
            fabSug.setVisibility(View.VISIBLE);
        }else{
            fabSug.setVisibility(View.GONE);
        }
        muestraCantidad();

    }


    private class ListarPromociones extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            arrayPromocion = new WebService().ListaPromociones(pref.getString("idUsuarioVenta",""));
            arrayCondicionBonificacion = new WebService().ListaCondicionesBonificacion(pref.getString("idUsuarioVenta",""));

            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            if(  arrayPromocion==null && arrayCondicionBonificacion == null){
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(MainActivity.this);

                builder.setTitle("Error en la red ") ;
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        new ListarPromociones().execute();

                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();


            }else{

                SqliteCondicion sqCondi = new SqliteCondicion();
                SqliteBonificacion sqBoni = new SqliteBonificacion();
                SqlitePromociones sql4 = new SqlitePromociones();


                sql4.eliminarPromocion(getApplicationContext());
                sqBoni.eliminarBonificaciones(getApplicationContext());
                sqCondi.eliminarCondiciones(getApplicationContext());

                for (int i = 0; i < arrayPromocion.size(); i++) {

                    sql4.insertarPromociones(getApplicationContext(),
                            arrayPromocion.get(i).getIdPromocion(),
                            arrayPromocion.get(i).getFlagHistorico(),
                            arrayPromocion.get(i).getIdCondicion(),
                            arrayPromocion.get(i).getIdTipoCondicion(),
                            arrayPromocion.get(i).getIdTipoPromocion(),
                            arrayPromocion.get(i).getIdTipoBonificacion(),
                            arrayPromocion.get(i).getMontoBonificacion(),
                            arrayPromocion.get(i).getIdTipoUsuario(),
                            arrayPromocion.get(i).getFlagPrimeraCompra());

                }

                for ( int x =0;x<arrayCondicionBonificacion.size();x++){
                    if(!arrayCondicionBonificacion.get(x).getIdPromocionCondicion().equals("")){
                        sqCondi.insertarCondiciones(getApplicationContext(),
                                arrayCondicionBonificacion.get(x).getIdPromocionCondicion(),
                                arrayCondicionBonificacion.get(x).getIdPromocion(),
                                arrayCondicionBonificacion.get(x).getIdProducto(),
                                arrayCondicionBonificacion.get(x).getIdCategoria(),
                                arrayCondicionBonificacion.get(x).getIdGrupo(),
                                arrayCondicionBonificacion.get(x).getCantidad(),
                                arrayCondicionBonificacion.get(x).getDescripcion() );

                    }else if (!arrayCondicionBonificacion.get(x).getIdPromocionBonificacion().equals("")){
                        sqBoni.insertarBonificacion(getApplicationContext(),
                                arrayCondicionBonificacion.get(x).getIdPromocionBonificacion(),
                                arrayCondicionBonificacion.get(x).getIdPromocion(),
                                arrayCondicionBonificacion.get(x).getIdProducto(),
                                arrayCondicionBonificacion.get(x).getIdGrupo(),
                                arrayCondicionBonificacion.get(x).getCantidad(),
                                arrayCondicionBonificacion.get(x).getStock() );
                    }
                }

            }
        }
    }

    private class ListarData extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            arrayCategoria = new WebService().ListaCategoria(pref.getString("idUsuarioCliente",""),idUsuarioVenta);
            arrayProducto = new WebService().ListaProducto(pref.getString("idUsuarioCliente",""),idUsuarioVenta);
            arrayPromocion = new WebService().ListaPromociones(pref.getString("idUsuarioVenta",""));
            arrayCondicionBonificacion = new WebService().ListaCondicionesBonificacion(pref.getString("idUsuarioVenta",""));
            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            if(arrayCategoria==null || arrayProducto == null || arrayPromocion==null || arrayCondicionBonificacion==null){
                dialog.dismiss();
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(MainActivity.this);

                builder.setTitle("Ocurrio un error de red") ;
                builder.setMessage("No se pudo  sincronizar los datos");
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        msj.setText("Obteniendo Datos..");
                        dialog.show();

                        new  ListarData().execute();

                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();
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
            SqliteCondicion sqCondi = new SqliteCondicion();
            SqliteBonificacion sqBoni = new SqliteBonificacion();

            SqlitePromociones sql4 = new SqlitePromociones();

            sql4.eliminarPromocion(getApplicationContext());


            for (int i = 0; i < arrayPromocion.size(); i++) {

                sql4.insertarPromociones(getApplicationContext(),
                        arrayPromocion.get(i).getIdPromocion(),
                        arrayPromocion.get(i).getFlagHistorico(),
                        arrayPromocion.get(i).getIdCondicion(),
                        arrayPromocion.get(i).getIdTipoCondicion(),
                        arrayPromocion.get(i).getIdTipoPromocion(),
                        arrayPromocion.get(i).getIdTipoBonificacion(),
                        arrayPromocion.get(i).getMontoBonificacion(),
                        arrayPromocion.get(i).getIdTipoUsuario(),
                        arrayPromocion.get(i).getFlagPrimeraCompra());

            }


            sqCondi.eliminarCondiciones(getApplicationContext());
            sqBoni.eliminarBonificaciones(getApplicationContext());
            for ( int x =0;x<arrayCondicionBonificacion.size();x++){
                if(!arrayCondicionBonificacion.get(x).getIdPromocionCondicion().equals("")){
                    sqCondi.insertarCondiciones(getApplicationContext(),
                            arrayCondicionBonificacion.get(x).getIdPromocionCondicion(),
                            arrayCondicionBonificacion.get(x).getIdPromocion(),
                            arrayCondicionBonificacion.get(x).getIdProducto(),
                            arrayCondicionBonificacion.get(x).getIdCategoria(),
                            arrayCondicionBonificacion.get(x).getIdGrupo(),
                            arrayCondicionBonificacion.get(x).getCantidad(),
                            arrayCondicionBonificacion.get(x).getDescripcion() );

                }else if (!arrayCondicionBonificacion.get(x).getIdPromocionBonificacion().equals("")){
                    sqBoni.insertarBonificacion(getApplicationContext(),
                            arrayCondicionBonificacion.get(x).getIdPromocionBonificacion(),
                            arrayCondicionBonificacion.get(x).getIdPromocion(),
                            arrayCondicionBonificacion.get(x).getIdProducto(),
                            arrayCondicionBonificacion.get(x).getIdGrupo(),
                            arrayCondicionBonificacion.get(x).getCantidad(),
                            arrayCondicionBonificacion.get(x).getStock() );
                }
            }

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
                        null,
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
                       null);

            }


            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);

            listarSoloCategorias();
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
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

    public void listarSoloCategorias( ){
        linearvacia.setVisibility(View.GONE);
        rc.setVisibility(View.VISIBLE);

        SqliteCategoria sql = new SqliteCategoria();
        ArrayList<Categoria>  lstCategoria = sql.listarSoloCategoria(getApplicationContext(),idTipoAcceso );

        adapter = new CustomListCategoria( this,lstCategoria);
        adapter.notifyDataSetChanged();

        /*crear controlador de animacion*/
        LayoutAnimationController controller = null;
        controller = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

        rc.setLayoutManager(new StaggeredGridLayoutManager(  2, StaggeredGridLayoutManager.VERTICAL));
        rc.setItemViewCacheSize(lstCategoria.size());
        /*setear controlador de animacion*/
        rc.setLayoutAnimation(controller);
        /*setear adaptador con datos*/
        rc.setAdapter(adapter);
        /*setear manejador de animacion*/
        rc.scheduleLayoutAnimation();

        setTextToolbar("Categorias");
        toolbar.setSubtitle(pref.getString("nomCliente",""));

        if(dialog!=null){
            dialog.dismiss();
        }

    }
    public void listSubCatXId(String idUp){

        SqliteCategoria sql = new SqliteCategoria();
        ArrayList<Categoria>  lstCategoria = sql.listSubCatXId(getApplicationContext(),idUp ,idTipoAcceso);

        if(lstCategoria.size()>0){
            linearvacia.setVisibility(View.GONE);
            rc.setVisibility(View.VISIBLE);

            adapter = new CustomListCategoria( this,lstCategoria);
            adapter.notifyDataSetChanged();

            /*crear controlador de animacion*/
            LayoutAnimationController controller = null;
            controller = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

            rc.setLayoutManager(new StaggeredGridLayoutManager(  2, StaggeredGridLayoutManager.VERTICAL));
            rc.setItemViewCacheSize(lstCategoria.size());
            /*setear controlador de animacion*/
            rc.setLayoutAnimation(controller);
            /*setear adaptador con datos*/
            rc.setAdapter(adapter);
            /*setear manejador de animacion*/
            rc.scheduleLayoutAnimation();
            dialog.dismiss();
        }else  {
            SqliteProducto sql2 = new SqliteProducto();
            ArrayList<Producto>  lstProducto = sql2.listarProductosXIdCat(getApplicationContext(),idUp,idTipoAcceso);

            if(lstProducto.size()>0){

                linearvacia.setVisibility(View.GONE);
                rc.setVisibility(View.VISIBLE);

                adapter2 = new CustomListProducto( this,lstProducto);
                adapter2.notifyDataSetChanged();

                /*crear controlador de animacion*/
                LayoutAnimationController controller = null;
                controller = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

                rc.setLayoutManager(new StaggeredGridLayoutManager(  1, StaggeredGridLayoutManager.VERTICAL));
                rc.setItemViewCacheSize(lstProducto.size());
                /*setear controlador de animacion*/
                 rc.setLayoutAnimation(controller);
                /*setear adaptador con datos*/
                rc.setAdapter(adapter2);
                /*setear manejador de animacion*/
                rc.scheduleLayoutAnimation();

                dialog.dismiss();

            }else{
                linearvacia.setVisibility(View.VISIBLE);
                rc.setVisibility(View.GONE);
            }
        }
    }

    public static void setWindowFlag(Activity activity, final int bits, boolean on) {
        Window win = activity.getWindow();
        WindowManager.LayoutParams winParams = win.getAttributes();
        if (on) {
            winParams.flags |= bits;
        } else {
            winParams.flags &= ~bits;
        }
        win.setAttributes(winParams);
    }
    @Override
    public void onBackPressed() {
        DrawerLayout drawer = findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
           // super.onBackPressed();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
       /* MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.activity_main_drawer, menu);

        MenuItem item = menu.findItem(R.id.nav_sincronizar);
        item.setVisible(false);
*/





        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();

        return super.onOptionsItemSelected(item);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        if (id == R.id.nav_menores) {
            Intent i = new Intent(MainActivity.this, ReporteSugeridoMenorActivity.class);
            startActivity(i);
        } else if (id == R.id.nav_clientes) {
            Intent i = new Intent(MainActivity.this, ListaClienteActivity.class);
            i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(i);
        } else if (id == R.id.nav_cart) {
            if (!txtCantidadPedido.getText().equals("0")) {
                Intent i = new Intent(MainActivity.this, CartActivity.class);
                i.putExtra("origen", "0");
                i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                startActivity(i);
            } else {
                Toast.makeText(getApplicationContext(), "EL CARRITO ESTA VACIO", Toast.LENGTH_SHORT).show();
            }
        } else if (id == R.id.nav_nuevocliente) {
          //  Toast.makeText(MainActivity.this, "AGREGAR NUEVO CLIENTE", Toast.LENGTH_LONG).show();
            Intent i = new Intent(MainActivity.this, RegistroUserActivity.class);
            i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(i);
        }
        else if (id == R.id.nav_inicio) {
            Intent i = new Intent(MainActivity.this, MainVendedor.class);
            i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(i);
        }else if (id == R.id.nav_pedidos) {

            Intent i = new Intent(MainActivity.this, ListaPedidosActivity.class);
            i.putExtra("reporte", "2");
            startActivity(i);
        } else if (id == R.id.nav_ventas) {

            Intent i = new Intent(MainActivity.this, ListaPedidosActivity.class);
            i.putExtra("reporte", "1");
            startActivity(i);

        } else if (id == R.id.nav_sincronizar) {
            msj.setText("SINCRONIZANDO DATOS...");
            dialog.show();

            new ListarPromociones().execute();
            new ListarData().execute();
        }else if (id==R.id.nav_avance){
            Intent i = new Intent(MainActivity.this,AvanceDiarioActivity.class);
            startActivity(i);

        }else if (id==R.id.nav_meta) {

            Intent i = new Intent(MainActivity.this, MetaMensualActivity.class);
            i.putExtra("reporte","1");
            startActivity(i);

        }else if (id==R.id.nav_meta_cliente) {
            Intent i = new Intent(MainActivity.this, MetaMensualActivity.class);
            i.putExtra("reporte", "2");
            startActivity(i);
        }else if ( id==R.id.nav_promos) {
            Intent i = new Intent(MainActivity.this, ListaPromocionesActivity.class);
            startActivity(i);
        }else if (id==R.id.nav_soporte){
            Intent i = new Intent(MainActivity.this, ContactoActivity.class);
            startActivity(i);

        } else if (id == R.id.nav_cerrar) {

            SqlitePromocionVista sql = new SqlitePromocionVista();
             sql.eliminarvistos(MainActivity.this);
            android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(MainActivity.this);
            builder.setMessage("¿Desea Cerrar Sesion?");
            builder.setTitle("Cerrar") ;
            builder.setPositiveButton("Si", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialogInterface, int i) {

                    msj.setText("CERRANDO SESION..");
                    dialog.show();
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
        DrawerLayout drawer = findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }


    public void InsertaAlCarrito(Carrito objj){

        Integer existeEnCarrito = sqlcarrito.existeProductoXIdProducto(MainActivity.this,pref.getString("idUsuarioCliente", ""),
                pref.getString("idUsuarioVenta", ""),objj.getIdProductoTxt());

        if(existeEnCarrito==1){
            //actualizar

            ActualizaProductoCarrito(pref.getString("idUsuarioCliente", "")+"",
                    pref.getString("idUsuarioVenta", ""),objj.getIdProductoTxt()
                    ,Integer.parseInt(objj.getCant()));

            Toast.makeText(MainActivity.this, "Agregado correctamente", Toast.LENGTH_LONG).show();
        }else{
            //insertar

            Carrito obj = new Carrito(1,
                    pref.getString("idUsuarioCliente", "")+"", pref.getString("idUsuarioVenta", ""),
                    objj.getIdProductoTxt() + "", objj.getIdCategoria() + "",
                    objj.getIdCategoriaPadre() + "", objj.getIdFabricante() + "",
                    objj.getNombrePro() + "", objj.getDescripcion() + "",
                    objj.getPrecio() + "", objj.getPeso() + "",
                    objj.getImagen() + "", objj.getIdAlmacen() + "",
                    objj.getStock() + "",objj.getCant()+"",
                    objj.getImg(), "", "", "", "","0","0");
            InsertaProductoCarrito(obj);

            Toast.makeText(MainActivity.this, "Agregado correctamente", Toast.LENGTH_LONG).show();
        }
    }



    public void InsertaProductoCarrito(Carrito obj){

        sqlcarrito.insertarCarrito(MainActivity.this,
                obj.getIdCliente(),
                obj.getIdVendedor(),
                obj.getIdProductoTxt() + "",
                obj.getIdCategoria() + "",
                obj.getIdCategoriaPadre() + "",
                obj.getIdFabricante() + "",
                obj.getNombrePro() + "",
                obj.getDescripcion() + "",
                obj.getPrecio() + "",
                obj.getPeso() + "",
                obj.getImagen() + "",
                obj.getIdAlmacen() + "",
                obj.getStock() + "",
                obj.getCant(),
                obj.getImg(),
                "",
                "",
                "",
                "",
                "0","0");
        muestraCantidad();
    }

    public void ActualizaProductoCarrito(String IdCliente,String IdVendedor,String IdProductoTxt,Integer Cant){
        Integer i = sqlcarrito.cantidadProductoEnCarritoXIdProducto(MainActivity.this,IdCliente,IdVendedor,IdProductoTxt);
        sqlcarrito.actualizaCarrito(MainActivity.this,IdCliente,IdVendedor,IdProductoTxt,(Cant+i)+"");
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

            dialog.dismiss();
            if (objparametros.getFlagIndicador()==0) {
                SharedPreferences.Editor editor = pref.edit();
                editor.putString("sesion", "");
                editor.putString("idTipoUsuario", "");
                editor.putString("idUsuarioCliente", "");
                editor.putString("nomCliente", "");
                editor.putString("idUsuarioVenta", "");
                editor.commit();

                Intent is = new Intent(MainActivity.this,LoginActivity.class);
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

}
