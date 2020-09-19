package com.delcorp.apptiendadelcorp.bean;

public class CondicionBonificacion {

    private String IdPromocionCondicion ;
    private String IdPromocionBonificacion ;
    private String IdPromocion ;
    private String IdProducto ;
    private String IdCategoria ;
    private String IdGrupo ;
    private String Cantidad ;
    private String Descripcion ;
    private String Stock ;

    public CondicionBonificacion() {
    }

    public String getIdPromocionCondicion() {
        return IdPromocionCondicion;
    }

    public void setIdPromocionCondicion(String idPromocionCondicion) {
        IdPromocionCondicion = idPromocionCondicion;
    }

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

    public String getIdCategoria() {
        return IdCategoria;
    }

    public void setIdCategoria(String idCategoria) {
        IdCategoria = idCategoria;
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

    public String getDescripcion() {
        return Descripcion;
    }

    public void setDescripcion(String descripcion) {
        Descripcion = descripcion;
    }

    public String getStock() {
        return Stock;
    }

    public void setStock(String stock) {
        Stock = stock;
    }

    public CondicionBonificacion(String idPromocionCondicion, String idPromocionBonificacion, String idPromocion, String idProducto, String idCategoria, String idGrupo, String cantidad, String descripcion, String stock) {
        IdPromocionCondicion = idPromocionCondicion;
        IdPromocionBonificacion = idPromocionBonificacion;
        IdPromocion = idPromocion;
        IdProducto = idProducto;
        IdCategoria = idCategoria;
        IdGrupo = idGrupo;
        Cantidad = cantidad;
        Descripcion = descripcion;
        Stock = stock;
    }
}
