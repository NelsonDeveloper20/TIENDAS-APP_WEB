package com.delcorp.apptiendadelcorp.activity;

import android.app.Dialog;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.DefaultItemAnimator;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.StaggeredGridLayoutManager;
import android.view.View;
import android.view.Window;
import android.view.animation.AnimationUtils;
import android.view.animation.LayoutAnimationController;
import android.widget.ImageView;
import android.widget.TextView;

import com.daimajia.androidanimations.library.fading_entrances.FadeInDownAnimator;
import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.PedidoDetalleLista;
import com.delcorp.apptiendadelcorp.bean.PedidoO;
import com.delcorp.apptiendadelcorp.webservice.WebService;

import java.util.ArrayList;

public class DetalleListaPedidoActivity extends AppCompatActivity {

    RecyclerView myrc;
    ImageView imgAtras;
    TextView txtCliente,txtPedido,txtCantidad,txtTotal,txtFecha;
    ArrayList<PedidoDetalleLista> arrPedidoDetalle;
    String IdPedido ="";
    CustomListPedidoDetalle adapter ;
    Dialog dialog;
    TextView msj ;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_detalle_lista_pedido);
        imgAtras=findViewById(R.id.imgAtras);
        myrc = findViewById(R.id.myrc);



        imgAtras.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });

        myrc = findViewById(R.id.myrc);
        txtPedido=findViewById(R.id.txtPedido);
        txtPedido.setText("DETALLE DEL PEDIDO : N°"+getIntent().getExtras().getString("IdPedido"));
        txtCliente=findViewById(R.id.txtCliente);
        txtCliente.setText(getIntent().getExtras().getString("Cliente"));
        txtCantidad=findViewById(R.id.txtCantidad);
        txtCantidad.setText("Cantidad productos : "+getIntent().getExtras().getString("Cantidad"));
        txtTotal= findViewById(R.id.txtTotal);
        txtTotal.setText("Monto Total : "+getIntent().getExtras().getString("Total"));
        txtFecha=findViewById(R.id.txtFecha);
        txtFecha.setText("Fecha del Pedido : "+getIntent().getExtras().getString("Fecha") );
        IdPedido = getIntent().getExtras().getString("IdPedido");

        RecyclerView.ItemAnimator itemAnimator = new DefaultItemAnimator();
        itemAnimator.setAddDuration(1000);
        itemAnimator.setRemoveDuration(1000);
        myrc.setItemAnimator(itemAnimator);
        dialog = new Dialog(DetalleListaPedidoActivity.this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setCancelable(false);
        dialog.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
        dialog.setContentView(R.layout.dialog_procesando);

        msj = dialog.findViewById(R.id.txt);
        msj.setText("Obteniendo Datos..");
        dialog.show();
        new ListarPedidosDetalle().execute();
    }



    private class ListarPedidosDetalle extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            arrPedidoDetalle = new WebService().ListaPedidoDetalle(IdPedido);
            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            if(  arrPedidoDetalle==null){
                dialog.dismiss();
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(DetalleListaPedidoActivity.this);

                builder.setTitle("Ocurrio un error de red") ;
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        new ListarPedidosDetalle().execute();

                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();
            }else{

                listarPedidos(arrPedidoDetalle);
            }



        }
    }
    public void listarPedidos( ArrayList<PedidoDetalleLista> lstPedidoDet){

        //SqlitePedido sql = new SqlitePedido();
        //ArrayList<Pedido> lstPedido = sql.listarPedidos(getApplicationContext(), cod);


        adapter = new CustomListPedidoDetalle( this,lstPedidoDet);
        adapter.notifyDataSetChanged();

        /*crear controlador de animacion*/
        LayoutAnimationController controller = null;
        controller = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

        myrc.setLayoutManager(new StaggeredGridLayoutManager(  1, StaggeredGridLayoutManager.VERTICAL));
        myrc.setItemViewCacheSize(lstPedidoDet.size());
        /*setear controlador de animacion*/
        myrc.setLayoutAnimation(controller);
        /*setear adaptador con datos*/
        myrc.setAdapter(adapter);
        /*setear manejador de animacion*/
        myrc.scheduleLayoutAnimation();
        //extender(i,true);
        dialog.dismiss();
    }

}
