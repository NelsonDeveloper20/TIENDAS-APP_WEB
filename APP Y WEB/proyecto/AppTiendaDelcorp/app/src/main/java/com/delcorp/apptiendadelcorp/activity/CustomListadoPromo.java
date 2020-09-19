package com.delcorp.apptiendadelcorp.activity;

import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.StaggeredGridLayoutManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.animation.AnimationUtils;
import android.view.animation.LayoutAnimationController;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Bonificacion;
import com.delcorp.apptiendadelcorp.bean.Condicion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteBonificacion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCondicion;

import java.util.ArrayList;

public class CustomListadoPromo extends RecyclerView.Adapter<HolderPromoListado> {

    private ListaPromocionesActivity activity;
    ArrayList<Condicion> promociones;
    CustomListDetalleBonis adapter;

    public CustomListadoPromo(ListaPromocionesActivity activity, ArrayList<Condicion> promociones) {
        this.activity = activity;
        this.promociones = promociones;
    }

    @NonNull
    @Override
    public HolderPromoListado onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.layout_listado_promo,parent,false);
        HolderPromoListado holder = new HolderPromoListado(v);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull HolderPromoListado holder, int position) {

        holder.txtPromo.setText(promociones.get(position).getDescripcion());



        SqliteBonificacion sq = new SqliteBonificacion();
        ArrayList<Bonificacion> lst  = sq.listaBonificacionXIdPromocionIdGrupo(activity,promociones.get(position).getIdPromocion()+"",
                                                                                        promociones.get(position).getIdGrupo()+"");

        Log.e("CANTIDAD ARRAY",lst.size()+" /"+promociones.get(position).getIdPromocion()+"/" +
                promociones.get(position).getIdGrupo()+"");

        if(lst!=null) {
            if(lst.size()==0){
                lst = new ArrayList<>();
                Bonificacion obj= new Bonificacion("0","0","0","0","0","0");
                lst.add(obj);
            }

        }else{
            lst = new ArrayList<>();
            Bonificacion obj= new Bonificacion("0","0","0","0","0","0");
            lst.add(obj);
        }


            adapter = new CustomListDetalleBonis(activity, lst);
            adapter.notifyDataSetChanged();


            holder.myrcc.setLayoutManager(new StaggeredGridLayoutManager(1, StaggeredGridLayoutManager.VERTICAL));
            holder.myrcc.setItemViewCacheSize(lst.size());
            holder.myrcc.setAdapter(adapter);


    }

    @Override
    public int getItemCount() {
        return promociones.size();
    }





}
