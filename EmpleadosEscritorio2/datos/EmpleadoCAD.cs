using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleadosEscritorio2.modelo;

namespace EmpleadosEscritorio2.datos
{
    internal class EmpleadoCAD
    {
        public static bool guardar(Empleado e)
        {
            try {
                Conexion con = new Conexion();
                string sql = "INSERT INTO tb_empleados VALUES('" + e.Documento + "', '" + e.Nombres + "', '" + e.Apellidos + "', '" + e.Edad + "', '" + e.Direccion + "', '" + e.Fecha_nacimiento + "')";
                SqlCommand comando = new SqlCommand(sql,con.conectar());
                int cantidad = comando.ExecuteNonQuery();

                if (cantidad == 1)
                {
                    con.desconectar();
                    return true;
                }
                else
                {
                    con.desconectar();
                    return false;
                }

            } catch (Exception ex)
            {
                return false;   
            }
        }

        public static DataTable listar()
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "SELECT * FROM tb_empleados";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection );

                DataTable dt = new DataTable();
                dt. Load(dr);

                con.desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Empleado consultar(string documento)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "SELECT * FROM tb_empleados WHERE documento='"+documento+"'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader();
                Empleado em = new Empleado();
                if (dr.Read())
                {
                    em.Documento = dr["documento"].ToString();
                    em.Nombres = dr["nombres"].ToString();
                    em.Apellidos = dr["apellidos"].ToString();
                    em.Edad = Convert.ToInt32(dr["edad"].ToString());
                    em.Direccion = dr["direccion"].ToString();
                    em.Fecha_nacimiento = dr["fecha_nacimiento"].ToString();
                    con.desconectar();
                    return em;
                } else
                {
                    con.desconectar();
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool actualizar(Empleado e)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "UPDATE tb_empleados SET nombres='" + e.Nombres + "', apellidos='" + e.Apellidos + "', edad='" + e.Edad + "', direccion='" + e.Direccion + "', fecha_nacimiento='" + e.Fecha_nacimiento + "' WHERE documento='"+e.Documento+"'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int cantidad = comando.ExecuteNonQuery();

                if (cantidad == 1)
                {
                    con.desconectar();
                    return true;
                }
                else
                {
                    con.desconectar();
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool eliminar(string documento)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "DELETE FROM tb_empleados WHERE documento='" + documento + "'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int cantidad = comando.ExecuteNonQuery();

                if (cantidad == 1)
                {
                    con.desconectar();
                    return true;
                }
                else
                {
                    con.desconectar();
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
