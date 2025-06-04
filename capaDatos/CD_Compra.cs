using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidad;
using System.Reflection;

namespace capaDatos
{
    public class CD_Compra
    {
        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from COMPRA");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    idcorrelativo = 0;
                }
            }

            return idcorrelativo;
        }

        public bool Registrar(Compra obj, DataTable detalleCompra, out string mensaje) 
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCOMPRA", oConexion);
                    cmd.Parameters.AddWithValue("idUsuario", obj.oUsuario.idUsuario);
                    cmd.Parameters.AddWithValue("idProveedor", obj.oProveedor.idProveedor);
                    cmd.Parameters.AddWithValue("tipoDocumento", obj.tipoDocumento);
                    cmd.Parameters.AddWithValue("numeroDocumento", obj.numeroDocumento);
                    cmd.Parameters.AddWithValue("montoTotal", obj.montoTotal);
                    cmd.Parameters.AddWithValue("detalleCompra", detalleCompra);

                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }
            }
            return respuesta;
        }


        public Compra ObtenerCompra(string numero) 
        {
            Compra obj = new Compra();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select c.idCompra, ");
                    query.AppendLine("u.nombre,");
                    query.AppendLine("pr.telefono, pr.razonSocial,");
                    query.AppendLine("c.tipoDocumento, c.numeroDocumento, c.montoTotal, CONVERT(char(10), c.fechaRegistro, 103)[fechaRegistro]");
                    query.AppendLine("from COMPRA c");
                    query.AppendLine("inner join USUARIO u on u.idUsuario = c.idUsuario");
                    query.AppendLine("inner join PROVEEDOR pr on pr.idProveedor = c.idProveedor");
                    query.AppendLine("where c.numeroDocumento = @numero");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Compra() 
                            {
                                idCompra = Convert.ToInt32(dr["idCompra"]),
                                oUsuario = new Usuario() { nombre = dr["nombre"].ToString() },
                                oProveedor = new Proveedor() { telefono = dr["telefono"].ToString(), razonSocial = dr["razonSocial"].ToString() },
                                tipoDocumento = dr["tipoDocumento"].ToString(),
                                numeroDocumento = dr["numeroDocumento"].ToString(),
                                montoTotal = Convert.ToDecimal( dr["montoTotal"].ToString()),
                                fechaRegistro = dr["fechaRegistro"].ToString()
                            };
                        }
                    }

                }
                catch
                {
                    obj = new Compra();
                }
            }
            return obj;
        }

        public List<DetalleCompra> ObtenerDetalleCompra(int idCompra) 
        {
            List<DetalleCompra> oLista = new List<DetalleCompra>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select p.nombre, dc.precioCompra, dc.cantidad, dc.montoTotal from DETALLE_COMPRA dc");
                    query.AppendLine("inner join MATERIAPRIMA p on p.idMateriaPrima = dc.idMateriaPrima");
                    query.AppendLine("where dc.idCompra = @idCompra");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idCompra", idCompra);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader()) 
                    {
                        while (dr.Read()) 
                        {
                            oLista.Add(new DetalleCompra()
                            {
                                oMateriaPrima = new MateriaPrima() {nombre = dr["nombre"].ToString() },
                                precioCompra = Convert.ToDecimal(dr["precioCompra"].ToString()),
                                cantidad = Convert.ToInt32(dr["cantidad"].ToString()),
                                montoTotal = Convert.ToDecimal(dr["montoTotal"].ToString())
                            });
                        }
                    };
                };
            }
            catch (Exception)
            {
                oLista = new List<DetalleCompra>();
            }
            return oLista;
        }

    }
}
