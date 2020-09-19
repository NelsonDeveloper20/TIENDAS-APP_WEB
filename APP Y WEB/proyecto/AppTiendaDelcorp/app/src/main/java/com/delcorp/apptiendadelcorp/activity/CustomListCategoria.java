package com.delcorp.apptiendadelcorp.activity;

import android.graphics.BitmapFactory;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Categoria;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;

public class CustomListCategoria extends RecyclerView.Adapter<HolderCategoria>
{
    private MainActivity activity;
    ArrayList<Categoria> Categoria;

    public CustomListCategoria(MainActivity activity, ArrayList<com.delcorp.apptiendadelcorp.bean.Categoria> categoria) {
        this.activity = activity;
        Categoria = categoria;
    }

    @NonNull
    @Override
    public HolderCategoria onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.custom_list_categoriaproducto,parent,false);
        HolderCategoria holder = new HolderCategoria(v);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull HolderCategoria holder, final int position) {
        holder.txtNombre.setText(Categoria.get(position).getNombre());

        if(!Categoria.get(position).getImagen().equals("")) {
          //  holder.img.setImageBitmap(BitmapFactory.decodeByteArray(Categoria.get(position).getImg(),0, Categoria.get(position).getImg().length));

            Picasso.get()
                    .load(Categoria.get(position).getImagen())
                    .error(R.drawable.noimagen)
                    .placeholder(R.drawable.noimagen)
                    .into(holder.img);
        }

        holder.card.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Toast.makeText(activity,Categoria.get(position).getIdCategoria()+" Nombre: "+Categoria.get(position).getNombre(),Toast.LENGTH_SHORT).show();

                activity.scaleView(activity.viewPager,0f,0f);
                activity.viewPager.setVisibility(View.GONE);

                activity.scaleView(activity.txtProducto,0f,0f);
                activity.txtProducto.setVisibility(View.GONE);

                activity.fabbb.setVisibility(View.VISIBLE);
                activity.scaleView(activity.fabbb,1f,1f);


                activity.listSubCatXId(Categoria.get(position).getIdCategoria()+"");

                activity.setTextToolbar(Categoria.get(position).getNombre());
                activity.fabbus.setImageDrawable(activity.getResources().getDrawable(R.drawable.ic_search_black_24dp));
            }
        });
    }

    @Override
    public int getItemCount() {
        return Categoria.size();
    }
}
