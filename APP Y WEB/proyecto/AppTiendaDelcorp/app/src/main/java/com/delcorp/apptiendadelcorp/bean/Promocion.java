package com.delcorp.apptiendadelcorp.bean;

public class Promocion {
 
    private String IdPromocion;
    private String flagHistorico;
    private String IdCondicion;
    private String IdTipoCondicion;
    private String IdTipoPromocion;
    private String IdTipoBonificacion;
    private String MontoBonificacion;
    private String IdTipoUsuario;
    private String flagPrimeraCompra;

    public Promocion() {
    }

    public String getIdPromocion() {
        return IdPromocion;
    }

    public void setIdPromocion(String idPromocion) {
        IdPromocion = idPromocion;
    }

    public String getFlagHistorico() {
        return flagHistorico;
    }

    public void setFlagHistorico(String flagHistorico) {
        this.flagHistorico = flagHistorico;
    }

    public String getIdCondicion() {
        return IdCondicion;
    }

    public void setIdCondicion(String idCondicion) {
        IdCondicion = idCondicion;
    }

    public String getIdTipoCondicion() {
        return IdTipoCondicion;
    }

    public void setIdTipoCondicion(String idTipoCondicion) {
        IdTipoCondicion = idTipoCondicion;
    }

    public String getIdTipoPromocion() {
        return IdTipoPromocion;
    }

    public void setIdTipoPromocion(String idTipoPromocion) {
        IdTipoPromocion = idTipoPromocion;
    }

    public String getIdTipoBonificacion() {
        return IdTipoBonificacion;
    }

    public void setIdTipoBonificacion(String idTipoBonificacion) {
        IdTipoBonificacion = idTipoBonificacion;
    }

    public String getMontoBonificacion() {
        return MontoBonificacion;
    }

    public void setMontoBonificacion(String montoBonificacion) {
        MontoBonificacion = montoBonificacion;
    }

    public String getIdTipoUsuario() {
        return IdTipoUsuario;
    }

    public void setIdTipoUsuario(String idTipoUsuario) {
        IdTipoUsuario = idTipoUsuario;
    }

    public String getFlagPrimeraCompra() {
        return flagPrimeraCompra;
    }

    public void setFlagPrimeraCompra(String flagPrimeraCompra) {
        this.flagPrimeraCompra = flagPrimeraCompra;
    }

    public Promocion(String idPromocion, String flagHistorico, String idCondicion, String idTipoCondicion, String idTipoPromocion, String idTipoBonificacion, String montoBonificacion, String idTipoUsuario, String flagPrimeraCompra) {
        IdPromocion = idPromocion;
        this.flagHistorico = flagHistorico;
        IdCondicion = idCondicion;
        IdTipoCondicion = idTipoCondicion;
        IdTipoPromocion = idTipoPromocion;
        IdTipoBonificacion = idTipoBonificacion;
        MontoBonificacion = montoBonificacion;
        IdTipoUsuario = idTipoUsuario;
        this.flagPrimeraCompra = flagPrimeraCompra;
    }
}
