package com.delcorp.apptiendadelcorp.activity;

import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.StaggeredGridLayoutManager;
import android.view.View;
import android.view.Window;
import android.view.animation.AnimationUtils;
import android.view.animation.LayoutAnimationController;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Categoria;
import com.delcorp.apptiendadelcorp.bean.Condicion;
import com.delcorp.apptiendadelcorp.bean.CondicionBonificacion;
import com.delcorp.apptiendadelcorp.bean.Producto;
import com.delcorp.apptiendadelcorp.bean.Promocion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteBonificacion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCategoria;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCliente;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCondicion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteProducto;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePromociones;
import com.delcorp.apptiendadelcorp.webservice.WebService;

import java.util.ArrayList;

public class ListaPromocionesActivity extends AppCompatActivity {

    RecyclerView rcPromo ;
    CustomListadoPromo adapter;
    ImageView imgBack,imgSyn;
    ArrayList<Promocion> arrayPromocion;
    ArrayList<CondicionBonificacion> arrayCondicionBonificacion;
    SharedPreferences pref;
    String idUsuario;
    Dialog dialog;
    TextView msj;
    ArrayList<Categoria> arrayCategoria;
    ArrayList<Producto> arrayProducto;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_lista_promociones);
        pref =   getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;
        idUsuario = pref.getString("idUsuarioVenta","0");
        imgBack=findViewById(R.id.imgBack);
        rcPromo = findViewById(R.id.rcPromo);
        imgSyn=findViewById(R.id.imgSyn);
        imgSyn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                msj.setText("Obteniendo datos...");
                dialog.show();
                new ListarData().execute();
            }
        });


        imgBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });

        dialog = new Dialog(ListaPromocionesActivity.this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setCancelable(false);
        dialog.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
        dialog.setContentView(R.layout.dialog_procesando);

        msj = dialog.findViewById(R.id.txt);

        android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(ListaPromocionesActivity.this);
        builder.setMessage("Las Promociones pueden estar desactualizadas se recomienta actualizar.");
        builder.setTitle("¿Desea Refrescar las promociones ahora?") ;
        builder.setPositiveButton("Actualizar", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {

                msj.setText("Obteniendo datos...");
                dialog.show();
                new ListarData().execute();

            }
        });
        builder.setNegativeButton("Ahora no", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                dialogInterface.cancel();
                msj.setText("Obteniendo datos...");
                dialog.show();
                listarPromos();
            }
        });
        android.app.AlertDialog dialog=builder.create();
        dialog.show();

    }


    private class ListarData extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            arrayPromocion = new WebService().ListaPromociones(pref.getString("idUsuarioVenta",""));
            arrayCondicionBonificacion = new WebService().ListaCondicionesBonificacion(pref.getString("idUsuarioVenta",""));

            arrayCategoria = new WebService().ListaCategoria(pref.getString("idUsuarioCliente",""),pref.getString("idUsuarioVenta","0"));
            arrayProducto = new WebService().ListaProducto(pref.getString("idUsuarioCliente",""),pref.getString("idUsuarioVenta","0"));

            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            if( arrayPromocion==null || arrayCondicionBonificacion==null||arrayCategoria==null || arrayProducto == null){
                dialog.dismiss();
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(ListaPromocionesActivity.this);

                builder.setTitle("Ocurrio un error de red") ;
                builder.setMessage("No se pudo  sincronizar los datos");
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        dialog.show();
                        new ListarData().execute();

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
            SqliteProducto sql = new SqliteProducto();
              SqliteCategoria sql2 = new SqliteCategoria();
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

            listarPromos();
        }
    }

    public void listarPromos( ){
        //linearvacia.setVisibility(View.GONE);
        rcPromo.setVisibility(View.VISIBLE);

        SqliteCondicion sql = new SqliteCondicion();
        ArrayList<Condicion> lst  = sql.listaPromocionesDescripcion(getApplicationContext() );

        if(lst.size()==0){
            finish();
            Toast.makeText(getApplicationContext(),"NO SE ENCONTRARON PROMOCIONES",Toast.LENGTH_LONG).show();
        }

        adapter = new CustomListadoPromo( this,lst);
        adapter.notifyDataSetChanged();

        /*crear controlador de animacion*/
        LayoutAnimationController controller = null;
        controller = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

        rcPromo.setLayoutManager(new StaggeredGridLayoutManager(  1, StaggeredGridLayoutManager.VERTICAL));
        rcPromo.setItemViewCacheSize(lst.size());
        /*setear controlador de animacion*/
        rcPromo.setLayoutAnimation(controller);
        /*setear adaptador con datos*/
        rcPromo.setAdapter(adapter);
        /*setear manejador de animacion*/
        rcPromo.scheduleLayoutAnimation();
        //extender(i,true);


         dialog.dismiss();
    }

}
