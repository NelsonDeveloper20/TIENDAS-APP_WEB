package com.delcorp.apptiendadelcorp.activity;

import android.Manifest;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.AsyncTask;
import android.support.annotation.NonNull;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Carrito;
import com.delcorp.apptiendadelcorp.bean.PedidoComplementario;
import com.delcorp.apptiendadelcorp.bean.PedidoComplementarioDetalle;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCarrito;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCliente;
import com.delcorp.apptiendadelcorp.sqlite.SqliteSugerido;
import com.delcorp.apptiendadelcorp.webservice.WebService;

import java.text.DecimalFormat;
import java.util.ArrayList;

public class CustomListPedidoComplementario extends RecyclerView.Adapter<HolderPedidoComplementario> {

    ReporteSugeridoMenorActivity activity;
    ArrayList<PedidoComplementario> pedidos;
    String IdPedido, IdUsuario;
    SharedPreferences pref;
    ArrayList<PedidoComplementarioDetalle> arr;
    SqliteCarrito sqlcarrito = new SqliteCarrito();
    SqliteCliente sqcliente = new SqliteCliente();

    public CustomListPedidoComplementario(ReporteSugeridoMenorActivity activity, ArrayList<PedidoComplementario> pedidos) {
        this.activity = activity;
        this.pedidos = pedidos;
    }


    @NonNull
    @Override
    public HolderPedidoComplementario onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_list_complementario, parent, false);
        HolderPedidoComplementario holder = new HolderPedidoComplementario(v);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull HolderPedidoComplementario h, final int position) {

        DecimalFormat precision = new DecimalFormat("0.00");


        pref = activity.getSharedPreferences(activity.getResources().getString(R.string.shared), Context.MODE_PRIVATE);
        h.txtNombreCliente.setText(pedidos.get(position).getNomUsuario());
        h.txtMontoComprado.setText("Monto Comprado : S/ " + pedidos.get(position).getMontoComprado());
        h.txtMontoSugerido.setText("Monto Sugerido : S/ " + pedidos.get(position).getMontoSugerido());
        if (Double.parseDouble(pedidos.get(position).getMontoComprado()) >= Double.parseDouble(pedidos.get(position).getMontoSugerido())) {
            h.txtDiferencia.setText("Diferencia : S/  0.00");
        } else {
            h.txtDiferencia.setText("Diferencia : S/ " + precision.format((Double.parseDouble(pedidos.get(position).getMontoSugerido()) - Double.parseDouble(pedidos.get(position).getMontoComprado()))));
        }

        h.btnCarrito.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                IdPedido = pedidos.get(position).getIdPedido();
                IdUsuario = pedidos.get(position).getIdUsuario();
                new ListarDetalleComplementario().execute();
            }
        });

        h.btnLlamar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (pedidos.get(position).getCelular().equals("")) {
                    Toast.makeText(activity, "NO SE ENCONTRO CELULAR", Toast.LENGTH_LONG).show();
                } else {

                    Intent callIntent = new Intent(Intent.ACTION_DIAL);
                    callIntent.setData(Uri.parse("tel:"+pedidos.get(position).getCelular()));
                    activity.startActivity(callIntent);


                }
            }
        });



    }

    @Override
    public int getItemCount() {
        return pedidos.size();
    }


    private class ListarDetalleComplementario extends AsyncTask<String,Void,Object> {

        @Override
        protected Object doInBackground(String... strings) {

            arr = new WebService().ListaPedidoComplementarioDetalle(IdPedido);
            return 1;
        }

        @Override
        protected void onPostExecute(Object o) {
            super.onPostExecute(o);
            if(arr==null ){

                android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(activity);

                builder.setTitle("Error en la red ") ;
                builder.setPositiveButton("Intentarlo Nuevamente", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        new ListarDetalleComplementario().execute();

                    }
                });
                android.app.AlertDialog dialog=builder.create();
                dialog.show();

            }else{
                SqliteCarrito sqlc  = new SqliteCarrito();

                SharedPreferences.Editor editor = pref.edit();
                editor.putString("idUsuarioCliente", IdUsuario);
                editor.putString("nomCliente", sqcliente.BuscarNombreCompleto(activity, IdUsuario,pref.getString("idUsuarioVenta","")) );
                editor.commit();


                sqlcarrito.eliminarCarritoxIdUsuarioCiente(activity,IdUsuario,pref.getString("idUsuarioVenta",""));
                for (int i = 0;i < arr.size();i++){

                    InsertaAlCarrito(new Carrito(1,
                            IdUsuario,
                            pref.getString("idUsuarioVenta",""),
                            arr.get(i).getIdProducto()+"",
                            arr.get(i).getIdCategoria()+"" ,
                            arr.get(i).getIdCategoriaPadre()+"" ,
                            arr.get(i).getIdFabricante()+"",
                            arr.get(i).getNombrePro()+"",
                            arr.get(i).getDescripcion()+"",
                            arr.get(i).getPrecio()+"",
                            arr.get(i).getPeso()+"",
                            arr.get(i).getImagen()+"",
                            arr.get(i).getIdAlmacen()+"",
                            arr.get(i).getStock()+"",
                             arr.get(i).getCantComprada()   +"",
                            null,
                            "",
                            "",
                            "",
                            "",
                            arr.get(i).getCantSugerido()+"",
                            arr.get(i).getIdPedido()+""));



                }


                    Intent in = new Intent(activity,CartActivity.class);

                    SharedPreferences.Editor  edit = pref.edit();
                    edit.putString("origen","1");
                    edit.commit();
                    activity.startActivity(in);

            }
        }
    }

    public void InsertaAlCarrito(Carrito objj){

        Integer existeEnCarrito = sqlcarrito.existeProductoXIdProducto(activity,IdUsuario+"",
                pref.getString("idUsuarioVenta", ""),objj.getIdProductoTxt());

        if(existeEnCarrito==1){
            //actualizar

            ActualizaProductoCarrito(IdUsuario+"",
                    pref.getString("idUsuarioVenta", ""),objj.getIdProductoTxt()
                    ,Integer.parseInt(objj.getCant()));

            Toast.makeText(activity, "Agregado correctamente", Toast.LENGTH_LONG).show();
        }else{
            //insertar

            Carrito obj = new Carrito(1,
                    IdUsuario+"", pref.getString("idUsuarioVenta", ""),
                    objj.getIdProductoTxt() + "", objj.getIdCategoria() + "",
                    objj.getIdCategoriaPadre() + "", objj.getIdFabricante() + "",
                    objj.getNombrePro() + "", objj.getDescripcion() + "",
                    objj.getPrecio() + "", objj.getPeso() + "",
                    objj.getImagen() + "", objj.getIdAlmacen() + "",
                    objj.getStock() + "",objj.getCant()+"",
                    objj.getImg(), "", "", "", "",objj.getCantSuge()+"",objj.getIdPedido()+"");

            InsertaProductoCarrito(obj);

            Toast.makeText(activity, "Agregado correctamente", Toast.LENGTH_LONG).show();
        }
    }
    public void ActualizaProductoCarrito(String IdCliente,String IdVendedor,String IdProductoTxt,Integer Cant){
        Integer i = sqlcarrito.cantidadProductoEnCarritoXIdProducto(activity,IdCliente,IdVendedor,IdProductoTxt);
        sqlcarrito.actualizaCarrito(activity,IdCliente,IdVendedor,IdProductoTxt,(Cant+i)+"");
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
                obj.getCantSuge()+"",obj.getIdPedido()+"");
    }
}
