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
using piccoloSistemaGestion.Modales;

namespace piccoloSistemaGestion
{
    public partial class frmVentas : Form
    {
        private Usuario _Usuario;

        public frmVentas(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cboDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cboDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cboDocumento.DisplayMember = "Texto";
            cboDocumento.ValueMember = "Valor";
            cboDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtIdProducto.Text = "0";

            txtTotal.Text = "0";
            txtPaga.Text = "0";
            txtCambio.Text = "0";
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtNombreCliente.Text = modal._Cliente.nombre;
                    txtTelefono.Text = modal._Cliente.telefono;
                    txtCodigoProducto.Select();
                }
                else
                {
                    txtTelefono.Select();
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modal._Producto.idProducto.ToString();
                    txtCodigoProducto.Text = modal._Producto.codigo;
                    txtProducto.Text = modal._Producto.nombre;
                    txtPrecioVenta.Text = modal._Producto.precioVenta.ToString("0.00");
                    txtCantidad.Select();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto oProducto = new CN_Producto().Listar().Where(p => p.codigo == txtCodigoProducto.Text && p.estado == true).FirstOrDefault();
                if (oProducto != null)
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.Honeydew;
                    txtIdProducto.Text = oProducto.idProducto.ToString();
                    txtProducto.Text = oProducto.nombre;
                    txtPrecioVenta.Text = oProducto.precioVenta.ToString("0.00");
                    txtCantidad.Select();
                }
                else
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                    txtPrecioVenta.Text = "0";
                    txtCantidad.Value = 1;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precioVenta = 0;
            bool producto_existe = false;

            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(txtPrecioVenta.Text, out precioVenta))
            {
                MessageBox.Show("Formato de moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioVenta.Select();
                return;
            }

            foreach (DataGridViewRow fila in dgvData.Rows)
            {
                if (fila.Cells["id"].Value.ToString() == txtIdProducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            if (!producto_existe)
            {
                dgvData.Rows.Add(new object[] {
                    txtIdProducto.Text,
                    txtProducto.Text,
                    precioVenta.ToString("0.00"),
                    txtCantidad.Value.ToString(),
                    (txtCantidad.Value * precioVenta).ToString("0.00")
                });

                calcularTotal();
                LimpiarProductos();
                txtCodigoProducto.Select();
            }
        }

        private void LimpiarProductos()
        {
            txtIdProducto.Text = "0";
            txtCodigoProducto.Text = "";
            txtCodigoProducto.BackColor = System.Drawing.Color.White;
            txtProducto.Text = "";
            txtPrecioVenta.Text = "";
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

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecioVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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
            if (txtNombreCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Debe ingresar el teléfono del cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos para registrar una venta", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable Detalle_Venta = new DataTable();

            Detalle_Venta.Columns.Add("idProducto", typeof(int));
            Detalle_Venta.Columns.Add("PrecioVenta", typeof(decimal));
            Detalle_Venta.Columns.Add("Cantidad", typeof(int));
            Detalle_Venta.Columns.Add("Subtotal", typeof(decimal));


            foreach (DataGridViewRow row in dgvData.Rows)
            {
                Detalle_Venta.Rows.Add(new object[] {
                    row.Cells["id"].Value.ToString(),
                    row.Cells["PrecioVenta"].Value.ToString(),
                    row.Cells["Cantidad"].Value.ToString(),
                    row.Cells["Subtotal"].Value.ToString()
                });
            }


            int idcorrelativo = new CN_Venta().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000}", idcorrelativo);
            CalcularCambio();

            Venta oVenta = new Venta()
            {
                oUsuario = new Usuario() { idUsuario = _Usuario.idUsuario },
                tipoDocumento = ((OpcionCombo)cboDocumento.SelectedItem).Texto,
                numeroDocumento = numeroDocumento,
                nombreCliente = txtNombreCliente.Text,
                telefonoCliente = txtTelefono.Text,
                montoPago = Convert.ToDecimal(txtPaga.Text),
                montoCambio = Convert.ToDecimal(txtCambio.Text),
                montoTotal = Convert.ToDecimal(txtTotal.Text)
            };


            string mensaje = string.Empty;
            bool respuesta = new CN_Venta().Registrar(oVenta, Detalle_Venta, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Número de venta:\n" + numeroDocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                    Clipboard.SetText(numeroDocumento);

                txtNombreCliente.Text = "";
                txtTelefono.Text = "";
                dgvData.Rows.Clear();
                calcularTotal();
                txtPaga.Text = "";
                txtCambio.Text = "";
            }
            else
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        private void txtPaga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPaga.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void CalcularCambio()
        {
            if (txtTotal.Text.Trim() == "")
            {
                MessageBox.Show("No hay productos en la venta", "Agregue productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal pagaCon;
            decimal total = Convert.ToDecimal(txtTotal.Text);

            if (txtPaga.Text.Trim() == "")
            {
                txtPaga.Text = "0";
            }

            if (decimal.TryParse(txtPaga.Text.Trim(), out pagaCon))
            {
                if (pagaCon < total)
                {
                    txtCambio.Text = "0.00";
                }
                else
                {
                    decimal cambio = pagaCon - total;
                    txtCambio.Text = cambio.ToString("0.00");
                }
            }
        }

        private void txtPaga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CalcularCambio();
            }
        }
    }
}
