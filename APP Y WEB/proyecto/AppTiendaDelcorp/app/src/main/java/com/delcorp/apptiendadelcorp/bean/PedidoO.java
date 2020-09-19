package com.delcorp.apptiendadelcorp.bean;

public class PedidoO {
    private String IdPedido ;
    private String IdUsuario ;
    private String NomCliente;
    private String IdCondicionVenta ;
    private String IdUsuarioVenta ;
    private String TotalPagar ;
    private String Cantidad ;
    private String Latitud ;
    private String Longitud ;
    private String Fecha ;
    private String FecCrea ;

    public PedidoO(String idPedido, String idUsuario, String nomCliente, String idCondicionVenta, String idUsuarioVenta, String totalPagar, String cantidad, String latitud, String longitud, String fecha, String fecCrea) {
        IdPedido = idPedido;
        IdUsuario = idUsuario;
        NomCliente = nomCliente;
        IdCondicionVenta = idCondicionVenta;
        IdUsuarioVenta = idUsuarioVenta;
        TotalPagar = totalPagar;
        Cantidad = cantidad;
        Latitud = latitud;
        Longitud = longitud;
        Fecha = fecha;
        FecCrea = fecCrea;
    }

    public String getNomCliente() {
        return NomCliente;
    }

    public void setNomCliente(String nomCliente) {
        NomCliente = nomCliente;
    }

    public String getIdPedido() {
        return IdPedido;
    }

    public void setIdPedido(String idPedido) {
        IdPedido = idPedido;
    }

    public String getIdUsuario() {
        return IdUsuario;
    }

    public void setIdUsuario(String idUsuario) {
        IdUsuario = idUsuario;
    }

    public String getIdCondicionVenta() {
        return IdCondicionVenta;
    }

    public void setIdCondicionVenta(String idCondicionVenta) {
        IdCondicionVenta = idCondicionVenta;
    }

    public String getIdUsuarioVenta() {
        return IdUsuarioVenta;
    }

    public void setIdUsuarioVenta(String idUsuarioVenta) {
        IdUsuarioVenta = idUsuarioVenta;
    }

    public String getTotalPagar() {
        return TotalPagar;
    }

    public void setTotalPagar(String totalPagar) {
        TotalPagar = totalPagar;
    }

    public String getCantidad() {
        return Cantidad;
    }

    public void setCantidad(String cantidad) {
        Cantidad = cantidad;
    }

    public String getLatitud() {
        return Latitud;
    }

    public void setLatitud(String latitud) {
        Latitud = latitud;
    }

    public String getLongitud() {
        return Longitud;
    }

    public void setLongitud(String longitud) {
        Longitud = longitud;
    }

    public String getFecha() {
        return Fecha;
    }

    public void setFecha(String fecha) {
        Fecha = fecha;
    }

    public String getFecCrea() {
        return FecCrea;
    }

    public void setFecCrea(String fecCrea) {
        FecCrea = fecCrea;
    }

    public PedidoO() {
    }


}
