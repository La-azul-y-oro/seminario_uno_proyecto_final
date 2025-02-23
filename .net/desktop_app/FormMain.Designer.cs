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
            tsmSalir = new ToolStripMenuItem();
            mnuModulos = new ToolStripMenuItem();
            tsmiConceptos = new ToolStripMenuItem();
            tsmiUsuarios = new ToolStripMenuItem();
            tsmiServicios = new ToolStripMenuItem();
            labelUserInfo = new Label();
            tsmChangePass = new ToolStripMenuItem();
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
            mnsPrincipal.Items.AddRange(new ToolStripItem[] { mnuArchivo, mnuModulos });
            mnsPrincipal.Location = new Point(0, 0);
            mnsPrincipal.Name = "mnsPrincipal";
            mnsPrincipal.Size = new Size(800, 29);
            mnsPrincipal.TabIndex = 0;
            mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            mnuArchivo.DropDownItems.AddRange(new ToolStripItem[] { tsmChangePass, tsmSalir });
            mnuArchivo.Name = "mnuArchivo";
            mnuArchivo.Size = new Size(75, 25);
            mnuArchivo.Text = "Archivo";
            // 
            // tsmSalir
            // 
            tsmSalir.Name = "tsmSalir";
            tsmSalir.Size = new Size(219, 26);
            tsmSalir.Text = "Salir";
            tsmSalir.Click += salirToolStripMenuItem_Click;
            // 
            // mnuModulos
            // 
            mnuModulos.DropDownItems.AddRange(new ToolStripItem[] { tsmiConceptos, tsmiUsuarios, tsmiServicios });
            mnuModulos.Name = "mnuModulos";
            mnuModulos.Size = new Size(83, 25);
            mnuModulos.Text = "Módulos";
            // 
            // tsmiConceptos
            // 
            tsmiConceptos.Name = "tsmiConceptos";
            tsmiConceptos.Size = new Size(153, 26);
            tsmiConceptos.Text = "Conceptos";
            // 
            // tsmiUsuarios
            // 
            tsmiUsuarios.Name = "tsmiUsuarios";
            tsmiUsuarios.Size = new Size(153, 26);
            tsmiUsuarios.Text = "Usuarios";
            // 
            // tsmiServicios
            // 
            tsmiServicios.Name = "tsmiServicios";
            tsmiServicios.Size = new Size(153, 26);
            tsmiServicios.Text = "Servicios";
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
            // tsmChangePass
            // 
            tsmChangePass.Name = "tsmChangePass";
            tsmChangePass.Size = new Size(219, 26);
            tsmChangePass.Text = "Cambiar contraseña";
            tsmChangePass.Click += tsmChangePass_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
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
        private ToolStripMenuItem tsmiServicios;
        private Label labelUserInfo;
        private ToolStripMenuItem tsmChangePass;
    }
}