package com.delcorp.apptiendadelcorp.sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.delcorp.apptiendadelcorp.bean.Bonificacion;
import com.delcorp.apptiendadelcorp.bean.Condicion;

import java.util.ArrayList;

public class SqliteBonificacion {

    public void insertarBonificacion(Context context,
                                     String IdPromocionBonificacion ,
                                    String IdPromocion ,
                                    String IdProducto ,
                                    String IdGrupo ,
                                    String Cantidad ,
                                    String Stock ) {

        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                ContentValues cv = new ContentValues();
                cv.put("IdPromocionBonificacion", IdPromocionBonificacion);
                cv.put("IdPromocion", IdPromocion);
                cv.put("IdProducto", IdProducto);
                cv.put("IdGrupo", IdGrupo);
                cv.put("Cantidad", Cantidad);
                cv.put("Stock", Stock);

                db.insert("tbonificacion", null, cv);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }

    public void eliminarBonificaciones(Context context) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("tbonificacion", null, null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }


    public ArrayList<Bonificacion> listaBonificacionXIdPromocionIdGrupo(Context context, String IdPromocion, String IdGrupo) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Bonificacion> objlstBonificacion = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstBonificacion = new ArrayList<Bonificacion>();
            if (db != null) {
               // Log.e("idpromo y id grupo","id promocion "+ IdPromocion+" / IDGRUPO "+ IdGrupo);
                Cursor c = db.rawQuery("SELECT * FROM tbonificacion WHERE  IdPromocion='"+IdPromocion+"' and IdGrupo ='"+ IdGrupo+"'",null);

                if (c.moveToFirst()) {
                    do {
                        Bonificacion bean = new Bonificacion();
                        bean.setIdPromocionBonificacion(c.getString(0));
                        bean.setIdPromocion(c.getString(1));
                        bean.setIdProducto(c.getString(2));
                        bean.setIdGrupo(c.getString(3));
                        bean.setCantidad(c.getString(4));
                        bean.setStock(c.getString(5));
                        objlstBonificacion.add(bean);
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

        return objlstBonificacion;
    }
    public ArrayList<Bonificacion> listaBonificacionXIdPrducto(Context context, String IdPromocion, String IdGrupo) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Bonificacion> objlstBonificacion = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstBonificacion = new ArrayList<Bonificacion>();
            if (db != null) {
                // Log.e("idpromo y id grupo","id promocion "+ IdPromocion+" / IDGRUPO "+ IdGrupo);
                Cursor c = db.rawQuery("SELECT * FROM tbonificacion WHERE  IdPromocion='"+IdPromocion+"' and IdGrupo ='"+ IdGrupo+"'",null);

                if (c.moveToFirst()) {
                    do {
                        Bonificacion bean = new Bonificacion();
                        bean.setIdPromocionBonificacion(c.getString(0));
                        bean.setIdPromocion(c.getString(1));
                        bean.setIdProducto(c.getString(2));
                        bean.setIdGrupo(c.getString(3));
                        bean.setCantidad(c.getString(4));
                        bean.setStock(c.getString(5));
                        objlstBonificacion.add(bean);
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

        return objlstBonificacion;
    }
}
