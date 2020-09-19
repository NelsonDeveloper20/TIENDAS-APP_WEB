package com.delcorp.apptiendadelcorp.activity;

import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.BitmapFactory;
import android.graphics.drawable.ColorDrawable;
import android.support.annotation.NonNull;
import android.support.v7.widget.CardView;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.StaggeredGridLayoutManager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Carrito;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCarrito;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;

public class CustomListCarrito extends RecyclerView.Adapter<HolderCarrito> {

    private CartActivity activity;
    ArrayList<Carrito> carrito;
    Integer cant=0;
    Dialog dialog;
    TextView txtCant,txtCantidad,txtPrecio,txtSubtotal,txtStock,txtNombre;
    ImageView btnMas,btnMenos,imagen;
    SqliteCarrito sq = new SqliteCarrito();

    public CustomListCarrito(CartActivity activity, ArrayList<Carrito> carrito) {
        this.activity = activity;
        this.carrito = carrito;
    }

    @NonNull
    @Override
    public HolderCarrito onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.custom_list_carrito,parent,false);
        HolderCarrito holder = new HolderCarrito(v);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull final HolderCarrito holder, final int position) {

          cant=Integer.parseInt(carrito.get(position).getCant());
        holder.txtNombre.setText(carrito.get(position).getNombrePro());

        holder.txtPrecio.setText("Precio: S/ "+  String.format("%.2f", Double.parseDouble(carrito.get(position).getPrecio().replace(",","."))));

        holder.txtCant.setText(carrito.get(position).getCant());
        holder.txtCantidad.setText("Cant: "+carrito.get(position).getCant());


        holder.txtSugerido.setText("CantSug: "+carrito.get(position).getCantSuge());



        if( activity.origen.equals("0")){
            holder.txtSugerido.setVisibility(View.GONE);
            holder.txtDiferencia.setVisibility(View.GONE);
        }else{
            Integer suge , comp,dif;
            suge = Integer.parseInt(carrito.get(position).getCantSuge());
            comp = Integer.parseInt(carrito.get(position).getCant());
            holder.txtSugerido.setVisibility(View.VISIBLE);
            holder.txtDiferencia.setVisibility(View.VISIBLE);
            if(suge<=comp){
                holder.txtDiferencia.setText("Dif: 0");
            }else{
                holder.txtDiferencia.setText("Dif: " +(suge-comp));
            }
        }




        holder.btnEdit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                cant = Integer.parseInt(carrito.get(position).getCant());
                dialog = new Dialog(activity);
                dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
                dialog.setCancelable(true);
                dialog.setContentView(R.layout.popup_edita_item_cart);
                dialog.getWindow().setBackgroundDrawable(new ColorDrawable(android.graphics.Color.TRANSPARENT));

                CardView mOk = dialog.findViewById(R.id.frmyess);
                CardView mNo = dialog.findViewById(R.id.frmNo);

                txtCantidad=dialog.findViewById(R.id.txtCantidad);
                txtCant  = dialog.findViewById(R.id.txtCant);
                imagen = dialog.findViewById(R.id.imagen);
                txtNombre=dialog.findViewById(R.id.txtNombre);

                txtPrecio = dialog.findViewById(R.id.txtPrecio);
                txtSubtotal = dialog.findViewById(R.id.txtSubtotal);
                btnMas = dialog.findViewById(R.id.btnMas);
                btnMenos = dialog.findViewById(R.id.btnMenos);
                txtStock=dialog.findViewById(R.id.txtStock);

                txtNombre.setText(carrito.get(position).getNombrePro());
                txtNombre.setText(carrito.get(position).getNombrePro());
               txtStock.setText("Stock "+carrito.get(position).getStock());
                txtCantidad.setText("Cant : "+carrito.get(position).getCant());
                txtCant.setText(cant+"");
                txtPrecio.setText("Precio : "+carrito.get(position).getPrecio());
                txtStock.setText("Stock : "+carrito.get(position).getStock());

                if(!carrito.get(position).getImagen().equals("")) {
                     Picasso.get()
                            .load(carrito.get(position).getImagen())
                            .error(R.drawable.noimagen)
                            .into(imagen);
                }

                Double precio = Double.parseDouble(carrito.get(position).getPrecio().replace(",","."));
                final Integer cantidad = Integer.parseInt(carrito.get(position).getCant());



                 txtSubtotal.setText("Subtotal: S/ "+String.format("%.2f", Double.parseDouble((precio*cantidad)+"" )   ));

                btnMenos.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {

                        if(!carrito.get(position).getStock().equals("0")&& !carrito.get(position).getPrecio().equals("0")) {

                            if (cant > 0) {
                                cant = cant - 1;
                            }

                            txtCant.setText(cant+"");
                            txtCantidad.setText("Cant : "+cant);

                            Double p  = Double.parseDouble(carrito.get(position).getPrecio().replace(",","."));

                            txtSubtotal.setText("Subtotal : S/. "+( Math.round(( p *cant ) * 100.00) / 100.00 +""));
                        }
                    }
                });
                 btnMas.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {

                        if(!carrito.get(position).getStock().equals("0")&& !carrito.get(position).getPrecio().equals("0")) {
                            if(Integer.parseInt(carrito.get(position).getStock())> cant){
                                cant = cant + 1;

                                txtCantidad.setText("Cant : "+cant);
                                txtCant.setText(cant +"");
                                Double p  = Double.parseDouble(carrito.get(position).getPrecio().replace(",","."));

                                txtSubtotal.setText("Subtotal : S/. "+( Math.round(( p *cant ) * 100.00) / 100.00 +""));


                            }else{
                                Toast.makeText(activity,"Verifique el Stock",Toast.LENGTH_SHORT).show();
                            }

                        }
                    }
                });

                mOk.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {

                        if(cant>0) {
                            sq.actualizaCarritoxId(activity, carrito.get(position).getId() + "", cant + "");
                        }else{
                            sq.eliminarCarritoxId(activity,carrito.get(position).getId()+"");
                        }
                        activity.calculaBonificaciones();
                        activity.listarCarrito2();
                        dialog.dismiss();
                    }
                });
                mNo.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        dialog.dismiss();
                    }
                });
                dialog.show();
            }
        });



        Double precio = Double.parseDouble(carrito.get(position).getPrecio().replace(",","."));
        final Integer cantidad = Integer.parseInt(carrito.get(position).getCant());

        holder.txtSubtotal.setText("Subtotal : S/. "+( Math.round(( precio*cantidad) * 100.00) / 100.00 +""));

        if(!carrito.get(position).getImagen().equals("")) {
           // holder.imagen.setImageBitmap(BitmapFactory.decodeByteArray(carrito.get(position).getImg(),0, carrito.get(position).getImg().length));
            Picasso.get()
                    .load(carrito.get(position).getImagen())
                    .error(R.drawable.noimagen)
                    .into(holder.imagen);
        }

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
                        //activity.calculaBoniMontoxcantidadCatgoria();
                        activity.calculaBonificaciones();
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
