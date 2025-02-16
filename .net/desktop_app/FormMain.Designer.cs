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
            mnsPrincipal = new MenuStrip();
            mnuArchivo = new ToolStripMenuItem();
            mnuSalir = new ToolStripMenuItem();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            pnlContainer = new Panel();
            conceptosToolStripMenuItem1 = new ToolStripMenuItem();
            consorciosToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            mnsPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // mnsPrincipal
            // 
            mnsPrincipal.Font = new Font("Segoe UI", 12F);
            mnsPrincipal.ImageScalingSize = new Size(20, 20);
            mnsPrincipal.Items.AddRange(new ToolStripItem[] { mnuArchivo, inicioToolStripMenuItem });
            mnsPrincipal.Location = new Point(0, 0);
            mnsPrincipal.Name = "mnsPrincipal";
            mnsPrincipal.Padding = new Padding(10, 3, 0, 3);
            mnsPrincipal.Size = new Size(1300, 38);
            mnsPrincipal.TabIndex = 1;
            mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            mnuArchivo.DropDownItems.AddRange(new ToolStripItem[] { mnuSalir });
            mnuArchivo.Name = "mnuArchivo";
            mnuArchivo.Size = new Size(93, 32);
            mnuArchivo.Text = "Archivo";
            // 
            // mnuSalir
            // 
            mnuSalir.Name = "mnuSalir";
            mnuSalir.Size = new Size(224, 32);
            mnuSalir.Text = "Salir";
            mnuSalir.Click += mnuSalir_Click;
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { conceptosToolStripMenuItem1, consorciosToolStripMenuItem, usuariosToolStripMenuItem });
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(104, 32);
            inicioToolStripMenuItem.Text = "Módulos";
            // 
            // pnlContainer
            // 
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 38);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1300, 660);
            pnlContainer.TabIndex = 3;
            // 
            // conceptosToolStripMenuItem1
            // 
            conceptosToolStripMenuItem1.Font = new Font("Segoe UI", 10F);
            conceptosToolStripMenuItem1.Name = "conceptosToolStripMenuItem1";
            conceptosToolStripMenuItem1.Size = new Size(224, 28);
            conceptosToolStripMenuItem1.Text = "Conceptos";
            // 
            // consorciosToolStripMenuItem
            // 
            consorciosToolStripMenuItem.Font = new Font("Segoe UI", 10F);
            consorciosToolStripMenuItem.Name = "consorciosToolStripMenuItem";
            consorciosToolStripMenuItem.Size = new Size(224, 28);
            consorciosToolStripMenuItem.Text = "Consorcios";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Font = new Font("Segoe UI", 10F);
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(224, 28);
            usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 698);
            Controls.Add(pnlContainer);
            Controls.Add(mnsPrincipal);
            Font = new Font("Segoe UI", 14F);
            IsMdiContainer = true;
            MainMenuStrip = mnsPrincipal;
            Margin = new Padding(5);
            Name = "FormMain";
            Text = "Consorcio";
            WindowState = FormWindowState.Maximized;
            Load += formMain_Shown;
            mnsPrincipal.ResumeLayout(false);
            mnsPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnsPrincipal;
        private ToolStripMenuItem mnuArchivo;
        private ToolStripMenuItem mnuSalir;
        private Panel pnlContainer;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem conceptosToolStripMenuItem1;
        private ToolStripMenuItem consorciosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
    }
}