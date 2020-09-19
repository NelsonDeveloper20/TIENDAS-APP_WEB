package com.delcorp.apptiendadelcorp.sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.delcorp.apptiendadelcorp.bean.Carrito;
import com.delcorp.apptiendadelcorp.bean.Pedido;

import java.util.ArrayList;

public class SqlitePedido {

    public String insertarPedido(Context context,
                                   String IdPedidoSql,
                                   String IdUsuario,
                                   String nomCliente,
                                   String CodigoTxt,
                                   String IdCondicionVenta,
                                   String IdUsuarioVenta,
                                   String TotalPagar,
                                   String Items,
                                   String Latitud,
                                   String Longitud,
                                   String FlagTipoRegistro,
                                   String Fecha ,
                                  String FlagSincronizado) {

        SqlLiteDB sql;
        SQLiteDatabase db = null;
        String i = "";
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                ContentValues cv = new ContentValues();
                cv.put("IdPedidoSql",IdPedidoSql);
                cv.put("IdUsuario", IdUsuario);
                cv.put("nomCliente", nomCliente);
                cv.put("CodigoTxt", CodigoTxt);
                cv.put("IdCondicionVenta", IdCondicionVenta);
                cv.put("IdUsuarioVenta", IdUsuarioVenta);
                cv.put("TotalPagar", TotalPagar);
                cv.put("Items", Items);
                cv.put("Latitud", Latitud);
                cv.put("Longitud", Longitud);
                cv.put("FlagTipoRegistro", FlagTipoRegistro);
                cv.put("Fecha", Fecha);
                cv.put("FlagSincronizado",FlagSincronizado);
                db.insert("tpedido", null, cv);

                Cursor c = db.rawQuery(" select * from tpedido where IdUsuarioVenta='"+IdUsuarioVenta+"' order by IdPedido desc  limit 1", null);
                if (c.moveToFirst()) {
                    do {

                        i=(c.getString(0));
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
        return i+"";

    }

    public void eliminarPedidoxIdPedido(Context context,String IdPedido) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("tpedido", "IdPedido="+IdPedido, null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }

    public void actualizaPedido(Context context,String IdPedido,String IdPedidoSql) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            ContentValues values = new ContentValues();
            values.put("FlagSincronizado","1");
            values.put("IdPedidoSql",IdPedidoSql);

            if (db != null) {
                db.update("tpedido", values,"IdPedido  = ?", new String[] {IdPedido});
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }

    public ArrayList<Pedido> listarPedidos(Context context, String IdUsuarioVenta) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Pedido> objlstPedido = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstPedido= new ArrayList<Pedido>();
            if (db != null) {
                Cursor c = db.rawQuery("SELECT * FROM tpedido where IdUsuarioVenta='"+IdUsuarioVenta+"'", null);
                if (c.moveToFirst()) {
                    do {
                        Pedido bean = new Pedido();
                        bean.setIdPedido(c.getString(0));
                        bean.setIdPedidoSql(c.getString(1));
                        bean.setIdUsuario(c.getString(2));
                        bean.setNomUsuario(c.getString(3));
                        bean.setCodigoTxt(c.getString(4));
                        bean.setIdCondicionVenta(c.getString(5));
                        bean.setIdUsuarioVenta(c.getString(6));
                        bean.setTotalPagar(c.getString(7));
                        bean.setItems(c.getString(8));
                        bean.setLatitud(c.getString(9));
                        bean.setLongitud(c.getString(10));
                        bean.setFlagTipoRegistro(c.getString(11));
                        bean.setFecha(c.getString(12));
                        bean.setFlagSincronizado(c.getString(13));
                        objlstPedido.add(bean);
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

        return objlstPedido;
    }



}
