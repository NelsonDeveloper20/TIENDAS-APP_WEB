package com.delcorp.apptiendadelcorp.bean;

public class Cliente {
    private String CodigoTxt ;
    private String Nombre ;
    private String Paterno ;
    private String Materno ;
    private String Direccion ;
    private String Latitud ;
    private String Longitud ;
    private String DiasVisita ;
    private String ActivaTotalClientes;
    private String VisitadoHoy;

    public Cliente(String codigoTxt, String nombre, String paterno, String materno, String direccion, String latitud, String longitud, String diasVisita, String activaTotalClientes, String visitadoHoy) {
        CodigoTxt = codigoTxt;
        Nombre = nombre;
        Paterno = paterno;
        Materno = materno;
        Direccion = direccion;
        Latitud = latitud;
        Longitud = longitud;
        DiasVisita = diasVisita;
        ActivaTotalClientes = activaTotalClientes;
        VisitadoHoy = visitadoHoy;
    }

    public String getCodigoTxt() {
        return CodigoTxt;
    }

    public void setCodigoTxt(String codigoTxt) {
        CodigoTxt = codigoTxt;
    }

    public String getNombre() {
        return Nombre;
    }

    public void setNombre(String nombre) {
        Nombre = nombre;
    }

    public String getPaterno() {
        return Paterno;
    }

    public void setPaterno(String paterno) {
        Paterno = paterno;
    }

    public String getMaterno() {
        return Materno;
    }

    public void setMaterno(String materno) {
        Materno = materno;
    }

    public String getDireccion() {
        return Direccion;
    }

    public void setDireccion(String direccion) {
        Direccion = direccion;
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

    public String getDiasVisita() {
        return DiasVisita;
    }

    public void setDiasVisita(String diasVisita) {
        DiasVisita = diasVisita;
    }

    public String getActivaTotalClientes() {
        return ActivaTotalClientes;
    }

    public void setActivaTotalClientes(String activaTotalClientes) {
        ActivaTotalClientes = activaTotalClientes;
    }

    public String getVisitadoHoy() {
        return VisitadoHoy;
    }

    public void setVisitadoHoy(String visitadoHoy) {
        VisitadoHoy = visitadoHoy;
    }

    public Cliente() {
    }
}
