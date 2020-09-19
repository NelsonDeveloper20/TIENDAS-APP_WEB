package com.delcorp.apptiendadelcorp.sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.delcorp.apptiendadelcorp.bean.Pedido;

import java.util.ArrayList;

public class SqlitePromocionVista {

    public void insertarvista(Context context,
                                 String IdPromocion,
                                 String IdPromocionCondicion ,
                                 String IdPromocionBonificacion,
                                 String Flag) {



        SqlLiteDB sql;
        SQLiteDatabase db = null;
        String i = "";
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {

                db.delete("tpromocionvista", "IdPromocion='"+IdPromocion+"' and IdPromocionCondicion='"+IdPromocionCondicion+"' and IdPromocionBonificacion='"+IdPromocionBonificacion+"'", null);

                ContentValues cv = new ContentValues();
                cv.put("IdPromocion",IdPromocion);
                cv.put("IdPromocionCondicion", IdPromocionCondicion);
                cv.put("IdPromocionBonificacion", IdPromocionBonificacion);
                cv.put("Flag", Flag);
                db.insert("tpromocionvista", null, cv);


            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }

    }

    public void eliminarvistos(Context context) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("tpromocionvista", null , null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }

    public ArrayList<String> listarPromoVistas(Context context) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<String> lst = new ArrayList<>();
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();

            if (db != null) {
                Cursor c = db.rawQuery("SELECT IdPromocion FROM tpromocionvista where Flag='1'", null);
                if (c.moveToFirst()) {
                    do {
                        lst.add(c.getString(0));
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

        return lst;
    }
}
