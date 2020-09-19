package com.delcorp.apptiendadelcorp.activity;

import android.support.v7.widget.CardView;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;

public class HolderPromos extends RecyclerView.ViewHolder {


      TextView txtDescripcion;
      CardView btnOk,cardtodo;

    public HolderPromos(View itemView) {
        super(itemView);

        txtDescripcion = itemView.findViewById(R.id.txtDescripcion);
        btnOk = itemView.findViewById(R.id.btnOk);
        cardtodo = itemView.findViewById(R.id.cardtodo);
    }


}
