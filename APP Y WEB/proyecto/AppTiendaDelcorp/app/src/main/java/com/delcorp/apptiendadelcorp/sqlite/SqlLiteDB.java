package com.delcorp.apptiendadelcorp.sqlite;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteDatabase.CursorFactory;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

public class SqlLiteDB extends SQLiteOpenHelper {

    static final String name = "BDxmarketstartt30";
    static final int version = 1;
    Context contexto;

    public SqlLiteDB(Context context, String name, CursorFactory factory, int version) {
        super(context, name, factory, version);
    }

    public SqlLiteDB(Context context){
        super(context, name, null, version);
        this.contexto = context;
    }

    @Override
    public void onCreate(SQLiteDatabase db) {

        try {
            String tcategoria = "CREATE TABLE IF NOT EXISTS tcategoria("+
              "IdCategoria  text,  IdUp text, Stock text, Nombre text,Descripcion text,Precio text,Peso text,Imagen text,Img BLOB);";
            db.execSQL(tcategoria);


          String tproducto = "CREATE TABLE IF NOT EXISTS tproducto("+
                    "IdProductoCategoria text,IdProductoTxt text, IdCategoria text,IdCategoriaPadre text, IdFabricante text, NombrePro text, Descripcion text, Precio text, Peso text, Imagen text, IdAlmacen text, Stock text,Img BLOB, visible text);";
            db.execSQL(tproducto);

              String tcarrito = "CREATE TABLE IF NOT EXISTS tcarrito("+
                    "Id integer primary key autoincrement,IdCliente text,IdVendedor text,IdProductoTxt text, IdCategoria text,IdCategoriaPadre text, IdFabricante text,NombrePro text ,Descripcion text,Precio text,Peso text,Imagen text,IdAlmacen text,Stock text ,Cant text,Img BLOB,IdCarrito text ,IdPromocion text,IdCondicion text ,IdBonificacion text,cantSuge text,IdPedido text);";
            db.execSQL(tcarrito);

            String tcliente = "CREATE TABLE IF NOT EXISTS tcliente("+
                    "CodigoTxt text,IdUsuario text,Nombre text,Paterno text,Materno text,Direccion text,Latitud text,Longitud text,DiasVisita text,ActivaTotalClientes text,VisitadoHoy text);";
            db.execSQL(tcliente);

            String tpedido = "CREATE TABLE IF NOT EXISTS tpedido("+
                    "IdPedido integer primary key autoincrement,IdPedidoSql integer , IdUsuario text,nomCliente text,CodigoTxt text,IdCondicionVenta text,IdUsuarioVenta text,TotalPagar text,Items text,Latitud text,Longitud text,FlagTipoRegistro text,Fecha text,FlagSincronizado text);";
            db.execSQL(tpedido);

            String tpedidodetalle = "CREATE TABLE IF NOT EXISTS tpedidodetalle(" +
                    "IdPedido text,IdProductoTxt text,Precio text,Cantidad text,SubTotal text);";
            db.execSQL(tpedidodetalle);

            String tvisita = "CREATE TABLE IF NOT EXISTS tvisita(" +
                    "IdVisita integer primary key autoincrement,IdCliente text,IdVendedor text,FechaRegistro text ,FlagSincronizado text);";
            db.execSQL(tvisita);

            String tsugerido = "CREATE TABLE IF NOT EXISTS tsugerido(" +
                    "IdSugerido integer primary key autoincrement,IdCliente text,IdVendedor text,Flag text);";
            db.execSQL(tsugerido);


            String tpromocionvista = "CREATE TABLE IF NOT EXISTS tpromocionvista(" +
                "IdPromocion text,IdPromocionCondicion text ,IdPromocionBonificacion text ,Flag text );";
            db.execSQL(tpromocionvista);

            String thistorico = "CREATE TABLE IF NOT EXISTS thistorico("+
                    "Id integer primary key autoincrement,IdCliente text,IdVendedor text,IdProductoTxt text, IdCategoria text,IdCategoriaPadre text, IdFabricante text,NombrePro text ,Descripcion text,Precio text,Peso text,Imagen text,IdAlmacen text,Stock text ,Cant text,Img BLOB,IdCarrito text ,IdPromocion text,IdCondicion text ,IdBonificacion text);";
            db.execSQL(thistorico);

            String tpromocioncabecera = "CREATE TABLE IF NOT EXISTS tpromocioncabecera("+
                    "IdPromocion text,flagHistorico text,IdCondicion text,IdTipoCondicion text, IdTipoPromocion text,IdTipoBonificacion text,MontoBonificacion text,IdTipoUsuario text,flagPrimeraCompra text);";
            db.execSQL(tpromocioncabecera);

            String tcondicion = "CREATE TABLE IF NOT EXISTS tcondicion("+
                    "IdPromocionCondicion text, IdPromocion text,IdProducto text,IdCategoria text,IdGrupo text,Cantidad text,Descripcion text );";
            db.execSQL(tcondicion);

            String tbonificacion= "CREATE TABLE IF NOT EXISTS tbonificacion("+
                    "IdPromocionBonificacion text,IdPromocion text,IdProducto text,IdGrupo text,Cantidad text, Stock text);";
            db.execSQL(tbonificacion);

        }catch (Exception e){
            Log.e("Error DB", e.toString());
        }
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {

        db.execSQL("drop table if exists tcategoria");
        db.execSQL("drop table if exists tproducto");
        db.execSQL("drop table if exists tcarrito");
        db.execSQL("drop table if exists tcliente");
        db.execSQL("drop table if exists tpedido");
        db.execSQL("drop table if exists tpedidodetalle");
        db.execSQL("drop table if exists tvisita");
        db.execSQL("drop table if exists tsugerido");
       // db.execSQL("drop table if exists tpromocion");
       // db.execSQL("drop table if exists tpromocionvista");
        db.execSQL("drop table if exists thistorico");

        db.execSQL("drop table if exists tpromocioncabecera");
        db.execSQL("drop table if exists tcondicion");
        db.execSQL("drop table if exists tbonificacion");
        onCreate(db);
    }
}
