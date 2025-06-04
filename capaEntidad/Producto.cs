using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion {  get; set; }
        public Categoria oCategoria { get; set; }
        public decimal precioCompra {  get; set; }
        public decimal precioVenta { get; set; }
        public bool estado { get; set; }
        public string fechaRegistro { get; set; }
    }
}
