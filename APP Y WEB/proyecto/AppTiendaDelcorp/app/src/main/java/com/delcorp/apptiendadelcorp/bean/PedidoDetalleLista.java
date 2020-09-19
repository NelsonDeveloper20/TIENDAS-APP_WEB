package com.delcorp.apptiendadelcorp.bean;

public class PedidoDetalleLista {

    private String IdPedidoDetalle ;
    private String IdProducto ;
    private String NombrePro ;
    private String Precio ;
    private String Cantidad ;
    private String SubTotal ;
    private String Imagen ;

    public String getIdPedidoDetalle() {
        return IdPedidoDetalle;
    }

    public void setIdPedidoDetalle(String idPedidoDetalle) {
        IdPedidoDetalle = idPedidoDetalle;
    }

    public String getIdProducto() {
        return IdProducto;
    }

    public void setIdProducto(String idProducto) {
        IdProducto = idProducto;
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

    public String getImagen() {
        return Imagen;
    }

    public void setImagen(String imagen) {
        Imagen = imagen;
    }

    public PedidoDetalleLista(String idPedidoDetalle, String idProducto, String nombrePro, String precio, String cantidad, String subTotal, String imagen) {
        IdPedidoDetalle = idPedidoDetalle;
        IdProducto = idProducto;
        NombrePro = nombrePro;
        Precio = precio;
        Cantidad = cantidad;
        SubTotal = subTotal;
        Imagen = imagen;
    }

    public PedidoDetalleLista() {
    }
}
