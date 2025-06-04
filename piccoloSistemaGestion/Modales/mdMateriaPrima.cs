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
    public partial class mdMateriaPrima: Form
    {
        public MateriaPrima _MateriaPrima { get; set; }

        public mdMateriaPrima()
        {
            InitializeComponent();
        }

        private void mdMateriaPrima_Load(object sender, EventArgs e)
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

            List<MateriaPrima> lista = new CN_MateriaPrima().Listar();
            foreach (MateriaPrima item in lista)
            {
                dgvData.Rows.Add(new object[]
                {
                    item.idMateriaPrima,
                    item.codigo,
                    item.nombre,
                    item.oCategoria.descripcion,
                    item.precioCompra,
                    item.stock
                });
            }
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
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

        private void btnLimpiar2_Click(object sender, EventArgs e)
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
                _MateriaPrima = new MateriaPrima()
                {
                    idMateriaPrima = Convert.ToInt32(dgvData.Rows[iRow].Cells["id"].Value.ToString()),
                    codigo = dgvData.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    nombre = dgvData.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    precioCompra = Convert.ToDecimal( dgvData.Rows[iRow].Cells["PrecioCompra"].Value.ToString()),
                    stock = Convert.ToInt32(dgvData.Rows[iRow].Cells["Stock"].Value.ToString())
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
