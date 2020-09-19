package com.delcorp.apptiendadelcorp.activity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.ParametrosSalida;
import com.delcorp.apptiendadelcorp.bean.Pedido;
import com.delcorp.apptiendadelcorp.bean.PedidoDetalle;
import com.delcorp.apptiendadelcorp.bean.PedidoO;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePedido;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePedidoDetalle;
import com.delcorp.apptiendadelcorp.webservice.WebService;

import java.lang.reflect.GenericArrayType;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;

public class CustomListPedidos extends RecyclerView.Adapter<HolderPedidos> {


    private ListaPedidosActivity activity;
    ArrayList<PedidoO> pedidos;
    SharedPreferences pref;
    String idPedido,idUsuarioCliente,nomCliente,idUsuarioVenta,total,totalPro,latitud,longitud;
    ArrayList<PedidoDetalle>lstPedidoDetalle;

    public CustomListPedidos(ListaPedidosActivity activity, ArrayList<PedidoO> pedidos) {
        this.activity = activity;
        this.pedidos = pedidos;
    }

    @NonNull
    @Override
    public HolderPedidos onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.custom_list_pedido,parent,false);
        HolderPedidos holder = new HolderPedidos(v);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull HolderPedidos holder, final int p) {


        holder.txtCodigo.setText(pedidos.get(p).getIdUsuario());
        holder.txtCliente.setText(pedidos.get(p).getNomCliente());
        holder.txtCantidad.setText(pedidos.get(p).getCantidad());
        holder.txtTotal.setText("S/. "+pedidos.get(p).getTotalPagar());
        holder.txtFecha.setText(pedidos.get(p).getFecha());
        holder.txtIdPedido.setText(pedidos.get(p).getIdPedido());

        holder.btnVer.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent  i = new Intent(activity,DetalleListaPedidoActivity.class);
                i.putExtra("IdPedido",pedidos.get(p).getIdPedido()+"");
                i.putExtra("Cliente",pedidos.get(p).getNomCliente()+"");
                i.putExtra("Cantidad",pedidos.get(p).getCantidad()+"");
                i.putExtra("Total",pedidos.get(p).getTotalPagar()+"");
                i.putExtra("Fecha",pedidos.get(p).getFecha()+"");
                activity.startActivity(i);
            }
        });

       /* if(pedidos.get(p).getFlagSincronizado().equals("0")){
            holder.btnSincronizar.setVisibility(View.VISIBLE);
        }else{
            holder.btnSincronizar.setVisibility(View.GONE);
        }

        holder.btnVer.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Toast.makeText(activity,pedidos.get(p).getIdPedidoSql()+" "+ pedidos.get(p).getIdPedido(),Toast.LENGTH_LONG).show();
            }
        });

        holder.btnSincronizar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                SqlitePedidoDetalle sql = new SqlitePedidoDetalle();
                lstPedidoDetalle = sql.listarPedidoDetalle(activity,pedidos.get(p).getIdPedido());
                idUsuarioCliente = pedidos.get(p).getIdUsuario();
                nomCliente = pedidos.get(p).getNomUsuario();
                idUsuarioVenta = pedidos.get(p).getIdUsuarioVenta();
                totalPro = pedidos.get(p).getItems();
                total=pedidos.get(p).getTotalPagar();
                latitud= pedidos.get(p).getLatitud();
                longitud = pedidos.get(p).getLongitud();
                idPedido = pedidos.get(p).getIdPedido();
                new sincronizaPedido().execute();


            }
        });*/

    }

    @Override
    public int getItemCount() {
        return pedidos.size();
    }

  /*  private class sincronizaPedido extends AsyncTask<String,Void,Object> {

        ParametrosSalida objparametros;

        @Override
        protected Object doInBackground(String... strings) {

            Calendar cal = Calendar.getInstance();
            //Toast.makeText(getApplicationContext(),new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").format(cal.getTime()),Toast.LENGTH_SHORT).show();
            objparametros = new WebService().SincronizarPedido(activity,idPedido,idUsuarioCliente,nomCliente,"","1",idUsuarioVenta,total
                    ,totalPro,latitud,longitud,"0",new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").format(cal.getTime())+""
                    ,lstPedidoDetalle);
            return null;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);

            if (objparametros.getFlagIndicador()==0) {
                Toast.makeText(activity,   objparametros.getMsgValidacion() + "", Toast.LENGTH_SHORT).show();
                activity.actualiza();

            }   else if ( objparametros.getFlagIndicador()==1){
                Toast.makeText(activity,objparametros.getMsgValidacion() + "",Toast.LENGTH_SHORT).show();

            }else if ( objparametros.getFlagIndicador()==10){
                Toast.makeText(activity, "Ocurrio un error de RED , vuelva a intentarlo",Toast.LENGTH_SHORT).show();


            }
        }
    }*/
}
