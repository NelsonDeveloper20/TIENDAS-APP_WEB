package com.delcorp.apptiendadelcorp.sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.delcorp.apptiendadelcorp.bean.Cliente;
import com.delcorp.apptiendadelcorp.bean.Visita;

import java.util.ArrayList;

public class SqliteVisita {

    public Integer insertarVisita(Context context,
                                   String IdCliente,
                                   String IdVendedor,
                                   String FechaRegistro,
                                   String FlagSincronizado) {

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
                cv.put("FechaRegistro", FechaRegistro);
                cv.put("FlagSincronizado", FlagSincronizado);
                db.insert("tvisita", null, cv);
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

    public void eliminarVisitaxId(Context context,String IdVisita) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("tvisita", "IdVisita="+IdVisita, null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }


    public Boolean fueVisitadoHoy(Context context, String fecha,String IdCliente,String IdVendedor) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Visita> objlstVisita = null;
        Boolean si=false;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstVisita = new ArrayList<Visita>();
            if (db != null) {
                Cursor c = db.rawQuery("SELECT * FROM tvisita where  FechaRegistro ='"+fecha+"'  and IdCliente='"+IdCliente+"' and IdVendedor='"+IdVendedor+"'", null);
                /*if (c.moveToFirst()) {
                    do {
                        Visita bean = new Visita();
                        bean.setIdVisita(c.getInt(0)+"");
                        bean.setIdCliente(c.getString(1));
                        bean.setIdVendedor(c.getString(2));
                        bean.setFechaRegistro(c.getString(3));
                        bean.setFlagSincronizado(c.getString(4));
                        objlstVisita.add(bean);
                    } while (c.moveToNext());
                }*/

                if(c.getCount()>0){
                    si=true;
                }
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }

        return si;
    }


    public ArrayList<Visita> listarVisita(Context context, String IdVendedor) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Visita> objlstVisita = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstVisita = new ArrayList<Visita>();
            if (db != null) {
                Cursor c = db.rawQuery("SELECT * FROM tvisita where IdVendedor='"+IdVendedor+"'", null);
                if (c.moveToFirst()) {
                    do {
                        Visita bean = new Visita();
                        bean.setIdVisita(c.getInt(0)+"");
                        bean.setIdCliente(c.getString(1));
                        bean.setIdVendedor(c.getString(2));
                        bean.setFechaRegistro(c.getString(3));
                        bean.setFlagSincronizado(c.getString(4));
                        objlstVisita.add(bean);
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

        return objlstVisita;
    }
}
