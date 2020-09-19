package com.delcorp.apptiendadelcorp.activity;

import android.support.v7.widget.CardView;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;

public class HolderPedidos extends RecyclerView.ViewHolder {

    CardView btnVer,btnSincronizar;
    TextView txtCodigo,txtCliente,txtCantidad,txtTotal,txtFecha,txtIdPedido,txtIdPedidoSql;

    public HolderPedidos(View itemView) {
        super(itemView);

        btnVer = itemView.findViewById(R.id.btnVer);
        btnSincronizar = itemView.findViewById(R.id.btnSincronizar);

        txtIdPedido = itemView.findViewById(R.id.txtIdPedido);
        txtIdPedidoSql=itemView.findViewById(R.id.txtIdPedidoSql);
        txtCodigo = itemView.findViewById(R.id.txtCodigo);
        txtCliente = itemView.findViewById(R.id.txtCliente);
        txtCantidad = itemView.findViewById(R.id.txtCantidad);
        txtTotal = itemView.findViewById(R.id.txtTotal);
        txtFecha = itemView.findViewById(R.id.txtFecha);
    }


}
