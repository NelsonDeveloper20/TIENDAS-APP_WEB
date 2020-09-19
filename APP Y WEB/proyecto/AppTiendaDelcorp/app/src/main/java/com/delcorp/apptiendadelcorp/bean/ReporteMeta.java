package com.delcorp.apptiendadelcorp.bean;

public class ReporteMeta {

    private String IdMetaMensual ;
    private String Fecha;
    private String Meta ;
    private String CantDiasMes ;
    private String MontoDiario ;
    private String MetaHastaHoy ;
    private String MontoHastaHoy ;
    private String cantVentas ;
    private String DiaHoy ;
    private String porcenActual;

    public String getIdMetaMensual() {
        return IdMetaMensual;
    }

    public void setIdMetaMensual(String idMetaMensual) {
        IdMetaMensual = idMetaMensual;
    }

    public String getFecha() {
        return Fecha;
    }

    public void setFecha(String fecha) {
        Fecha = fecha;
    }

    public String getMeta() {
        return Meta;
    }

    public void setMeta(String meta) {
        Meta = meta;
    }

    public String getCantDiasMes() {
        return CantDiasMes;
    }

    public void setCantDiasMes(String cantDiasMes) {
        CantDiasMes = cantDiasMes;
    }

    public String getMontoDiario() {
        return MontoDiario;
    }

    public void setMontoDiario(String montoDiario) {
        MontoDiario = montoDiario;
    }

    public String getMetaHastaHoy() {
        return MetaHastaHoy;
    }

    public void setMetaHastaHoy(String metaHastaHoy) {
        MetaHastaHoy = metaHastaHoy;
    }

    public String getMontoHastaHoy() {
        return MontoHastaHoy;
    }

    public void setMontoHastaHoy(String montoHastaHoy) {
        MontoHastaHoy = montoHastaHoy;
    }

    public String getCantVentas() {
        return cantVentas;
    }

    public void setCantVentas(String cantVentas) {
        this.cantVentas = cantVentas;
    }

    public String getDiaHoy() {
        return DiaHoy;
    }

    public void setDiaHoy(String diaHoy) {
        DiaHoy = diaHoy;
    }

    public String getPorcenActual() {
        return porcenActual;
    }

    public void setPorcenActual(String porcenActual) {
        this.porcenActual = porcenActual;
    }

    public ReporteMeta(String idMetaMensual, String fecha, String meta, String cantDiasMes, String montoDiario, String metaHastaHoy, String montoHastaHoy, String cantVentas, String diaHoy, String porcenActual) {
        IdMetaMensual = idMetaMensual;
        Fecha = fecha;
        Meta = meta;
        CantDiasMes = cantDiasMes;
        MontoDiario = montoDiario;
        MetaHastaHoy = metaHastaHoy;
        MontoHastaHoy = montoHastaHoy;
        this.cantVentas = cantVentas;
        DiaHoy = diaHoy;
        this.porcenActual = porcenActual;
    }

    public ReporteMeta() {
    }
}
