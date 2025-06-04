using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidad;

namespace capaNegocio
{
    public class CN_Negocio
    {
        private CD_Negocio objcd_Negocio = new CD_Negocio();

        public Negocio ObtenerDatos()
        {
            return objcd_Negocio.ObtenerDatos();
        }

        public bool GuardarDatos(Negocio obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.nombre == "")
            {
                mensaje += "Es necesario el nombre.\n";
            }
            if (obj.CUIT == "")
            {
                mensaje += "Es necesario el CUIT.\n";
            }
            if (obj.direccion == "")
            {
                mensaje += "Es necesaria la dirección.\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Negocio.GuardarDatos(obj, out mensaje);
            }
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            return objcd_Negocio.ObtenerLogo(out obtenido);
        }

        public bool ActualizarLogo(byte[] imagen, out string mensaje)
        {
            return objcd_Negocio.ActualizarLogo(imagen, out mensaje);
        }
    }
}
