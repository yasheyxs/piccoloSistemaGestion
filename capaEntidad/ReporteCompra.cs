using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public class ReporteCompra
    {
        public string fechaRegistro { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string montoTotal { get; set; }
        public string usuarioRegistro { get; set; }
        public string telefonoProveedor { get; set; }
        public string razonSocial { get; set; }
        public string codigoMateria { get; set; }
        public string nombreMateria { get; set; }
        public string categoria { get; set; }
        public string precioCompra { get; set; }
        public string cantidad { get; set; }
        public string subtotal { get; set; }
    }
}
