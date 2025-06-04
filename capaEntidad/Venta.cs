using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public class Venta
    {
        public int idVenta {  get; set; }
        public Usuario oUsuario { get; set; }
        public Cliente oCliente { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string nombreCliente { get; set; }
        public string telefonoCliente { get; set; }
        public decimal montoPago { get; set; }
        public decimal montoCambio { get; set; }
        public decimal montoTotal { get; set; }
        public List<DetalleVenta> oDetalleVenta {get; set;}
        public string fechaRegistro { get; set; }
    }
}
