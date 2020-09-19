package com.delcorp.apptiendadelcorp.activity;

import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Bonificacion;
import com.delcorp.apptiendadelcorp.bean.CondicionBonificacion;
import com.delcorp.apptiendadelcorp.bean.Producto;
import com.delcorp.apptiendadelcorp.sqlite.SqliteProducto;

import java.util.ArrayList;

public class CustomListDetalleBonis extends RecyclerView.Adapter<HolderDetalleBonis> {

    private ListaPromocionesActivity activity;
    ArrayList<Bonificacion> condiBonis;

    public CustomListDetalleBonis(ListaPromocionesActivity activity, ArrayList< Bonificacion> condiBonis) {
        this.activity = activity;
        this.condiBonis = condiBonis;
    }

    @NonNull
    @Override
    public HolderDetalleBonis onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_stock_promos,parent,false);
        HolderDetalleBonis holder = new HolderDetalleBonis(v);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull HolderDetalleBonis holder, int position) {
        SqliteProducto sq = new SqliteProducto();

        Producto s = sq.BuscarProductoxid(activity,condiBonis.get(position).getIdProducto() );


        if(s!=null) {
            holder.txtNombres.setText(s.getNombrePro()+ "");
            holder.txtStocks.setText("Stock : " + condiBonis.get(position).getStock());
        }else{
            holder.txtNombres.setText(  "PROMOCION AGOTADA");
            holder.txtStocks.setText("Stock : 0" );
        }
    }

    @Override
    public int getItemCount() {
        return condiBonis.size();
    }
}
