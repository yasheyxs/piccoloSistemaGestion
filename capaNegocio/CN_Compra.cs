using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidad;

namespace capaNegocio
{
    public class CN_Compra
    {
        private CD_Compra objcd_Compra = new CD_Compra();

        public int ObtenerCorrelativo()
        {
            return objcd_Compra.ObtenerCorrelativo();
        }

        public bool Registrar(Compra obj, DataTable detalleCompra, out string mensaje)
        {
            return objcd_Compra.Registrar(obj, detalleCompra, out mensaje);
        }

        public Compra ObtenerCompra(string numero) 
        {
            Compra oCompra = objcd_Compra.ObtenerCompra(numero);

            if (oCompra.idCompra != 0)
            {
                List<DetalleCompra> oDetalleCompra = objcd_Compra.ObtenerDetalleCompra(oCompra.idCompra);
                oCompra.oDetalleCompra = oDetalleCompra;
            }
            return oCompra;
        }
    }
}
