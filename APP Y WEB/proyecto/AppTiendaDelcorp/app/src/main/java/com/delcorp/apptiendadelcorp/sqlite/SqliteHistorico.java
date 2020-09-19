package com.delcorp.apptiendadelcorp.sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.delcorp.apptiendadelcorp.bean.Carrito;

import java.util.ArrayList;

public class SqliteHistorico {

    public Integer insertarHistorico(Context context,
                                   String idCliente,
                                   String IdVendedor,
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
                                   String cant,
                                   byte[] Img,
                                   String IdCarrito,
                                   String IdPromocion,
                                   String IdCondicion,
                                   String IdBonificacion) {

        SqlLiteDB sql;
        SQLiteDatabase db = null;
        Integer i = 0;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                ContentValues cv = new ContentValues();
                cv.put("IdCliente", idCliente);
                cv.put("IdVendedor",IdVendedor);
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
                cv.put("cant", cant);
                cv.put("Img", Img);
                cv.put("IdCarrito", IdCarrito);
                cv.put("IdPromocion", IdPromocion);
                cv.put("IdCondicion", IdCondicion);
                cv.put("IdBonificacion", IdBonificacion);
                db.insert("thistorico", null, cv);
                Cursor c = db.rawQuery("select Id from thistorico order by Id desc limit 1 ", null);

                if (c.moveToFirst()) {
                    do {
                        i =Integer.parseInt(c.getString(0));
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

        return i;
    }

    public void eliminarhistorico(Context context ) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("thistorico", null,   null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }

    public String UnidadesxProductoHistorico(Context context, String IdProducto) {
        String cant ="0";
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Carrito> objlstCarrito = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCarrito = new ArrayList<Carrito>();
            if (db != null) {
                Cursor c = db.rawQuery("select sum(Cant) as monto from thistorico where IdProductoTxt='"+IdProducto+"'  and IdPromocion='' group by IdProductoTxt ", null);
                if (c.moveToFirst()) {
                    do {

                        cant = c.getString(0);
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
        return cant;
    }

    public String MontoxProductoHistorico(Context context, String IdProducto) {
        String monto ="0";
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Carrito> objlstCarrito = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCarrito = new ArrayList<Carrito>();
            if (db != null) {
                Cursor c = db.rawQuery("select  sum(Precio * Cant) as monto from thistorico where IdProductoTxt="+IdProducto+"   and IdPromocion='' group by IdProductoTxt ", null);
                if (c.moveToFirst()) {
                    do {

                        monto = c.getString(0);
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


        return monto;
    }


    public String MontoxCategoriaHistorico(Context context, String IdCategoria) {
        String monto ="0";
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Carrito> objlstCarrito = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCarrito = new ArrayList<Carrito>();
            if (db != null) {
                Cursor c = db.rawQuery("select  sum(Precio * Cant) as monto from thistorico where IdCategoriaPadre='"+IdCategoria+"' and Precio!='0'   group by IdCategoriaPadre ", null);
                if (c.moveToFirst()) {
                    do {
                        monto = c.getString(0);
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


        return monto;
    }


}
