namespace piccoloSistemaGestion
{
    partial class inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.iconDropDownButton1 = new FontAwesome.Sharp.IconDropDownButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuusuario = new FontAwesome.Sharp.IconMenuItem();
            this.menuventas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuregistrar = new FontAwesome.Sharp.IconMenuItem();
            this.submenudetalleventas = new FontAwesome.Sharp.IconMenuItem();
            this.menucompras = new FontAwesome.Sharp.IconMenuItem();
            this.submenuregistrarcompra = new FontAwesome.Sharp.IconMenuItem();
            this.submenudetallecompra = new FontAwesome.Sharp.IconMenuItem();
            this.menuclientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuproveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menureportes = new FontAwesome.Sharp.IconMenuItem();
            this.submenuReporteCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuReporteVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menumantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            this.iconMenuItem3 = new FontAwesome.Sharp.IconMenuItem();
            this.submenuMateriaPrima = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuNegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPedidos = new FontAwesome.Sharp.IconMenuItem();
            this.menuacercade = new FontAwesome.Sharp.IconMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconDropDownButton1
            // 
            this.iconDropDownButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconDropDownButton1.IconColor = System.Drawing.Color.Black;
            this.iconDropDownButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconDropDownButton1.Name = "iconDropDownButton1";
            this.iconDropDownButton1.Size = new System.Drawing.Size(23, 23);
            this.iconDropDownButton1.Text = "iconDropDownButton1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuusuario,
            this.menuventas,
            this.menucompras,
            this.menuclientes,
            this.menuproveedores,
            this.menureportes,
            this.menumantenedor,
            this.menuPedidos,
            this.menuacercade});
            this.menuStrip1.Location = new System.Drawing.Point(0, 66);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1262, 78);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menu";
            // 
            // menuusuario
            // 
            this.menuusuario.AutoSize = false;
            this.menuusuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuusuario.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.menuusuario.IconColor = System.Drawing.Color.Black;
            this.menuusuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuusuario.IconSize = 50;
            this.menuusuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuusuario.Name = "menuusuario";
            this.menuusuario.Size = new System.Drawing.Size(100, 74);
            this.menuusuario.Text = "Usuarios";
            this.menuusuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuusuario.Click += new System.EventHandler(this.menuusuario_Click);
            // 
            // menuventas
            // 
            this.menuventas.AutoSize = false;
            this.menuventas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuregistrar,
            this.submenudetalleventas});
            this.menuventas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuventas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuventas.IconColor = System.Drawing.Color.Black;
            this.menuventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuventas.IconSize = 50;
            this.menuventas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuventas.Name = "menuventas";
            this.menuventas.Size = new System.Drawing.Size(100, 74);
            this.menuventas.Text = "Ventas";
            this.menuventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuregistrar
            // 
            this.submenuregistrar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuregistrar.IconColor = System.Drawing.Color.Black;
            this.submenuregistrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuregistrar.Name = "submenuregistrar";
            this.submenuregistrar.Size = new System.Drawing.Size(175, 28);
            this.submenuregistrar.Text = "Registrar";
            this.submenuregistrar.Click += new System.EventHandler(this.submenuregistrar_Click);
            // 
            // submenudetalleventas
            // 
            this.submenudetalleventas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenudetalleventas.IconColor = System.Drawing.Color.Black;
            this.submenudetalleventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenudetalleventas.Name = "submenudetalleventas";
            this.submenudetalleventas.Size = new System.Drawing.Size(175, 28);
            this.submenudetalleventas.Text = "Ver detalle";
            this.submenudetalleventas.Click += new System.EventHandler(this.submenudetalleventas_Click);
            // 
            // menucompras
            // 
            this.menucompras.AutoSize = false;
            this.menucompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuregistrarcompra,
            this.submenudetallecompra});
            this.menucompras.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menucompras.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            this.menucompras.IconColor = System.Drawing.Color.Black;
            this.menucompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucompras.IconSize = 50;
            this.menucompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menucompras.Name = "menucompras";
            this.menucompras.Size = new System.Drawing.Size(100, 74);
            this.menucompras.Text = "Compras";
            this.menucompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuregistrarcompra
            // 
            this.submenuregistrarcompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuregistrarcompra.IconColor = System.Drawing.Color.Black;
            this.submenuregistrarcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuregistrarcompra.Name = "submenuregistrarcompra";
            this.submenuregistrarcompra.Size = new System.Drawing.Size(175, 28);
            this.submenuregistrarcompra.Text = "Registrar";
            this.submenuregistrarcompra.Click += new System.EventHandler(this.submenuregistrarcompra_Click);
            // 
            // submenudetallecompra
            // 
            this.submenudetallecompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenudetallecompra.IconColor = System.Drawing.Color.Black;
            this.submenudetallecompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenudetallecompra.Name = "submenudetallecompra";
            this.submenudetallecompra.Size = new System.Drawing.Size(175, 28);
            this.submenudetallecompra.Text = "Ver detalle";
            this.submenudetallecompra.Click += new System.EventHandler(this.submenudetallecompra_Click);
            // 
            // menuclientes
            // 
            this.menuclientes.AutoSize = false;
            this.menuclientes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuclientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.menuclientes.IconColor = System.Drawing.Color.Black;
            this.menuclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuclientes.IconSize = 50;
            this.menuclientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuclientes.Name = "menuclientes";
            this.menuclientes.Size = new System.Drawing.Size(100, 74);
            this.menuclientes.Text = "Clientes";
            this.menuclientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuclientes.Click += new System.EventHandler(this.menuclientes_Click);
            // 
            // menuproveedores
            // 
            this.menuproveedores.AutoSize = false;
            this.menuproveedores.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuproveedores.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.menuproveedores.IconColor = System.Drawing.Color.Black;
            this.menuproveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuproveedores.IconSize = 50;
            this.menuproveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuproveedores.Name = "menuproveedores";
            this.menuproveedores.Size = new System.Drawing.Size(100, 74);
            this.menuproveedores.Text = "Proveedores";
            this.menuproveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuproveedores.Click += new System.EventHandler(this.menuproveedores_Click);
            // 
            // menureportes
            // 
            this.menureportes.AutoSize = false;
            this.menureportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuReporteCompras,
            this.submenuReporteVentas});
            this.menureportes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menureportes.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.menureportes.IconColor = System.Drawing.Color.Black;
            this.menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menureportes.IconSize = 50;
            this.menureportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menureportes.Name = "menureportes";
            this.menureportes.Size = new System.Drawing.Size(100, 74);
            this.menureportes.Text = "Reportes";
            this.menureportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuReporteCompras
            // 
            this.submenuReporteCompras.Name = "submenuReporteCompras";
            this.submenuReporteCompras.Size = new System.Drawing.Size(248, 28);
            this.submenuReporteCompras.Text = "Reporte de compras";
            this.submenuReporteCompras.Click += new System.EventHandler(this.submenuReporteCompras_Click);
            // 
            // submenuReporteVentas
            // 
            this.submenuReporteVentas.Name = "submenuReporteVentas";
            this.submenuReporteVentas.Size = new System.Drawing.Size(248, 28);
            this.submenuReporteVentas.Text = "Reporte de ventas";
            this.submenuReporteVentas.Click += new System.EventHandler(this.submenuReporteVentas_Click);
            // 
            // menumantenedor
            // 
            this.menumantenedor.AutoSize = false;
            this.menumantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconMenuItem2,
            this.iconMenuItem3,
            this.submenuMateriaPrima,
            this.submenuNegocio});
            this.menumantenedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menumantenedor.IconChar = FontAwesome.Sharp.IconChar.Toolbox;
            this.menumantenedor.IconColor = System.Drawing.Color.Black;
            this.menumantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menumantenedor.IconSize = 50;
            this.menumantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menumantenedor.Name = "menumantenedor";
            this.menumantenedor.Size = new System.Drawing.Size(100, 74);
            this.menumantenedor.Text = "Mantenedor";
            this.menumantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // iconMenuItem2
            // 
            this.iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconMenuItem2.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem2.Name = "iconMenuItem2";
            this.iconMenuItem2.Size = new System.Drawing.Size(201, 28);
            this.iconMenuItem2.Text = "Categoría";
            this.iconMenuItem2.Click += new System.EventHandler(this.iconMenuItem2_Click);
            // 
            // iconMenuItem3
            // 
            this.iconMenuItem3.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconMenuItem3.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem3.Name = "iconMenuItem3";
            this.iconMenuItem3.Size = new System.Drawing.Size(201, 28);
            this.iconMenuItem3.Text = "Producto";
            this.iconMenuItem3.Click += new System.EventHandler(this.iconMenuItem3_Click);
            // 
            // submenuMateriaPrima
            // 
            this.submenuMateriaPrima.Name = "submenuMateriaPrima";
            this.submenuMateriaPrima.Size = new System.Drawing.Size(201, 28);
            this.submenuMateriaPrima.Text = "Materia prima";
            this.submenuMateriaPrima.Click += new System.EventHandler(this.submenuMateriaPrima_Click);
            // 
            // submenuNegocio
            // 
            this.submenuNegocio.Name = "submenuNegocio";
            this.submenuNegocio.Size = new System.Drawing.Size(201, 28);
            this.submenuNegocio.Text = "Negocio";
            this.submenuNegocio.Click += new System.EventHandler(this.submenuNegocio_Click);
            // 
            // menuPedidos
            // 
            this.menuPedidos.AutoSize = false;
            this.menuPedidos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuPedidos.IconChar = FontAwesome.Sharp.IconChar.FilePen;
            this.menuPedidos.IconColor = System.Drawing.Color.Black;
            this.menuPedidos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuPedidos.IconSize = 50;
            this.menuPedidos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuPedidos.Name = "menuPedidos";
            this.menuPedidos.Size = new System.Drawing.Size(100, 74);
            this.menuPedidos.Text = "Pedidos";
            this.menuPedidos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuPedidos.Click += new System.EventHandler(this.menuPedidos_Click);
            // 
            // menuacercade
            // 
            this.menuacercade.AutoSize = false;
            this.menuacercade.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuacercade.IconChar = FontAwesome.Sharp.IconChar.Info;
            this.menuacercade.IconColor = System.Drawing.Color.Black;
            this.menuacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuacercade.IconSize = 50;
            this.menuacercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuacercade.Name = "menuacercade";
            this.menuacercade.Size = new System.Drawing.Size(100, 74);
            this.menuacercade.Text = "Acerca de...";
            this.menuacercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(184)))), ((int)(((byte)(37)))));
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip2.Size = new System.Drawing.Size(1262, 66);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuTitulo";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(184)))), ((int)(((byte)(37)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(562, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema de Gestión Piccolo Burgers";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 144);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1262, 709);
            this.contenedor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(184)))), ((int)(((byte)(37)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(808, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(184)))), ((int)(((byte)(37)))));
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(894, 24);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(94, 20);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(184)))), ((int)(((byte)(37)))));
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(1173, 8);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(54, 51);
            this.iconButton1.TabIndex = 6;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // inicio
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1262, 853);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Piccolo";
            this.Load += new System.EventHandler(this.inicio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconDropDownButton iconDropDownButton1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menuacercade;
        private FontAwesome.Sharp.IconMenuItem menuusuario;
        private FontAwesome.Sharp.IconMenuItem menumantenedor;
        private FontAwesome.Sharp.IconMenuItem menuventas;
        private FontAwesome.Sharp.IconMenuItem menucompras;
        private FontAwesome.Sharp.IconMenuItem menuclientes;
        private FontAwesome.Sharp.IconMenuItem menuproveedores;
        private FontAwesome.Sharp.IconMenuItem menureportes;
        private System.Windows.Forms.Panel contenedor;
        private FontAwesome.Sharp.IconMenuItem menuPedidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem3;
        private FontAwesome.Sharp.IconMenuItem submenuregistrar;
        private FontAwesome.Sharp.IconMenuItem submenudetalleventas;
        private FontAwesome.Sharp.IconMenuItem submenuregistrarcompra;
        private FontAwesome.Sharp.IconMenuItem submenudetallecompra;
        private System.Windows.Forms.ToolStripMenuItem submenuNegocio;
        private System.Windows.Forms.ToolStripMenuItem submenuMateriaPrima;
        private System.Windows.Forms.ToolStripMenuItem submenuReporteVentas;
        private System.Windows.Forms.ToolStripMenuItem submenuReporteCompras;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}

