package com.delcorp.apptiendadelcorp.sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.delcorp.apptiendadelcorp.bean.Carrito;
import com.delcorp.apptiendadelcorp.bean.Pedido;

import java.util.ArrayList;

public class SqliteSugerido {

    public void insertarSugerido(Context context,
                                   String IdCliente,
                                   String IdVendedor,
                                    String Flag) {

        SqlLiteDB sql;
        SQLiteDatabase db = null;
        Integer i = 0;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                ContentValues cv = new ContentValues();
                cv.put("IdCliente", IdCliente);
                cv.put("IdVendedor", IdVendedor);
                cv.put("Flag", Flag);
                db.insert("tsugerido", null, cv);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }

    }

    public void actualizaSugerido(Context context,String IdCliente,String IdVendedor,String Flag) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            ContentValues values = new ContentValues();
            values.put("Flag",Flag);

            if (db != null) {
                db.update("tsugerido", values,"IdCliente  = ? and IdVendedor = ?", new String[] {IdCliente,IdVendedor});

            }

        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }

    public String buscarFlagSugerido(Context context,String IdCliente,String IdVendedor)  {

        String value = new String();
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        Integer i = 0;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                Cursor  c = db.rawQuery("SELECT ifnull(Flag,'2')  FROM tsugerido where IdCliente='"+IdCliente+"'"+" and IdVendedor='"+IdVendedor+"'", null);


                if (c.moveToFirst()) {
                    do {

                        value=(c.getString(0));

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

        return value;
    }



}
