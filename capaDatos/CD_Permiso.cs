using System;
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
    public class CD_Permiso
    {
        public List<Permiso> Listar(int idUsuario)
        {
            List<Permiso> lista = new List<Permiso>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select p.idRol, p.nombreMenu from PERMISO p");
                    query.AppendLine("inner join ROL r on r.idRol = p.idRol");
                    query.AppendLine("inner join USUARIO u on u.idRol = r.idRol");
                    query.AppendLine("where u.idUsuario = @idUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                oRol = new Rol { idRol = Convert.ToInt32(dr["idRol"])},
                                nombreMenu = dr["nombreMenu"].ToString(),
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();
                }
            }
            return lista;
        }
    }
}
