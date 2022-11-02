using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//Permite utilizar el metodo DataTable
using System.Data.SqlClient;
using C_Entidades;

namespace C_Datos
{
    public class Datos_Alumno
    {
        //Metodo para listar elementos de la base de datos
        public DataTable Listar()
        {
            SqlDataReader resultado;  //Permite leer una secuencia de filas en una tabla dentro de sql
            DataTable Tabla = new DataTable();
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("listar_alumno", conexion); //Permite ejecutar consultas
                comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                resultado = comando.ExecuteReader();
                Tabla.Load(resultado);
                return Tabla;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
        }

        //Metodo para buscar a los alumnos
        public DataTable Buscar(string valor)
        {
            SqlDataReader resultado;  //Permite leer una secuencia de filas en una tabla dentro de sql
            DataTable Tabla = new DataTable();
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("buscar_alumno", conexion); //Permite ejecutar consultas
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;//Parametros
                conexion.Open();
                resultado = comando.ExecuteReader();
                Tabla.Load(resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
        }

        //Metodo para insertar datos del alumno
        public string Insertar(Alumno obj)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("insertar_alumno", conexion); //Permite ejecutar consultas
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = obj.Nombre;//Parametros
                comando.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = obj.Apellido;
                comando.Parameters.Add("@Edad", SqlDbType.Int).Value = obj.Edad;
                conexion.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo ingresr el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return respuesta;
        }
        //Metodo para actualizar los datos del alumno
        public string Actualizar(Alumno obj)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("actualizar_alumno", conexion); //Permite ejecutar consultas
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = obj.Id;
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = obj.Nombre;//Parametros
                comando.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = obj.Apellido;
                comando.Parameters.Add("@Edad", SqlDbType.Int).Value = obj.Edad;
                conexion.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return respuesta;
        }
        
        //Metodo para eliminar los registros de los alumnos
        public string Eliminar(int Id)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("eliminar_alumno", conexion); //Permite ejecutar consultas
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = Id;//Parametros
                conexion.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return respuesta;
        }

        //Metodo para activar el registro del alumno
        public string Activar(int Id)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("activar_alumno", conexion); //Permite ejecutar consultas
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = Id;//Parametros
                conexion.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo activar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return respuesta;
        }

        ////Metodo para Desactivar el registro del alumno
        public string Desactivar(int Id)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("descativar_alumno", conexion); //Permite ejecutar consultas
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = Id;//Parametros
                conexion.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo Desactivar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return respuesta;
        }
    }
}