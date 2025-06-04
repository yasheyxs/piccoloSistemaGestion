using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidad;

namespace capaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objcd_cliente = new CD_Cliente();

        public List<Cliente> Listar()
        {
            return objcd_cliente.Listar();
        }

        public int Registrar(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.nombre == "")
            {
                mensaje += "Es necesario el nombre del cliente.\n";
            }
            if (obj.telefono == "")
            {
                mensaje += "Es necesario el teléfono del cliente.\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_cliente.Registrar(obj, out mensaje);
            }
        }

        public bool Editar(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.nombre == "")
            {
                mensaje += "Es necesario el nombre del cliente.\n";
            }
            if (obj.telefono == "")
            {
                mensaje += "Es necesario el teléfono del cliente.\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_cliente.Editar(obj, out mensaje);
            }
        }

        public bool Eliminar(Cliente obj, out string mensaje)
        {
            return objcd_cliente.Eliminar(obj, out mensaje);
        }
    }
}
