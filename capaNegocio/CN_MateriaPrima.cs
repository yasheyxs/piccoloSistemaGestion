using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidad;

namespace capaNegocio
{
    public class CN_MateriaPrima
    {
        private CD_MateriaPrima objcd_MateriaPrima = new CD_MateriaPrima();

        public List<MateriaPrima> Listar()
        {
            return objcd_MateriaPrima.Listar();
        }

        public int Registrar(MateriaPrima obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.codigo == "")
            {
                mensaje += "Es necesario el código de la materia prima.\n";
            }
            if (obj.nombre == "")
            {
                mensaje += "Es necesario el nombre de la materia prima.\n";
            }
            if (obj.descripcion == "")
            {
                mensaje += "Es necesaria la descripción de la materia prima.\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_MateriaPrima.Registrar(obj, out mensaje);
            }
        }

        public bool Editar(MateriaPrima obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.codigo == "")
            {
                mensaje += "Es necesario el código de la materia prima.\n";
            }
            if (obj.nombre == "")
            {
                mensaje += "Es necesario el nombre de la materia prima.\n";
            }
            if (obj.descripcion == "")
            {
                mensaje += "Es necesaria la descripción de la materia prima.\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_MateriaPrima.Editar(obj, out mensaje);
            }
        }

        public bool Eliminar(MateriaPrima obj, out string mensaje)
        {
            return objcd_MateriaPrima.Eliminar(obj, out mensaje);
        }
    }
}
