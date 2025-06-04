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

namespace piccoloSistemaGestion.Modales
{
    public partial class mdProducto: Form
    {
        public mdProducto()
        {
            InitializeComponent();
        }

        public Producto _Producto { get; set; }
        private void mdProducto_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true)
                {
                    cboBuscar.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
                cboBuscar.DisplayMember = "Texto";
                cboBuscar.ValueMember = "Valor";
                if (cboBuscar.Items.Count > 0)
                {
                    cboBuscar.SelectedIndex = 0;
                }
            }

            List<Producto> lista = new CN_Producto().Listar();
            foreach (Producto item in lista)
            {
                dgvData.Rows.Add(new object[]
                {
                    item.idProducto,
                    item.codigo,
                    item.nombre,
                    item.oCategoria.descripcion,
                    item.precioCompra
                });
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBuscar.SelectedItem).Valor.ToString();

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscar.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else { row.Visible = false; }
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;

            if (iRow >= 0 && iColumn > 0)
            {
                _Producto = new Producto()
                {
                    idProducto = Convert.ToInt32(dgvData.Rows[iRow].Cells["id"].Value.ToString()),
                    codigo = dgvData.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    nombre = dgvData.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    precioCompra = Convert.ToDecimal(dgvData.Rows[iRow].Cells["PrecioCompra"].Value.ToString()),
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
