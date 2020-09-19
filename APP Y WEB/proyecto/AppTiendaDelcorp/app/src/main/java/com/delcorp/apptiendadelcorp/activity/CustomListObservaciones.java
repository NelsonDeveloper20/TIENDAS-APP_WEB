package com.delcorp.apptiendadelcorp.activity;

import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.PedidoDetalleRespuesta;
import com.delcorp.apptiendadelcorp.sqlite.SqliteBonificacion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCarrito;
import com.delcorp.apptiendadelcorp.sqlite.SqliteProducto;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;

public class CustomListObservaciones extends RecyclerView.Adapter<HolderObservaciones> {

    ArrayList<PedidoDetalleRespuesta> pedidos;
    CartActivity activity;

    public CustomListObservaciones(ArrayList<PedidoDetalleRespuesta> pedidos, CartActivity activity) {
        this.pedidos = pedidos;
        this.activity = activity;
    }

    @NonNull
    @Override
    public HolderObservaciones onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_pedidos_observaciones,parent,false);
        HolderObservaciones holder = new HolderObservaciones(v);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull HolderObservaciones holder, int position) {

        SqliteProducto sqp = new SqliteProducto();
        SqliteBonificacion sqb = new SqliteBonificacion();
        SqliteCarrito sqc  = new SqliteCarrito();

        if(Double.parseDouble(pedidos.get(position).getPrecio()) == 0){
          holder.linearMod.setVisibility(View.VISIBLE);
        }else{
            holder.linearMod.setVisibility(View.GONE);
        }


        sqp.actualizaStockProducto(activity,pedidos.get(position).getIdProductoTxt(),pedidos.get(position).getCantidad());
        sqc.actualizaStockCarrito(activity,pedidos.get(position).getIdProductoTxt(),pedidos.get(position).getCantidad());




        holder.txtCantidad.setText(pedidos.get(position).getCantidad() );
        holder.txtNomb.setText(pedidos.get(position).getNombrePro() );
        if(!pedidos.get(position).getImagen().equals("")) {
              Picasso.get()
                    .load(pedidos.get(position).getImagen() )
                    .error(R.drawable.noimagen)
                    .into(holder.img);
        }
    }

    @Override
    public int getItemCount() {
        return pedidos.size();
    }


}
