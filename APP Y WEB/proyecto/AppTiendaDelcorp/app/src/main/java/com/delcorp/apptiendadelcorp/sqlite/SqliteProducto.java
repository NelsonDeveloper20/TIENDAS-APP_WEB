package com.delcorp.apptiendadelcorp.sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.delcorp.apptiendadelcorp.bean.Producto;

import java.util.ArrayList;

public class SqliteProducto {

    public void insertarProducto(Context context,
                                 String IdProductoCategoria,
                                 String IdProductoTxt,
                                 String IdCategoria,
                                 String IdCategoriaPadre,
                                 String IdFabricante,
                                 String NombrePro,
                                 String Descripcion,
                                 String Precio,
                                 String Peso,
                                 String Imagen,
                                 String IdAlmacen,
                                 String Stock,
                                 byte[] Img,
                                 String visible) {

        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                ContentValues cv = new ContentValues();
                cv.put("IdProductoCategoria", IdProductoCategoria);
                cv.put("IdProductoTxt", IdProductoTxt);
                cv.put("IdCategoria", IdCategoria);
                cv.put("IdCategoriaPadre", IdCategoriaPadre);
                cv.put("IdFabricante", IdFabricante);
                cv.put("NombrePro", NombrePro);
                cv.put("Descripcion", Descripcion);
                cv.put("Precio", Precio);
                cv.put("Peso", Peso);
                cv.put("Imagen", Imagen);
                cv.put("IdAlmacen", IdAlmacen);
                cv.put("Stock", Stock);
                cv.put("Img", Img);
                cv.put("visible", visible);
                db.insert("tproducto", null, cv);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }

    public void eliminarProducto(Context context) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("tproducto", null, null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }



    public  Producto BuscarProductoxid(Context context,String idProducto) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
         Producto  objlstProducto  = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            if (db != null) {

                Cursor c = db.rawQuery("SELECT * FROM tproducto WHERE  IdProductoTxt='"+idProducto+"'",null);

                if (c.moveToFirst()) {
                    do {
                        Producto bean = new Producto();
                        bean.setIdProductoCategoria(c.getString(0));
                        bean.setIdProductoTxt(c.getString(1));
                        bean.setIdCategoria(c.getString(2));
                        bean.setIdCategoriaPadre(c.getString(3));
                        bean.setIdFabricante(c.getString(4));
                        bean.setNombrePro(c.getString(5));
                        bean.setDescripcion(c.getString(6));
                        bean.setPrecio(c.getString(7));
                        bean.setPeso(c.getString(8));
                        bean.setImagen(c.getString(9));
                        bean.setIdAlmacen(c.getString(10));
                        bean.setStock(c.getString(11));
                        bean.setImg(c.getBlob(12));
                        bean.setVisible(c.getString(13));
                        objlstProducto = bean;
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

        return objlstProducto;
    }


    public ArrayList<Producto> BuscarProducto(Context context,String nombre,String idTipoAcceso) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Producto> objlstProducto = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstProducto = new ArrayList<Producto>();
            if (db != null) {
                Cursor c;
                if(idTipoAcceso.equals("1")){
                    c = db.rawQuery("SELECT * FROM tproducto WHERE (Precio!=? or visible=?) and \"IdProductoTxt\" || \" \" ||  \"NombrePro\"  LIKE ?   ",new String[]{"0","1","%"+nombre+"%"});

                }else{
                    c = db.rawQuery("SELECT * FROM tproducto WHERE  Precio!=?  and \"IdProductoTxt\" || \" \" ||  \"NombrePro\"  LIKE ?   ",new String[]{"0" ,"%"+nombre+"%"});

                }


                if (c.moveToFirst()) {
                    do {
                        Producto bean = new Producto();
                        bean.setIdProductoCategoria(c.getString(0));
                        bean.setIdProductoTxt(c.getString(1));
                        bean.setIdCategoria(c.getString(2));
                        bean.setIdCategoriaPadre(c.getString(3));
                        bean.setIdFabricante(c.getString(4));
                        bean.setNombrePro(c.getString(5));
                        bean.setDescripcion(c.getString(6));
                        bean.setPrecio(c.getString(7));
                        bean.setPeso(c.getString(8));
                        bean.setImagen(c.getString(9));
                        bean.setIdAlmacen(c.getString(10));
                        bean.setStock(c.getString(11));
                        bean.setImg(c.getBlob(12));
                        bean.setVisible(c.getString(13));
                        objlstProducto.add(bean);
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

        return objlstProducto;
    }

    public ArrayList<Producto> listarProductosXIdCat(Context context,String IdCat,String idTipoAcceso) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Producto> objlstProducto = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstProducto = new ArrayList<Producto>();
            if (db != null) {

                Cursor c;
                if(idTipoAcceso.equals("1")){
                    c = db.rawQuery("SELECT * FROM tproducto where IdCategoria=" + IdCat + " and (Precio!=0  or visible=1) order by NombrePro asc", null);

                }else {

                    c = db.rawQuery("SELECT * FROM tproducto where IdCategoria=" + IdCat + " and Precio!=0 order by NombrePro asc", null);

                }

                if (c.moveToFirst()) {
                    do {
                        Producto bean = new Producto();
                        bean.setIdProductoCategoria(c.getString(0));
                        bean.setIdProductoTxt(c.getString(1));
                        bean.setIdCategoria(c.getString(2));
                        bean.setIdCategoriaPadre(c.getString(3));
                        bean.setIdFabricante(c.getString(4));
                        bean.setNombrePro(c.getString(5));
                        bean.setDescripcion(c.getString(6));
                        bean.setPrecio(c.getString(7));
                        bean.setPeso(c.getString(8));
                        bean.setImagen(c.getString(9));
                        bean.setIdAlmacen(c.getString(10));
                        bean.setStock(c.getString(11));
                        bean.setImg(c.getBlob(12));
                        bean.setVisible(c.getString(13));
                        objlstProducto.add(bean);
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

        return objlstProducto;
    }

    public String obtenerStock(Context context ,String IdProductoTxt ) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        String stock = "0";
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();

            if (db != null) {

                Cursor
                      c = db.rawQuery("SELECT * FROM tproducto where    IdProductoTxt='"+IdProductoTxt+"'  ", null);



                if (c.moveToFirst()) {
                    do {

                        stock =(c.getString(11));



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

        return stock;
    }


    public ArrayList<Producto> listarProductosTodos(Context context ,String idTipoAcceso) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Producto> objlstProducto = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstProducto = new ArrayList<Producto>();
            if (db != null) {

                Cursor c;
                if(idTipoAcceso.equals("1")){
                      c = db.rawQuery("SELECT * FROM tproducto where    Precio!=0 order by NombrePro asc", null);
                }else{
                      c = db.rawQuery("SELECT * FROM tproducto where    (Precio!=0  or visible=1) order by NombrePro asc", null);
                }

                if (c.moveToFirst()) {
                    do {
                        Producto bean = new Producto();
                        bean.setIdProductoCategoria(c.getString(0));
                        bean.setIdProductoTxt(c.getString(1));
                        bean.setIdCategoria(c.getString(2));
                        bean.setIdCategoriaPadre(c.getString(3));
                        bean.setIdFabricante(c.getString(4));
                        bean.setNombrePro(c.getString(5));
                        bean.setDescripcion(c.getString(6));
                        bean.setPrecio(c.getString(7));
                        bean.setPeso(c.getString(8));
                        bean.setImagen(c.getString(9));
                        bean.setIdAlmacen(c.getString(10));
                        bean.setStock(c.getString(11));
                        bean.setImg(c.getBlob(12));
                        bean.setVisible(c.getString(13));
                        objlstProducto.add(bean);
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

        return objlstProducto;
    }



    public void actualizaStockProducto(Context context, String IdProductoTxt,String Stock) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            ContentValues values = new ContentValues();
            values.put("Stock",Stock);

            if (db != null) {
                db.update("tproducto", values,"  IdProductoTxt  = ?   ", new String[] { IdProductoTxt});

            }

        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }


}
