package com.delcorp.apptiendadelcorp.bean;

public class Producto {

    public String IdProductoCategoria ;
    public String IdProductoTxt ;
    public String IdCategoria ;
    public String IdCategoriaPadre ;
    public String IdFabricante ;
    public String NombrePro ;
    public String Descripcion ;
    public String Precio ;
    public String Peso ;
    public String Imagen ;
    public String IdAlmacen ;
    public String Stock ;
    public byte[] Img ;
    public String visible;

    public String getIdProductoCategoria() {
        return IdProductoCategoria;
    }

    public void setIdProductoCategoria(String idProductoCategoria) {
        IdProductoCategoria = idProductoCategoria;
    }

    public String getIdProductoTxt() {
        return IdProductoTxt;
    }

    public void setIdProductoTxt(String idProductoTxt) {
        IdProductoTxt = idProductoTxt;
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

    public byte[] getImg() {
        return Img;
    }

    public void setImg(byte[] img) {
        Img = img;
    }

    public String getVisible() {
        return visible;
    }

    public void setVisible(String visible) {
        this.visible = visible;
    }

    public Producto(String idProductoCategoria, String idProductoTxt, String idCategoria, String idCategoriaPadre, String idFabricante, String nombrePro, String descripcion, String precio, String peso, String imagen, String idAlmacen, String stock, byte[] img, String visible) {
        IdProductoCategoria = idProductoCategoria;
        IdProductoTxt = idProductoTxt;
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
        Img = img;
        this.visible = visible;
    }

    public Producto() {
    }
}
