using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DProducto
    {
        public List<EProducto> ObtenerListado()
        {
            using (SqlConnection miconexion = new SqlConnection(Conexion.GetCadena()))
            {
                miconexion.Open();
                using (SqlCommand micomando = new SqlCommand())
                {
                    micomando.Connection = miconexion;
                    micomando.CommandText = "[usp.PRODUCTO.ObtenerListado]";
                    micomando.CommandType = CommandType.StoredProcedure;
                    SqlDataReader milector = micomando.ExecuteReader();
                    List<EProducto> milista = new List<EProducto>();
                    while (milector.Read())
                    {
                        EProducto miItem = new EProducto();
                        miItem.IdProducto = int.Parse(milector["IdProducto"].ToString());
                        miItem.Nombre = milector["Nombre"].ToString();
                        miItem.Precio = decimal.Parse(milector["Precio"].ToString());
                        miItem.Stock = int.Parse(milector["Stock"].ToString());
                        milista.Add(miItem);
                    }
                    miconexion.Close();
                    return milista;
                }
            }
        }

        public bool Insertar(EProducto producto)
        {
            bool respuesta = false;
            using (SqlConnection miconexion = new SqlConnection(Conexion.GetCadena()))
            {
                miconexion.Open();
                using (SqlCommand micomando = new SqlCommand())
                {
                    micomando.Connection = miconexion;
                    micomando.CommandText = "[usp.PRODUCTO.Insertar]";
                    micomando.CommandType = CommandType.StoredProcedure;
                    micomando.Parameters.AddWithValue("@nombre",producto.Nombre);
                    micomando.Parameters.AddWithValue("@precio",producto.Precio);
                    micomando.Parameters.AddWithValue("@stock",producto.Stock);

                    int filasAfectadas = micomando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        respuesta = true;
                    }
                    miconexion.Close();
                    return respuesta;
                }
            }
        }
    }
}
