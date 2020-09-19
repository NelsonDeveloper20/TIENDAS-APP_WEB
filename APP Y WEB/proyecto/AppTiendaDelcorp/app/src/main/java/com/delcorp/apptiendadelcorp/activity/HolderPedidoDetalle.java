package com.delcorp.apptiendadelcorp.activity;

import android.media.Image;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;

public class HolderPedidoDetalle  extends RecyclerView.ViewHolder {

    TextView txtSubtotal,txtPrecio,txtCantidad,txtNombrePro;
    ImageView imagen;
    LinearLayout linear;

    public HolderPedidoDetalle(View itemView) {
        super(itemView);

        txtSubtotal = itemView.findViewById(R.id.txtSubtotal);
        txtPrecio = itemView.findViewById(R.id.txtPrecio);
        txtCantidad = itemView.findViewById(R.id.txtCantidad);
        txtNombrePro = itemView.findViewById(R.id.txtNombrePro);
        imagen = itemView.findViewById(R.id.imagen);
        linear = itemView.findViewById(R.id.linear);
    }


}
