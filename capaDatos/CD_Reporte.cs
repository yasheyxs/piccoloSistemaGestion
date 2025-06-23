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
    public class CD_Reporte
    {
        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            List<ReporteCompra> lista = new List<ReporteCompra>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("SP_REPORTECOMPRAS", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
                    cmd.Parameters.AddWithValue("idproveedor", idproveedor);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            lista.Add(new ReporteCompra()
                            {
                                fechaRegistro = dr["fechaRegistro"].ToString(),
                                tipoDocumento = dr["tipoDocumento"].ToString(),
                                numeroDocumento = dr["numeroDocumento"].ToString(),
                                montoTotal = dr["montoTotal"].ToString(),
                                usuarioRegistro = dr["usuarioRegistro"].ToString(),
                                telefonoProveedor = dr["telefonoProveedor"].ToString(),
                                razonSocial = dr["razonSocial"].ToString(),
                                codigoMateria = dr["codigoProducto"].ToString(),
                                nombreMateria = dr["nombreProducto"].ToString(),
                                categoria = dr["categoria"].ToString(),
                                precioCompra = dr["precioCompra"].ToString(),
                                cantidad = dr["cantidad"].ToString(),
                                subtotal = dr["subtotal"].ToString(),
                            });
                        }
                    }
                }
                catch
                {

                    lista = new List<ReporteCompra>();
                }
            }

            return lista;

        }

        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta()
                            {
                                fechaRegistro = dr["FechaRegistro"].ToString(),
                                tipoDocumento = dr["TipoDocumento"].ToString(),
                                numeroDocumento = dr["NumeroDocumento"].ToString(),
                                montoTotal = dr["MontoTotal"].ToString(),
                                usuarioRegistro = dr["usuarioRegistro"].ToString(),
                                telefonoCliente = dr["telefono"].ToString(),
                                nombreCliente = dr["nombreCliente"].ToString(),
                                codigoProducto = dr["codigoProducto"].ToString(),
                                nombreProducto = dr["nombreProducto"].ToString(),
                                categoria = dr["categoria"].ToString(),
                                precioVenta = dr["precioVenta"].ToString(),
                                cantidad = dr["cantidad"].ToString(),
                                subtotal = dr["subTotal"].ToString(),
                            });
                        }
                    }
                }
                catch
                {
                    lista = new List<ReporteVenta>();
                }
            }

            return lista;

        }
    }
}
