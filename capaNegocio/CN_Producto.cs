using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidad;

namespace capaNegocio
{
    public class CN_Producto
    {
        private CD_Producto objcd_Producto = new CD_Producto();

        public List<Producto> Listar()
        {
            return objcd_Producto.Listar();
        }

        public int Registrar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.codigo == "")
            {
                mensaje += "Es necesario el código del producto.\n";
            }
            if (obj.nombre == "")
            {
                mensaje += "Es necesario el nombre del producto.\n";
            }
            if (obj.descripcion == "")
            {
                mensaje += "Es necesaria la descripción del producto.\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Producto.Registrar(obj, out mensaje);
            }
        }

        public bool Editar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.codigo == "")
            {
                mensaje += "Es necesario el código del producto.\n";
            }
            if (obj.nombre == "")
            {
                mensaje += "Es necesario el nombre del producto.\n";
            }
            if (obj.descripcion == "")
            {
                mensaje += "Es necesaria la descripción del producto.\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Producto.Editar(obj, out mensaje);
            }
        }

        public bool Eliminar(Producto obj, out string mensaje)
        {
            return objcd_Producto.Eliminar(obj, out mensaje);
        }
    }
}
