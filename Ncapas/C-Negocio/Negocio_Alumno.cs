using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Datos;
using C_Entidades;

namespace C_Negocio
{
    public class Negocio_Alumno
    {
        //Metodo para listar alumnos
        public static DataTable Listar()
        {
            //Generar una instancia a la clase Datos_Alumno
            Datos_Alumno datos = new Datos_Alumno();
            return datos.Listar();
        }

        //Metodo para buscar a los alumnos
        public static DataTable Buscar(string valor)
        {
            //Generar una instancia a la clase Datos_Alumno
            Datos_Alumno datos = new Datos_Alumno();
            return datos.Buscar(valor);
        }

        //Metodo para insertar a los alumnos
        public static string Insertar(string Nombre, string Apellidio, int Edad)
        {
            //1- Realizo la referencia hacia la clase Datos_Alumno y la clase Alumno
            Datos_Alumno datos = new Datos_Alumno();
            Alumno obj = new Alumno();
            //2- La informacion de las variables del metodo insertar de la capa de negocios debo asignar variables de la clase Alumno
            obj.Nombre = Nombre;
            obj.Apellido = Apellidio;
            obj.Edad = Edad;
            return datos.Insertar(obj);
        }

        //Metodo para actualizar a los alumnos
        public static string Actualizar(int Id, string Nombre, string Apellidio, int Edad)
        {
            //1- Realizo la referencia hacia la clase Datos_Alumno y la clase Alumno
            Datos_Alumno datos = new Datos_Alumno();
            Alumno obj = new Alumno();
            //2- La informacion de las variables del metodo insertar de la capa de negocios debo asignar variables de la clase Alumno
            obj.Id = Id;
            obj.Nombre = Nombre;
            obj.Apellido = Apellidio;
            obj.Edad = Edad;
            return datos.Actualizar(obj);
        }

        //Metodo para eliminar registros
        public static string Eliminar(int Id)
        {
            //Generar una instancia a la clase Datos_Alumno
            Datos_Alumno datos = new Datos_Alumno();
            return datos.Eliminar(Id);
        } 

        //Metodo para activar registros
        public static string Activar(int Id)
        {
            //Generar una instancia a la clase Datos_Alumno
            Datos_Alumno datos = new Datos_Alumno();
            return datos.Activar(Id);
        } 

        //Metodo para desactivar los registros
        public static string Desactivar(int Id)
        {
            //Generar una instancia a la clase Datos_Alumno
            Datos_Alumno datos = new Datos_Alumno();
            return datos.Desactivar(Id);
        }
    }
}
