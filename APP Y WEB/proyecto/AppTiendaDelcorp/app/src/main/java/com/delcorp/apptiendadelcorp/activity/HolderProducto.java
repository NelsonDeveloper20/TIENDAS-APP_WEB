package com.delcorp.apptiendadelcorp.activity;

import android.support.v7.widget.CardView;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;

public class HolderProducto extends RecyclerView.ViewHolder {

    TextView txtPrecio,txtNombre,txtCant,txtStock,txtCodigo,txtCategoria;
    ImageView btnMas,btnMenos;
    ImageView imagen;
    CardView btnAgregar;

    public HolderProducto(View itemView) {
        super(itemView);

        txtPrecio = itemView.findViewById(R.id.txtPrecio);
        txtNombre = itemView.findViewById(R.id.txtNombre);
        txtCant = itemView.findViewById(R.id.txtCant);
        btnMas = itemView.findViewById(R.id.btnMas);
        btnMenos = itemView.findViewById(R.id.btnMenos);
        imagen = itemView.findViewById(R.id.imagen);
        btnAgregar = itemView.findViewById(R.id.btnAgregar);
        txtStock = itemView.findViewById(R.id.txtStock);
        txtCodigo = itemView.findViewById(R.id.txtCodigo);
        txtCategoria = itemView.findViewById(R.id.txtCategoria);
    }
}
