package com.delcorp.apptiendadelcorp.webservice;

import android.content.Context;
import android.content.Intent;

import com.delcorp.apptiendadelcorp.bean.Categoria;
import com.delcorp.apptiendadelcorp.bean.Cliente;
import com.delcorp.apptiendadelcorp.bean.CondicionBonificacion;
import com.delcorp.apptiendadelcorp.bean.DiasVisita;
import com.delcorp.apptiendadelcorp.bean.ParametrosSalida;
import com.delcorp.apptiendadelcorp.bean.PedidoComplementario;
import com.delcorp.apptiendadelcorp.bean.PedidoComplementarioDetalle;
import com.delcorp.apptiendadelcorp.bean.PedidoDetalle;
import com.delcorp.apptiendadelcorp.bean.PedidoDetalleLista;
import com.delcorp.apptiendadelcorp.bean.PedidoDetalleRespuesta;
import com.delcorp.apptiendadelcorp.bean.PedidoO;
import com.delcorp.apptiendadelcorp.bean.Producto;
import com.delcorp.apptiendadelcorp.bean.ProductoSugerido;
import com.delcorp.apptiendadelcorp.bean.Promocion;
import com.delcorp.apptiendadelcorp.bean.ReporteMeta;
import com.delcorp.apptiendadelcorp.sqlite.SqliteCarrito;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePedido;
import com.delcorp.apptiendadelcorp.sqlite.SqlitePedidoDetalle;
import com.delcorp.apptiendadelcorp.sqlite.SqliteProducto;
import com.delcorp.apptiendadelcorp.sqlite.SqliteVisita;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.ConnectException;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;

public class WebService {

//SERVIDOR NRH
    private static final String api = "http://192.168.0.159/ApiDelcorpTienda/api";
    private int flag =9 ;
    private String mensaje = "";

    public ParametrosSalida cancelaPedidoComp(String IdUsuario,String IdPedido)  {

        String Controlador = "/CancelaPedidoComp";

        try {

            URL url = new URL(api + Controlador);
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setDoOutput(true);
            httpcon.setRequestMethod("POST");
            httpcon.setRequestProperty("Content-Type", "application/json");

            JSONObject jsonObject= new JSONObject();
            jsonObject.put("IdUsuario", IdUsuario);
            jsonObject.put("IdPedido", IdPedido);

            OutputStream os = httpcon.getOutputStream();
            os.write(jsonObject.toString().getBytes());
            os.flush();

            InputStream inputStream = new BufferedInputStream(httpcon.getInputStream());

            BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
            JSONObject jsonObject2 = new JSONObject(reader.readLine());
            flag = Integer.parseInt(jsonObject2.getString("FlagIndicador"));
            mensaje = jsonObject2.getString("MsgValidacion");
            httpcon.disconnect();

        } catch (ConnectException e) {
            flag = 2;
            mensaje = "Error: " + e.toString();
        } catch (MalformedURLException e) {
            flag = 3;
            mensaje = "Error: " + e.toString();
        } catch (IOException e) {
            flag = 4;
            mensaje = "Error: " + e.toString();
        } catch (JSONException e) {
            flag = 5;
            mensaje = "Error: " + e.toString();
        }
        return new ParametrosSalida(flag,mensaje );
    }
    public ParametrosSalida ValidarUsuario(String User,String Clave,String token)  {

        String Controlador = "/Loginv2";
        String idUsuario = "", nombre = ""  ,idTipoUsuario="",idTipoAcceso="" ,CodigoTxt="",flagvalida="";


        try {

            URL url = new URL(api + Controlador);
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setDoOutput(true);
            httpcon.setRequestMethod("POST");
            httpcon.setRequestProperty("Content-Type", "application/json");

            JSONObject jsonObject= new JSONObject();
            jsonObject.put("User", User);
            jsonObject.put("Clave", Clave);
            jsonObject.put("token", token);

            OutputStream os = httpcon.getOutputStream();
            os.write(jsonObject.toString().getBytes());
            os.flush();

            InputStream inputStream = new BufferedInputStream(httpcon.getInputStream());

            BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
            JSONObject jsonObject2 = new JSONObject(reader.readLine());



            flag = Integer.parseInt(jsonObject2.getString("FlagIndicador"));
            mensaje = jsonObject2.getString("MsgValidacion");
            idUsuario = jsonObject2.getString("Param1");
            CodigoTxt = jsonObject2.getString("Param2");
            nombre = jsonObject2.getString("Param3");
            idTipoUsuario = jsonObject2.getString("Param4");
            idTipoAcceso = jsonObject2.getString("Param5");
            flagvalida = jsonObject2.getString("Param7");
            httpcon.disconnect();

        } catch (ConnectException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (MalformedURLException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (IOException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (JSONException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        }
        return new ParametrosSalida(flag,mensaje,idUsuario,CodigoTxt,nombre,idTipoUsuario,idTipoAcceso,flagvalida);
    }


    public ParametrosSalida obtenNumeroVendedor(String User )  {

        String Controlador = "/ObtenDatosVendedor";
        String celular = "", nombre = ""   ;

        try {

            URL url = new URL(api + Controlador);
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setDoOutput(true);
            httpcon.setRequestMethod("POST");
            httpcon.setRequestProperty("Content-Type", "application/json");

            JSONObject jsonObject= new JSONObject();
            jsonObject.put("User", User);

            OutputStream os = httpcon.getOutputStream();
            os.write(jsonObject.toString().getBytes());
            os.flush();

            InputStream inputStream = new BufferedInputStream(httpcon.getInputStream());

            BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
            JSONObject jsonObject2 = new JSONObject(reader.readLine());

            flag = Integer.parseInt(jsonObject2.getString("FlagIndicador"));
            mensaje = jsonObject2.getString("MsgValidacion");
            nombre = jsonObject2.getString("Param1");
            celular = jsonObject2.getString("Param2");
            httpcon.disconnect();

        } catch (ConnectException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (MalformedURLException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (IOException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (JSONException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        }
        return new ParametrosSalida(flag,mensaje,nombre,celular);
    }


    public ParametrosSalida cerrarSesion(String User ,String token)  {

        String Controlador = "/CerrarSesion";
        String idUsuario = "", nombre = ""  ,idTipoUsuario="",idTipoAcceso="" ,CodigoTxt="",flagvalida="";


        try {

            URL url = new URL(api + Controlador);
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setDoOutput(true);
            httpcon.setRequestMethod("POST");
            httpcon.setRequestProperty("Content-Type", "application/json");

            JSONObject jsonObject= new JSONObject();
            jsonObject.put("User", User);
            jsonObject.put("token", token);

            OutputStream os = httpcon.getOutputStream();
            os.write(jsonObject.toString().getBytes());
            os.flush();

            InputStream inputStream = new BufferedInputStream(httpcon.getInputStream());

            BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
            JSONObject jsonObject2 = new JSONObject(reader.readLine());

            flag = Integer.parseInt(jsonObject2.getString("FlagIndicador"));
            mensaje = jsonObject2.getString("MsgValidacion");
            httpcon.disconnect();

        } catch (ConnectException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (MalformedURLException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (IOException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (JSONException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        }
        return new ParametrosSalida(flag,mensaje );
    }

    public ParametrosSalida reporteEficiencia(String User )  {

        String Controlador = "/ReporteEficiencia";
        String totalClientes = "", clienteVisitados = "", clientesConPedidos = "", totalPedidos = ""
                , totalPedidosBodega = "", avanceRuta = "", MontoTotalVenta = "", totalItems=""
                , clienteUltimoPedido = "", fechaUltimoPedido = "";
        try {

            URL url = new URL(api + Controlador);
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setDoOutput(true);
            httpcon.setRequestMethod("POST");
            httpcon.setRequestProperty("Content-Type", "application/json");

            JSONObject jsonObject= new JSONObject();
            jsonObject.put("User", User);

            OutputStream os = httpcon.getOutputStream();
            os.write(jsonObject.toString().getBytes());
            os.flush();

            InputStream inputStream = new BufferedInputStream(httpcon.getInputStream());

            BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
            JSONObject jsonObject2 = new JSONObject(reader.readLine());

            flag = Integer.parseInt(jsonObject2.getString("FlagIndicador"));
            mensaje = jsonObject2.getString("MsgValidacion");
            totalClientes = jsonObject2.getString("Param1");
            clienteVisitados = jsonObject2.getString("Param2");
            clientesConPedidos = jsonObject2.getString("Param3");
            totalPedidos = jsonObject2.getString("Param4");
            totalPedidosBodega = jsonObject2.getString("Param5");
            avanceRuta = jsonObject2.getString("Param6");
            MontoTotalVenta = jsonObject2.getString("Param7");
            totalItems = jsonObject2.getString("Param8");
            clienteUltimoPedido = jsonObject2.getString("Param9");
            fechaUltimoPedido = jsonObject2.getString("Param10");
            httpcon.disconnect();

        } catch (ConnectException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (MalformedURLException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (IOException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (JSONException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        }
        return new ParametrosSalida(flag,mensaje,totalClientes,clienteVisitados,clientesConPedidos,totalPedidos,totalPedidosBodega
                ,avanceRuta,MontoTotalVenta,totalItems,clienteUltimoPedido,fechaUltimoPedido);
    }

    public ParametrosSalida obtenDatos(String IdUsuario)  {

        String Controlador = "/DatosPersonales";
        String  Nombre = "",Paterno = "", Materno = "",Celular = "",Telefono = "",dni = "",
                ruc = "",RazonSocial = "", Direccion = "", Correo = "";

        try {

            URL url = new URL(api + Controlador);
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setDoOutput(true);
            httpcon.setRequestMethod("POST");
            httpcon.setRequestProperty("Content-Type", "application/json");

            JSONObject jsonObject= new JSONObject();
            jsonObject.put("CodigoTxt", IdUsuario);

            OutputStream os = httpcon.getOutputStream();
            os.write(jsonObject.toString().getBytes());
            os.flush();

            InputStream inputStream = new BufferedInputStream(httpcon.getInputStream());

            BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
            JSONObject jsonObject2 = new JSONObject(reader.readLine());

            flag = Integer.parseInt(jsonObject2.getString("FlagIndicador"));
            mensaje = jsonObject2.getString("MsgValidacion");
            Nombre = jsonObject2.getString("Param1");
            Paterno = jsonObject2.getString("Param2");
            Materno = jsonObject2.getString("Param3");
            Celular = jsonObject2.getString("Param4");
            Telefono = jsonObject2.getString("Param5");
            dni = jsonObject2.getString("Param6");
            ruc = jsonObject2.getString("Param7");
            RazonSocial = jsonObject2.getString("Param8");
            Direccion = jsonObject2.getString("Param9");
            Correo = jsonObject2.getString("Param10");
            httpcon.disconnect();

        } catch (ConnectException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (MalformedURLException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (IOException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (JSONException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        }
        return new ParametrosSalida(flag,mensaje,Nombre,Paterno,Materno,Celular,Telefono,dni,ruc,RazonSocial,Direccion,Correo);
    }
    public ParametrosSalida insertarCliente(
String Nombre,  String Paterno,String Materno,String Celular,
String Telefono,String dni,String ruc,String RazonSocial,
String Direccion,String Referencia,String Latitud,String Longitud,
String Correo,String usuario,String clave,String IdTxtVendedor)  {
        String Controlador = "/RegistrarCliente";
        try {

            URL url = new URL(api + Controlador);
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setDoOutput(true);
            httpcon.setRequestMethod("POST");
            httpcon.setRequestProperty("Content-Type", "application/json");

            JSONObject jsonObject= new JSONObject();
            jsonObject.put("Nombre",Nombre);
            jsonObject.put("Paterno",Paterno);
            jsonObject.put("Materno",Materno);
            jsonObject.put("Celular",Celular);
            jsonObject.put("Telefono",Telefono);
            jsonObject.put("dni",dni);
            jsonObject.put("ruc",ruc);
            jsonObject.put("RazonSocial",RazonSocial);
            jsonObject.put("Direccion",Direccion);
            jsonObject.put("Referencia",Referencia);
            jsonObject.put("Latitud",Latitud);
            jsonObject.put("Longitud",Longitud);
            jsonObject.put("Correo",Correo);
            jsonObject.put("usuario",usuario);
            jsonObject.put("clave",clave);
            jsonObject.put("IdTxtVendedor",IdTxtVendedor);


            OutputStream os = httpcon.getOutputStream();
            os.write(jsonObject.toString().getBytes());
            os.flush();

            InputStream inputStream = new BufferedInputStream(httpcon.getInputStream());

            BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
            JSONObject jsonObject2 = new JSONObject(reader.readLine());

            flag = Integer.parseInt(jsonObject2.getString("FlagIndicador"));
            mensaje = jsonObject2.getString("MsgValidacion");
            httpcon.disconnect();

        } catch (ConnectException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (MalformedURLException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (IOException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (JSONException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        }
        return new ParametrosSalida(flag,mensaje );
    }





    public ParametrosSalida modificaDatos(String CodigoTxt, String Nombre,String Paterno, String Materno,String Celular, String Telefono
            ,String dni, String ruc,String RazonSocial, String Direccion,String Correo)  {

        String Controlador = "/ModificaDatosPersonales";

        try {

            URL url = new URL(api + Controlador);
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setDoOutput(true);
            httpcon.setRequestMethod("POST");
            httpcon.setRequestProperty("Content-Type", "application/json");

            JSONObject jsonObject= new JSONObject();
            jsonObject.put("CodigoTxt", CodigoTxt);
            jsonObject.put("Nombre", Nombre);
            jsonObject.put("Paterno", Paterno);
            jsonObject.put("Materno", Materno);
            jsonObject.put("Celular", Celular);
            jsonObject.put("Telefono", Telefono);
            jsonObject.put("dni", dni);
            jsonObject.put("ruc", ruc);
            jsonObject.put("RazonSocial", RazonSocial);
            jsonObject.put("Direccion", Direccion);
            jsonObject.put("Correo", Correo);

            OutputStream os = httpcon.getOutputStream();
            os.write(jsonObject.toString().getBytes());
            os.flush();

            InputStream inputStream = new BufferedInputStream(httpcon.getInputStream());

            BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
            JSONObject jsonObject2 = new JSONObject(reader.readLine());

            flag = Integer.parseInt(jsonObject2.getString("FlagIndicador"));
            mensaje = jsonObject2.getString("MsgValidacion");
            httpcon.disconnect();

        } catch (ConnectException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (MalformedURLException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (IOException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (JSONException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        }
        return new ParametrosSalida(flag,mensaje );
    }





    public ArrayList<Promocion> ListaPromociones (String idUsuario){

        ArrayList<Promocion> arrayPromocion = new ArrayList<Promocion>();
        Promocion objPromocion = null;


        String IdPromocion="",flagHistorico="",IdCondicion="",IdTipoCondicion="",IdTipoPromocion="",IdTipoBonificacion="",
                MontoBonificacion="",IdPromocionCondicion="",IdTipoUsuario="",flagPrimeraCompra="" ;

        String controlador = "/ListaPromoCabeceraV2?idUsuario="+idUsuario;
        try
        {
            URL url = new URL(api + controlador );
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setRequestMethod("GET");

            InputStream inputStream= new BufferedInputStream(httpcon.getInputStream());
            BufferedReader bufferedReader= new BufferedReader(new InputStreamReader(inputStream));
            JSONArray jsonArray= new JSONArray(bufferedReader.readLine());

            for(int i=0; i<jsonArray.length(); i++)
            {
                JSONObject obj = jsonArray.getJSONObject(i);

                IdPromocion  = obj.getString("IdPromocion");
                flagHistorico  = obj.getString("flagHistorico");
                IdCondicion = obj.getString("IdCondicion");
                IdTipoCondicion = obj.getString("IdTipoCondicion");
                IdTipoPromocion = obj.getString("IdTipoPromocion");
                IdTipoBonificacion = obj.getString("IdTipoBonificacion");
                MontoBonificacion = obj.getString("MontoBonificacion");
                IdTipoUsuario = obj.getString("IdTipoUsuario");
                flagPrimeraCompra = obj.getString("flagPrimeraCompra");

                objPromocion = new Promocion(IdPromocion,flagHistorico,IdCondicion,IdTipoCondicion
                        ,IdTipoPromocion,IdTipoBonificacion,
                        MontoBonificacion,IdTipoUsuario ,flagPrimeraCompra);

                arrayPromocion.add(objPromocion);
            }

        } catch (ConnectException e) {
            e.printStackTrace() ;
            arrayPromocion=null;
        } catch (MalformedURLException e) {
            e.printStackTrace() ;
            arrayPromocion=null;
        } catch (IOException e) {
            e.printStackTrace() ;
            arrayPromocion=null;
        } catch (JSONException e) {
            e.printStackTrace() ;
            arrayPromocion=null;
        }
        return arrayPromocion;
    }
    public ArrayList<PedidoDetalleRespuesta> EnviarPedidoComp(Context context,String IdPed, String IdUsuarioCliente,
                                                          String nomCliente,
                                                          String CodigoTxt,
                                                          String IdCondicionVenta,
                                                          String IdUsuarioVenta,
                                                          String TotalPagar,
                                                          String Items,
                                                          String Latitud,
                                                          String Longitud,
                                                          String FlagTipoRegistro,
                                                          String Fecha,
                                                          ArrayList<PedidoDetalle> lista)  {

        String IdPedido="";
        String Controlador = "/RegistrarPedidoComp";

        String IdProductoTxt="",NombrePro="",Precio="",Cantidad="",SubTotal="",IdPromocion="",IdCondicion="",IdBonificacion="",Imagen="";


        ArrayList<PedidoDetalleRespuesta> ar = new ArrayList<PedidoDetalleRespuesta>();
        PedidoDetalleRespuesta objPedido = null;

        try {

            URL url = new URL(api + Controlador);
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setDoOutput(true);
            httpcon.setRequestMethod("POST");
            httpcon.setRequestProperty("Content-Type", "application/json");


            JSONArray jsonArray = new JSONArray();
            for (PedidoDetalle c : lista){

                JSONObject jsonObject= new JSONObject();
                jsonObject.put("IdPedido", IdPed);
                jsonObject.put("IdUsuario", IdUsuarioCliente);
                jsonObject.put("CodigoTxt", CodigoTxt);
                jsonObject.put("IdCondicionVenta",  IdCondicionVenta);
                jsonObject.put("IdUsuarioVenta",  IdUsuarioVenta);
                jsonObject.put("TotalPagar",  TotalPagar);
                jsonObject.put("Items",  Items);
                jsonObject.put("Latitud",  Latitud);
                jsonObject.put("Longitud",  Longitud);
                jsonObject.put("FlagTipoRegistro",  FlagTipoRegistro);
                jsonObject.put("Fecha",  Fecha);

                jsonObject.put("IdProductoTxt", c.getIdProductoTxt());
                jsonObject.put("NombrePro", c.getNombrePro());
                jsonObject.put("Precio", c.getPrecio());
                jsonObject.put("Cantidad", c.getCantidad());
                jsonObject.put("SubTotal", c.getSubTotal());

                jsonObject.put("IdPromocion", c.getIdPromocion());
                jsonObject.put("IdCondicion", c.getIdCondicion());
                jsonObject.put("IdBonificacion", c.getIdBonificacion());
                jsonObject.put("Imagen", c.getImagen());

                jsonArray.put(jsonObject);
            }

            OutputStream os = httpcon.getOutputStream();
            os.write(jsonArray.toString().getBytes());
            os.flush();

            InputStream inputStream = new BufferedInputStream(httpcon.getInputStream());
            BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
            JSONArray jsonArrayy= new JSONArray(reader.readLine());


            for(int i=0; i<jsonArrayy.length(); i++)
            {
                JSONObject obj = jsonArrayy.getJSONObject(i);

                IdProductoTxt  = obj.getString("IdProductoTxt");
                NombrePro  = obj.getString("NombrePro");
                Precio = obj.getString("Precio");
                Cantidad = obj.getString("Cantidad");
                SubTotal = obj.getString("SubTotal");
                IdPromocion = obj.getString("IdPromocion");
                IdCondicion = obj.getString("IdCondicion");
                IdBonificacion = obj.getString("IdBonificacion");
                Imagen = obj.getString("Imagen");

                objPedido = new PedidoDetalleRespuesta(IdProductoTxt,NombrePro,Precio,Cantidad,SubTotal,IdPromocion,
                        IdCondicion,IdBonificacion,Imagen);

                ar.add(objPedido);
            }

            httpcon.disconnect();


        } catch (ConnectException e) {
            ar=null;
            //Log.i(TAG,"Error: " + e.toString());
        } catch (MalformedURLException e) {
            ar=null;
            //Log.i(TAG, "Error: " + e.toString());
        } catch (IOException e) {
            ar=null;
            //Log.i(TAG,"Error: " + e.toString());
        } catch (JSONException e) {
            ar=null;
            //Log.i(TAG, "Error: " + e.toString());
        } catch (Exception e){
            ar=null;
        }



        return ar;
    }

    public ArrayList<PedidoDetalleRespuesta> EnviarPedido(Context context, String IdUsuarioCliente,
                                                          String nomCliente,
                                                          String CodigoTxt,
                                                          String IdCondicionVenta,
                                                          String IdUsuarioVenta,
                                                          String TotalPagar,
                                                          String Items,
                                                          String Latitud,
                                                          String Longitud,
                                                          String FlagTipoRegistro,
                                                          String Fecha,
                                                          String IdOrigen,
                                                          ArrayList<PedidoDetalle> lista)  {



        String IdPedido="";
        String Controlador = "/PedidosV6";

        String IdProductoTxt="",NombrePro="",Precio="",Cantidad="",SubTotal="",IdPromocion="",IdCondicion="",IdBonificacion="",Imagen="";


        ArrayList<PedidoDetalleRespuesta> ar = new ArrayList<PedidoDetalleRespuesta>();
        PedidoDetalleRespuesta objPedido = null;

        try {

            URL url = new URL(api + Controlador);
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setDoOutput(true);
            httpcon.setRequestMethod("POST");
            httpcon.setRequestProperty("Content-Type", "application/json");


            JSONArray jsonArray = new JSONArray();
            for (PedidoDetalle c : lista){

                JSONObject jsonObject= new JSONObject();
                jsonObject.put("IdUsuario", IdUsuarioCliente);
                jsonObject.put("CodigoTxt", CodigoTxt);
                jsonObject.put("IdCondicionVenta",  IdCondicionVenta);
                jsonObject.put("IdUsuarioVenta",  IdUsuarioVenta);
                jsonObject.put("TotalPagar",  TotalPagar);
                jsonObject.put("Items",  Items);
                jsonObject.put("Latitud",  Latitud);
                jsonObject.put("Longitud",  Longitud);
                jsonObject.put("FlagTipoRegistro",  FlagTipoRegistro);
                jsonObject.put("Fecha",  Fecha);
                jsonObject.put("IdOrigen",  IdOrigen);

                jsonObject.put("IdProductoTxt", c.getIdProductoTxt());
                jsonObject.put("NombrePro", c.getNombrePro());
                jsonObject.put("Precio", c.getPrecio());
                jsonObject.put("Cantidad", c.getCantidad());
                jsonObject.put("SubTotal", c.getSubTotal());

                jsonObject.put("IdPromocion", c.getIdPromocion());
                jsonObject.put("IdCondicion", c.getIdCondicion());
                jsonObject.put("IdBonificacion", c.getIdBonificacion());
                jsonObject.put("Imagen", c.getImagen());

                jsonArray.put(jsonObject);
            }

            OutputStream os = httpcon.getOutputStream();
            os.write(jsonArray.toString().getBytes());
            os.flush();

            InputStream inputStream = new BufferedInputStream(httpcon.getInputStream());
            BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
            JSONArray jsonArrayy= new JSONArray(reader.readLine());


            for(int i=0; i<jsonArrayy.length(); i++)
            {
                JSONObject obj = jsonArrayy.getJSONObject(i);

                IdProductoTxt  = obj.getString("IdProductoTxt");
                NombrePro  = obj.getString("NombrePro");
                Precio = obj.getString("Precio");
                Cantidad = obj.getString("Cantidad");
                SubTotal = obj.getString("SubTotal");
                IdPromocion = obj.getString("IdPromocion");
                IdCondicion = obj.getString("IdCondicion");
                IdBonificacion = obj.getString("IdBonificacion");
                Imagen = obj.getString("Imagen");

                objPedido = new PedidoDetalleRespuesta(IdProductoTxt,NombrePro,Precio,Cantidad,SubTotal,IdPromocion,
                        IdCondicion,IdBonificacion,Imagen);

                ar.add(objPedido);
            }

            httpcon.disconnect();


        } catch (ConnectException e) {
            ar=null;
            //Log.i(TAG,"Error: " + e.toString());
        } catch (MalformedURLException e) {
            ar=null;
            //Log.i(TAG, "Error: " + e.toString());
        } catch (IOException e) {
            ar=null;
            //Log.i(TAG,"Error: " + e.toString());
        } catch (JSONException e) {
            ar=null;
            //Log.i(TAG, "Error: " + e.toString());
        } catch (Exception e){
            ar=null;
        }



        return ar;
    }

    public ParametrosSalida SincronizarPedido(Context context,
                                         String IdPedido,
                                         String IdUsuarioCliente,
                                         String nomCliente,
                                         String CodigoTxt,
                                         String IdCondicionVenta,
                                         String IdUsuarioVenta,
                                         String TotalPagar,
                                         String Items,
                                         String Latitud,
                                         String Longitud,
                                         String FlagTipoRegistro,
                                         String Fecha,
                                         ArrayList<PedidoDetalle> lista)  {

        String IdPedidoSql="";
        String Controlador = "/PedidosV6";

        try {

            URL url = new URL(api + Controlador);
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setDoOutput(true);
            httpcon.setRequestMethod("POST");
            httpcon.setRequestProperty("Content-Type", "application/json");

            JSONArray jsonArray = new JSONArray();
            for (PedidoDetalle c : lista){

                JSONObject jsonObject= new JSONObject();
                jsonObject.put("IdUsuario", IdUsuarioCliente);
                jsonObject.put("CodigoTxt", CodigoTxt);
                jsonObject.put("IdCondicionVenta",  IdCondicionVenta);
                jsonObject.put("IdUsuarioVenta",  IdUsuarioVenta);
                jsonObject.put("TotalPagar",  TotalPagar);
                jsonObject.put("Items",  Items);
                jsonObject.put("Latitud",  Latitud);
                jsonObject.put("Longitud",  Longitud);
                jsonObject.put("FlagTipoRegistro",  FlagTipoRegistro);
                jsonObject.put("Fecha",  Fecha);

                jsonObject.put("IdProductoTxt", c.getIdProductoTxt());
                jsonObject.put("Precio", c.getPrecio());
                jsonObject.put("Cantidad", c.getCantidad());
                jsonObject.put("SubTotal", c.getSubTotal());

                jsonArray.put(jsonObject);
            }

            OutputStream os = httpcon.getOutputStream();
            os.write(jsonArray.toString().getBytes());
            os.flush();

            InputStream inputStream = new BufferedInputStream(httpcon.getInputStream());
            BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
            JSONObject jsonObject2 = new JSONObject(reader.readLine());
            flag = Integer.parseInt(jsonObject2.getString("FlagIndicador"));
            mensaje = jsonObject2.getString("MsgValidacion");
            IdPedidoSql = jsonObject2.getString("Param1");
            httpcon.disconnect();

        } catch (ConnectException e) {
            flag = 10;
            mensaje = "Error: " + e.toString();
            //Log.i(TAG,"Error: " + e.toString());
        } catch (MalformedURLException e) {
            flag = 10;
            mensaje = "Error: " + e.toString();
            //Log.i(TAG, "Error: " + e.toString());
        } catch (IOException e) {
            flag = 10;
            mensaje = "Error: " + e.toString();
            //Log.i(TAG,"Error: " + e.toString());
        } catch (JSONException e) {
            flag = 10;
            mensaje = "Error: " + e.toString();
            //Log.i(TAG, "Error: " + e.toString());
        } catch (Exception e){
            flag=   10;
            mensaje="Error "+e.toString();
        }

         if (flag==0){

            SqlitePedido  sql = new SqlitePedido();

            sql.actualizaPedido(context,IdPedido,IdPedidoSql);
        }

        return new ParametrosSalida(flag,mensaje);
    }




    public ArrayList<CondicionBonificacion> ListaCondicionesBonificacion (String idUsuario){

        ArrayList<CondicionBonificacion> arrayCondicionBonificacion = new ArrayList<CondicionBonificacion>();
        CondicionBonificacion objCondicionBonificacion = null;


        String IdPromocionCondicion="",IdPromocionBonificacion="",IdPromocion ="",IdProducto="",IdCategoria="",IdGrupo="",Cantidad="",
                                Descripcion="",Stock="" ;

        String controlador = "/ListaCondiBoni?idUsuario="+idUsuario;
        try
        {
            URL url = new URL(api + controlador );
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setRequestMethod("GET");
            InputStream inputStream= new BufferedInputStream(httpcon.getInputStream());
            BufferedReader bufferedReader= new BufferedReader(new InputStreamReader(inputStream));
            JSONArray jsonArray= new JSONArray(bufferedReader.readLine());

            for(int i=0; i<jsonArray.length(); i++)
            {
                JSONObject obj = jsonArray.getJSONObject(i);

                IdPromocionCondicion  = obj.getString("IdPromocionCondicion");
                IdPromocionBonificacion  = obj.getString("IdPromocionBonificacion");
                IdPromocion = obj.getString("IdPromocion");
                IdProducto = obj.getString("IdProducto");
                IdCategoria = obj.getString("IdCategoria");
                IdGrupo = obj.getString("IdGrupo");
                Cantidad = obj.getString("Cantidad");
                Descripcion = obj.getString("Descripcion");
                Stock = obj.getString("Stock");

                objCondicionBonificacion = new CondicionBonificacion(IdPromocionCondicion,IdPromocionBonificacion,IdPromocion
                        ,IdProducto,IdCategoria,IdGrupo, Cantidad,Descripcion,Stock );

                arrayCondicionBonificacion.add(objCondicionBonificacion);
            }

        } catch (ConnectException e) {
            e.printStackTrace() ;
            arrayCondicionBonificacion=null;
        } catch (MalformedURLException e) {
            e.printStackTrace() ;
            arrayCondicionBonificacion=null;
        } catch (IOException e) {
            e.printStackTrace() ;
            arrayCondicionBonificacion=null;
        } catch (JSONException e) {
            e.printStackTrace() ;
            arrayCondicionBonificacion=null;
        }
        return arrayCondicionBonificacion;
    }



    public ArrayList<Categoria> ListaCategoria (String idUsuario,String CodigoTxt){

        ArrayList<Categoria> arrayCategoria = new ArrayList<Categoria>();
        Categoria objCategoriaProducto = null;

        String IdCategoriaProducto="", IdUp="" , Stock=""
        ,Nombre="" ,Descripcion="" ,Precio="", Peso ="",Imagen ="";


        String controlador = "/ListarCategoria?idUsuario="+idUsuario+"&CodigoTxt="+CodigoTxt;
        try
        {
            URL url = new URL(api + controlador );
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setRequestMethod("GET");
            InputStream inputStream= new BufferedInputStream(httpcon.getInputStream());
            BufferedReader bufferedReader= new BufferedReader(new InputStreamReader(inputStream));
            JSONArray jsonArray= new JSONArray(bufferedReader.readLine());


            for(int i=0; i<jsonArray.length(); i++)
            {
                JSONObject obj = jsonArray.getJSONObject(i);

                IdCategoriaProducto = obj.getString("IdCategoria");
                IdUp = obj.getString("IdUp");
                Stock = obj.getString("Stock");
                Nombre = obj.getString("Nombre");
                Descripcion = obj.getString("Descripcion");
                Precio = obj.getString("Precio");
                Peso = obj.getString("Peso");
                Imagen = obj.getString("Imagen");

                objCategoriaProducto = new Categoria( IdCategoriaProducto ,IdUp,Stock,Nombre,
                        Descripcion,Precio,Peso,Imagen);

                arrayCategoria.add(objCategoriaProducto);
            }

        } catch (ConnectException e) {
            e.printStackTrace() ;
            arrayCategoria=null;
        } catch (MalformedURLException e) {
            e.printStackTrace() ;
            arrayCategoria=null;
        } catch (IOException e) {
            e.printStackTrace() ;
            arrayCategoria=null;
        } catch (JSONException e) {
            e.printStackTrace() ;
            arrayCategoria=null;
        }
        return arrayCategoria;
    }
    public ArrayList<PedidoO> ListaPedidoO (String idUsuario ,String fecInicio,String fecFinal){

        ArrayList<PedidoO> arrayPedidoO = new ArrayList<PedidoO>();
        PedidoO objPedidoO = null;

        String IdPedido="",IdUsuario ="",IdCondicionVenta ="",IdUsuarioVenta="",TotalPagar="",Cantidad="",
                Latitud="",Longitud ="", Fecha="",FecCrea ="",NomCliente="";


        String controlador = "/ListaPedidos?idUsuario="+idUsuario+"&fecInicio="+fecInicio+"&fecFinal="+fecFinal;
        try
        {
            URL url = new URL(api + controlador );
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setRequestMethod("GET");
            InputStream inputStream= new BufferedInputStream(httpcon.getInputStream());
            BufferedReader bufferedReader= new BufferedReader(new InputStreamReader(inputStream));
            JSONArray jsonArray= new JSONArray(bufferedReader.readLine());


            for(int i=0; i<jsonArray.length(); i++)
            {
                JSONObject obj = jsonArray.getJSONObject(i);

                IdPedido = obj.getString("IdPedido");
                IdUsuario = obj.getString("IdUsuario");
                NomCliente=obj.getString("NomCliente");
                IdCondicionVenta = obj.getString("IdCondicionVenta");
                IdUsuarioVenta = obj.getString("IdUsuarioVenta");
                TotalPagar = obj.getString("TotalPagar");
                Cantidad = obj.getString("Cantidad");
                Latitud = obj.getString("Latitud");
                Longitud = obj.getString("Longitud");
                Fecha = obj.getString("Fecha");
                FecCrea = obj.getString("FecCrea");

                objPedidoO = new PedidoO( IdPedido ,IdUsuario,NomCliente,IdCondicionVenta,IdUsuarioVenta,
                        TotalPagar,Cantidad,Latitud,Longitud,Fecha,FecCrea);

                arrayPedidoO.add(objPedidoO);
            }

        } catch (ConnectException e) {
            e.printStackTrace() ;
            arrayPedidoO=null;
        } catch (MalformedURLException e) {
            e.printStackTrace() ;
            arrayPedidoO=null;
        } catch (IOException e) {
            e.printStackTrace() ;
            arrayPedidoO=null;
        } catch (JSONException e) {
            e.printStackTrace() ;
            arrayPedidoO=null;
        }
        return arrayPedidoO;
    }






    public ReporteMeta reporteMeta (String idUsuario ){

        ReporteMeta objReporteMeta = new ReporteMeta() ;



        String controlador = "/ReporteMeta?idUsuario="+idUsuario ;
        try
        {
            URL url = new URL(api + controlador );
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setRequestMethod("GET");
            InputStream inputStream= new BufferedInputStream(httpcon.getInputStream());
            BufferedReader bufferedReader= new BufferedReader(new InputStreamReader(inputStream));
            JSONObject obj= new JSONObject(bufferedReader.readLine());


                objReporteMeta = new ReporteMeta(obj.getString("IdMetaMensual")  ,
                        obj.getString("Fecha")+"",
                        obj.getString("Meta")+"",
                        obj.getString("CantDiasMes")+"",
                        obj.getString("MontoDiario")+"",
                        obj.getString("MetaHastaHoy")+"",
                        obj.getString("MontoHastaHoy")+"",
                        obj.getString("cantVentas")+"",
                        obj.getString("DiaHoy")+"",
                obj.getString("porcenActual")+"");


        } catch (ConnectException e) {
            e.printStackTrace() ;
            objReporteMeta=null;
        } catch (MalformedURLException e) {
            e.printStackTrace() ;
            objReporteMeta=null;
        } catch (IOException e) {
            e.printStackTrace() ;
            objReporteMeta=null;
        } catch (JSONException e) {
            e.printStackTrace() ;
            objReporteMeta=null;
        }
        return objReporteMeta;
    }

    public ArrayList<Producto> ListaProducto (String idUsuario,String CodigoTxt){

        ArrayList<Producto> arrayProducto = new ArrayList<Producto>();
        Producto objProducto = null;

        String IdProductoCategoria="", IdProductoTxt="" , IdCategoria="",IdCategoriaPadre=""
                ,IdFabricante="" ,NombrePro="",Descripcion="" ,Precio="", Peso ="",Imagen ="",IdAlmacen="",Stock="",visible="";


        String controlador = "/ListaProductoV2?idUsuario="+idUsuario+"&CodigoTxt="+CodigoTxt;
        try
        {
            URL url = new URL(api + controlador );
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setRequestMethod("GET");
            InputStream inputStream= new BufferedInputStream(httpcon.getInputStream());
            BufferedReader bufferedReader= new BufferedReader(new InputStreamReader(inputStream));
            JSONArray jsonArray= new JSONArray(bufferedReader.readLine());


            for(int i=0; i<jsonArray.length(); i++)
            {
                JSONObject obj = jsonArray.getJSONObject(i);

                IdProductoCategoria = obj.getString("IdProductoCategoria");
                IdProductoTxt = obj.getString("IdProductoTxt");
                IdCategoria = obj.getString("IdCategoria");
                IdCategoriaPadre = obj.getString("IdCategoriaPadre");
                IdFabricante = obj.getString("IdFabricante");
                NombrePro = obj.getString("NombrePro");
                Descripcion = obj.getString("Descripcion");
                Precio = obj.getString("Precio");
                Peso = obj.getString("Peso");
                Imagen = obj.getString("Imagen");
                IdAlmacen = obj.getString("IdAlmacen");
                Stock = obj.getString("Stock");
                visible = obj.getString("visible");

                objProducto = new Producto(IdProductoCategoria,IdProductoTxt ,IdCategoria,IdCategoriaPadre,IdFabricante,NombrePro,Descripcion,Precio,Peso,Imagen,
                        IdAlmacen,Stock,null,visible);

                arrayProducto.add(objProducto);
            }

        } catch (ConnectException e) {
            e.printStackTrace() ;
            arrayProducto=null;
        } catch (MalformedURLException e) {
            e.printStackTrace() ;
            arrayProducto=null;
        } catch (IOException e) {
            e.printStackTrace() ;
            arrayProducto=null;
        } catch (JSONException e) {
            e.printStackTrace() ;
            arrayProducto=null;
        }
        return arrayProducto;
    }


    public ArrayList<PedidoDetalleLista> ListaPedidoDetalle (String IdPedido){

        ArrayList<PedidoDetalleLista> arrayPedidoDetalleLista = new ArrayList<PedidoDetalleLista>();
        PedidoDetalleLista objPedidoDetalleLista = null;

        String IdPedidoDetalle="", IdProducto="" , NombrePro="",Precio="",Cantidad="",SubTotal="",Imagen="";


        String controlador = "/ListaPedidoDetalle?IdPedido="+IdPedido ;
        try
        {
            URL url = new URL(api + controlador );
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setRequestMethod("GET");
            InputStream inputStream= new BufferedInputStream(httpcon.getInputStream());
            BufferedReader bufferedReader= new BufferedReader(new InputStreamReader(inputStream));
            JSONArray jsonArray= new JSONArray(bufferedReader.readLine());


            for(int i=0; i<jsonArray.length(); i++)
            {
                JSONObject obj = jsonArray.getJSONObject(i);

                IdPedidoDetalle = obj.getString("IdPedidoDetalle");
                IdProducto = obj.getString("IdProducto");
                NombrePro = obj.getString("NombrePro");
                Precio = obj.getString("Precio");
                Cantidad = obj.getString("Cantidad");
                SubTotal = obj.getString("SubTotal");
                Imagen = obj.getString("Imagen");

                objPedidoDetalleLista = new PedidoDetalleLista(IdPedidoDetalle,IdProducto ,NombrePro,Precio,Cantidad,SubTotal,Imagen);

                arrayPedidoDetalleLista.add(objPedidoDetalleLista);
            }

        } catch (ConnectException e) {
            e.printStackTrace() ;
            arrayPedidoDetalleLista=null;
        } catch (MalformedURLException e) {
            e.printStackTrace() ;
            arrayPedidoDetalleLista=null;
        } catch (IOException e) {
            e.printStackTrace() ;
            arrayPedidoDetalleLista=null;
        } catch (JSONException e) {
            e.printStackTrace() ;
            arrayPedidoDetalleLista=null;
        }
        return arrayPedidoDetalleLista;
    }


    public ArrayList<PedidoComplementario> ListaPedidoComplementario (String idUsuario ){

        ArrayList<PedidoComplementario> arrayPedidoComplementario = new ArrayList<PedidoComplementario>();
        PedidoComplementario objPedidoComplementario = null;

        String IdPedido ="", IdUsuario ="", nomUsuario ="", montoComprado ="", montoSugerido ="", celular =""  ;

        String controlador = "/ListaPedidoComplementario?IdUsuario="+idUsuario;
        try
        {
            URL url = new URL(api + controlador );
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setRequestMethod("GET");
            InputStream inputStream= new BufferedInputStream(httpcon.getInputStream());
            BufferedReader bufferedReader= new BufferedReader(new InputStreamReader(inputStream));
            JSONArray jsonArray= new JSONArray(bufferedReader.readLine());


            for(int i=0; i<jsonArray.length(); i++)
            {
                JSONObject obj = jsonArray.getJSONObject(i);

                IdPedido = obj.getString("IdPedido");
                IdUsuario = obj.getString("IdUsuario");
                nomUsuario = obj.getString("nomUsuario");
                montoComprado=obj.getString("montoComprado");
                montoSugerido = obj.getString("montoSugerido");
                celular = obj.getString("celular");

                objPedidoComplementario = new PedidoComplementario( IdPedido ,IdUsuario,nomUsuario,montoComprado,montoSugerido,celular );

                arrayPedidoComplementario.add(objPedidoComplementario);
            }

        } catch (ConnectException e) {
            e.printStackTrace() ;
            arrayPedidoComplementario=null;
        } catch (MalformedURLException e) {
            e.printStackTrace() ;
            arrayPedidoComplementario=null;
        } catch (IOException e) {
            e.printStackTrace() ;
            arrayPedidoComplementario=null;
        } catch (JSONException e) {
            e.printStackTrace() ;
            arrayPedidoComplementario=null;
        }
        return arrayPedidoComplementario;
    }

    public ArrayList<ProductoSugerido> ListaProductoSugerido (String idUsuario ){

        ArrayList<ProductoSugerido> arrayProductoSugerido = new ArrayList<ProductoSugerido>();
        ProductoSugerido objProductoSugerido = null;

        String IdProducto ="", IdCategoria ="", IdFabricante ="", NombrePro ="", Descripcion ="", Precio ="", Peso ="",IdCategoriaPadre="",
                Imagen ="", IdAlmacen ="", Stock ="", CantidadUnidades ="", NumeroOrdenesOrdenes ="", CantidadSugerida ="", PorcentajeAdicional ="" ;

        String controlador = "/ProductoSugerido?idUsuario="+idUsuario;
        try
        {
            URL url = new URL(api + controlador );
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setRequestMethod("GET");
            InputStream inputStream= new BufferedInputStream(httpcon.getInputStream());
            BufferedReader bufferedReader= new BufferedReader(new InputStreamReader(inputStream));
            JSONArray jsonArray= new JSONArray(bufferedReader.readLine());


            for(int i=0; i<jsonArray.length(); i++)
            {
                JSONObject obj = jsonArray.getJSONObject(i);

                IdProducto = obj.getString("IdProducto");
                IdCategoria = obj.getString("IdCategoria");
                IdCategoriaPadre = obj.getString("IdCategoriaPadre");
                IdFabricante=obj.getString("IdFabricante");
                NombrePro = obj.getString("NombrePro");
                Descripcion = obj.getString("Descripcion");
                Precio = obj.getString("Precio");
                Peso = obj.getString("Peso");
                Imagen = obj.getString("Imagen");
                IdAlmacen = obj.getString("IdAlmacen");
                Stock = obj.getString("Stock");
                CantidadUnidades = obj.getString("CantidadUnidades");
                NumeroOrdenesOrdenes = obj.getString("NumeroOrdenesOrdenes");
                CantidadSugerida = obj.getString("CantidadSugerida");
                PorcentajeAdicional = obj.getString("PorcentajeAdicional");

                objProductoSugerido = new ProductoSugerido( IdProducto ,IdCategoria,IdCategoriaPadre,IdFabricante,NombrePro,Descripcion,Precio,
                        Peso,Imagen,IdAlmacen,Stock,CantidadUnidades,NumeroOrdenesOrdenes,CantidadSugerida,PorcentajeAdicional);

                arrayProductoSugerido.add(objProductoSugerido);
            }

        } catch (ConnectException e) {
            e.printStackTrace() ;
            arrayProductoSugerido=null;
        } catch (MalformedURLException e) {
            e.printStackTrace() ;
            arrayProductoSugerido=null;
        } catch (IOException e) {
            e.printStackTrace() ;
            arrayProductoSugerido=null;
        } catch (JSONException e) {
            e.printStackTrace() ;
            arrayProductoSugerido=null;
        }
        return arrayProductoSugerido;
    }


    public ArrayList<PedidoComplementarioDetalle> ListaPedidoComplementarioDetalle (String IdPed  ){

        ArrayList<PedidoComplementarioDetalle> arrayPedidoComplementarioDetalle = new ArrayList<PedidoComplementarioDetalle>();
        PedidoComplementarioDetalle objPedidoComplementarioDetalle = null;

        String IdPedido ="",IdProducto="",IdCategoria ="",IdCategoriaPadre="",IdFabricante="",NombrePro ="",Descripcion="",Precio ="",
                Peso ="", Imagen="",IdAlmacen="",Stock="",CantComprada ="",CantSugerido ="";

        String controlador = "/ListaDetallePedidoComp?IdPedido="+IdPed ;
        try
        {
            URL url = new URL(api + controlador );
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setRequestMethod("GET");
            InputStream inputStream= new BufferedInputStream(httpcon.getInputStream());
            BufferedReader bufferedReader= new BufferedReader(new InputStreamReader(inputStream));
            JSONArray jsonArray= new JSONArray(bufferedReader.readLine());


            for(int i=0; i<jsonArray.length(); i++)
            {
                JSONObject obj = jsonArray.getJSONObject(i);

                IdPedido=obj.getString("IdPedido");
                IdProducto = obj.getString("IdProducto");
                IdCategoria = obj.getString("IdCategoria");
                IdCategoriaPadre = obj.getString("IdCategoriaPadre");
                IdFabricante=obj.getString("IdFabricante");
                NombrePro = obj.getString("NombrePro");
                Descripcion = obj.getString("Descripcion");
                Precio = obj.getString("Precio");
                Peso = obj.getString("Peso");
                Imagen = obj.getString("Imagen");
                IdAlmacen = obj.getString("IdAlmacen");
                Stock = obj.getString("Stock");
                CantComprada = obj.getString("CantComprada");
                CantSugerido = obj.getString("CantSugerido");

                objPedidoComplementarioDetalle = new PedidoComplementarioDetalle(IdPedido, IdProducto ,IdCategoria,IdCategoriaPadre
                        ,IdFabricante,NombrePro,Descripcion,Precio,
                        Peso,Imagen,IdAlmacen,Stock, CantComprada,CantSugerido);

                arrayPedidoComplementarioDetalle.add(objPedidoComplementarioDetalle);
            }

        } catch (ConnectException e) {
            e.printStackTrace() ;
            arrayPedidoComplementarioDetalle=null;
        } catch (MalformedURLException e) {
            e.printStackTrace() ;
            arrayPedidoComplementarioDetalle=null;
        } catch (IOException e) {
            e.printStackTrace() ;
            arrayPedidoComplementarioDetalle=null;
        } catch (JSONException e) {
            e.printStackTrace() ;
            arrayPedidoComplementarioDetalle=null;
        }
        return arrayPedidoComplementarioDetalle;
    }

    public ArrayList<Cliente> ListaCliente (String idUsuario, String CodigoTxt){

        ArrayList<Cliente> arrayCliente = new ArrayList<Cliente>();
        Cliente objCliente = null;

        String CodigoTx="", Nombre="" , Paterno=""
                ,Materno="" ,Direccion="",Latitud="" ,Longitud="", DiasVisita ="",ActivaTotalClientes="",VisitadoHoy="";


        String controlador = "/ListaCliente?idUsuario="+idUsuario+"&CodigoTxt="+CodigoTxt;
        try
        {
            URL url = new URL(api + controlador );
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setRequestMethod("GET");
            InputStream inputStream= new BufferedInputStream(httpcon.getInputStream());
            BufferedReader bufferedReader= new BufferedReader(new InputStreamReader(inputStream));
            JSONArray jsonArray= new JSONArray(bufferedReader.readLine());


            for(int i=0; i<jsonArray.length(); i++)
            {
                JSONObject obj = jsonArray.getJSONObject(i);

                CodigoTx = obj.getString("CodigoTxt");
                Nombre = obj.getString("Nombre");
                Paterno = obj.getString("Paterno");
                Materno = obj.getString("Materno");
                Direccion = obj.getString("Direccion");
                Latitud = obj.getString("Latitud");
                Longitud = obj.getString("Longitud");
                DiasVisita = obj.getString("DiasVisita");
                ActivaTotalClientes = obj.getString("ActivaTotalClientes");
                VisitadoHoy = obj.getString("VisitadoHoy");

                objCliente = new Cliente(CodigoTx,Nombre ,Paterno,Materno,Direccion,Latitud,Longitud,DiasVisita,ActivaTotalClientes,VisitadoHoy);

                arrayCliente.add(objCliente);
            }

        } catch (ConnectException e) {
            e.printStackTrace() ;
            arrayCliente=null;
        } catch (MalformedURLException e) {
            e.printStackTrace() ;
            arrayCliente=null;
        } catch (IOException e) {
            e.printStackTrace() ;
            arrayCliente=null;
        } catch (JSONException e) {
            e.printStackTrace() ;
            arrayCliente=null;
        }
        return arrayCliente;
    }

    public ArrayList<DiasVisita> ListaDiaVisita (String idUsuario ){

        ArrayList<DiasVisita> arrayDiasVisita = new ArrayList<DiasVisita>();
        DiasVisita objDiasVisita = null;

        String codigoEmpleado="", diasVisita=""  ;


        String controlador = "/ListaDiaVisita?idUsuario="+idUsuario  ;
        try
        {
            URL url = new URL(api + controlador );
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setRequestMethod("GET");
            InputStream inputStream= new BufferedInputStream(httpcon.getInputStream());
            BufferedReader bufferedReader= new BufferedReader(new InputStreamReader(inputStream));
            JSONArray jsonArray= new JSONArray(bufferedReader.readLine());


            for(int i=0; i<jsonArray.length(); i++)
            {
                JSONObject obj = jsonArray.getJSONObject(i);

                codigoEmpleado = obj.getString("CodigoEmpleado");
                diasVisita = obj.getString("DiasVisita");

                objDiasVisita = new DiasVisita(codigoEmpleado,diasVisita);

                arrayDiasVisita.add(objDiasVisita);
            }

        } catch (ConnectException e) {
            e.printStackTrace() ;
            arrayDiasVisita=null;
        } catch (MalformedURLException e) {
            e.printStackTrace() ;
            arrayDiasVisita=null;
        } catch (IOException e) {
            e.printStackTrace() ;
            arrayDiasVisita=null;
        } catch (JSONException e) {
            e.printStackTrace() ;
            arrayDiasVisita=null;
        }
        return arrayDiasVisita;
    }

    public ParametrosSalida InsertaVisita(String IdCliente,String IdVendedor )  {

        String Controlador = "/Visita";
        String idUsuario = "", nombre = ""  ,idTipoUsuario="",idTipoAcceso="" ,CodigoTxt="";


        try {

            URL url = new URL(api + Controlador);
            HttpURLConnection httpcon= (HttpURLConnection) url.openConnection();
            httpcon.setDoOutput(true);
            httpcon.setRequestMethod("POST");
            httpcon.setRequestProperty("Content-Type", "application/json");

            JSONObject jsonObject= new JSONObject();
            jsonObject.put("IdCliente", IdCliente);
            jsonObject.put("IdVendedor", IdVendedor);
            jsonObject.put("FechaRegistro","");

            OutputStream os = httpcon.getOutputStream();
            os.write(jsonObject.toString().getBytes());
            os.flush();

            InputStream inputStream = new BufferedInputStream(httpcon.getInputStream());

            BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
            JSONObject jsonObject2 = new JSONObject(reader.readLine());
            flag = Integer.parseInt(jsonObject2.getString("FlagIndicador"));
            mensaje = jsonObject2.getString("MsgValidacion");
            httpcon.disconnect();

        } catch (ConnectException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (MalformedURLException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (IOException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        } catch (JSONException e) {
            flag = 9;
            mensaje = "Error: " + e.toString();
        }
        return new ParametrosSalida(flag,mensaje );
    }

}
