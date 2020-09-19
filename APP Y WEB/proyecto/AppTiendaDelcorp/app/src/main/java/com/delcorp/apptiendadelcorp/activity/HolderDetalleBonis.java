package com.delcorp.apptiendadelcorp.activity;

import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;

public class HolderDetalleBonis extends RecyclerView.ViewHolder {

    TextView txtNombres,txtStocks;
    public HolderDetalleBonis(View itemView) {
        super(itemView);
        txtNombres = itemView.findViewById(R.id.txtNombres);
        txtStocks = itemView.findViewById(R.id.txtStocks);
    }

}
