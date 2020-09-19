package com.delcorp.apptiendadelcorp.activity;

import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;

public class HolderCliente extends RecyclerView.ViewHolder {

    TextView txtNombre;
    ImageView imgBallon;

    public HolderCliente(View itemView) {
        super(itemView);
        txtNombre  = itemView.findViewById(R.id.txtNombre);
        imgBallon = itemView.findViewById(R.id.imgBallon);
    }
}
