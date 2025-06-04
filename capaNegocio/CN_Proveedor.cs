using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidad;

namespace capaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor objcd_Proveedor = new CD_Proveedor();

        public List<Proveedor> Listar()
        {
            return objcd_Proveedor.Listar();
        }

        public int Registrar(Proveedor obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.razonSocial == "")
            {
                mensaje += "Es necesaria la razón social del proveedor.\n";
            }
            if (obj.correo == "")
            {
                mensaje += "Es necesario el correo del proveedor.\n";
            }
            if (obj.telefono == "")
            {
                mensaje += "Es necesario el teléfono del proveedor.\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Proveedor.Registrar(obj, out mensaje);
            }
        }

        public bool Editar(Proveedor obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.razonSocial == "")
            {
                mensaje += "Es necesaria la razón social del proveedor.\n";
            }
            if (obj.correo == "")
            {
                mensaje += "Es necesario el correo del proveedor.\n";
            }
            if (obj.telefono == "")
            {
                mensaje += "Es necesario el teléfono del proveedor.\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Proveedor.Editar(obj, out mensaje);
            }
        }

        public bool Eliminar(Proveedor obj, out string mensaje)
        {
            return objcd_Proveedor.Eliminar(obj, out mensaje);
        }
    }
}
