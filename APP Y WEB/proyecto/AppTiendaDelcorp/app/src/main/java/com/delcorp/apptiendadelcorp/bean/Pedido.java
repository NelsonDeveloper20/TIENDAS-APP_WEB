package com.delcorp.apptiendadelcorp.bean;

public class Pedido {

    private String IdPedido;
    private String IdPedidoSql;
    private String IdUsuario;
    private String nomUsuario;
    private String CodigoTxt ;
    private String IdCondicionVenta ;
    private String IdUsuarioVenta ;
    private String TotalPagar ;
    private String Items ;
    private String Latitud ;
    private String Longitud ;
    private String FlagTipoRegistro ;
    private String Fecha ;
    private String FlagSincronizado;

    public Pedido() {
    }

    public String getIdPedido() {
        return IdPedido;
    }

    public void setIdPedido(String idPedido) {
        IdPedido = idPedido;
    }

    public String getIdPedidoSql() {
        return IdPedidoSql;
    }

    public void setIdPedidoSql(String idPedidoSql) {
        IdPedidoSql = idPedidoSql;
    }

    public String getIdUsuario() {
        return IdUsuario;
    }

    public void setIdUsuario(String idUsuario) {
        IdUsuario = idUsuario;
    }

    public String getNomUsuario() {
        return nomUsuario;
    }

    public void setNomUsuario(String nomUsuario) {
        this.nomUsuario = nomUsuario;
    }

    public String getCodigoTxt() {
        return CodigoTxt;
    }

    public void setCodigoTxt(String codigoTxt) {
        CodigoTxt = codigoTxt;
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

    public String getItems() {
        return Items;
    }

    public void setItems(String items) {
        Items = items;
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

    public String getFlagTipoRegistro() {
        return FlagTipoRegistro;
    }

    public void setFlagTipoRegistro(String flagTipoRegistro) {
        FlagTipoRegistro = flagTipoRegistro;
    }

    public String getFecha() {
        return Fecha;
    }

    public void setFecha(String fecha) {
        Fecha = fecha;
    }

    public String getFlagSincronizado() {
        return FlagSincronizado;
    }

    public void setFlagSincronizado(String flagSincronizado) {
        FlagSincronizado = flagSincronizado;
    }

    public Pedido(String idPedido, String idPedidoSql, String idUsuario, String nomUsuario, String codigoTxt, String idCondicionVenta, String idUsuarioVenta, String totalPagar, String items, String latitud, String longitud, String flagTipoRegistro, String fecha, String flagSincronizado) {
        IdPedido = idPedido;
        IdPedidoSql = idPedidoSql;
        IdUsuario = idUsuario;
        this.nomUsuario = nomUsuario;
        CodigoTxt = codigoTxt;
        IdCondicionVenta = idCondicionVenta;
        IdUsuarioVenta = idUsuarioVenta;
        TotalPagar = totalPagar;
        Items = items;
        Latitud = latitud;
        Longitud = longitud;
        FlagTipoRegistro = flagTipoRegistro;
        Fecha = fecha;
        FlagSincronizado = flagSincronizado;
    }
}
