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
    public partial class mdCliente: Form
    {
        public mdCliente()
        {
            InitializeComponent();
        }

        public Cliente _Cliente { get; set; }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvData.Columns)
            { 
                cboBuscar.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                
                cboBuscar.DisplayMember = "Texto";
                cboBuscar.ValueMember = "Valor";
                cboBuscar.SelectedIndex = 0;
            }

            List<Cliente> lista = new CN_Cliente().Listar();
            foreach (Cliente item in lista)
            {
                if (item.estado) 
                {
                    dgvData.Rows.Add(new object[]
                    {
                    item.nombre,
                    item.telefono
                    });
                }
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
                _Cliente = new Cliente()
                {
                    telefono = dgvData.Rows[iRow].Cells["Telefono"].Value.ToString(),
                    nombre = dgvData.Rows[iRow].Cells["Nombre"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
