package com.delcorp.apptiendadelcorp.activity;

import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.TextView;

import com.delcorp.apptiendadelcorp.R;

public class HolderPromoListado extends RecyclerView.ViewHolder {

    TextView txtPromo;
    RecyclerView myrcc;


    public HolderPromoListado(View itemView) {
        super(itemView);
        txtPromo = itemView.findViewById(R.id.txtPromo);
        myrcc = itemView.findViewById(R.id.myrcc);
    }
}
