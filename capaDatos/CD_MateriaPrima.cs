using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidad;

namespace capaDatos
{
    public class CD_MateriaPrima
    {
        public List<MateriaPrima> Listar()
        {
            List<MateriaPrima> lista = new List<MateriaPrima>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idMateriaPrima, codigo, nombre, p.descripcion, c.idCategoria, c.descripcion[descripcionCategoria], precioCompra, p.estado, stock from MateriaPrima p");
                    query.AppendLine("inner join CATEGORIA c on c.idCategoria = p.idCategoria");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new MateriaPrima()
                            {
                                idMateriaPrima = Convert.ToInt32(dr["idMateriaPrima"]),
                                codigo = dr["codigo"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                descripcion = dr["descripcion"].ToString(),
                                oCategoria = new Categoria() { idCategoria = Convert.ToInt32(dr["idCategoria"]), descripcion = dr["descripcionCategoria"].ToString() },
                                precioCompra = Convert.ToDecimal(dr["precioCompra"]),
                                estado = Convert.ToBoolean(dr["estado"]),
                                stock = Convert.ToInt32(dr["stock"])
                            });
                        }
                    }

                }
                catch (Exception ex)
                {

                    lista = new List<MateriaPrima>();
                }
            }
            return lista;
        }

        public int Registrar(MateriaPrima obj, out string mensaje)
        {
            mensaje = string.Empty;
            int idMateriaPrimaGenerado = 0;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARMATERIAPRIMA", oConexion);
                    cmd.Parameters.AddWithValue("codigo", obj.codigo);
                    cmd.Parameters.AddWithValue("nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("idCategoria", obj.oCategoria.idCategoria);
                    cmd.Parameters.AddWithValue("estado", obj.estado);
                    cmd.Parameters.AddWithValue("stock", obj.stock);

                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();
                    idMateriaPrimaGenerado = Convert.ToInt32(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idMateriaPrimaGenerado = 0;
                mensaje = ex.Message;
            }

            return idMateriaPrimaGenerado;
        }

        public bool Editar(MateriaPrima obj, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = false;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_MODIFICARMATERIAPRIMA", oConexion);
                    cmd.Parameters.AddWithValue("idMateriaPrima", obj.idMateriaPrima);
                    cmd.Parameters.AddWithValue("codigo", obj.codigo);
                    cmd.Parameters.AddWithValue("nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("idCategoria", obj.oCategoria.idCategoria);
                    cmd.Parameters.AddWithValue("estado", obj.estado);
                    cmd.Parameters.AddWithValue("stock", obj.stock);

                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }

            return respuesta;
        }

        public bool Eliminar(MateriaPrima obj, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = false;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARMATERIAPRIMA", oConexion);
                    cmd.Parameters.AddWithValue("idMateriaPrima", obj.idMateriaPrima);

                    cmd.Parameters.Add("respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }

            return respuesta;
        }
    }
}
