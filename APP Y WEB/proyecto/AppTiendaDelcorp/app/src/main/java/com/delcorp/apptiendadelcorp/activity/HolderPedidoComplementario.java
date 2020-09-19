package com.delcorp.apptiendadelcorp.activity;

import android.support.v7.widget.CardView;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;

public class HolderPedidoComplementario extends RecyclerView.ViewHolder {

    CardView btnLlamar,btnCarrito;
    TextView txtMontoSugerido,txtNombreCliente,txtMontoComprado,txtDiferencia;


    public HolderPedidoComplementario(View itemView) {
        super(itemView);

        btnLlamar=itemView.findViewById(R.id.btnLlamar);
        btnCarrito = itemView.findViewById(R.id.btnCarrito);
        txtMontoSugerido = itemView.findViewById(R.id.txtMontoSugerido);
        txtNombreCliente = itemView.findViewById(R.id.txtNombreCliente);
        txtMontoComprado=itemView.findViewById(R.id.txtMontoComprado);
        txtDiferencia=itemView.findViewById(R.id.txtDiferencia);
    }



}
