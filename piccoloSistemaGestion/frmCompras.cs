using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidad;
using capaNegocio;
using capaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Wordprocessing;
using piccoloSistemaGestion.Modales;

namespace piccoloSistemaGestion
{
    public partial class frmCompras: Form
    {
        private Usuario _Usuario;

        public frmCompras(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            cboDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cboDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cboDocumento.DisplayMember = "Texto";
            cboDocumento.ValueMember = "Valor";
            cboDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtIdProveedor.Text = "0";
            txtIdMateria.Text = "0";
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProveedor())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProveedor.Text = modal._Proveedor.idProveedor.ToString();
                    txtNombreProveedor.Text = modal._Proveedor.razonSocial;
                    txtTelefono.Text = modal._Proveedor.telefono;
                }
                else
                {
                    txtTelefono.Select();
                }
            }
        }

        private void btnBuscarMateria_Click(object sender, EventArgs e)
        {
            using (var modal = new mdMateriaPrima())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdMateria.Text = modal._MateriaPrima.idMateriaPrima.ToString();
                    txtCodigoMateria.Text = modal._MateriaPrima.codigo;
                    txtNombreMateria.Text = modal._MateriaPrima.nombre;
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtCodigoMateria.Select();
                }
            }
        }

        private void txtCodigoMateria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                MateriaPrima oMateriaPrima = new CN_MateriaPrima().Listar().Where(p => p.codigo == txtCodigoMateria.Text && p.estado == true).FirstOrDefault();
                if (oMateriaPrima != null)
                {
                    txtCodigoMateria.BackColor = System.Drawing.Color.Honeydew;
                    txtIdMateria.Text = oMateriaPrima.idMateriaPrima.ToString();
                    txtNombreMateria.Text = oMateriaPrima.nombre;
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtCodigoMateria.BackColor = System.Drawing.Color.MistyRose;
                    txtIdMateria.Text = "0";
                    txtNombreMateria.Text = "";
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precioCompra = 0;
            bool producto_existe = false;

            if (int.Parse(txtIdMateria.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(txtPrecioCompra.Text, out precioCompra))
            {
                MessageBox.Show("Formato de moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioCompra.Select();
                return;
            }

            foreach (DataGridViewRow fila in dgvData.Rows)
            {
                if (fila.Cells["id"].Value.ToString() == txtIdMateria.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            if (!producto_existe)
            {
                dgvData.Rows.Add(new object[] { 
                    txtIdMateria.Text,
                    txtNombreMateria.Text,
                    precioCompra.ToString("0.00"),
                    txtCantidad.Value.ToString(),
                    (txtCantidad.Value * precioCompra).ToString("0.00")
                });

                calcularTotal();
                LimpiarMaterias();
                txtCodigoMateria.Select();
            }
        }

        private void LimpiarMaterias()
        {
            txtIdMateria.Text = "0";
            txtCodigoMateria.Text = "";
            txtCodigoMateria.BackColor = System.Drawing.Color.White;
            txtNombreMateria.Text = "";
            txtPrecioCompra.Text = "";
            txtCantidad.Value = 1;
        }

        private void calcularTotal()
        {
            decimal total = 0;
            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows) 
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value.ToString());
                }
            }
            txtTotal.Text = total.ToString("0.00");
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.basura16px.Width;
                var h = Properties.Resources.basura16px.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.basura16px, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btneEliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dgvData.Rows.RemoveAt(indice);
                    calcularTotal();
                }
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecioCompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtIdProveedor.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la comrpa", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalle_compra = new DataTable();
            detalle_compra.Columns.Add("idMateriaPrima", typeof(int));
            detalle_compra.Columns.Add("precioCompra", typeof(decimal));
            detalle_compra.Columns.Add("cantidad", typeof(int));
            detalle_compra.Columns.Add("montoTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                detalle_compra.Rows.Add(
                    new object[]
                    {
                        Convert.ToInt32(row.Cells["id"].Value.ToString()),
                        row.Cells["PrecioCompra"].Value.ToString(),
                        row.Cells["Cantidad"].Value.ToString(),
                        row.Cells["Subtotal"].Value.ToString()
                    }
                    );
            }

            int idCorrelativo = new CN_Compra().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000}", idCorrelativo);

            Compra oCompra = new Compra()
            {
                oUsuario = new Usuario() {idUsuario = _Usuario.idUsuario },
                oProveedor = new Proveedor() { idProveedor = Convert.ToInt32(txtIdProveedor.Text)},
                tipoDocumento = ((OpcionCombo)cboDocumento.SelectedItem).Texto,
                numeroDocumento = numeroDocumento,
                montoTotal = Convert.ToDecimal(txtTotal.Text)
            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Compra().Registrar(oCompra, detalle_compra, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Número de compra generado:\n" + numeroDocumento + "\n\n¿Desea copiar al portapapeles?", "Estado de compra", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Clipboard.SetText(numeroDocumento);
                }

                txtIdProveedor.Text = "";
                txtTelefono.Text = "";
                txtNombreProveedor.Text = "";
                dgvData.Rows.Clear();
                calcularTotal();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
