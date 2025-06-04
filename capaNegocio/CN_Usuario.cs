﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capaDatos;
using capaEntidad;

namespace capaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();

        public List<Usuario> Listar()
        { 
            return objcd_usuario.Listar();
        }

        public int Registrar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.documento == "")
            {
                mensaje += "Es necesario el documento del usuario.\n";
            }
            if (obj.nombre == "")
            {
                mensaje += "Es necesario el nombre del usuario.\n";
            }
            if (obj.clave == "")
            {
                mensaje += "Es necesaria la clave del usuario.\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.Registrar(obj, out mensaje);
            }
         }

        public bool Editar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.documento == "")
            {
                mensaje += "Es necesario el documento del usuario.\n";
            }
            if (obj.nombre == "")
            {
                mensaje += "Es necesario el nombre del usuario.\n";
            }
            if (obj.clave == "")
            {
                mensaje += "Es necesaria la clave del usuario.\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.Editar(obj, out mensaje);
            }
        }

        public bool Eliminar(Usuario obj, out string mensaje)
        {
            return objcd_usuario.Eliminar(obj, out mensaje);
        }
    }
}
