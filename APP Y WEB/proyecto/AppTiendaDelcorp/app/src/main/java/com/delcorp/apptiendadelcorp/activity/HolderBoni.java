package com.delcorp.apptiendadelcorp.activity;

import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;

public class HolderBoni extends RecyclerView.ViewHolder {

    TextView txtNombre, txtPrecio, txtCantidad, txtSubtotal;
    ImageView btnBorrar, imagen,btnEliminarBoni;
    LinearLayout linearEquiz;

    public HolderBoni(View itemView) {
        super(itemView);
        txtNombre = itemView.findViewById(R.id.txtNombre);
        txtPrecio = itemView.findViewById(R.id.txtPrecio);
        txtCantidad = itemView.findViewById(R.id.txtCantidad);
        txtSubtotal = itemView.findViewById(R.id.txtSubtotal);
        btnBorrar = itemView.findViewById(R.id.btnBorrar);
        imagen = itemView.findViewById(R.id.imagen);
        linearEquiz=itemView.findViewById(R.id.linearEquiz);
        btnEliminarBoni=itemView.findViewById(R.id.btnEliminarBoni);
    }


}
