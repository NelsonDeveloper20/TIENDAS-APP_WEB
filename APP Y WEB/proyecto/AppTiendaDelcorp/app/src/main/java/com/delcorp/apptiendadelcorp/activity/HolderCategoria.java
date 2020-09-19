package com.delcorp.apptiendadelcorp.activity;

import android.support.v7.widget.CardView;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;

public class HolderCategoria extends RecyclerView.ViewHolder {


    TextView txtNombre;
    ImageView img;
    CardView card;
    public HolderCategoria(View itemView) {
        super(itemView);
        txtNombre = itemView.findViewById(R.id.txtNombre);
        img = itemView.findViewById(R.id.img);
        card = itemView.findViewById(R.id.card);
    }
}
