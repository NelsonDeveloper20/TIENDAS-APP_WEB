package com.delcorp.apptiendadelcorp.activity;

import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.PedidoDetalleLista;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;

public class CustomListPedidoDetalle extends RecyclerView.Adapter<HolderPedidoDetalle> {

    private DetalleListaPedidoActivity activity;
    ArrayList<PedidoDetalleLista> arr;

    public CustomListPedidoDetalle(DetalleListaPedidoActivity activity, ArrayList<PedidoDetalleLista> arr) {
        this.activity = activity;
        this.arr = arr;
    }

    @NonNull
    @Override
    public HolderPedidoDetalle onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.custom_lis_pedido_detalle,parent,false);
        HolderPedidoDetalle holder = new HolderPedidoDetalle(v);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull HolderPedidoDetalle h, int i) {

        if(!arr.get(i).getImagen().equals("")){
            Picasso.get()
                    .load(arr.get(i).getImagen())
                    .error(R.drawable.noimagen)
                    .placeholder(R.drawable.noimagen)
                    .into(h.imagen);
            h.linear.setVisibility(View.VISIBLE);
        }else{
            h.linear.setVisibility(View.GONE);
        }

        h.txtNombrePro.setText(arr.get(i).getNombrePro());
        h.txtCantidad.setText("Cantidad : "+arr.get(i).getCantidad());
        h.txtPrecio.setText("Precio : "+arr.get(i).getPrecio());
        h.txtSubtotal.setText("SubTotal : "+arr.get(i).getSubTotal());

    }

    @Override
    public int getItemCount() {
        return arr.size();
    }
}
