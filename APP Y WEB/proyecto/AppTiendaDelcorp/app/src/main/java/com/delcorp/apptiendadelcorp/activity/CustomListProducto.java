package com.delcorp.apptiendadelcorp.activity;

import android.app.Dialog;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.BitmapFactory;
import android.graphics.drawable.ColorDrawable;
import android.support.annotation.NonNull;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.CardView;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.FrameLayout;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Carrito;
import com.delcorp.apptiendadelcorp.bean.Categoria;
import com.delcorp.apptiendadelcorp.bean.Condicion;
import com.delcorp.apptiendadelcorp.bean.Producto;
import com.delcorp.apptiendadelcorp.bean.Promocion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCarrito;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCategoria;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCondicion;
import com.delcorp.apptiendadelcorp.sqlite.SqliteHistorico;
import com.delcorp.apptiendadelcorp.sqlite.SqliteProducto;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePromocionVista;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePromociones;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;

public class CustomListProducto extends RecyclerView.Adapter<HolderProducto> {


    private MainActivity activity;
    ArrayList<Producto> producto;
    String idTipoAcceso;
    SharedPreferences pref ;
    Dialog dialog2 ;
    TextView descripcion;
    SqliteCarrito sqlcarrito = new SqliteCarrito();
    SqliteHistorico sqHistorico = new SqliteHistorico();
    SqlitePromociones sqPromo = new SqlitePromociones();
    SqliteCondicion sqCondi = new SqliteCondicion();
    SqliteProducto sqProd = new SqliteProducto();

    public CustomListProducto(MainActivity activity, ArrayList<Producto> producto) {
        this.activity = activity;
        this.producto = producto;
    }

    @NonNull
    @Override
    public HolderProducto onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.custom_list_producto,parent,false);
        HolderProducto holder = new HolderProducto(v);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull final HolderProducto holder, final int position) {



        pref =   activity.getSharedPreferences(activity.getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;
        idTipoAcceso=pref.getString("idTipoAcceso","2");
        holder.txtNombre.setText(producto.get(position).NombrePro);



        holder.txtPrecio.setText("S/. "+ String.format("%.2f", Double.parseDouble(producto.get(position).getPrecio().replace(",","."))));


        holder.txtCodigo.setText(producto.get(position).getIdProductoTxt());

        if(producto.get(position).getIdCategoriaPadre().equals("0")){

            holder.txtCategoria.setVisibility(View.GONE);
        }else{
            holder.txtCategoria.setVisibility(View.VISIBLE);
            SqliteCategoria sq = new SqliteCategoria();
            ArrayList<Categoria> a = sq.listarCategoriaPadreXIdCategoria(activity,producto.get(position).getIdCategoriaPadre(),idTipoAcceso);
            if(a.size()>0){
                holder.txtCategoria.setText(a.get(0).getNombre());
            }else{
                holder.txtCategoria.setVisibility(View.GONE);
            }

        }

          if(!producto.get(position).getImagen().equals("")) {

              Picasso.get()
                      .load(producto.get(position).getImagen())
                      .error(R.drawable.noimagen)
                      .placeholder(R.drawable.noimagen)
                      .into(holder.imagen);
          }
        holder.btnMenos.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                activity.ocultarTeclado();
                if(!producto.get(position).getStock().equals("0")/*&& !producto.get(position).getPrecio().equals("0")*/) {

                    if ( Integer.parseInt(holder.txtCant.getText().toString()) > 0) {
                        holder.txtCant.setText((Integer.parseInt(holder.txtCant.getText().toString())-1)+""); //cant = cant - 1;
                    }

                    //holder.txtCant.setText(cant + "");
                }
            }
        });
        holder.btnMas.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                activity.ocultarTeclado();
                if(!producto.get(position).getStock().equals("0")/*&& !producto.get(position).getPrecio().equals("0")*/) {
                    if(Integer.parseInt(producto.get(position).getStock())!= Integer.parseInt(holder.txtCant.getText().toString())){
                        //cant = cant + 1;
                        //holder.txtCant.setText(cant + "");
                        holder.txtCant.setText((Integer.parseInt(holder.txtCant.getText().toString())+1)+"");

                    }else{
                        Toast.makeText(activity,"Verifique el Stock",Toast.LENGTH_SHORT).show();
                    }

                }
            }
        });
        holder.txtStock.setText("Stock "+producto.get(position).getStock());

        holder.btnAgregar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                activity.ocultarTeclado();

                if(!producto.get(position).getStock().equals("0")/* && !producto.get(position).getPrecio().equals("0")*/){

                if (!holder.txtCant.getText().equals("0")) {

                     final ArrayList<Condicion> arrCondi = sqCondi.listaCondicionesXIdProducto(activity,producto.get(position).getIdProductoTxt());



                    if(arrCondi.size()>0) {
                        Promocion objPromo = sqPromo.PromocionxId(activity,arrCondi.get(0).getIdPromocion());

                        final ArrayList<Condicion>arrCondiciones = sqCondi.listaCondicionesXIdPromocionIdGrupo(activity,arrCondi.get(0).getIdPromocion()
                                                                                                            ,arrCondi.get(0).getIdGrupo());
                        Integer evaluaPromo =1;
                        for(int i=0;i<arrCondiciones.size();i++){
                            Double uniHis = 0.0;
                            if(objPromo.getFlagHistorico().equals("1")){
                                uniHis = Double.parseDouble(sqHistorico.UnidadesxProductoHistorico(activity,arrCondiciones.get(i).getIdProducto()));
                                Log.e("uni historico",uniHis+"");
                            }
                            if(uniHis>Double.parseDouble(arrCondiciones.get(i).getCantidad())){
                                evaluaPromo=0;
                                Log.e("HIST  MAYOR A CONDICION","historico : "+uniHis+" - cantidadCondi"+arrCondiciones.get(i).getCantidad());
                                break;
                            }
                        }

                        if(objPromo.getIdCondicion().equals("1") && evaluaPromo==1){

                            Integer mostarPop = 0;
                            for (int i=0;i<arrCondiciones.size();i++){
                                Integer ca = sqlcarrito.UnixProdCarrito(activity, pref.getString("idUsuarioCliente", ""), pref.getString("idUsuarioVenta", "")
                                        , arrCondiciones.get(i).getIdProducto());

                                Integer cantAgregar = Integer.parseInt(holder.txtCant.getText().toString());

                                Integer valor = ca;
                                if(holder.txtCodigo.getText().toString().equals(arrCondiciones.get(i).getIdProducto())){
                                    valor = valor +cantAgregar;
                                    Log.e("EVALUA CODIGO2",holder.txtCodigo.getText()+ " / "+arrCondiciones.get(i).getIdProducto());
                                }

                                if(Integer.parseInt(arrCondiciones.get(i).getCantidad())>valor){

                                    mostarPop = 1;
                                }
                                if (Integer.parseInt(objPromo.getIdTipoPromocion())==3){
                                    mostarPop=0;
                                }
                            }

                            if(mostarPop==1){
                                //************************************************************************************************************************
                                dialog2 = new Dialog(activity);
                                dialog2.requestWindowFeature(Window.FEATURE_NO_TITLE);
                                dialog2.setCancelable(false);
                                dialog2.setContentView(R.layout.layout_popup_promo);
                                dialog2.getWindow().setBackgroundDrawable(new ColorDrawable(android.graphics.Color.TRANSPARENT));

                                CardView mDialogNo = dialog2.findViewById(R.id.frmNo);
                                CardView mDialogyes = dialog2.findViewById(R.id.frmyes);
                                descripcion = dialog2.findViewById(R.id.descripcion);

                                    descripcion.setText(arrCondiciones.get(0).getDescripcion() + "\n Maximo 2 promociones por compra");

                                CardView card = dialog2.findViewById(R.id.card);
                                ImageView img = dialog2.findViewById(R.id.img);

                                img.setVisibility(View.GONE);



                                mDialogNo.setOnClickListener(new View.OnClickListener() {
                                    @Override
                                    public void onClick(View view) {
                                        InsertaAlCarrito(new Carrito(1,
                                                pref.getString("idUsuarioCliente", "") + "", pref.getString("idUsuarioVenta", ""),
                                                producto.get(position).getIdProductoTxt() + "", producto.get(position).getIdCategoria() + "",
                                                producto.get(position).getIdCategoriaPadre() + "", producto.get(position).getIdFabricante() + "",
                                                producto.get(position).getNombrePro() + "", producto.get(position).getDescripcion() + "",
                                                producto.get(position).getPrecio() + "", producto.get(position).getPeso() + "",
                                                producto.get(position).getImagen() + "", producto.get(position).getIdAlmacen() + "",
                                                producto.get(position).getStock() + "", holder.txtCant.getText() + "",
                                                producto.get(position).getImg(), "", "", "", "","0","0"));

                                        holder.txtCant.setText("0");
                                       //cant=0;
                                        activity.txtProducto.setText("");
                                        dialog2.dismiss();
                                    }
                                });
                                mDialogyes.setOnClickListener(new View.OnClickListener() {
                                    @Override
                                    public void onClick(View view) {

                                        for (int i=0;i<arrCondiciones.size();i++){
                                            Integer ca = sqlcarrito.UnixProdCarrito(activity, pref.getString("idUsuarioCliente", ""), pref.getString("idUsuarioVenta", "")
                                                    , arrCondiciones.get(i).getIdProducto());

                                            Integer cantAgregar = Integer.parseInt(holder.txtCant.getText().toString());

                                            Integer valor = ca;
                                            if(holder.txtCodigo.getText().toString().equals(arrCondiciones.get(i).getIdProducto())){
                                                valor = valor +cantAgregar;

                                            }

                                            Producto obj = sqProd.BuscarProductoxid(activity,arrCondiciones.get(i).getIdProducto());

                                            if(Integer.parseInt(arrCondiciones.get(i).getCantidad())>valor) {
                                                Integer faltante = (Integer.parseInt(arrCondiciones.get(i).getCantidad()) );


                                                Log.e("ESTE_ESTE_ESTE","VALOR : "+valor +" /  condicion :"+arrCondiciones.get(i).getCantidad() +" //CA :"+ca);

                                                InsertaAlCarrito(new Carrito(1,
                                                        pref.getString("idUsuarioCliente", "") + "", pref.getString("idUsuarioVenta", ""),
                                                        obj.getIdProductoTxt() + "", obj.getIdCategoria() + "",
                                                        obj.getIdCategoriaPadre() + "", obj.getIdFabricante() + "",
                                                        obj.getNombrePro() + "", obj.getDescripcion() + "",
                                                        obj.getPrecio() + "", obj.getPeso() + "",
                                                        obj.getImagen() + "", obj.getIdAlmacen() + "",
                                                        obj.getStock() + "", faltante +  "",
                                                        obj.getImg(), "", "", "", "","0","0"));

                                            }else if(holder.txtCodigo.getText().toString().equals(arrCondiciones.get(i).getIdProducto())){
                                                InsertaAlCarrito(new Carrito(1,
                                                        pref.getString("idUsuarioCliente", "") + "", pref.getString("idUsuarioVenta", ""),
                                                        obj.getIdProductoTxt() + "", obj.getIdCategoria() + "",
                                                        obj.getIdCategoriaPadre() + "", obj.getIdFabricante() + "",
                                                        obj.getNombrePro() + "", obj.getDescripcion() + "",
                                                        obj.getPrecio() + "", obj.getPeso() + "",
                                                        obj.getImagen() + "", obj.getIdAlmacen() + "",
                                                        obj.getStock() + "", valor.toString(),
                                                        obj.getImg(), "", "", "", "","0","0"));

                                                holder.txtCant.setText("0");
                                                //cant=0;
                                            }
                                        }



                                            holder.txtCant.setText("0");
                                            //cant=0;
                                        activity.txtProducto.setText("");
                                            dialog2.dismiss();


                                    }
                                });


                                dialog2.show();
                                activity.scaleView(card, 1.0f, 1.0f);


                                //****************************************************************************************************************

                            }else {
                                InsertaAlCarrito(new Carrito(1,
                                        pref.getString("idUsuarioCliente", "") + "", pref.getString("idUsuarioVenta", ""),
                                        producto.get(position).getIdProductoTxt() + "", producto.get(position).getIdCategoria() + "",
                                        producto.get(position).getIdCategoriaPadre() + "", producto.get(position).getIdFabricante() + "",
                                        producto.get(position).getNombrePro() + "", producto.get(position).getDescripcion() + "",
                                        producto.get(position).getPrecio() + "", producto.get(position).getPeso() + "",
                                        producto.get(position).getImagen() + "", producto.get(position).getIdAlmacen() + "",
                                        producto.get(position).getStock() + "", holder.txtCant.getText() + "",
                                        producto.get(position).getImg(), "", "", "", "","0","0"));

                                holder.txtCant.setText("0");
                                activity.txtProducto.setText("");
                                //cant=0;
                            }



                        }else{
                            InsertaAlCarrito(new Carrito(1,
                                    pref.getString("idUsuarioCliente", "") + "", pref.getString("idUsuarioVenta", ""),
                                    producto.get(position).getIdProductoTxt() + "", producto.get(position).getIdCategoria() + "",
                                    producto.get(position).getIdCategoriaPadre() + "", producto.get(position).getIdFabricante() + "",
                                    producto.get(position).getNombrePro() + "", producto.get(position).getDescripcion() + "",
                                    producto.get(position).getPrecio() + "", producto.get(position).getPeso() + "",
                                    producto.get(position).getImagen() + "", producto.get(position).getIdAlmacen() + "",
                                    producto.get(position).getStock() + "", holder.txtCant.getText() + "",
                                    producto.get(position).getImg(), "", "", "", "","0","0"));

                            holder.txtCant.setText("0");
                            activity.txtProducto.setText("");
                            //cant=0;
                        }



                    }else{
                        InsertaAlCarrito(new Carrito(1,
                                pref.getString("idUsuarioCliente", "") + "", pref.getString("idUsuarioVenta", ""),
                                producto.get(position).getIdProductoTxt() + "", producto.get(position).getIdCategoria() + "",
                                producto.get(position).getIdCategoriaPadre() + "", producto.get(position).getIdFabricante() + "",
                                producto.get(position).getNombrePro() + "", producto.get(position).getDescripcion() + "",
                                producto.get(position).getPrecio() + "", producto.get(position).getPeso() + "",
                                producto.get(position).getImagen() + "", producto.get(position).getIdAlmacen() + "",
                                producto.get(position).getStock() + "", holder.txtCant.getText() + "",
                                producto.get(position).getImg(), "", "", "", "","0","0"));

                        holder.txtCant.setText("0");
                        activity.txtProducto.setText("");
                        //cant=0;

                    }



                } else {
                    Toast.makeText(activity, "Debe incrementar la cantidad", Toast.LENGTH_LONG).show();
                }

            }else{
                    Toast.makeText(activity,"NO SE PUEDE ELEGIR ESTE PRODUCTO",Toast.LENGTH_SHORT).show();
                }

        }
        });


    }


    @Override
    public int getItemCount() {
        return producto.size();
    }



    public Integer retornaFaltante (String condi,Integer sugerido,Integer ca,Integer add){

        boolean salir = false;
        Integer y = 1;
        Integer faltante=0;

        while (!salir) {
            Integer rango = Integer.parseInt(condi) * y;

            if (rango >=  sugerido && rango > (ca+add)) {
                salir = true;
                faltante = rango -  ca   ;
            }
            y = y + 1;

        }
        Log.e("FALTANTEE", faltante+"");
        return faltante;
    }







    public void InsertaAlCarrito(Carrito objj){

        Integer existeEnCarrito = sqlcarrito.existeProductoXIdProducto(activity,pref.getString("idUsuarioCliente", ""),
                pref.getString("idUsuarioVenta", ""),objj.getIdProductoTxt());

        if(existeEnCarrito==1){
            //actualizar

            ActualizaProductoCarrito(pref.getString("idUsuarioCliente", "")+"",
                    pref.getString("idUsuarioVenta", ""),objj.getIdProductoTxt()
                    ,Integer.parseInt(objj.getCant()));

            Toast.makeText(activity, "Agregado correctamente", Toast.LENGTH_LONG).show();
        }else{
            //insertar

            Carrito obj = new Carrito(1,
                    pref.getString("idUsuarioCliente", "")+"", pref.getString("idUsuarioVenta", ""),
                    objj.getIdProductoTxt() + "", objj.getIdCategoria() + "",
                    objj.getIdCategoriaPadre() + "", objj.getIdFabricante() + "",
                    objj.getNombrePro() + "", objj.getDescripcion() + "",
                    objj.getPrecio() + "", objj.getPeso() + "",
                    objj.getImagen() + "", objj.getIdAlmacen() + "",
                    objj.getStock() + "",objj.getCant()+"",
                    objj.getImg(), "", "", "", "","0","0");
            InsertaProductoCarrito(obj);

            Toast.makeText(activity, "Agregado correctamente", Toast.LENGTH_LONG).show();
        }
    }



    public void InsertaProductoCarrito(Carrito obj){
          sqlcarrito.insertarCarrito(activity,
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
          activity.muestraCantidad();
    }

    public void ActualizaProductoCarrito(String IdCliente,String IdVendedor,String IdProductoTxt,Integer Cant){
        Integer i = sqlcarrito.cantidadProductoEnCarritoXIdProducto(activity,IdCliente,IdVendedor,IdProductoTxt);
        sqlcarrito.actualizaCarrito(activity,IdCliente,IdVendedor,IdProductoTxt,(Cant+i)+"");
    }



}
