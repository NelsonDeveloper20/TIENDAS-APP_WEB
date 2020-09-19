using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTiendaDelcorp.Models
{
    public class ParametrosSalida
    {
        private String _FlagIndicador = "0";
        private String _MsgValidacion = "";
        private String _Param1;
        private String _Param2;
        private String _Param3;
        private String _Param4;
        private String _Param5;
        private String _Param6;
        private String _Param7;
        private String _Param8;
        private String _Param9;
        private String _Param10;

        private String _Param11;
        private String _Param12;
        private String _Param13;
        private String _Param14;

        public ParametrosSalida() { }


        public ParametrosSalida(String FlagIndicador, String MsgValidacion)
        {
            this._FlagIndicador = FlagIndicador;
            this._MsgValidacion = MsgValidacion;
        }

        public ParametrosSalida(String FlagIndicador, String MsgValidacion,
                                String Param1)
        {
            //this.LimpiarPropiedades();
            this._FlagIndicador = FlagIndicador;
            this._MsgValidacion = MsgValidacion;
            this._Param1 = Param1;
        }

        public ParametrosSalida(String FlagIndicador, String MsgValidacion,
                                String Param1, String Param2)
        {
            //this.LimpiarPropiedades();
            this._FlagIndicador = FlagIndicador;
            this._MsgValidacion = MsgValidacion;
            this._Param1 = Param1;
            this._Param2 = Param2;
        }

        public ParametrosSalida(String FlagIndicador, String MsgValidacion,
                                String Param1, String Param2, String Param3)
        {
            //this.LimpiarPropiedades();
            this._FlagIndicador = FlagIndicador;
            this._MsgValidacion = MsgValidacion;
            this._Param1 = Param1;
            this._Param2 = Param2;
            this._Param3 = Param3;
        }
        public ParametrosSalida(String FlagIndicador, String MsgValidacion,
                                String Param1, String Param2, String Param3, String Param4)
        {
            //this.LimpiarPropiedades();
            this._FlagIndicador = FlagIndicador;
            this._MsgValidacion = MsgValidacion;
            this._Param1 = Param1;
            this._Param2 = Param2;
            this._Param3 = Param3;
            this._Param4 = Param4;
        }
        public ParametrosSalida(String FlagIndicador, String MsgValidacion,
                                String Param1, String Param2, String Param3, String Param4, String Param5)
        {
            //this.LimpiarPropiedades();
            this._FlagIndicador = FlagIndicador;
            this._MsgValidacion = MsgValidacion;
            this._Param1 = Param1;
            this._Param2 = Param2;
            this._Param3 = Param3;
            this._Param4 = Param4;
            this._Param5 = Param5;
        }
        public ParametrosSalida(String FlagIndicador, String MsgValidacion,
                                String Param1, String Param2, String Param3, String Param4, String Param5, String Param6)
        {
            //this.LimpiarPropiedades();
            this._FlagIndicador = FlagIndicador;
            this._MsgValidacion = MsgValidacion;
            this._Param1 = Param1;
            this._Param2 = Param2;
            this._Param3 = Param3;
            this._Param4 = Param4;
            this._Param5 = Param5;
            this._Param6 = Param6;
        }
        public ParametrosSalida(String FlagIndicador, String MsgValidacion,
                                String Param1, String Param2, String Param3, String Param4, String Param5, String Param6
                                , String Param7)
        {
            //this.LimpiarPropiedades();
            this._FlagIndicador = FlagIndicador;
            this._MsgValidacion = MsgValidacion;
            this._Param1 = Param1;
            this._Param2 = Param2;
            this._Param3 = Param3;
            this._Param4 = Param4;
            this._Param5 = Param5;
            this._Param6 = Param6;
            this._Param7 = Param7;
        }
        public ParametrosSalida(String FlagIndicador, String MsgValidacion,
                                String Param1, String Param2, String Param3, String Param4, String Param5, String Param6
                                , String Param7, String Param8)
        {
            //this.LimpiarPropiedades();
            this._FlagIndicador = FlagIndicador;
            this._MsgValidacion = MsgValidacion;
            this._Param1 = Param1;
            this._Param2 = Param2;
            this._Param3 = Param3;
            this._Param4 = Param4;
            this._Param5 = Param5;
            this._Param6 = Param6;
            this._Param7 = Param7;
            this._Param8 = Param8;
        }
        public ParametrosSalida(String FlagIndicador, String MsgValidacion,
                               String Param1, String Param2, String Param3, String Param4, String Param5, String Param6
                               , String Param7, String Param8, String Param9, string correo)
        {
            //this.LimpiarPropiedades();
            this._FlagIndicador = FlagIndicador;
            this._MsgValidacion = MsgValidacion;
            this._Param1 = Param1;
            this._Param2 = Param2;
            this._Param3 = Param3;
            this._Param4 = Param4;
            this._Param5 = Param5;
            this._Param6 = Param6;
            this._Param7 = Param7;
            this._Param8 = Param8;
            this._Param9 = Param9;
        }
        public ParametrosSalida(String FlagIndicador, String MsgValidacion,
                               String Param1, String Param2, String Param3, String Param4, String Param5, String Param6
                               , String Param7, String Param8, String Param9, String Param10, string longitud, string correo)
        {
            //this.LimpiarPropiedades();
            this._FlagIndicador = FlagIndicador;
            this._MsgValidacion = MsgValidacion;
            this._Param1 = Param1;
            this._Param2 = Param2;
            this._Param3 = Param3;
            this._Param4 = Param4;
            this._Param5 = Param5;
            this._Param6 = Param6;
            this._Param7 = Param7;
            this._Param8 = Param8;
            this._Param9 = Param9;
            this._Param10 = Param10;
        }
        public ParametrosSalida(String FlagIndicador, String MsgValidacion,
String Nombre,
String Paterno,
String Materno,
String Celular,
String Telefono,
String dni,
String ruc,
String RazonSocial,
String Direccion,
String Latitud,
String Longitud,
String Correo,
String usuario,
String clave)
        {
            //this.LimpiarPropiedades();
            this._FlagIndicador = FlagIndicador;
            this._MsgValidacion = MsgValidacion;
            this._Param1 = Nombre;
            this._Param2 = Paterno;
            this._Param3 = Materno;
            this._Param4 = Celular;
            this._Param5 = Telefono;
            this._Param6 = dni;
            this._Param7 = ruc;
            this._Param8 = RazonSocial;
            this._Param9 = Direccion;
            this._Param10 = Latitud;
            this._Param11 = Longitud;
            this._Param12 = Correo;
            this._Param13 = usuario;
            this._Param14 = clave;

        }
        public String FlagIndicador
        {
            get { return _FlagIndicador; }
            set { _FlagIndicador = value; }
        }

        public String MsgValidacion
        {
            get { return _MsgValidacion; }
            set { _MsgValidacion = value; }
        }

        public String Param1
        {
            get { return _Param1; }
            set { _Param1 = value; }
        }

        public String Param2
        {
            get { return _Param2; }
            set { _Param2 = value; }
        }

        public String Param3
        {
            get { return _Param3; }
            set { _Param3 = value; }
        }
        public String Param4
        {
            get { return _Param4; }
            set { _Param4 = value; }
        }

        public String Param5
        {
            get { return _Param5; }
            set { _Param5 = value; }
        }
        public String Param6
        {
            get { return _Param6; }
            set { _Param6 = value; }
        }
        public String Param7
        {
            get { return _Param7; }
            set { _Param7 = value; }
        }
        public String Param8
        {
            get { return _Param8; }
            set { _Param8 = value; }
        }
        public String Param9
        {
            get { return _Param9; }
            set { _Param9 = value; }
        }
        public String Param10
        {
            get { return _Param10; }
            set { _Param10 = value; }
        }

        public String Param11
        {
            get { return _Param11; }
            set { _Param11 = value; }
        }
        public String Param12
        {
            get { return _Param12; }
            set { _Param12 = value; }
        }
        public String Param13
        {
            get { return _Param13; }
            set { _Param13 = value; }
        }
        public String Param14
        {
            get { return _Param14; }
            set { _Param14 = value; }
        }
    }
} 