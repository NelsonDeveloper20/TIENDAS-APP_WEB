package com.delcorp.apptiendadelcorp.sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.delcorp.apptiendadelcorp.bean.Categoria;

import java.util.ArrayList;

public class SqliteCategoria {


        public void insertarCategoria(Context context,
                                      String IdCategoria,
                                      String IdUp,
                                      String Stock,
                                      String Nombre,
                                      String Descripcion,
                                      String Precio,
                                      String Peso,
                                      String Imagen,
                                      byte[] Img) {

            SqlLiteDB sql;
            SQLiteDatabase db = null;
            try {
                sql = new SqlLiteDB(context);
                db = sql.getWritableDatabase();
                if (db != null) {
                    ContentValues cv = new ContentValues();
                    cv.put("IdCategoria", IdCategoria);
                    cv.put("IdUp", IdUp);
                    cv.put("Stock", Stock);
                    cv.put("Nombre", Nombre);
                    cv.put("Descripcion", Descripcion);
                    cv.put("Precio", Precio);
                    cv.put("Peso", Peso);
                    cv.put("Imagen", Imagen);
                    cv.put("Img", Img);
                    db.insert("tcategoria", null, cv);
                }
            } catch (Exception e) {
                Log.e("Error DB", e.toString());
            } finally {
                if (db.isOpen()) {
                    db.close();
                }
            }
        }

        public void eliminarCategoria(Context context) {
            SqlLiteDB sql;
            SQLiteDatabase db = null;
            try {
                sql = new SqlLiteDB(context);
                db = sql.getWritableDatabase();
                if (db != null) {
                    db.delete("tcategoria", null, null);
                }
            } catch (Exception e) {
                Log.e("Error DB", e.toString());
            } finally {
                if (db.isOpen()) {
                    db.close();
                }
            }
        }

    public ArrayList<Categoria> listarCategoriaPadreXIdCategoria(Context context,String IdCategoria,String idTipoAcceso) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Categoria> objlstCategoria = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCategoria = new ArrayList<Categoria>();
            if (db != null) {
                Cursor c;
                if(idTipoAcceso.equals("1")){
                    c = db.rawQuery("SELECT * FROM tcategoria where IdCategoria='" + IdCategoria + "'  " , null);
                }else {
                      c = db.rawQuery("SELECT * FROM tcategoria where IdCategoria='" + IdCategoria + "'and IdCategoria!='1057'", null);
                }

                if (c.moveToFirst()) {
                    do {
                        Categoria bean = new Categoria();
                        bean.setIdCategoria(c.getString(0));
                        bean.setIdUp(c.getString(1));
                        bean.setStock(c.getString(2));
                        bean.setNombre(c.getString(3));
                        bean.setDescripcion(c.getString(4));
                        bean.setPrecio(c.getString(5));
                        bean.setPeso(c.getString(6));
                        bean.setImagen(c.getString(7));
                        bean.setImg(c.getBlob(8));
                        objlstCategoria.add(bean);
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

        return objlstCategoria;
    }


        public ArrayList<Categoria> listarSoloCategoria(Context context,String  idTipoAcceso) {
            SqlLiteDB sql;
            SQLiteDatabase db = null;
            ArrayList<Categoria> objlstCategoria = null;
            try {
                sql = new SqlLiteDB(context);
                db = sql.getReadableDatabase();
                objlstCategoria = new ArrayList<Categoria>();
                if (db != null) {
                    Cursor c;
                    if(idTipoAcceso.equals("1")){
                        c = db.rawQuery("SELECT * FROM tcategoria where IdUp='0' order by Nombre asc", null);
                    }else {

                          c = db.rawQuery("SELECT * FROM tcategoria where IdUp='0' and IdCategoria!='1057' order by Nombre asc", null);
                    }
                    if (c.moveToFirst()) {
                        do {
                            Categoria bean = new Categoria();
                            bean.setIdCategoria(c.getString(0));
                            bean.setIdUp(c.getString(1));
                            bean.setStock(c.getString(2));
                            bean.setNombre(c.getString(3));
                            bean.setDescripcion(c.getString(4));
                            bean.setPrecio(c.getString(5));
                            bean.setPeso(c.getString(6));
                            bean.setImagen(c.getString(7));
                            bean.setImg(c.getBlob(8));
                            objlstCategoria.add(bean);
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

            return objlstCategoria;
        }


        public ArrayList<Categoria> listSubCatXId(Context context, String idUp,String idTipoAcceso) {
            SqlLiteDB sql;
            SQLiteDatabase db = null;
            ArrayList<Categoria> objlstCategoria = null;
            try {
                sql = new SqlLiteDB(context);
                db = sql.getReadableDatabase();
                objlstCategoria = new ArrayList<Categoria>();
                if (db != null) {
                    Cursor c;
                    if(idTipoAcceso.equals("1")) {
                        c = db.rawQuery("SELECT * FROM tcategoria where IdUp=" + idUp + " and IdCategoria!='1057'  order by Nombre asc", null);
                    }else {
                          c = db.rawQuery("SELECT * FROM tcategoria where IdUp=" + idUp + "   order by Nombre asc", null);
                    }
                    if (c.moveToFirst()) {
                        do {
                            Categoria bean = new Categoria();
                            bean.setIdCategoria(c.getString(0));
                            bean.setIdUp(c.getString(1));
                            bean.setStock(c.getString(2));
                            bean.setNombre(c.getString(3));
                            bean.setDescripcion(c.getString(4));
                            bean.setPrecio(c.getString(5));
                            bean.setPeso(c.getString(6));
                            bean.setImagen(c.getString(7));
                            bean.setImg(c.getBlob(8));
                            objlstCategoria.add(bean);
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

            return objlstCategoria;
        }

    }