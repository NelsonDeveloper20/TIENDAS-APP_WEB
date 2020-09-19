package com.delcorp.apptiendadelcorp.sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.delcorp.apptiendadelcorp.bean.Producto;
import com.delcorp.apptiendadelcorp.bean.Promocion;

import java.util.ArrayList;

public class SqlitePromociones {

    public void insertarPromociones(Context context,
                                    String IdPromocion,
                                    String flagHistorico,
                                    String IdCondicion,
                                    String IdTipoCondicion,
                                    String IdTipoPromocion,
                                    String IdTipoBonificacion,
                                    String MontoBonificacion,
                                    String IdTipoUsuario,
                                    String flagPrimeraCompra) {

        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                ContentValues cv = new ContentValues();
                cv.put("IdPromocion", IdPromocion);
                cv.put("flagHistorico", flagHistorico);
                cv.put("IdCondicion", IdCondicion);
                cv.put("IdTipoCondicion", IdTipoCondicion);
                cv.put("IdTipoPromocion", IdTipoPromocion);
                cv.put("IdTipoBonificacion", IdTipoBonificacion);
                cv.put("MontoBonificacion", MontoBonificacion);
                cv.put("IdTipoUsuario", IdTipoUsuario);
                cv.put("flagPrimeraCompra",flagPrimeraCompra);

                db.insert("tpromocioncabecera", null, cv);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }

    public void eliminarPromocion(Context context) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("tpromocioncabecera", null, null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }

    public ArrayList<Promocion> listaPromosMontoCategoria(Context context) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Promocion> objlstPromocion = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstPromocion = new ArrayList<Promocion>();
            if (db != null) {

                Cursor c = db.rawQuery("SELECT * FROM tpromocioncabecera WHERE  IdTipoPromocion=2 and IdCondicion=2",null);

                if (c.moveToFirst()) {
                    do {
                        Promocion bean = new Promocion();
                        bean.setIdPromocion(c.getString(0));
                        bean.setFlagHistorico(c.getString(1));
                        bean.setIdCondicion(c.getString(2));
                        bean.setIdTipoCondicion(c.getString(3));
                        bean.setIdTipoPromocion(c.getString(4));
                        bean.setIdTipoBonificacion(c.getString(5));
                        bean.setMontoBonificacion(c.getString(6));
                        bean.setIdTipoUsuario(c.getString(7));
                        bean.setFlagPrimeraCompra(c.getString(8));
                        objlstPromocion.add(bean);
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

        return objlstPromocion;
    }

    public ArrayList<Promocion> listaPromosUnidaCategoria(Context context) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Promocion> objlstPromocion = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstPromocion = new ArrayList<Promocion>();
            if (db != null) {

                Cursor c = db.rawQuery("SELECT * FROM tpromocioncabecera WHERE  IdTipoPromocion in(1,3) and IdCondicion=1",null);

                if (c.moveToFirst()) {
                    do {
                        Promocion bean = new Promocion();
                        bean.setIdPromocion(c.getString(0));
                        bean.setFlagHistorico(c.getString(1));
                        bean.setIdCondicion(c.getString(2));
                        bean.setIdTipoCondicion(c.getString(3));
                        bean.setIdTipoPromocion(c.getString(4));
                        bean.setIdTipoBonificacion(c.getString(5));
                        bean.setMontoBonificacion(c.getString(6));
                        bean.setIdTipoUsuario(c.getString(7));
                        bean.setFlagPrimeraCompra(c.getString(8));
                        objlstPromocion.add(bean);
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

        return objlstPromocion;
    }

    public  Promocion  PromocionxId(Context context,String IdPromocion) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
         Promocion  objPromocion = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();

            if (db != null) {

                Cursor c = db.rawQuery("SELECT * FROM tpromocioncabecera WHERE  IdPromocion='"+IdPromocion+"'",null);

                if (c.moveToFirst()) {
                    do {
                        Promocion bean = new Promocion();
                        bean.setIdPromocion(c.getString(0));
                        bean.setFlagHistorico(c.getString(1));
                        bean.setIdCondicion(c.getString(2));
                        bean.setIdTipoCondicion(c.getString(3));
                        bean.setIdTipoPromocion(c.getString(4));
                        bean.setIdTipoBonificacion(c.getString(5));
                        bean.setMontoBonificacion(c.getString(6));
                        bean.setIdTipoUsuario(c.getString(7));
                        bean.setFlagPrimeraCompra(c.getString(8));
                        objPromocion =  bean ;
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

        return objPromocion;
    }
}
