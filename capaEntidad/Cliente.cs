using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public class Cliente
    {
        public int idCliente {  get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public bool estado { get; set; }
        public string fechaRegistro { get; set; }
    }
}
