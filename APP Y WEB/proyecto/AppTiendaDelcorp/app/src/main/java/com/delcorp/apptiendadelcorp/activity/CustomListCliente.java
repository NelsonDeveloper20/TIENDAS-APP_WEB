package com.delcorp.apptiendadelcorp.activity;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.delcorp.apptiendadelcorp.R;
import com.delcorp.apptiendadelcorp.bean.Cliente;
import com.delcorp.apptiendadelcorp.sqlite.SqliteVisita;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;

public class CustomListCliente extends RecyclerView.Adapter<HolderCliente> {

    private ListaClienteActivity activity;
    ArrayList<Cliente> cliente;
    SharedPreferences pref;

    public CustomListCliente(ListaClienteActivity activity, ArrayList<Cliente> cliente) {
        this.activity = activity;
        this.cliente = cliente;
    }

    @NonNull
    @Override
    public HolderCliente onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.custom_list_cliente,parent,false);
        HolderCliente holder = new HolderCliente(v);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull final HolderCliente holder, final int position) {

        pref=   activity.getSharedPreferences(activity.getResources().getString(R.string.shared), Context.MODE_PRIVATE) ;

        Calendar cal = Calendar.getInstance();
        String hoy = new SimpleDateFormat("dd/MM/yyyy").format(cal.getTime());
        SqliteVisita sql = new SqliteVisita();

        Boolean si = sql.fueVisitadoHoy(activity,hoy,cliente.get(position).getCodigoTxt(),pref.getString("idUsuarioVenta",""));

        if( cliente.get(position).getVisitadoHoy().equals("1") || si){
            holder.imgBallon.setBackgroundResource(R.drawable.ballonverde);
        }else{
            holder.imgBallon.setBackgroundResource(R.drawable.ballonrojo);
        }

        if(cliente.get(position).getActivaTotalClientes().equals("1")){
            activity.activaRadio(true);
        }else{
            activity.activaRadio(false);
        }

        /*SharedPreferences.Editor editor = pref.edit();
        editor.putString("idUsuarioCliente",cliente.get(position).getCodigoTxt());
        editor.putString("nomCliente",cliente.get(position).getNombre()+" "+cliente.get(position).getPaterno()+" "+cliente.get(position).getMaterno());
        editor.commit();*/

        holder.txtNombre.setText(cliente.get(position).getCodigoTxt()+" | "+cliente.get(position).getNombre()+" "+cliente.get(position).getPaterno()+" "+cliente.get(position).getMaterno());

        holder.txtNombre.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                SharedPreferences.Editor editor = pref.edit();
                editor.putString("idUsuarioCliente",cliente.get(position).getCodigoTxt());
                editor.putString("nomCliente",cliente.get(position).getNombre()+" "+cliente.get(position).getPaterno()+" "+cliente.get(position).getMaterno());
                editor.commit();
                Intent i = new Intent(activity,DetalleClienteActivity.class);
                 i.putExtra("idCliente",cliente.get(position).getCodigoTxt());
                i.putExtra("Nombre",cliente.get(position).getNombre());
                i.putExtra("Paterno",cliente.get(position).getPaterno());
                i.putExtra("Materno",cliente.get(position).getMaterno());
                i.putExtra("Direccion",cliente.get(position).getDireccion());
                activity.startActivity(i);
            }
        });

    }

    @Override
    public int getItemCount() {
        return cliente.size();
    }
}
