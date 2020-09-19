package com.delcorp.apptiendadelcorp.sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.delcorp.apptiendadelcorp.bean.Carrito;
import com.delcorp.apptiendadelcorp.bean.Cliente;

import java.util.ArrayList;

public class SqliteCliente {
    public Integer insertarCliente(Context context,
                                   String CodigoTxt,
                                   String IdUsuario,
                                   String Nombre,
                                   String Paterno,
                                   String Materno,
                                   String Direccion,
                                   String Latitud,
                                   String Longitud,
                                   String DiasVisita,
                                   String ActivaTotalClientes,
                                   String VisitadoHoy) {

        SqlLiteDB sql;
        SQLiteDatabase db = null;
        Integer i = 0;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                ContentValues cv = new ContentValues();
                cv.put("CodigoTxt", CodigoTxt);
                cv.put("IdUsuario", IdUsuario);
                cv.put("Nombre", Nombre);
                cv.put("Paterno", Paterno);
                cv.put("Materno", Materno);
                cv.put("Direccion", Direccion);
                cv.put("Latitud", Latitud);
                cv.put("Longitud", Longitud);
                cv.put("DiasVisita", DiasVisita);
                cv.put("ActivaTotalClientes", ActivaTotalClientes);
                cv.put("VisitadoHoy", VisitadoHoy);
                db.insert("tcliente", null, cv);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }

        return i;
    }

    public void eliminarClientexId(Context context,String CodigoTxt) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("tcliente", "IdUsuario='"+CodigoTxt+"'", null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }


    public ArrayList<Cliente> listarCliente(Context context, String IdCliente) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Cliente> objlstCliente = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCliente = new ArrayList<Cliente>();
            if (db != null) {
                Cursor c = db.rawQuery("SELECT * FROM tcliente where IdUsuario='"+IdCliente+"'", null);
                if (c.moveToFirst()) {
                    do {
                        Cliente bean = new Cliente();
                        bean.setCodigoTxt(c.getString(0));
                        bean.setNombre(c.getString(2));
                        bean.setPaterno(c.getString(3));
                        bean.setMaterno(c.getString(4));
                        bean.setDireccion(c.getString(5));
                        bean.setLatitud(c.getString(6));
                        bean.setLongitud(c.getString(7));
                        bean.setDiasVisita(c.getString(8));
                        bean.setActivaTotalClientes(c.getString(9));
                        bean.setVisitadoHoy(c.getString(10));
                        objlstCliente.add(bean);
                    } while (c.moveToNext());
                }
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }

        return objlstCliente;
    }

    public ArrayList<Cliente> BuscarTrabajador(Context context,String nombre,String IdUsuario) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Cliente> objlstCliente = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCliente = new ArrayList<Cliente>();
            if(db != null){
                Cursor c = db.rawQuery("SELECT * FROM tcliente WHERE \"CodigoTxt\" || \" \" ||  \"Nombre\" || \" \" || \"Paterno\" || \" \" || \"Materno\"  LIKE ? AND IdUsuario = ?",new String[]{"%"+nombre+"%",IdUsuario});
                if(c.moveToFirst()){
                    do {
                        Cliente bean = new Cliente();
                        bean.setCodigoTxt(c.getString(0));
                        bean.setNombre(c.getString(2));
                        bean.setPaterno(c.getString(3));
                        bean.setMaterno(c.getString(4));
                        bean.setDireccion(c.getString(5));
                        bean.setLatitud(c.getString(6));
                        bean.setLongitud(c.getString(7));
                        bean.setDiasVisita(c.getString(8));
                        bean.setActivaTotalClientes(c.getString(9));
                        bean.setVisitadoHoy(c.getString(10));
                        objlstCliente.add(bean);
                    }while (c.moveToNext());
                }
            }
        }catch (Exception e){
            Log.e("Error DB",e.toString());
        }finally {
            if (db.isOpen()){
                db.close();
            }
        }

        return objlstCliente;
    }

    public String BuscarNombreCompleto(Context context ,String codigo,String IdUsuario) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        String nombre ="";
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            if(db != null){
                Cursor c = db.rawQuery("SELECT Nombre ,Paterno,Materno FROM tcliente WHERE  CodigoTxt= ? AND IdUsuario = ?",new String[]{ codigo ,IdUsuario});
                if(c.moveToFirst()){
                    do {
                        nombre= c.getString(0)+" "+  c.getString(1)+" "+ c.getString(2);
                    }while (c.moveToNext());
                }
            }
        }catch (Exception e){
            Log.e("Error DB",e.toString());
        }finally {
            if (db.isOpen()){
                db.close();
            }
        }

        return nombre;
    }
    public ArrayList<Cliente> BuscarTrabajador2(Context context,String nombre,String IdUsuario,String dia) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Cliente> objlstCliente = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCliente = new ArrayList<Cliente>();
            if(db != null){
                Cursor c = db.rawQuery("SELECT * FROM tcliente WHERE substr(DiasVisita,"+dia+",1)='1' AND \"CodigoTxt\" || \" \" ||  \"Nombre\" || \" \" || \"Paterno\" || \" \" || \"Materno\"  LIKE ? AND IdUsuario = ?",new String[]{"%"+nombre+"%",IdUsuario});
                if(c.moveToFirst()){
                    do {
                        Cliente bean = new Cliente();
                        bean.setCodigoTxt(c.getString(0));
                        bean.setNombre(c.getString(2));
                        bean.setPaterno(c.getString(3));
                        bean.setMaterno(c.getString(4));
                        bean.setDireccion(c.getString(5));
                        bean.setLatitud(c.getString(6));
                        bean.setLongitud(c.getString(7));
                        bean.setDiasVisita(c.getString(8));
                        bean.setActivaTotalClientes(c.getString(9));
                        bean.setVisitadoHoy(c.getString(10));
                        objlstCliente.add(bean);
                    }while (c.moveToNext());
                }
            }
        }catch (Exception e){
            Log.e("Error DB",e.toString());
        }finally {
            if (db.isOpen()){
                db.close();
            }
        }

        return objlstCliente;
    }

}
