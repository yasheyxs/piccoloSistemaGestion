using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using capaNegocio;
using capaEntidad;

namespace piccoloSistemaGestion
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario oUsuario = new CN_Usuario().Listar().Where(u => u.documento == txtDocumento.Text.Trim() &&
            u.clave == txtClave.Text.Trim()).FirstOrDefault();

            if (oUsuario != null)
            {
                inicio form = new inicio(oUsuario);
                form.FormClosed += frm_closing;
                form.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Usuario no encontrado en la base de datos", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void frm_closing(object sender, FormClosedEventArgs e)
        {
            txtDocumento.Text = "";
            txtClave.Text = "";

            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
