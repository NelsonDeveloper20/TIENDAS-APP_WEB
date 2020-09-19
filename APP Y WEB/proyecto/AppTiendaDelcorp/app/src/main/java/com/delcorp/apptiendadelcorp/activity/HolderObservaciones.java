package com.delcorp.apptiendadelcorp.activity;

import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;

public class HolderObservaciones extends RecyclerView.ViewHolder {

    TextView txtCantidad,txtNomb ;
    ImageView img;
    LinearLayout linearMod;

    public HolderObservaciones(View itemView) {
        super(itemView);

        txtCantidad= itemView.findViewById(R.id.txtCantidad);
        img=itemView.findViewById(R.id.img);
        txtNomb= itemView.findViewById(R.id.txtNomb);
        linearMod=itemView.findViewById(R.id.linearMod);
    }
}
