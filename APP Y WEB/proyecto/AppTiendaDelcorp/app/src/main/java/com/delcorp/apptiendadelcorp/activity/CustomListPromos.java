package com.delcorp.apptiendadelcorp.activity;

import android.content.Context;
import android.content.SharedPreferences;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Carrito;
import com.delcorp.apptiendadelcorp.bean.Condicion;
import com.delcorp.apptiendadelcorp.bean.Producto;
import com.delcorp.apptiendadelcorp.bean.Promocion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCarrito;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCondicion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteHistorico;
import com.delcorp.apptiendadelcorp.sqlite.SqliteProducto;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePromociones;

import java.util.ArrayList;

@SuppressWarnings("UnusedAssignment")
public class CustomListPromos extends RecyclerView.Adapter<HolderPromos> {

    private CartActivity activity;
    ArrayList<Condicion> promociones;
    SharedPreferences pref ;
    String idTipoAcceso;
    SqliteCarrito sqCarrito = new SqliteCarrito();
    SqliteHistorico sqHistorico = new SqliteHistorico();
    SqlitePromociones sqPromo = new SqlitePromociones();
    SqliteCondicion sqCondi = new SqliteCondicion();
    SqliteProducto sqpro = new SqliteProducto();

    public CustomListPromos(CartActivity activity, ArrayList<Condicion> promociones) {
        this.activity = activity;
        this.promociones = promociones;
    }

    @NonNull
    @Override
    public HolderPromos onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_list_promos,parent,false);
        HolderPromos holder = new HolderPromos(v);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull final HolderPromos holder, final int position) {
        pref =   activity.getSharedPreferences(activity.getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;
        idTipoAcceso=pref.getString("idTipoAcceso","2");
        Promocion objPromo = sqPromo.PromocionxId(activity,promociones.get(position).getIdPromocion());


        if(objPromo.getIdCondicion().equals("1")   ){
            holder.btnOk.setVisibility(View.VISIBLE);
        }else {
            holder.btnOk.setVisibility(View.GONE);

        }
        if(objPromo.getIdTipoPromocion().equals("3")   ){
            holder.btnOk.setVisibility(View.GONE);
        }


        holder.btnOk.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                holder.cardtodo.setVisibility(View.GONE);

                ArrayList<Condicion> arrCondiciones = sqCondi.listaCondicionesXIdPromocionIdGrupo(activity,promociones.get(position).getIdPromocion(),
                                                                                                promociones.get(position).getIdGrupo());


                for (int i =0;i<arrCondiciones.size();i++) {

                    Integer ca = sqCarrito.cantidadProductoEnCarritoXIdProducto(activity,pref.getString("idUsuarioCliente", ""),
                            pref.getString("idUsuarioVenta", ""),arrCondiciones.get(i).getIdProducto());

                    Integer faltante=0;
                    if(ca<(Integer.parseInt(arrCondiciones.get(i).getCantidad()))) {
                          faltante = (Integer.parseInt(arrCondiciones.get(i).getCantidad()) - ca);
                    }

                    Log.d("FALTANTEEEE ","FALTANTEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE "+faltante + " / "+arrCondiciones.get(i).getCantidad()+ " / ca :"+ca);

                    if(faltante>0) {

                        ArrayList<Producto> p1 = sqpro.BuscarProducto(activity, arrCondiciones.get(i).getIdProducto(),idTipoAcceso);
                        Integer existeEnCarrito = sqCarrito.existeProductoXIdProducto(activity, pref.getString("idUsuarioCliente", ""),
                                pref.getString("idUsuarioVenta", ""), arrCondiciones.get(i).getIdProducto());


                        Log.d("ENTROOO ","PRODUCTO "+p1.get(0).getNombrePro());
                        if (existeEnCarrito == 1) {
                            //actualizar

                            ActualizaProductoCarrito(pref.getString("idUsuarioCliente", "") + "",
                                    pref.getString("idUsuarioVenta", ""), p1.get(0).getIdProductoTxt()
                                    , Integer.parseInt(faltante + ""));


                            Toast.makeText(activity, "Agregado correctamente", Toast.LENGTH_LONG).show();
                        } else {
                            //insertar

                            Carrito obj = new Carrito(1,
                                    pref.getString("idUsuarioCliente", "") + "", pref.getString("idUsuarioVenta", ""),
                                    p1.get(0).getIdProductoTxt() + "", p1.get(0).getIdCategoria() + "",
                                    p1.get(0).getIdCategoriaPadre() + "", p1.get(0).getIdFabricante() + "",
                                    p1.get(0).getNombrePro() + "", p1.get(0).getDescripcion() + "",
                                    p1.get(0).getPrecio() + "", p1.get(0).getPeso() + "",
                                    p1.get(0).getImagen() + "", p1.get(0).getIdAlmacen() + "",
                                    p1.get(0).getStock() + "", faltante + "",
                                    p1.get(0).getImg(), "", "", "", "","0","");
                            InsertaProductoCarrito(obj);

                            Toast.makeText(activity, "Agregado correctamente", Toast.LENGTH_LONG).show();
                        }




                    }
                }

                activity.calculaBonificaciones();
                activity.listarCarrito();

                Toast.makeText(activity, "AGREGADO AL CARRITO!", Toast.LENGTH_SHORT).show();
            }
        });



        double val=0;
        Integer uni =0;
        if(objPromo.getIdCondicion().equals("1")){ //unidad
            uni=Integer.parseInt(sqHistorico.UnidadesxProductoHistorico(activity,promociones.get(position).getIdProducto()));
            holder.txtDescripcion.setText(promociones.get(position).getDescripcion()+"\n"+" Maximo 2 bonificaciones por compra");

        }else if(objPromo.getIdCondicion().equals("2")){//moneda
            if(promociones.get(position).getIdCategoria().equals("")){//PRODUCO
                val=Double.parseDouble(sqHistorico.MontoxProductoHistorico(activity,promociones.get(position).getIdProducto()));
            }else if(promociones.get(position).getIdProducto().equals("")){//CATEGORIa
                val=Double.parseDouble(sqHistorico.MontoxCategoriaHistorico(activity,promociones.get(position).getIdCategoria()));
            }
            holder.txtDescripcion.setText(promociones.get(position).getDescripcion()+"\n"+" Maximo 2 bonificaciones por compra");

        }



    }

    @Override
    public int getItemCount() {
        return promociones.size();
    }


    public void ActualizaProductoCarrito(String IdCliente,String IdVendedor,String IdProductoTxt,Integer Cant){
        Integer i = sqCarrito.cantidadProductoEnCarritoXIdProducto(activity,IdCliente,IdVendedor,IdProductoTxt);
        sqCarrito.actualizaCarrito(activity,IdCliente,IdVendedor,IdProductoTxt,(Cant+i)+"");
    }
    public void InsertaProductoCarrito(Carrito obj){
        sqCarrito.insertarCarrito(activity,
                obj.getIdCliente(),
                obj.getIdVendedor(),
                obj.getIdProductoTxt() + "",
                obj.getIdCategoria() + "",
                obj.getIdCategoriaPadre() + "",
                obj.getIdFabricante() + "",
                obj.getNombrePro() + "",
                obj.getDescripcion() + "",
                obj.getPrecio() + "",
                obj.getPeso() + "",
                obj.getImagen() + "",
                obj.getIdAlmacen() + "",
                obj.getStock() + "",
                obj.getCant(),
                obj.getImg(),
                "",
                "",
                "",
                "",
                "0","0");
    }
}
