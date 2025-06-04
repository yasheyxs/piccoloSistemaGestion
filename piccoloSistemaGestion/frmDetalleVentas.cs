using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidad;
using capaNegocio;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace piccoloSistemaGestion
{
    public partial class frmDetalleVentas: Form
    {
        public frmDetalleVentas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Venta oVenta = new CN_Venta().ObtenerVenta(txtBuscar.Text);

            if (oVenta.idVenta != 0)
            {
                txtNroDocumento.Text = oVenta.numeroDocumento;

                txtFecha.Text = oVenta.fechaRegistro;
                txtTipoDocumento.Text = oVenta.tipoDocumento;
                txtUsuario.Text = oVenta.oUsuario.nombre;
                txtTelefono.Text = oVenta.telefonoCliente;
                txtNombreCliente.Text = oVenta.nombreCliente;

                dgvData.Rows.Clear();
                foreach (DetalleVenta dc in oVenta.oDetalleVenta)
                {
                    dgvData.Rows.Add(new object[] { dc.oProducto.nombre, dc.precioVenta, dc.cantidad, dc.subTotal });
                }

                txtMontoTotal.Text = oVenta.montoTotal.ToString("0.00");
                txtMontoPago.Text = oVenta.montoPago.ToString("0.00");
                txtMontoCambio.Text = oVenta.montoCambio.ToString("0.00");
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            txtTipoDocumento.Text = "";
            txtUsuario.Text = "";
            txtTelefono.Text = "";
            txtNombreCliente.Text = "";

            dgvData.Rows.Clear();
            txtMontoTotal.Text = "0.00";
            txtMontoPago.Text = "";
            txtMontoCambio.Text = "";
        }

        private void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            if (txtTipoDocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_Html = Properties.Resources.PlantillaVenta.ToString();
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", odatos.CUIT);
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.direccion);

            Texto_Html = Texto_Html.Replace("@tipodocumento", txtTipoDocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtNroDocumento.Text);


            Texto_Html = Texto_Html.Replace("@telcliente", txtTelefono.Text);
            Texto_Html = Texto_Html.Replace("@nombrecliente", txtNombreCliente.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtFecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioVenta"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Subtotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txtMontoTotal.Text);
            Texto_Html = Texto_Html.Replace("@pagocon", txtMontoPago.Text);
            Texto_Html = Texto_Html.Replace("@cambio", txtMontoCambio.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}.pdf", txtNroDocumento.Text);
            savefile.Filter = "Pdf Files | *.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {

                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    bool obtenido = true;
                    byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento generado", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmDetalleVentas_Load(object sender, EventArgs e)
        {
            txtBuscar.Select();
        }
    }
}
