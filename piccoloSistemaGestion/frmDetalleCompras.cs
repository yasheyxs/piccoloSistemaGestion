using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidad;
using capaNegocio;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace piccoloSistemaGestion
{
    public partial class frmDetalleCompras: Form
    {
        public frmDetalleCompras()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Compra oCompra = new CN_Compra().ObtenerCompra(txtBuscar.Text);

            if (oCompra.idCompra != 0)
            {
                txtNroDocumento.Text = oCompra.numeroDocumento;

                txtFecha.Text = oCompra.fechaRegistro;
                txtTipoDocumento.Text = oCompra.tipoDocumento;
                txtUsuario.Text = oCompra.oUsuario.nombre;
                txtTelefono.Text = oCompra.oProveedor.telefono;
                txtNombreProveedor.Text = oCompra.oProveedor.razonSocial;

                dgvData.Rows.Clear();
                foreach (DetalleCompra dc in oCompra.oDetalleCompra)
                {
                    dgvData.Rows.Add(new object[] {dc.oMateriaPrima.nombre, dc.precioCompra, dc.cantidad, dc.montoTotal });
                }

                txtMonto.Text = oCompra.montoTotal.ToString("0.00");
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            txtTipoDocumento.Text = "";
            txtUsuario.Text = "";
            txtTelefono.Text = "";
            txtNombreProveedor.Text = "";

            dgvData.Rows.Clear();
            txtMonto.Text = "0.00";
        }

        private void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            if (txtTipoDocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_html = Properties.Resources.PlantillaCompra.ToString();
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            Texto_html = Texto_html.Replace("@nombrenegocio", odatos.nombre.ToUpper());
            Texto_html = Texto_html.Replace("@docnegocio", odatos.CUIT.ToUpper());
            Texto_html = Texto_html.Replace("@direcnegocio", odatos.direccion.ToUpper());

            Texto_html = Texto_html.Replace("@tipodocumento", txtTipoDocumento.Text.ToUpper());
            Texto_html = Texto_html.Replace("@numerodocumento", txtNroDocumento.Text);

            Texto_html = Texto_html.Replace("@telproveedor", txtTelefono.Text);
            Texto_html = Texto_html.Replace("@nombreproveedor", txtNombreProveedor.Text);
            Texto_html = Texto_html.Replace("@fecharegistro", txtFecha.Text);
            Texto_html = Texto_html.Replace("@usuarioregistro", txtUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["MateriaPrima"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Subtotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_html = Texto_html.Replace("@filas", filas);
            Texto_html = Texto_html.Replace("@montototal", txtMonto.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("DetalleCompra_{0}.pdf", txtNroDocumento.Text);
            savefile.Filter = "Pdf Files | *.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream (savefile.FileName, FileMode.Create)) 
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    
                    bool obtenido = true;
                    byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60,60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(Texto_html)) 
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento generado", "Estado de documento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmDetalleCompras_Load(object sender, EventArgs e)
        {

        }
    }
}
