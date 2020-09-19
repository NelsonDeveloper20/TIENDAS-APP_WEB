package com.delcorp.apptiendadelcorp.bean;

public class PedidoComplementarioDetalle {

    private String IdPedido ;
    private String IdProducto ;
    private String IdCategoria ;
    private String IdCategoriaPadre ;
    private String IdFabricante ;
    private String NombrePro ;
    private String Descripcion ;
    private String Precio ;
    private String Peso ;
    private String Imagen ;
    private String IdAlmacen ;
    private String Stock ;
    private String CantComprada ;
    private String CantSugerido ;

    public String getIdPedido() {
        return IdPedido;
    }

    public void setIdPedido(String idPedido) {
        IdPedido = idPedido;
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

    public String getIdCategoriaPadre() {
        return IdCategoriaPadre;
    }

    public void setIdCategoriaPadre(String idCategoriaPadre) {
        IdCategoriaPadre = idCategoriaPadre;
    }

    public String getIdFabricante() {
        return IdFabricante;
    }

    public void setIdFabricante(String idFabricante) {
        IdFabricante = idFabricante;
    }

    public String getNombrePro() {
        return NombrePro;
    }

    public void setNombrePro(String nombrePro) {
        NombrePro = nombrePro;
    }

    public String getDescripcion() {
        return Descripcion;
    }

    public void setDescripcion(String descripcion) {
        Descripcion = descripcion;
    }

    public String getPrecio() {
        return Precio;
    }

    public void setPrecio(String precio) {
        Precio = precio;
    }

    public String getPeso() {
        return Peso;
    }

    public void setPeso(String peso) {
        Peso = peso;
    }

    public String getImagen() {
        return Imagen;
    }

    public void setImagen(String imagen) {
        Imagen = imagen;
    }

    public String getIdAlmacen() {
        return IdAlmacen;
    }

    public void setIdAlmacen(String idAlmacen) {
        IdAlmacen = idAlmacen;
    }

    public String getStock() {
        return Stock;
    }

    public void setStock(String stock) {
        Stock = stock;
    }

    public String getCantComprada() {
        return CantComprada;
    }

    public void setCantComprada(String cantComprada) {
        CantComprada = cantComprada;
    }

    public String getCantSugerido() {
        return CantSugerido;
    }

    public void setCantSugerido(String cantSugerido) {
        CantSugerido = cantSugerido;
    }

    public PedidoComplementarioDetalle() {
    }

    public PedidoComplementarioDetalle(String idPedido, String idProducto, String idCategoria, String idCategoriaPadre, String idFabricante, String nombrePro, String descripcion, String precio, String peso, String imagen, String idAlmacen, String stock, String cantComprada, String cantSugerido) {
        IdPedido = idPedido;
        IdProducto = idProducto;
        IdCategoria = idCategoria;
        IdCategoriaPadre = idCategoriaPadre;
        IdFabricante = idFabricante;
        NombrePro = nombrePro;
        Descripcion = descripcion;
        Precio = precio;
        Peso = peso;
        Imagen = imagen;
        IdAlmacen = idAlmacen;
        Stock = stock;
        CantComprada = cantComprada;
        CantSugerido = cantSugerido;
    }
}
