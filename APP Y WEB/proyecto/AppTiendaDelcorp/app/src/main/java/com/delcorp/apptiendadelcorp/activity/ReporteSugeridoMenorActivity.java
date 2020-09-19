package com.delcorp.apptiendadelcorp.activity;

import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.SharedPreferences;
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
import android.widget.LinearLayout;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Cliente;
import com.delcorp.apptiendadelcorp.bean.PedidoComplementario;
import com.delcorp.apptiendadelcorp.webservice.WebService;

import java.util.ArrayList;

public class ReporteSugeridoMenorActivity extends AppCompatActivity {

    ImageView imgAtras;
    String idUsuario;
    ArrayList<PedidoComplementario> arrayPedido;
    SharedPreferences pref;
    Dialog progress;
    TextView txt;
    LinearLayout linVacio;
    RecyclerView rccc;
    CustomListPedidoComplementario adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reporte_sugerido_menor);
        linVacio=findViewById(R.id.linVacio);
        pref =   getSharedPreferences(getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;
        idUsuario = pref.getString("idUsuarioVenta","");
        imgAtras=findViewById(R.id.imgAtras);
        rccc = findViewById(R.id.rccc);
        imgAtras.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });
        progress = new Dialog(ReporteSugeridoMenorActivity.this);
        progress.requestWindowFeature(Window.FEATURE_NO_TITLE);
        progress.setCancelable(false);
        progress.getWindow().setBackgroundDrawableResource(android.R.color.transparent);
        progress.setContentView(R.layout.dialog_procesando);

        RecyclerView.ItemAnimator itemAnimator = new DefaultItemAnimator();
        itemAnimator.setAddDuration(1000);
        itemAnimator.setRemoveDuration(1000);
        rccc.setItemAnimator(itemAnimator);

        txt = progress.findViewById(R.id.txt);
        txt.setText("Obteniendo Informacion...");
        progress.show();

         new ListarPedidosComplementarios().execute();
    }


    private class ListarPedidosComplementarios extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            arrayPedido = new WebService().ListaPedidoComplementario(idUsuario );
            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            if(  arrayPedido==null){
                progress.dismiss();
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(ReporteSugeridoMenorActivity.this);

                builder.setTitle("Ocurrio un error de red") ;
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        new  ListarPedidosComplementarios().execute();

                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();
            }else{
                    if(arrayPedido.size()==0){
                        linVacio.setVisibility(View.VISIBLE);
                        rccc.setVisibility(View.GONE);
                        progress.dismiss();
                    }else {
                        linVacio.setVisibility(View.GONE);
                        rccc.setVisibility(View.VISIBLE);

                        adapter = new CustomListPedidoComplementario(ReporteSugeridoMenorActivity.this, arrayPedido);
                        adapter.notifyDataSetChanged();

                        /*crear controlador de animacion*/
                        LayoutAnimationController controller = null;
                        controller = AnimationUtils.loadLayoutAnimation(getApplicationContext(), R.anim.layout_slide_from_bottom);

                        rccc.setLayoutManager(new StaggeredGridLayoutManager(1, StaggeredGridLayoutManager.VERTICAL));
                        rccc.setItemViewCacheSize(arrayPedido.size());
                        /*setear controlador de animacion*/
                        rccc.setLayoutAnimation(controller);
                        /*setear adaptador con datos*/
                        rccc.setAdapter(adapter);
                        /*setear manejador de animacion*/
                        rccc.scheduleLayoutAnimation();
                        //extender(i,true);
                        progress.dismiss();
                    }

            }

        }
    }

}
