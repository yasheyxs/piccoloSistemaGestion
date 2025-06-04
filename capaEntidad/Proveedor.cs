using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public class Proveedor
    {
        public int idProveedor { get; set; }
        public string razonSocial { get; set; }
        public string correo {  get; set; }
        public string telefono { get; set; }
        public bool estado { get; set; }
        public string fechaRegistro { get; set; }
    }
}
