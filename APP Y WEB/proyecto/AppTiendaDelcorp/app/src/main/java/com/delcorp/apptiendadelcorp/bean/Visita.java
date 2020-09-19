package com.delcorp.apptiendadelcorp.bean;

public class Visita {

    public String IdVisita ;
    public String IdCliente ;
    public String IdVendedor ;
    public String FechaRegistro;
    public String FlagSincronizado;

    public String getIdVisita() {
        return IdVisita;
    }

    public void setIdVisita(String idVisita) {
        IdVisita = idVisita;
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

    public String getFechaRegistro() {
        return FechaRegistro;
    }

    public void setFechaRegistro(String fechaRegistro) {
        FechaRegistro = fechaRegistro;
    }

    public String getFlagSincronizado() {
        return FlagSincronizado;
    }

    public void setFlagSincronizado(String flagSincronizado) {
        FlagSincronizado = flagSincronizado;
    }

    public Visita(String idVisita, String idCliente, String idVendedor, String fechaRegistro, String flagSincronizado) {
        IdVisita = idVisita;
        IdCliente = idCliente;
        IdVendedor = idVendedor;
        FechaRegistro = fechaRegistro;
        FlagSincronizado = flagSincronizado;
    }

    public Visita() {
    }
}
