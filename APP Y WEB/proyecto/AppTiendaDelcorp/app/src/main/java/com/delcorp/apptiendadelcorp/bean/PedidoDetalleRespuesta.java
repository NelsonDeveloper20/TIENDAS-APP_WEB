package com.delcorp.apptiendadelcorp.bean;

public class PedidoDetalleRespuesta {

    private String IdProductoTxt ;
    private String NombrePro ;
    private String Precio ;
    private String Cantidad ;
    private String SubTotal ;
    private String IdPromocion ;
    private String IdCondicion ;
    private String IdBonificacion ;
    private String Imagen ;

    public String getIdProductoTxt() {
        return IdProductoTxt;
    }

    public void setIdProductoTxt(String idProductoTxt) {
        IdProductoTxt = idProductoTxt;
    }

    public String getNombrePro() {
        return NombrePro;
    }

    public void setNombrePro(String nombrePro) {
        NombrePro = nombrePro;
    }

    public String getPrecio() {
        return Precio;
    }

    public void setPrecio(String precio) {
        Precio = precio;
    }

    public String getCantidad() {
        return Cantidad;
    }

    public void setCantidad(String cantidad) {
        Cantidad = cantidad;
    }

    public String getSubTotal() {
        return SubTotal;
    }

    public void setSubTotal(String subTotal) {
        SubTotal = subTotal;
    }

    public String getIdPromocion() {
        return IdPromocion;
    }

    public void setIdPromocion(String idPromocion) {
        IdPromocion = idPromocion;
    }

    public String getIdCondicion() {
        return IdCondicion;
    }

    public void setIdCondicion(String idCondicion) {
        IdCondicion = idCondicion;
    }

    public String getIdBonificacion() {
        return IdBonificacion;
    }

    public void setIdBonificacion(String idBonificacion) {
        IdBonificacion = idBonificacion;
    }

    public String getImagen() {
        return Imagen;
    }

    public void setImagen(String imagen) {
        Imagen = imagen;
    }

    public PedidoDetalleRespuesta() {
    }

    public PedidoDetalleRespuesta(String idProductoTxt, String nombrePro, String precio, String cantidad, String subTotal, String idPromocion, String idCondicion, String idBonificacion, String imagen) {
        IdProductoTxt = idProductoTxt;
        NombrePro = nombrePro;
        Precio = precio;
        Cantidad = cantidad;
        SubTotal = subTotal;
        IdPromocion = idPromocion;
        IdCondicion = idCondicion;
        IdBonificacion = idBonificacion;
        Imagen = imagen;
    }
}
