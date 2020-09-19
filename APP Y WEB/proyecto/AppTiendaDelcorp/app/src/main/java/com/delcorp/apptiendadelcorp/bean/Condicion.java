package com.delcorp.apptiendadelcorp.bean;

public class Condicion {

    private String IdPromocionCondicion ;
    private String IdPromocion ;
    private String IdProducto ;
    private String IdCategoria ;
    private String IdGrupo ;
    private String Cantidad ;
    private String Descripcion ;

    public Condicion(String idPromocionCondicion, String idPromocion, String idProducto, String idCategoria, String idGrupo, String cantidad, String descripcion) {
        IdPromocionCondicion = idPromocionCondicion;
        IdPromocion = idPromocion;
        IdProducto = idProducto;
        IdCategoria = idCategoria;
        IdGrupo = idGrupo;
        Cantidad = cantidad;
        Descripcion = descripcion;
    }

    public String getIdPromocionCondicion() {
        return IdPromocionCondicion;
    }

    public void setIdPromocionCondicion(String idPromocionCondicion) {
        IdPromocionCondicion = idPromocionCondicion;
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

    public Condicion() {
    }
}
