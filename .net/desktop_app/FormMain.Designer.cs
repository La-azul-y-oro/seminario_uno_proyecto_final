namespace PracticaSeminario
{
    partial class FormMain
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
            pnlContainer = new Panel();
            layoutPanel = new TableLayoutPanel();
            mnsPrincipal = new MenuStrip();
            mnuArchivo = new ToolStripMenuItem();
            tsmChangePass = new ToolStripMenuItem();
            tsmSalir = new ToolStripMenuItem();
            mnuModulos = new ToolStripMenuItem();
            tsmiConceptos = new ToolStripMenuItem();
            tsmiConsorcios = new ToolStripMenuItem();
            tsmiSupplier = new ToolStripMenuItem();
            tsmiUsuarios = new ToolStripMenuItem();
            tsmiMovimientos = new ToolStripMenuItem();
            labelUserInfo = new Label();
            layoutPanel.SuspendLayout();
            mnsPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.WhiteSmoke;
            layoutPanel.SetColumnSpan(pnlContainer, 2);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(3, 43);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1294, 652);
            pnlContainer.TabIndex = 3;
            // 
            // layoutPanel
            // 
            layoutPanel.ColumnCount = 2;
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            layoutPanel.Controls.Add(mnsPrincipal, 0, 0);
            layoutPanel.Controls.Add(pnlContainer, 0, 1);
            layoutPanel.Controls.Add(labelUserInfo, 1, 0);
            layoutPanel.Dock = DockStyle.Fill;
            layoutPanel.Location = new Point(0, 0);
            layoutPanel.Name = "layoutPanel";
            layoutPanel.RowCount = 2;
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutPanel.Size = new Size(1300, 698);
            layoutPanel.TabIndex = 0;
            // 
            // mnsPrincipal
            // 
            mnsPrincipal.BackColor = Color.Gainsboro;
            mnsPrincipal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mnsPrincipal.ImageScalingSize = new Size(20, 20);
            mnsPrincipal.Items.AddRange(new ToolStripItem[] { mnuArchivo, mnuModulos });
            mnsPrincipal.Location = new Point(0, 0);
            mnsPrincipal.Name = "mnsPrincipal";
            mnsPrincipal.Size = new Size(800, 39);
            mnsPrincipal.TabIndex = 0;
            mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            mnuArchivo.DropDownItems.AddRange(new ToolStripItem[] { tsmChangePass, tsmSalir });
            mnuArchivo.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mnuArchivo.Name = "mnuArchivo";
            mnuArchivo.Size = new Size(108, 35);
            mnuArchivo.Text = "Archivo";
            // 
            // tsmChangePass
            // 
            tsmChangePass.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsmChangePass.Name = "tsmChangePass";
            tsmChangePass.Size = new Size(306, 36);
            tsmChangePass.Text = "Cambiar contraseña";
            tsmChangePass.Click += tsmChangePass_Click;
            // 
            // tsmSalir
            // 
            tsmSalir.Font = new Font("Segoe UI", 13.8F);
            tsmSalir.Name = "tsmSalir";
            tsmSalir.Size = new Size(306, 36);
            tsmSalir.Text = "Salir";
            tsmSalir.Click += salirToolStripMenuItem_Click;
            // 
            // mnuModulos
            // 
            mnuModulos.DropDownItems.AddRange(new ToolStripItem[] { tsmiConceptos, tsmiConsorcios, tsmiSupplier, tsmiUsuarios, tsmiMovimientos });
            mnuModulos.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mnuModulos.Name = "mnuModulos";
            mnuModulos.Size = new Size(120, 35);
            mnuModulos.Text = "Módulos";
            // 
            // tsmiConceptos
            // 
            tsmiConceptos.Font = new Font("Segoe UI", 13.8F);
            tsmiConceptos.Name = "tsmiConceptos";
            tsmiConceptos.Size = new Size(235, 36);
            tsmiConceptos.Text = "Conceptos";
            tsmiConceptos.Click += tsmiConceptos_Click;
            // 
            // tsmiConsorcios
            // 
            tsmiConsorcios.Font = new Font("Segoe UI", 13.8F);
            tsmiConsorcios.Name = "tsmiConsorcios";
            tsmiConsorcios.Size = new Size(235, 36);
            tsmiConsorcios.Text = "Consorcios";
            tsmiConsorcios.Click += tsmiConsorcios_Click;
            // 
            // tsmiSupplier
            // 
            tsmiSupplier.Font = new Font("Segoe UI", 13.8F);
            tsmiSupplier.Name = "tsmiSupplier";
            tsmiSupplier.Size = new Size(235, 36);
            tsmiSupplier.Text = "Proveedores";
            tsmiSupplier.Click += tsmiSupplier_Click;
            // 
            // tsmiUsuarios
            // 
            tsmiUsuarios.Font = new Font("Segoe UI", 13.8F);
            tsmiUsuarios.Name = "tsmiUsuarios";
            tsmiUsuarios.Size = new Size(235, 36);
            tsmiUsuarios.Text = "Usuarios";
            tsmiUsuarios.Click += tsmiUsuarios_Click;
            // 
            // tsmiMovimientos
            // 
            tsmiMovimientos.Font = new Font("Segoe UI", 13.8F);
            tsmiMovimientos.Name = "tsmiMovimientos";
            tsmiMovimientos.Size = new Size(235, 36);
            tsmiMovimientos.Text = "Movimientos";
            tsmiMovimientos.Click += tsmiMovimientos_Click;
            // 
            // labelUserInfo
            // 
            labelUserInfo.AutoSize = true;
            labelUserInfo.BackColor = Color.Gainsboro;
            labelUserInfo.Dock = DockStyle.Fill;
            labelUserInfo.Font = new Font("Segoe UI Light", 13.8F);
            labelUserInfo.Location = new Point(803, 0);
            labelUserInfo.Name = "labelUserInfo";
            labelUserInfo.Size = new Size(494, 40);
            labelUserInfo.TabIndex = 4;
            labelUserInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 698);
            Controls.Add(layoutPanel);
            Font = new Font("Segoe UI", 14F);
            IsMdiContainer = true;
            Margin = new Padding(5);
            Name = "FormMain";
            Text = "Consorcio";
            WindowState = FormWindowState.Maximized;
            Load += formMain_Shown;
            layoutPanel.ResumeLayout(false);
            layoutPanel.PerformLayout();
            mnsPrincipal.ResumeLayout(false);
            mnsPrincipal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlContainer;
        private TableLayoutPanel layoutPanel;
        private MenuStrip mnsPrincipal;
        private ToolStripMenuItem mnuArchivo;
        private ToolStripMenuItem tsmSalir;
        private ToolStripMenuItem mnuModulos;
        private ToolStripMenuItem tsmiConceptos;
        private ToolStripMenuItem tsmiUsuarios;
        private ToolStripMenuItem tsmiSupplier;
        private Label labelUserInfo;
        private ToolStripMenuItem tsmChangePass;
        private ToolStripMenuItem tsmiConsorcios;
        private ToolStripMenuItem tsmiMovimientos;
    }
}