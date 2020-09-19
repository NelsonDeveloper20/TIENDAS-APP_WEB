package com.delcorp.apptiendadelcorp.sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.delcorp.apptiendadelcorp.bean.Condicion;
import com.delcorp.apptiendadelcorp.bean.Promocion;

import java.util.ArrayList;

public class SqliteCondicion {

    public void insertarCondiciones(Context context,
                                    String IdPromocionCondicion ,
                                    String IdPromocion ,
                                    String IdProducto ,
                                    String IdCategoria ,
                                    String IdGrupo ,
                                    String Cantidad ,
                                    String Descripcion ) {

        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                ContentValues cv = new ContentValues();
                cv.put("IdPromocionCondicion", IdPromocionCondicion);
                cv.put("IdPromocion", IdPromocion);
                cv.put("IdProducto", IdProducto);
                cv.put("IdCategoria", IdCategoria);
                cv.put("IdGrupo", IdGrupo);
                cv.put("Cantidad", Cantidad);
                cv.put("Descripcion", Descripcion);

                db.insert("tcondicion", null, cv);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }

    public void eliminarCondiciones(Context context) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("tcondicion", null, null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }

    public ArrayList<Condicion> listaCondiciones3xIdGrupoIdPromo(Context context, String IdPromocion,String idGrupo) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Condicion> objlstCondicion = new ArrayList<>();
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCondicion = new ArrayList<Condicion>();
            if (db != null) {

                Cursor c = db.rawQuery("SELECT * FROM tcondicion WHERE  IdPromocion='"+IdPromocion+"' and IdGrupo='"+idGrupo+"'  ",null);

                if (c.moveToFirst()) {
                    do {
                        Condicion bean = new Condicion();
                        bean.setIdPromocionCondicion(c.getString(0));
                        bean.setIdPromocion(c.getString(1));
                        bean.setIdProducto(c.getString(2));
                        bean.setIdCategoria(c.getString(3));
                        bean.setIdGrupo(c.getString(4));
                        bean.setCantidad(c.getString(5));
                        bean.setDescripcion(c.getString(6));
                        objlstCondicion.add(bean);
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

        return objlstCondicion;
    }

    public ArrayList<Condicion> listaCondiciones3xIdPromocionGroupBy(Context context, String IdPromocion) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Condicion> objlstCondicion = new ArrayList<>();
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCondicion = new ArrayList<Condicion>();
            if (db != null) {

                Cursor c = db.rawQuery("SELECT * FROM tcondicion WHERE  IdPromocion='"+IdPromocion+"' group by IdGrupo order by CAST(Cantidad as INTEGER) Desc",null);

                if (c.moveToFirst()) {
                    do {
                        Condicion bean = new Condicion();
                        bean.setIdPromocionCondicion(c.getString(0));
                        bean.setIdPromocion(c.getString(1));
                        bean.setIdProducto(c.getString(2));
                        bean.setIdCategoria(c.getString(3));
                        bean.setIdGrupo(c.getString(4));
                        bean.setCantidad(c.getString(5));
                        bean.setDescripcion(c.getString(6));
                        objlstCondicion.add(bean);
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

        return objlstCondicion;
    }
    public ArrayList<Condicion> listaCondicionesXIdPromocion(Context context, String IdPromocion) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Condicion> objlstCondicion = new ArrayList<>();
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCondicion = new ArrayList<Condicion>();
            if (db != null) {

                Cursor c = db.rawQuery("SELECT * FROM tcondicion WHERE  IdPromocion='"+IdPromocion+"' order by CAST(Cantidad as INTEGER) Desc",null);

                if (c.moveToFirst()) {
                    do {
                        Condicion bean = new Condicion();
                        bean.setIdPromocionCondicion(c.getString(0));
                        bean.setIdPromocion(c.getString(1));
                        bean.setIdProducto(c.getString(2));
                        bean.setIdCategoria(c.getString(3));
                        bean.setIdGrupo(c.getString(4));
                        bean.setCantidad(c.getString(5));
                        bean.setDescripcion(c.getString(6));
                        objlstCondicion.add(bean);
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

        return objlstCondicion;
    }

    public ArrayList<Condicion> listaCondicionesXIdPromocionIdGrupo(Context context, String IdPromocion,String IdGrupo) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Condicion> objlstCondicion = new ArrayList<>();
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCondicion = new ArrayList<Condicion>();
            if (db != null) {

                Cursor c = db.rawQuery("SELECT * FROM tcondicion WHERE  IdPromocion='"+IdPromocion+"' and IdGrupo='"+IdGrupo+"' order by CAST(Cantidad as INTEGER) asc",null);

                if (c.moveToFirst()) {
                    do {
                        Condicion bean = new Condicion();
                        bean.setIdPromocionCondicion(c.getString(0));
                        bean.setIdPromocion(c.getString(1));
                        bean.setIdProducto(c.getString(2));
                        bean.setIdCategoria(c.getString(3));
                        bean.setIdGrupo(c.getString(4));
                        bean.setCantidad(c.getString(5));
                        bean.setDescripcion(c.getString(6));
                        objlstCondicion.add(bean);
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

        return objlstCondicion;
    }

    public ArrayList<Condicion> listaCondicionesXIdProducto(Context context, String IdProducto) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Condicion> objlstCondicion = new ArrayList<>();
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCondicion = new ArrayList<Condicion>();
            if (db != null) {

                Cursor c = db.rawQuery("SELECT * FROM tcondicion WHERE  IdProducto='"+IdProducto+"'  order by CAST(Cantidad as INTEGER) asc",null);

                if (c.moveToFirst()) {
                    do {
                        Condicion bean = new Condicion();
                        bean.setIdPromocionCondicion(c.getString(0));
                        bean.setIdPromocion(c.getString(1));
                        bean.setIdProducto(c.getString(2));
                        bean.setIdCategoria(c.getString(3));
                        bean.setIdGrupo(c.getString(4));
                        bean.setCantidad(c.getString(5));
                        bean.setDescripcion(c.getString(6));
                        objlstCondicion.add(bean);
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

        return objlstCondicion;
    }

    public ArrayList<Condicion> listaPromocionesDescripcion(Context context ) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Condicion> objlstCondicion = new ArrayList<>();
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCondicion = new ArrayList<Condicion>();
            if (db != null) {

                Cursor c = db.rawQuery("select distinct(Descripcion),IdPromocion,IdGrupo from tcondicion",null);

                if (c.moveToFirst()) {
                    do {
                        Condicion bean = new Condicion();
                        bean.setIdPromocionCondicion("");
                        bean.setIdPromocion(c.getString(1));
                        bean.setIdProducto("");
                        bean.setIdCategoria("");
                        bean.setIdGrupo(c.getString(2));
                        bean.setCantidad("");
                        bean.setDescripcion(c.getString(0));
                        objlstCondicion.add(bean);
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

        return objlstCondicion;
    }
}
