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
using ClosedXML.Excel;

namespace piccoloSistemaGestion
{
    public partial class frmMateriaPrima: Form
    {
        public frmMateriaPrima()
        {
            InitializeComponent();
        }

        private void frmMateriaPrima_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;


            List<Categoria> listaCategoria = new CN_Categoria().Listar();
            foreach (Categoria item in listaCategoria)
            {

                cboCategoria.Items.Add(new OpcionCombo() { Valor = item.idCategoria, Texto = item.descripcion });
                cboCategoria.DisplayMember = "Texto";
                cboCategoria.ValueMember = "Valor";
                cboCategoria.SelectedIndex = 0;
            }

            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
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

            //mostrar todos los Productos
            List<MateriaPrima> lista = new CN_MateriaPrima().Listar();
            foreach (MateriaPrima item in lista)
            {
                dgvData.Rows.Add(new object[]
                {
                    "",
                    item.idMateriaPrima,
                    item.codigo,
                    item.nombre,
                    item.descripcion,
                    item.oCategoria.idCategoria,
                    item.oCategoria.descripcion,
                    item.precioCompra,
                    item.estado == true ?1 : 0,
                    item.estado == true ?"Activo" : "Inactivo",
                    item.stock
                });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            MateriaPrima obj = new MateriaPrima()
            {
                idMateriaPrima = Convert.ToInt32(txtId.Text),
                codigo = txtCodigo.Text,
                nombre = txtNombre.Text,
                descripcion = txtDescripcion.Text,
                oCategoria = new Categoria() { idCategoria = Convert.ToInt32(((OpcionCombo)cboCategoria.SelectedItem).Valor) },
                estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false,
                stock = Convert.ToInt32(txtStock.Text)
            };

            if (obj.idMateriaPrima == 0)
            {
                int idGenerado = new CN_MateriaPrima().Registrar(obj, out mensaje);

                if (idGenerado != 0)
                {
                    dgvData.Rows.Add(new object[]
                    {
                    "",
                    idGenerado,
                    txtCodigo.Text,
                    txtNombre.Text,
                    txtDescripcion.Text,
                    ((OpcionCombo)cboCategoria.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cboCategoria.SelectedItem).Texto.ToString(),
                    "0,00",
                    ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString(),
                    txtStock.Text
                    });
                }
                else
                {
                    MessageBox.Show(mensaje);
                }

                Limpiar();
            }
            else
            {
                bool resultado = new CN_MateriaPrima().Editar(obj, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["id"].Value = txtId.Text;
                    row.Cells["Codigo"].Value = txtCodigo.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Descripcion"].Value = txtDescripcion.Text;
                    row.Cells["idCategoria"].Value = ((OpcionCombo)cboCategoria.SelectedItem).Valor.ToString();
                    row.Cells["Categoria"].Value = ((OpcionCombo)cboCategoria.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString();
                    row.Cells["stock"].Value = txtStock.Text;

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            cboCategoria.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            txtStock.Text = "";

            txtCodigo.Select();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["id"].Value.ToString();
                    txtCodigo.Text = dgvData.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombre.Text = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtDescripcion.Text = dgvData.Rows[indice].Cells["Descripcion"].Value.ToString();
                    txtStock.Text = dgvData.Rows[indice].Cells["stock"].Value.ToString();

                    foreach (OpcionCombo oc in cboCategoria.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["idCategoria"].Value))
                        {
                            int indice_combo = cboCategoria.Items.IndexOf(oc);
                            cboCategoria.SelectedIndex = indice_combo;
                            break;
                        }

                    }

                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indice_combo;
                            break;
                        }

                    }
                }

            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.check16px.Width;
                var h = Properties.Resources.check16px.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check16px, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar esta materia prima?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    MateriaPrima obj = new MateriaPrima()
                    {
                        idMateriaPrima = Convert.ToInt32(txtId.Text),
                    };

                    bool respuesta = new CN_MateriaPrima().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error durante la eliminación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

            Limpiar();
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "No se puede exportar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgvData.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }

                foreach (DataGridViewRow fila in dgvData.Rows)
                {
                    if (fila.Visible)
                    {
                        dt.Rows.Add(new object[] {
                            fila.Cells[2].Value.ToString(),
                            fila.Cells[3].Value.ToString(),
                            fila.Cells[4].Value.ToString(),
                            fila.Cells[6].Value.ToString(),
                            fila.Cells[7].Value.ToString(),
                            fila.Cells[9].Value.ToString(),
                            fila.Cells[10].Value.ToString()
                        });
                    }
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteMateriaPrima_(0).xlsx");
                savefile.Filter = "Excel Files | *.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Reporte de Materias Primas");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);

                        MessageBox.Show("Reporte generado", "Estado del reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch
                    {
                        MessageBox.Show("Error al generar el reporte", "Estado del reporte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
