package com.delcorp.apptiendadelcorp.sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.delcorp.apptiendadelcorp.bean.Carrito;
import com.delcorp.apptiendadelcorp.bean.Categoria;

import java.util.ArrayList;

public class SqliteCarrito {

    public Integer insertarCarrito(Context context,
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
                                    String IdBonificacion,

                                   String cantSuge,
                                   String IdPedido) {

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
                cv.put("cantSuge",cantSuge);
                cv.put("IdPedido",IdPedido);
                db.insert("tcarrito", null, cv);
                Cursor  c = db.rawQuery("select Id from tcarrito order by Id desc limit 1 ", null);

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

    public void actualizaCarrito(Context context,String IdCliente,String IdVendedor, String IdProductoTxt,String Cant) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            ContentValues values = new ContentValues();
            values.put("Cant",Cant);

            if (db != null) {
                db.update("tcarrito", values,"IdCliente = ? and IdVendedor = ? and IdProductoTxt  = ?   ", new String[] {IdCliente,IdVendedor,IdProductoTxt});

            }

        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }


    public void actualizaStockCarrito(Context context, String IdProductoTxt,String Stock) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            ContentValues values = new ContentValues();
            values.put("Stock",Stock);

            if (db != null) {
                db.update("tcarrito", values,"  IdProductoTxt  = ?   ", new String[] { IdProductoTxt});

            }

        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }



    public void actualizaCarritoxId(Context context,String Id,String Cant) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            ContentValues values = new ContentValues();
            values.put("Cant",Cant);

            if (db != null) {
                db.update("tcarrito", values,"Id  = ?  ", new String[] {Id});

            }

        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }



     public ArrayList<String> listarPromoEnElCarrito(Context context) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<String> lst = new ArrayList<>();
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();

            if (db != null) {
                Cursor c = db.rawQuery("SELECT IdPromocion  FROM tcarrito where IdPromocion!=''  group by IdPromocion", null);
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





    public Integer existeProductoXIdProducto(Context context,String IdCliente,String IdVendedor,String IdProducto) {
        Integer i = 0;
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<String> lst = new ArrayList<>();
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();

            if (db != null) {
                Cursor c = db.rawQuery("SELECT IdPromocion  FROM tcarrito where IdCliente='"+IdCliente+"' and IdVendedor='"+IdVendedor+"' and IdProductoTxt='"+IdProducto+"'", null);
                if (c.moveToFirst()) {
                    do {
                        lst.add(c.getString(0));
                    } while (c.moveToNext());
                }
                if(c.getCount()>0){
                    i=1;
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

    public Integer cantidadProductoEnCarritoXIdProducto(Context context,String IdCliente,String IdVendedor,String IdProducto) {
        Integer i = 0;
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<String> lst = new ArrayList<>();
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();

            if (db != null) {
                Cursor c = db.rawQuery("SELECT Cant  FROM tcarrito where IdCliente='"+IdCliente+"' and IdVendedor='"+IdVendedor+"' and IdProductoTxt='"+IdProducto+"'", null);
                if (c.moveToFirst()) {
                    do {
                        i =c.getInt(0);
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


    public void eliminarBonificacionesCarrito(Context context  ) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("tcarrito", "IdPromocion!=''",   null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }
    public void eliminarBoniXIdCategoria(Context context  ) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("tcarrito", "IdPromocion!=''",   null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }

    public void eliminarCarritoxId(Context context,String id) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("tcarrito", "Id="+id, null);
                db.delete("tcarrito", "IdCarrito="+id, null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }
    public void eliminarCarritoxIdUsuarioCiente(Context context,String IdCliente,String IdVendedor) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                db.delete("tcarrito", "IdCliente='"+IdCliente+"' and IdVendedor='"+IdVendedor+"'", null);
            }
        } catch (Exception e) {
            Log.e("Error DB", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }
    }



    /*LISTA TOD EL CARRO PARA INSERTARLO*/
    public ArrayList<Carrito> listarTodoCarro(Context context,String IdCliente,String IdVendedor) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Carrito> objlstCarrito = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCarrito = new ArrayList<Carrito>();
            if (db != null) {
                Cursor c = db.rawQuery("SELECT * FROM tcarrito where IdCliente='"+IdCliente+"' and IdVendedor='"+IdVendedor+"' and Cant!=0 and Stock!=0", null);
                if (c.moveToFirst()) {
                    do {
                        Carrito bean = new Carrito();
                        bean.setId(c.getInt(0));
                        bean.setIdCliente(c.getString(1));
                        bean.setIdVendedor(c.getString(2));
                        bean.setIdProductoTxt(c.getString(3));
                        bean.setIdCategoria(c.getString(4));
                        bean.setIdCategoriaPadre(c.getString(5));
                        bean.setIdFabricante(c.getString(6));
                        bean.setNombrePro(c.getString(7));
                        bean.setDescripcion(c.getString(8));
                        bean.setPrecio(c.getString(9));
                        bean.setPeso(c.getString(10));
                        bean.setImagen(c.getString(11));
                        bean.setIdAlmacen(c.getString(12));
                        bean.setStock(c.getString(13));
                        bean.setCant(c.getString(14));
                        bean.setImg(c.getBlob(15));

                        bean.setIdPromocion(c.getString(17));
                        bean.setIdCondicion(c.getString(18));
                        bean.setIdBonificacion(c.getString(19));

                        bean.setCantSuge(c.getString(20));
                        bean.setIdPedido(c.getString(21));

                        objlstCarrito.add(bean);
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

        return objlstCarrito;
    }


    public ArrayList<Categoria> listarSubtotales(Context context, String IdCliente, String IdVendedor) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Categoria> objlstCarrito = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCarrito = new ArrayList<Categoria>();
            if (db != null) {
                Cursor c = db.rawQuery("select (select Nombre from tcategoria where   IdCategoria =c.IdCategoriaPadre) as cat, sum(c.Precio*c.Cant) from tcarrito c where   IdCliente='"+IdCliente+"' and IdVendedor='"+IdVendedor+"' and IdCategoriaPadre!='' group by IdCategoriaPadre", null);
                if (c.moveToFirst()) {
                    do {
                        Categoria bean = new Categoria();
                        bean.setNombre(c.getString(0));
                        bean.setStock(c.getString(1 ));

                        objlstCarrito.add(bean);
                    } while (c.moveToNext());
                }
            }
        } catch (Exception e) {
            Log.e("Error DBbbbb", e.toString());
        } finally {
            if (db.isOpen()) {
                db.close();
            }
        }

        return objlstCarrito;
    }



/**/
    public ArrayList<Carrito> listarCarrito(Context context,String IdCliente,String IdVendedor) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Carrito> objlstCarrito = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCarrito = new ArrayList<Carrito>();
            if (db != null) {
                Cursor c = db.rawQuery("SELECT * FROM tcarrito where IdCliente='"+IdCliente+"' and IdVendedor='"+IdVendedor+"' and Precio!='0'", null);
                if (c.moveToFirst()) {
                    do {
                        Carrito bean = new Carrito();
                        bean.setId(c.getInt(0));
                        bean.setIdCliente(c.getString(1));
                        bean.setIdVendedor(c.getString(2));
                        bean.setIdProductoTxt(c.getString(3));
                        bean.setIdCategoria(c.getString(4));
                        bean.setIdCategoriaPadre(c.getString(5));
                        bean.setIdFabricante(c.getString(6));
                        bean.setNombrePro(c.getString(7));
                        bean.setDescripcion(c.getString(8));
                        bean.setPrecio(c.getString(9));
                        bean.setPeso(c.getString(10));
                        bean.setImagen(c.getString(11));
                        bean.setIdAlmacen(c.getString(12));
                        bean.setStock(c.getString(13));
                        bean.setCant(c.getString(14));
                        bean.setImg(c.getBlob(15));

                        bean.setIdPromocion(c.getString(17));
                        bean.setIdCondicion(c.getString(18));
                        bean.setIdBonificacion(c.getString(19));

                        bean.setCantSuge(c.getString(20));
                        bean.setIdPedido(c.getString(21));
                        objlstCarrito.add(bean);
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

        return objlstCarrito;
    }

    public Double MontoxCatCarrito(Context context,String IdCliente,String IdVendedor,String IdCategoria) {
        Double valor = 0.0;

        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Carrito> objlstCarrito = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCarrito = new ArrayList<Carrito>();
            if (db != null) {
                Cursor c = db.rawQuery("select  sum(Precio * Cant) as monto from tcarrito where   IdCategoriaPadre ='"+IdCategoria+"' and IdCliente='"+IdCliente+"' and IdVendedor='"+IdVendedor+"' and IdPromocion=''  group by IdCategoriaPadre ", null);
                if (c.moveToFirst()) {
                    do {

                        valor = (c.getDouble(0));

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

        return valor;
    }
    public Integer UnixProdCarrito(Context context,String IdCliente,String IdVendedor,String IdProducto) {
        Integer valor = 0;

        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Carrito> objlstCarrito = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCarrito = new ArrayList<Carrito>();
            if (db != null) {
                Cursor c = db.rawQuery("select  sum(Cant) as monto from tcarrito where   IdProductoTxt ='"+IdProducto+"' and IdCliente='"+IdCliente+"' and IdVendedor='"+IdVendedor+"' and IdPromocion=''  group by IdProductoTxt ", null);
                if (c.moveToFirst()) {
                    do {

                        valor = (c.getInt(0));

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

        return valor;
    }

    public ArrayList<Carrito> listarTotalxCategoria(Context context,String IdCliente,String IdVendedor) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Carrito> objlstCarrito = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCarrito = new ArrayList<Carrito>();
            if (db != null) {
                Cursor c = db.rawQuery("select IdCategoriaPadre,sum(Precio * Cant) as monto from tcarrito where IdCategoria!=0 and IdCliente='"+IdCliente+"' and IdVendedor='"+IdVendedor+"' and IdPromocion=''  group by IdCategoriaPadre ", null);
                if (c.moveToFirst()) {
                    do {
                        Carrito bean = new Carrito();

                        bean.setIdCategoriaPadre(c.getString(0));
                        bean.setPrecio(c.getString(1));

                        objlstCarrito.add(bean);
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

        return objlstCarrito;
    }



    public ArrayList<Carrito> listarTotalxProducto(Context context,String IdCliente,String IdVendedor) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Carrito> objlstCarrito = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCarrito = new ArrayList<Carrito>();
            if (db != null) {
                Cursor c = db.rawQuery("select IdProductoTxt,sum(Precio * Cant)  from tcarrito where IdCliente='"+IdCliente+"' and IdVendedor='"+IdVendedor+"' and IdPromocion='' group by IdProductoTxt ", null);
                if (c.moveToFirst()) {
                    do {
                        Carrito bean = new Carrito();

                        bean.setIdProductoTxt(c.getString(0));
                        bean.setPrecio(c.getString(1));

                        objlstCarrito.add(bean);
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

        return objlstCarrito;
    }


    public ArrayList<Carrito> listarBoni(Context context,String IdCliente,String IdVendedor) {
        SqlLiteDB sql;
        SQLiteDatabase db = null;
        ArrayList<Carrito> objlstCarrito = null;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getReadableDatabase();
            objlstCarrito = new ArrayList<Carrito>();
            if (db != null) {
                Cursor c = db.rawQuery("SELECT Id,IdCliente,IdVendedor,IdProductoTxt,IdCategoria,IdCategoriaPadre,IdFabricante, NombrePro,Descripcion,Precio,Peso,Imagen,IdAlmacen,Stock,Sum(Cant)  ,Img,IdCarrito,IdPromocion,IdCondicion,IdBonificacion,cantSuge,IdPedido FROM tcarrito where  IdCliente='"+IdCliente+"' and IdVendedor='"+IdVendedor+"' and Precio='0' group by  IdProductoTxt", null);
                if (c.moveToFirst()) {
                    do {
                        Carrito bean = new Carrito();
                        bean.setId(c.getInt(0));
                        bean.setIdCliente(c.getString(1));
                        bean.setIdVendedor(c.getString(2));
                        bean.setIdProductoTxt(c.getString(3));
                        bean.setIdCategoria(c.getString(4));
                        bean.setIdCategoriaPadre(c.getString(5));
                        bean.setIdFabricante(c.getString(6));
                        bean.setNombrePro(c.getString(7));
                        bean.setDescripcion(c.getString(8));
                        bean.setPrecio(c.getString(9));
                        bean.setPeso(c.getString(10));
                        bean.setImagen(c.getString(11));
                        bean.setIdAlmacen(c.getString(12));
                        bean.setStock(c.getString(13));
                        bean.setCant(c.getString(14));
                        bean.setImg(c.getBlob(15));

                        bean.setIdPromocion(c.getString(17));
                        bean.setIdCondicion(c.getString(18));
                        bean.setIdBonificacion(c.getString(19));

                        bean.setCantSuge(c.getString(20));
                        bean.setIdPedido(c.getString(21));

                        objlstCarrito.add(bean);
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

        return objlstCarrito;
    }
    public Integer cantidadCarrito(Context context, String idCliente ,String IdVendedor)  {

        SqlLiteDB sql;
        SQLiteDatabase db = null;
        Integer i = 0;
        try {
            sql = new SqlLiteDB(context);
            db = sql.getWritableDatabase();
            if (db != null) {
                Cursor  c = db.rawQuery("SELECT * FROM tcarrito where IdCliente='"+idCliente+"' and IdVendedor='"+IdVendedor+"'", null);
                i= c.getCount();
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

}
