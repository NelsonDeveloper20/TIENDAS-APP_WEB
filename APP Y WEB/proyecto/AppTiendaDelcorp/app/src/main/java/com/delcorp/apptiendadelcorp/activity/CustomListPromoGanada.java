package com.delcorp.apptiendadelcorp.activity;

import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Condicion;

import java.util.ArrayList;

public class CustomListPromoGanada extends RecyclerView.Adapter<HolderPromoGanada> {

    private CartActivity activity;
    ArrayList<Condicion> promociones;

    public CustomListPromoGanada(CartActivity activity, ArrayList<Condicion> promociones) {
        this.activity = activity;
        this.promociones = promociones;
    }

    @NonNull
    @Override
    public HolderPromoGanada onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_list_promo_ganada,parent,false);
        HolderPromoGanada holder = new HolderPromoGanada(v);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull HolderPromoGanada holder, int position) {

        holder.txtDescripcion.setText(promociones.get(position).getDescripcion());


    }

    @Override
    public int getItemCount() {
        return promociones.size();
    }
}
