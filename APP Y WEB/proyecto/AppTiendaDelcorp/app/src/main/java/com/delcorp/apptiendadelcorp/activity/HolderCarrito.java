package com.delcorp.apptiendadelcorp.activity;

import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;

public class HolderCarrito extends RecyclerView.ViewHolder {

    TextView txtNombre,txtPrecio,txtCantidad,txtSubtotal,txtCant,txtStock,txtSugerido,txtDiferencia;
    ImageView btnBorrar,imagen,btnMenos,btnMas,btnEdit;

    public HolderCarrito(View itemView) {
        super(itemView);

        txtNombre = itemView.findViewById(R.id.txtNombre);
        txtPrecio = itemView.findViewById(R.id.txtPrecio);
        txtCantidad = itemView.findViewById(R.id.txtCantidad);
        txtSubtotal = itemView.findViewById(R.id.txtSubtotal);
        btnBorrar = itemView.findViewById(R.id.btnBorrar);
        imagen = itemView.findViewById(R.id.imagen);
        txtCant=itemView.findViewById(R.id.txtCant);
        btnMas=itemView.findViewById(R.id.btnMas);
        btnMenos=itemView.findViewById(R.id.btnMenos);
        txtStock=itemView.findViewById(R.id.txtStock);
        btnEdit=itemView.findViewById(R.id.btnEdit);
        txtSugerido=itemView.findViewById(R.id.txtSugerido);
        txtDiferencia=itemView.findViewById(R.id.txtDiferencia);
    }
}
