package com.delcorp.apptiendadelcorp.bean;

public class Categoria {
    private String IdCategoria;
    private String IdUp;
    private String Stock;
    private String Nombre;
    private String Descripcion;
    private String Precio;
    private String Peso;
    private String Imagen;
    private byte[] Img;

    public String getIdCategoria() {
        return IdCategoria;
    }

    public void setIdCategoria(String idCategoria) {
        IdCategoria = idCategoria;
    }

    public String getIdUp() {
        return IdUp;
    }

    public void setIdUp(String idUp) {
        IdUp = idUp;
    }

    public String getStock() {
        return Stock;
    }

    public void setStock(String stock) {
        Stock = stock;
    }

    public String getNombre() {
        return Nombre;
    }

    public void setNombre(String nombre) {
        Nombre = nombre;
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

    public byte[] getImg() {
        return Img;
    }

    public void setImg(byte[] img) {
        Img = img;
    }

    public Categoria(String idCategoria, String idUp, String stock, String nombre, String descripcion, String precio, String peso, String imagen) {
        IdCategoria = idCategoria;
        IdUp = idUp;
        Stock = stock;
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
        Peso = peso;
        Imagen = imagen;
    }

    public Categoria(String idCategoria, String idUp, String stock, String nombre, String descripcion, String precio, String peso, String imagen, byte[] img) {
        IdCategoria = idCategoria;
        IdUp = idUp;
        Stock = stock;
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
        Peso = peso;
        Imagen = imagen;
        Img = img;
    }

    public Categoria() {
    }
}
