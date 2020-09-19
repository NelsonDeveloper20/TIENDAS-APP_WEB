package com.delcorp.apptiendadelcorp.activity;

import android.content.DialogInterface;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Carrito;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCarrito;
import com.delcorp.apptiendadelcorp.sqlite.SqliteProducto;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;

public class CustomListBoni  extends RecyclerView.Adapter<HolderBoni> {



    private CartActivity activity;
    ArrayList<Carrito> carrito;

    public CustomListBoni(CartActivity activity, ArrayList<Carrito> carrito) {
        this.activity = activity;
        this.carrito = carrito;
    }

    @NonNull
    @Override
    public HolderBoni onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.layout_boni,parent,false);
        HolderBoni holder = new HolderBoni(v);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull HolderBoni holder, final int position) {

        holder.txtNombre.setText(carrito.get(position).getNombrePro());
        if(carrito.get(position).getPrecio().equals("0")){
            holder.txtPrecio.setText("B O N I F I C A C I O N");
            holder.txtSubtotal.setVisibility(View.GONE);
            holder.btnBorrar.setVisibility(View.GONE);
        }else{
            holder.txtSubtotal.setVisibility(View.VISIBLE);
            holder.btnBorrar.setVisibility(View.VISIBLE);
            holder.txtPrecio.setText("Precio : S/. "+carrito.get(position).getPrecio());
        }

        SqliteProducto sqp = new SqliteProducto();
        String stock = sqp.obtenerStock(activity,carrito.get(position).getIdProductoTxt());

        if(stock.equals("0")) {
            holder.linearEquiz.setVisibility(View.VISIBLE);
        }else{
            holder.linearEquiz.setVisibility(View.GONE);
        }


        holder.txtCantidad.setText("Cant : "+carrito.get(position).getCant());

        Double precio = Double.parseDouble(carrito.get(position).getPrecio());
        final Integer cantidad = Integer.parseInt(carrito.get(position).getCant());

        holder.txtSubtotal.setText("Subtotal : S/. "+( Math.round(( precio*cantidad) * 100.0) / 100.0 +""));

        if(!carrito.get(position).getImagen().equals("")) {
            // holder.imagen.setImageBitmap(BitmapFactory.decodeByteArray(carrito.get(position).getImg(),0, carrito.get(position).getImg().length));
            Picasso.get()
                    .load(carrito.get(position).getImagen())
                    .error(R.drawable.noimagen)
                    .into(holder.imagen);
        }
        holder.btnEliminarBoni.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(activity);
                builder.setMessage("¿Elminar la bonificacion?");
                builder.setTitle("Eliminar") ;
                builder.setPositiveButton("Confirmar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        SqliteCarrito sq = new SqliteCarrito();
                        sq.eliminarCarritoxId(activity,carrito.get(position).getId()+"");
                         activity.listarCarrito2();


                    }
                });
                builder.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        dialogInterface.cancel();
                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();
            }
        });

        holder.btnBorrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(activity);
                builder.setMessage("¿Elminar el producto del carrito?");
                builder.setTitle("Eliminar") ;
                builder.setPositiveButton("Confirmar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        SqliteCarrito sq = new SqliteCarrito();
                        sq.eliminarCarritoxId(activity,carrito.get(position).getId()+"");
                        activity.listarCarrito2();

                    }
                });
                builder.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        dialogInterface.cancel();
                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();

            }
        });

    }

    @Override
    public int getItemCount() {
        return carrito.size();
    }
}
