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
    public class CN_Venta
    {
        private CD_Venta objcd_venta = new CD_Venta();

        public int ObtenerCorrelativo()
        {
            return objcd_venta.ObtenerCorrelativo();
        }

        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            return objcd_venta.Registrar(obj, DetalleVenta, out Mensaje);
        }

        public Venta ObtenerVenta(string numero)
        {
            Venta oVenta = objcd_venta.ObtenerVenta(numero);

            if (oVenta.idVenta != 0)
            {
                List<DetalleVenta> oDetalleVenta = objcd_venta.ObtenerDetalleVenta(oVenta.idVenta);
                oVenta.oDetalleVenta = oDetalleVenta;
            }

            return oVenta;
        }
    }
}
