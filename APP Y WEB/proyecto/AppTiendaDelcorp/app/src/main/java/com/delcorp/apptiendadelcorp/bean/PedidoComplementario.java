package com.delcorp.apptiendadelcorp.bean;

public class PedidoComplementario {


    private String IdPedido ;
    private String IdUsuario ;
    private String nomUsuario ;
    private String montoComprado ;
    private String montoSugerido ;
    private String celular ;

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

    public String getNomUsuario() {
        return nomUsuario;
    }

    public void setNomUsuario(String nomUsuario) {
        this.nomUsuario = nomUsuario;
    }

    public String getMontoComprado() {
        return montoComprado;
    }

    public void setMontoComprado(String montoComprado) {
        this.montoComprado = montoComprado;
    }

    public String getMontoSugerido() {
        return montoSugerido;
    }

    public void setMontoSugerido(String montoSugerido) {
        this.montoSugerido = montoSugerido;
    }

    public String getCelular() {
        return celular;
    }

    public void setCelular(String celular) {
        this.celular = celular;
    }

    public PedidoComplementario(String idPedido, String idUsuario, String nomUsuario, String montoComprado, String montoSugerido, String celular) {
        IdPedido = idPedido;
        IdUsuario = idUsuario;
        this.nomUsuario = nomUsuario;
        this.montoComprado = montoComprado;
        this.montoSugerido = montoSugerido;
        this.celular = celular;
    }

    public PedidoComplementario() {
    }
}
