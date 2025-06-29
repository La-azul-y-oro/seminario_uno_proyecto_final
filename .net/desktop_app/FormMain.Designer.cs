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
            tableLayoutPanel1 = new TableLayoutPanel();
            mnsPrincipal = new MenuStrip();
            mnuArchivo = new ToolStripMenuItem();
            tsmChangePass = new ToolStripMenuItem();
            tsmSalir = new ToolStripMenuItem();
            mnuModulos = new ToolStripMenuItem();
            tsmiConceptos = new ToolStripMenuItem();
            tsmiConsorcios = new ToolStripMenuItem();
            tsmiSupplier = new ToolStripMenuItem();
            tsmiUsuarios = new ToolStripMenuItem();
            labelUserInfo = new Label();
            unidadesFuncionalesToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            mnsPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            tableLayoutPanel1.SetColumnSpan(pnlContainer, 2);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(3, 43);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1294, 652);
            pnlContainer.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            tableLayoutPanel1.Controls.Add(mnsPrincipal, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlContainer, 0, 1);
            tableLayoutPanel1.Controls.Add(labelUserInfo, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1300, 698);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // mnsPrincipal
            // 
            mnsPrincipal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mnsPrincipal.ImageScalingSize = new Size(20, 20);
            mnsPrincipal.Items.AddRange(new ToolStripItem[] { mnuArchivo, mnuModulos });
            mnsPrincipal.Location = new Point(0, 0);
            mnsPrincipal.Name = "mnsPrincipal";
            mnsPrincipal.Size = new Size(800, 36);
            mnsPrincipal.TabIndex = 0;
            mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            mnuArchivo.DropDownItems.AddRange(new ToolStripItem[] { tsmChangePass, tsmSalir });
            mnuArchivo.Name = "mnuArchivo";
            mnuArchivo.Size = new Size(93, 32);
            mnuArchivo.Text = "Archivo";
            // 
            // tsmChangePass
            // 
            tsmChangePass.Name = "tsmChangePass";
            tsmChangePass.Size = new Size(271, 32);
            tsmChangePass.Text = "Cambiar contraseña";
            tsmChangePass.Click += tsmChangePass_Click;
            // 
            // tsmSalir
            // 
            tsmSalir.Name = "tsmSalir";
            tsmSalir.Size = new Size(271, 32);
            tsmSalir.Text = "Salir";
            tsmSalir.Click += salirToolStripMenuItem_Click;
            // 
            // mnuModulos
            // 
            mnuModulos.DropDownItems.AddRange(new ToolStripItem[] { tsmiConceptos, tsmiConsorcios, tsmiSupplier, tsmiUsuarios, unidadesFuncionalesToolStripMenuItem });
            mnuModulos.Name = "mnuModulos";
            mnuModulos.Size = new Size(104, 32);
            mnuModulos.Text = "Módulos";
            // 
            // tsmiConceptos
            // 
            tsmiConceptos.Name = "tsmiConceptos";
            tsmiConceptos.Size = new Size(283, 32);
            tsmiConceptos.Text = "Conceptos";
            tsmiConceptos.Click += tsmiConceptos_Click;
            // 
            // tsmiConsorcios
            // 
            tsmiConsorcios.Name = "tsmiConsorcios";
            tsmiConsorcios.Size = new Size(283, 32);
            tsmiConsorcios.Text = "Consorcios";
            tsmiConsorcios.Click += tsmiConsorcios_Click;
            // 
            // tsmiSupplier
            // 
            tsmiSupplier.Name = "tsmiSupplier";
            tsmiSupplier.Size = new Size(283, 32);
            tsmiSupplier.Text = "Proveedores";
            tsmiSupplier.Click += tsmiSupplier_Click;
            // 
            // tsmiUsuarios
            // 
            tsmiUsuarios.Name = "tsmiUsuarios";
            tsmiUsuarios.Size = new Size(283, 32);
            tsmiUsuarios.Text = "Usuarios";
            tsmiUsuarios.Click += tsmiUsuarios_Click;
            // 
            // labelUserInfo
            // 
            labelUserInfo.AutoSize = true;
            labelUserInfo.Dock = DockStyle.Fill;
            labelUserInfo.Location = new Point(803, 0);
            labelUserInfo.Name = "labelUserInfo";
            labelUserInfo.Size = new Size(494, 40);
            labelUserInfo.TabIndex = 4;
            labelUserInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // unidadesFuncionalesToolStripMenuItem
            // 
            unidadesFuncionalesToolStripMenuItem.Name = "unidadesFuncionalesToolStripMenuItem";
            unidadesFuncionalesToolStripMenuItem.Size = new Size(283, 32);
            unidadesFuncionalesToolStripMenuItem.Text = "Unidades funcionales";
            unidadesFuncionalesToolStripMenuItem.Click += unidadesFuncionalesToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 698);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 14F);
            IsMdiContainer = true;
            Margin = new Padding(5);
            Name = "FormMain";
            Text = "Consorcio";
            WindowState = FormWindowState.Maximized;
            Load += formMain_Shown;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            mnsPrincipal.ResumeLayout(false);
            mnsPrincipal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlContainer;
        private TableLayoutPanel tableLayoutPanel1;
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
        private ToolStripMenuItem unidadesFuncionalesToolStripMenuItem;
    }
}