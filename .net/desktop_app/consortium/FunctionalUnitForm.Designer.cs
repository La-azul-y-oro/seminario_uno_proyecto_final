namespace desktop_app.consortium
{
    partial class FunctionalUnitForm
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
            lblIntro = new Label();
            btnAsistida = new Button();
            btnManual = new Button();
            labelAsistida = new Label();
            labelManual = new Label();
            panelInicial = new Panel();
            panelAsistida = new Panel();
            buttonAsistida = new Button();
            labelFactor = new Label();
            labelNomenclatura = new Label();
            labelUnit = new Label();
            labelFloor = new Label();
            comboBoxNomenclatura = new ComboBox();
            textFactor = new TextBox();
            textUnits = new TextBox();
            textFloor = new TextBox();
            labelPanelAsistida = new Label();
            panelList = new Panel();
            buttonSaveList = new Button();
            dgvUnits = new DataGridView();
            panelInicial.SuspendLayout();
            panelAsistida.SuspendLayout();
            panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnits).BeginInit();
            SuspendLayout();
            // 
            // lblIntro
            // 
            lblIntro.AutoSize = true;
            lblIntro.Font = new Font("Segoe UI", 12F);
            lblIntro.Location = new Point(210, 63);
            lblIntro.Name = "lblIntro";
            lblIntro.Size = new Size(529, 28);
            lblIntro.TabIndex = 0;
            lblIntro.Text = "Seleccione un método para cargar las unidades funcionales:";
            // 
            // btnAsistida
            // 
            btnAsistida.Font = new Font("Segoe UI", 12F);
            btnAsistida.Location = new Point(210, 205);
            btnAsistida.Name = "btnAsistida";
            btnAsistida.Size = new Size(120, 50);
            btnAsistida.TabIndex = 1;
            btnAsistida.Text = "Asistida";
            btnAsistida.UseVisualStyleBackColor = true;
            btnAsistida.Click += btnAsistida_Click;
            // 
            // btnManual
            // 
            btnManual.Font = new Font("Segoe UI", 12F);
            btnManual.Location = new Point(619, 205);
            btnManual.Name = "btnManual";
            btnManual.Size = new Size(120, 50);
            btnManual.TabIndex = 2;
            btnManual.Text = "Manual";
            btnManual.UseVisualStyleBackColor = true;
            btnManual.Click += btnManual_Click;
            // 
            // labelAsistida
            // 
            labelAsistida.AutoSize = true;
            labelAsistida.Location = new Point(132, 280);
            labelAsistida.Name = "labelAsistida";
            labelAsistida.Size = new Size(284, 20);
            labelAsistida.TabIndex = 3;
            labelAsistida.Text = "Ideal para edificios con estructura regular";
            // 
            // labelManual
            // 
            labelManual.AutoSize = true;
            labelManual.Location = new Point(498, 280);
            labelManual.Name = "labelManual";
            labelManual.Size = new Size(356, 20);
            labelManual.TabIndex = 4;
            labelManual.Text = "Carga uno por uno, ideal para estructuras irregulares";
            // 
            // panelInicial
            // 
            panelInicial.Controls.Add(btnAsistida);
            panelInicial.Controls.Add(labelManual);
            panelInicial.Controls.Add(lblIntro);
            panelInicial.Controls.Add(labelAsistida);
            panelInicial.Controls.Add(btnManual);
            panelInicial.Dock = DockStyle.Fill;
            panelInicial.Location = new Point(0, 0);
            panelInicial.Name = "panelInicial";
            panelInicial.Size = new Size(956, 450);
            panelInicial.TabIndex = 5;
            panelInicial.Visible = false;
            // 
            // panelAsistida
            // 
            panelAsistida.Controls.Add(buttonAsistida);
            panelAsistida.Controls.Add(labelFactor);
            panelAsistida.Controls.Add(labelNomenclatura);
            panelAsistida.Controls.Add(labelUnit);
            panelAsistida.Controls.Add(labelFloor);
            panelAsistida.Controls.Add(comboBoxNomenclatura);
            panelAsistida.Controls.Add(textFactor);
            panelAsistida.Controls.Add(textUnits);
            panelAsistida.Controls.Add(textFloor);
            panelAsistida.Controls.Add(labelPanelAsistida);
            panelAsistida.Dock = DockStyle.Fill;
            panelAsistida.Location = new Point(0, 0);
            panelAsistida.Name = "panelAsistida";
            panelAsistida.Size = new Size(956, 450);
            panelAsistida.TabIndex = 5;
            // 
            // buttonAsistida
            // 
            buttonAsistida.Font = new Font("Segoe UI", 11F);
            buttonAsistida.Location = new Point(727, 358);
            buttonAsistida.Name = "buttonAsistida";
            buttonAsistida.Size = new Size(144, 44);
            buttonAsistida.TabIndex = 9;
            buttonAsistida.Text = "Continuar";
            buttonAsistida.UseVisualStyleBackColor = true;
            buttonAsistida.Click += buttonAsistida_Click;
            // 
            // labelFactor
            // 
            labelFactor.AutoSize = true;
            labelFactor.Font = new Font("Segoe UI", 10F);
            labelFactor.Location = new Point(549, 233);
            labelFactor.Name = "labelFactor";
            labelFactor.Size = new Size(96, 23);
            labelFactor.TabIndex = 8;
            labelFactor.Text = "Factor base";
            // 
            // labelNomenclatura
            // 
            labelNomenclatura.AutoSize = true;
            labelNomenclatura.Font = new Font("Segoe UI", 10F);
            labelNomenclatura.Location = new Point(211, 233);
            labelNomenclatura.Name = "labelNomenclatura";
            labelNomenclatura.Size = new Size(119, 23);
            labelNomenclatura.TabIndex = 7;
            labelNomenclatura.Text = "Nomenclatura";
            // 
            // labelUnit
            // 
            labelUnit.AutoSize = true;
            labelUnit.Font = new Font("Segoe UI", 10F);
            labelUnit.Location = new Point(546, 117);
            labelUnit.Name = "labelUnit";
            labelUnit.Size = new Size(224, 23);
            labelUnit.TabIndex = 6;
            labelUnit.Text = "Cantidad de departamentos";
            // 
            // labelFloor
            // 
            labelFloor.AutoSize = true;
            labelFloor.Font = new Font("Segoe UI", 10F);
            labelFloor.Location = new Point(211, 117);
            labelFloor.Name = "labelFloor";
            labelFloor.Size = new Size(146, 23);
            labelFloor.TabIndex = 5;
            labelFloor.Text = "Cantidad de pisos";
            // 
            // comboBoxNomenclatura
            // 
            comboBoxNomenclatura.FormattingEnabled = true;
            comboBoxNomenclatura.Location = new Point(211, 261);
            comboBoxNomenclatura.Name = "comboBoxNomenclatura";
            comboBoxNomenclatura.Size = new Size(160, 28);
            comboBoxNomenclatura.TabIndex = 4;
            // 
            // textFactor
            // 
            textFactor.Location = new Point(546, 261);
            textFactor.Name = "textFactor";
            textFactor.Size = new Size(160, 27);
            textFactor.TabIndex = 3;
            // 
            // textUnits
            // 
            textUnits.Location = new Point(546, 145);
            textUnits.Name = "textUnits";
            textUnits.Size = new Size(160, 27);
            textUnits.TabIndex = 2;
            // 
            // textFloor
            // 
            textFloor.Location = new Point(211, 145);
            textFloor.Name = "textFloor";
            textFloor.Size = new Size(160, 27);
            textFloor.TabIndex = 1;
            // 
            // labelPanelAsistida
            // 
            labelPanelAsistida.AutoSize = true;
            labelPanelAsistida.Font = new Font("Segoe UI", 12F);
            labelPanelAsistida.Location = new Point(211, 63);
            labelPanelAsistida.Name = "labelPanelAsistida";
            labelPanelAsistida.Size = new Size(205, 28);
            labelPanelAsistida.TabIndex = 0;
            labelPanelAsistida.Text = "Configuración asistida";
            // 
            // panelList
            // 
            panelList.Controls.Add(buttonSaveList);
            panelList.Controls.Add(dgvUnits);
            panelList.Dock = DockStyle.Fill;
            panelList.Location = new Point(0, 0);
            panelList.Name = "panelList";
            panelList.Size = new Size(956, 450);
            panelList.TabIndex = 6;
            panelList.Visible = false;
            // 
            // buttonSaveList
            // 
            buttonSaveList.Font = new Font("Segoe UI", 11F);
            buttonSaveList.Location = new Point(813, 392);
            buttonSaveList.Name = "buttonSaveList";
            buttonSaveList.Size = new Size(120, 46);
            buttonSaveList.TabIndex = 1;
            buttonSaveList.Text = "Guardar";
            buttonSaveList.UseVisualStyleBackColor = true;
            buttonSaveList.Click += buttonSaveList_Click;
            // 
            // dgvUnits
            // 
            dgvUnits.AllowUserToDeleteRows = false;
            dgvUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUnits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUnits.Dock = DockStyle.Top;
            dgvUnits.Location = new Point(0, 0);
            dgvUnits.Name = "dgvUnits";
            dgvUnits.RowHeadersVisible = false;
            dgvUnits.RowHeadersWidth = 51;
            dgvUnits.Size = new Size(956, 380);
            dgvUnits.TabIndex = 0;
            // 
            // FunctionalUnitForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 450);
            Controls.Add(panelList);
            Controls.Add(panelInicial);
            Controls.Add(panelAsistida);
            Name = "FunctionalUnitForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Unidades funcionales";
            panelInicial.ResumeLayout(false);
            panelInicial.PerformLayout();
            panelAsistida.ResumeLayout(false);
            panelAsistida.PerformLayout();
            panelList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUnits).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblIntro;
        private Button btnAsistida;
        private Button btnManual;
        private Label labelAsistida;
        private Label labelManual;
        private Panel panelInicial;
        private Panel panelAsistida;
        private TextBox textFloor;
        private Label labelPanelAsistida;
        private Button buttonAsistida;
        private Label labelFactor;
        private Label labelNomenclatura;
        private Label labelUnit;
        private Label labelFloor;
        private ComboBox comboBoxNomenclatura;
        private TextBox textFactor;
        private TextBox textUnits;
        private Panel panelList;
        private Button buttonSaveList;
        private DataGridView dgvUnits;
    }
}