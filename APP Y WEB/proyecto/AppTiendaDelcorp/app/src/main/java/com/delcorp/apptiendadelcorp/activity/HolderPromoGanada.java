package com.delcorp.apptiendadelcorp.activity;

import android.support.v7.widget.CardView;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;

public class HolderPromoGanada  extends RecyclerView.ViewHolder {
    TextView txtDescripcion;
    CardView cardtodo;

    public HolderPromoGanada(View itemView) {
        super(itemView);

        txtDescripcion = itemView.findViewById(R.id.txtDescripcion);
        cardtodo = itemView.findViewById(R.id.cardtodo);
    }

}
