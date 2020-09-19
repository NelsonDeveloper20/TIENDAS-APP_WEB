package com.delcorp.apptiendadelcorp.bean;

public class Bonificacion {

    private String IdPromocionBonificacion ;
    private String IdPromocion ;
    private String IdProducto ;
    private String IdGrupo ;
    private String Cantidad;
    private String Stock ;

    public String getIdPromocionBonificacion() {
        return IdPromocionBonificacion;
    }

    public void setIdPromocionBonificacion(String idPromocionBonificacion) {
        IdPromocionBonificacion = idPromocionBonificacion;
    }

    public String getIdPromocion() {
        return IdPromocion;
    }

    public void setIdPromocion(String idPromocion) {
        IdPromocion = idPromocion;
    }

    public String getIdProducto() {
        return IdProducto;
    }

    public void setIdProducto(String idProducto) {
        IdProducto = idProducto;
    }

    public String getIdGrupo() {
        return IdGrupo;
    }

    public void setIdGrupo(String idGrupo) {
        IdGrupo = idGrupo;
    }

    public String getCantidad() {
        return Cantidad;
    }

    public void setCantidad(String cantidad) {
        Cantidad = cantidad;
    }

    public String getStock() {
        return Stock;
    }

    public void setStock(String stock) {
        Stock = stock;
    }

    public Bonificacion(String idPromocionBonificacion, String idPromocion, String idProducto, String idGrupo, String cantidad, String stock) {
        IdPromocionBonificacion = idPromocionBonificacion;
        IdPromocion = idPromocion;
        IdProducto = idProducto;
        IdGrupo = idGrupo;
        Cantidad = cantidad;
        Stock = stock;
    }

    public Bonificacion() {
    }
}
