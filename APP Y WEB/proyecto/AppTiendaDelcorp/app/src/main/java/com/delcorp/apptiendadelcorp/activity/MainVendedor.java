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
import android.widget.Button;
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

public class MainVendedor extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {

    ArrayList<Categoria> arrayCategoria;
    ArrayList<Producto> arrayProducto;
    ArrayList<Promocion> arrayPromocion;
    ArrayList<CondicionBonificacion> arrayCondicionBonificacion;

    SqliteCarrito sqlcarrito = new SqliteCarrito();
    ArrayList<ProductoSugerido> arraProductoSugerido;
    String idUsuarioVenta,idUsuarioCliente ,CodigoTxt;

    CustomListCategoria adapter;
    CardView card;
    CustomListProducto adapter2;
    SharedPreferences pref;
    Dialog dialog;
    TextView msj,txtCantidadPedido;
    AppBarLayout appb;
    Toolbar toolbar;
    Integer i =0,j=0;
    LinearLayout viewOne,linearpromo;
    AutoScrollViewPager viewPager ;
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
    Button btnubicar;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_vendedor);

        dialog3 = new Dialog(MainVendedor.this);
        dialog2 = new Dialog(MainVendedor.this);
        dialog2.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog2.setCancelable(false);
        dialog2.setContentView(R.layout.activity_meta_mensual_dialog);
        dialog2.getWindow().setBackgroundDrawable(new ColorDrawable(android.graphics.Color.TRANSPARENT));

        FrameLayout mDialogNo = dialog2.findViewById(R.id.frmNo);
btnubicar=(Button)findViewById(R.id.btnVerUbicacion);
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
        viewOne = findViewById(R.id.viewOne);


        dialog = new  Dialog(MainVendedor.this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setCancelable(false);
        dialog.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
        dialog.setContentView(R.layout.dialog_procesando);

        msj = dialog.findViewById(R.id.txt);


        toolbar = findViewById(R.id.toolbarVendedor);
        toolbar.setBackgroundColor(Color.TRANSPARENT);
        toolbar.setTitle("Bienvenido");
        /*   setSupportActionBar(toolbar);
*/


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


        NavigationView navigationView = findViewById(R.id.nav_viewVendedor);
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





        idUsuarioVenta = pref.getString("idUsuarioVenta","0");
        idUsuarioCliente = pref.getString("idUsuarioCliente","0");

        if(i==0){
            i=getHeightOfView(appb) ;
        }
        if(j==0){

        }
        //  extender(i  ,true);


// 1 ES VENDEDOR
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
            nav_Menu.findItem(R.id.nav_inicio).setTitle("Inicio");
            nav_Menu.findItem(R.id.nav_inicio).setIcon(R.drawable.ic_home_black_24dp);
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
            nav_Menu.findItem(R.id.nav_inicio).setVisible(false);
        }



        Integer mostrar =0;
        try {
            mostrar = Integer.parseInt(getIntent().getExtras().getString("muestra","0"));
        }catch (Exception es){
            Log.e("el error es"," ERRROR: "+es.getMessage());
            es.printStackTrace();
        }finally {

        }

        btnubicar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent in = new Intent(MainVendedor.this,Location_Cliente.class);
                startActivity(in);
            }
        });

        //  token = pref.getString("token","NO DEFINIDO");

        String nelson_data="nm";
        //Toast.makeText(getApplicationContext(),"PASÓ :"+nelson_data,Toast.LENGTH_LONG).show();

    }
   private int getHeightOfView(View contentview) {
        contentview.measure(View.MeasureSpec.UNSPECIFIED, View.MeasureSpec.UNSPECIFIED);
        //contentview.getMeasuredWidth();
        return contentview.getMeasuredHeight();
    }


    public void muestraCantidad(){
        SqliteCarrito sql2 = new SqliteCarrito();

        Integer i  = sql2.cantidadCarrito(getApplicationContext(),idUsuarioCliente,idUsuarioVenta);




    }
    //region MODIFICAR DATOS
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
    //endregion


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
            //dialog.show();
           // new MainVendedor.obtenDatos().execute();
        }


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
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(MainVendedor.this);

                builder.setTitle("Error en la red ") ;
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        new MainVendedor.ListarPromociones().execute();

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
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(MainVendedor.this);

                builder.setTitle("Ocurrio un error de red") ;
                builder.setMessage("No se pudo  sincronizar los datos");
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        msj.setText("Obteniendo Datos..");
                        dialog.show();

                        new MainVendedor.ListarData().execute();

                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();
            }else{

                new MainVendedor.cargarData().execute();
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

            //listarSoloCategorias();
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
            Intent i = new Intent(MainVendedor.this, ReporteSugeridoMenorActivity.class);
            startActivity(i);
        } else if (id == R.id.nav_clientes) {
            Intent i = new Intent(MainVendedor.this, ListaClienteActivity.class);
            i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(i);
        }else if (id == R.id.nav_nuevocliente) {
            Toast.makeText(MainVendedor.this, "AGREGAR NUEVO CLIENTE", Toast.LENGTH_LONG).show();
             Intent i = new Intent(MainVendedor.this, RegistroUserActivity.class);
            i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(i);
        }
        else if (id == R.id.nav_inicio) {
             Intent i = new Intent(MainVendedor.this, MainVendedor.class);
            i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(i);
        }


        else if (id == R.id.nav_pedidos) {

            Intent i = new Intent(MainVendedor.this, ListaPedidosActivity.class);
            i.putExtra("reporte", "2");
            startActivity(i);
        } else if (id == R.id.nav_ventas) {

            Intent i = new Intent(MainVendedor.this, ListaPedidosActivity.class);
            i.putExtra("reporte", "1");
            startActivity(i);

        } else if (id == R.id.nav_sincronizar) {
            msj.setText("SINCRONIZANDO DATOS...");
            dialog.show();

            new MainVendedor.ListarPromociones().execute();
            new MainVendedor.ListarData().execute();
        }else if (id==R.id.nav_avance){
            Intent i = new Intent(MainVendedor.this,AvanceDiarioActivity.class);
            startActivity(i);

        }else if (id==R.id.nav_meta) {

            Intent i = new Intent(MainVendedor.this, MetaMensualActivity.class);
            i.putExtra("reporte","1");
            startActivity(i);

        }else if (id==R.id.nav_meta_cliente) {
            Intent i = new Intent(MainVendedor.this, MetaMensualActivity.class);
            i.putExtra("reporte", "2");
            startActivity(i);
        }else if ( id==R.id.nav_promos) {
            Intent i = new Intent(MainVendedor.this, ListaPromocionesActivity.class);
            startActivity(i);
        }else if (id==R.id.nav_soporte){
            Intent i = new Intent(MainVendedor.this, ContactoActivity.class);
            startActivity(i);

        } else if (id == R.id.nav_cerrar) {

            SqlitePromocionVista sql = new SqlitePromocionVista();
            sql.eliminarvistos(MainVendedor.this);
            android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(MainVendedor.this);
            builder.setMessage("¿Desea Cerrar Sesion?");
            builder.setTitle("Cerrar") ;
            builder.setPositiveButton("Si", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialogInterface, int i) {

                    msj.setText("CERRANDO SESION..");
                    dialog.show();
                    new MainVendedor.cerrarSesion().execute();

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

        Integer existeEnCarrito = sqlcarrito.existeProductoXIdProducto(MainVendedor.this,pref.getString("idUsuarioCliente", ""),
                pref.getString("idUsuarioVenta", ""),objj.getIdProductoTxt());

        if(existeEnCarrito==1){
            //actualizar

            ActualizaProductoCarrito(pref.getString("idUsuarioCliente", "")+"",
                    pref.getString("idUsuarioVenta", ""),objj.getIdProductoTxt()
                    ,Integer.parseInt(objj.getCant()));

            Toast.makeText(MainVendedor.this, "Agregado correctamente", Toast.LENGTH_LONG).show();
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

            Toast.makeText(MainVendedor.this, "Agregado correctamente", Toast.LENGTH_LONG).show();
        }
    }



    public void InsertaProductoCarrito(Carrito obj){

        sqlcarrito.insertarCarrito(MainVendedor.this,
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
        Integer i = sqlcarrito.cantidadProductoEnCarritoXIdProducto(MainVendedor.this,IdCliente,IdVendedor,IdProductoTxt);
        sqlcarrito.actualizaCarrito(MainVendedor.this,IdCliente,IdVendedor,IdProductoTxt,(Cant+i)+"");
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

                Intent is = new Intent(MainVendedor.this,LoginActivity.class);
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

