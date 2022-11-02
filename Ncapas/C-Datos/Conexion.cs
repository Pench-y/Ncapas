using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace C_Datos
{
    class Conexion
    {
        //Variables privadas
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;//Metodo de autenticacion
        private static Conexion con = null;//objeto tipo conexion

        private Conexion()
        {
            this.Base = "Datos";
            this.Servidor = "DENICOLAS\\SQLEXPRESS";
            this.Usuario = "sa";
            this.Clave = "1031644280";
            this.Seguridad = true;
        }

  
            //Metodo para devolver el string conexion
            public SqlConnection crearConexion()
        {
            //Variale sqlconnection
            SqlConnection cadena = new SqlConnection();
            try
            {
                //Cadena de conexion
                cadena.ConnectionString = "Server=" + this.Servidor + "; Database=" + this.Base + ";";
                //validacion de seguridad en conexion
                if (this.Seguridad)
                {
                    cadena.ConnectionString = cadena.ConnectionString + "Integrated Security = SSPI";
                }
                else
                {
                    cadena.ConnectionString = cadena.ConnectionString + "User id=" + this.Usuario + ";Password" + this.Clave;
                }
            }
            catch(Exception ex)
            {
                cadena = null;
                throw ex; //mostrar mensaje error
            }
            return cadena;
        }

        //Asignar valor a las variables
        public static Conexion crearInstancia()
        {
            if(con == null)
            {
                con = new Conexion();
            }
            return con;
        }
    }

}
