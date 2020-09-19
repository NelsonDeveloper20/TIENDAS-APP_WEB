package com.delcorp.apptiendadelcorp.sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.delcorp.apptiendadelcorp.bean.Carrito;
import com.delcorp.apptiendadelcorp.bean.PedidoDetalle;

import java.util.ArrayList;

public class SqlitePedidoDetalle {
    public void insertarPedidoDetalle(Context context,
                                   String IdPedido,
                                   String IdProductoTxt,
                                   String Precio,
                                   String Cantidad,
                                   String SubTotal  ) {

        SqlLiteDB sql;
        SQLiteDatabase db = null;
        Integer i = 0;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                ContentValues cv = new ContentValues();
                cv.put("IdPedido", IdPedido);
                cv.put("IdProductoTxt", IdProductoTxt);
                cv.put("Precio", Precio);
                cv.put("Cantidad", Cantidad);
                cv.put("SubTotal", SubTotal);
                db.insert("tpedidodetalle", null, cv);

            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }

    }

    public void eliminarCarritoxId(Context context,String IdPedido) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("tpedidodetalle", "IdPedido='"+IdPedido+"'", null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }


    public ArrayList<PedidoDetalle> listarPedidoDetalle(Context context, String IdPedido) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<PedidoDetalle> objlstPedidoDetalle = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstPedidoDetalle = new ArrayList<PedidoDetalle>();
            if (db != null) {
                Cursor c = db.rawQuery("SELECT * FROM tpedidodetalle where IdPedido='"+IdPedido+"'", null);
                if (c.moveToFirst()) {
                    do {
                        PedidoDetalle bean = new PedidoDetalle();
                        bean.setIdPedido(c.getString(0));
                        bean.setIdProductoTxt(c.getString(1));
                        bean.setPrecio(c.getString(2));
                        bean.setCantidad(c.getString(3));
                        bean.setSubTotal(c.getString(4));
                        objlstPedidoDetalle.add(bean);
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

        return objlstPedidoDetalle;
    }


}
