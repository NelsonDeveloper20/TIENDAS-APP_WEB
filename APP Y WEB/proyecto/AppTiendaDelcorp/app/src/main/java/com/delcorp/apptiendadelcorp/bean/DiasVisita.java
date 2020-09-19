package com.delcorp.apptiendadelcorp.bean;

public class DiasVisita {

    private String codigoEmpleado ;
    private String diasVisita  ;

    public String getCodigoEmpleado() {
        return codigoEmpleado;
    }

    public void setCodigoEmpleado(String codigoEmpleado) {
        this.codigoEmpleado = codigoEmpleado;
    }

    public String getDiasVisita() {
        return diasVisita;
    }

    public void setDiasVisita(String diasVisita) {
        this.diasVisita = diasVisita;
    }

    public DiasVisita(String codigoEmpleado, String diasVisita) {
        this.codigoEmpleado = codigoEmpleado;
        this.diasVisita = diasVisita;
    }

    public DiasVisita() {
    }
}
