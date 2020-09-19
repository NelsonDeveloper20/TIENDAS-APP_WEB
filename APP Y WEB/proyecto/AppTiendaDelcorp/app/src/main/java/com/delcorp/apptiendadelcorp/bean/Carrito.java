package com.delcorp.apptiendadelcorp.bean;

public class Carrito {
    private Integer Id;

    private String IdCliente;
    private String IdVendedor;
    private String IdProductoTxt ;
    private String IdCategoria ;
    private String IdCategoriaPadre ;
    private String IdFabricante ;
    private String NombrePro ;
    private String Descripcion ;
    private String Precio ;
    private String Peso ;
    private String Imagen ;
    private String IdAlmacen ;
    private String Stock;
    private String Cant;
    private byte[] Img ;

    private String IdCarrito;
    private String IdPromocion;
    private String IdCondicion;
    private String IdBonificacion;

    private String cantSuge;
    private String IdPedido;

    public Integer getId() {
        return Id;
    }

    public void setId(Integer id) {
        Id = id;
    }

    public String getIdCliente() {
        return IdCliente;
    }

    public void setIdCliente(String idCliente) {
        IdCliente = idCliente;
    }

    public String getIdVendedor() {
        return IdVendedor;
    }

    public void setIdVendedor(String idVendedor) {
        IdVendedor = idVendedor;
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

    public String getCant() {
        return Cant;
    }

    public void setCant(String cant) {
        Cant = cant;
    }

    public byte[] getImg() {
        return Img;
    }

    public void setImg(byte[] img) {
        Img = img;
    }

    public String getIdCarrito() {
        return IdCarrito;
    }

    public void setIdCarrito(String idCarrito) {
        IdCarrito = idCarrito;
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

    public String getCantSuge() {
        return cantSuge;
    }

    public void setCantSuge(String cantSuge) {
        this.cantSuge = cantSuge;
    }

    public String getIdPedido() {
        return IdPedido;
    }

    public void setIdPedido(String idPedido) {
        IdPedido = idPedido;
    }

    public Carrito(Integer id, String idCliente, String idVendedor, String idProductoTxt, String idCategoria, String idCategoriaPadre, String idFabricante, String nombrePro, String descripcion, String precio, String peso, String imagen, String idAlmacen, String stock, String cant, byte[] img, String idCarrito, String idPromocion, String idCondicion, String idBonificacion, String cantSuge, String idPedido) {
        Id = id;
        IdCliente = idCliente;
        IdVendedor = idVendedor;
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
        Cant = cant;
        Img = img;
        IdCarrito = idCarrito;
        IdPromocion = idPromocion;
        IdCondicion = idCondicion;
        IdBonificacion = idBonificacion;
        this.cantSuge = cantSuge;
        IdPedido = idPedido;
    }

    public Carrito() {
    }
}
