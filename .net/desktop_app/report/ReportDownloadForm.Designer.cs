namespace desktop_app.report
{
    partial class ReportDownloadForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panelButtons = new Panel();
            downloadButton = new Button();
            nextButton = new Button();
            cancelButton = new Button();
            panelSelectType = new Panel();
            comboBoxTipo = new ComboBox();
            label1 = new Label();
            panelExpensas = new Panel();
            labelNoExpenses = new Label();
            flowLayoutPanelExpenses = new FlowLayoutPanel();
            label4 = new Label();
            panelFinanciero = new Panel();
            periodPicker = new DateTimePicker();
            checkYear = new CheckBox();
            buttonPDF = new RadioButton();
            buttonExcel = new RadioButton();
            label3 = new Label();
            label2 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panelButtons.SuspendLayout();
            panelSelectType.SuspendLayout();
            panelExpensas.SuspendLayout();
            panelFinanciero.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panelButtons, 0, 1);
            tableLayoutPanel1.Controls.Add(panelSelectType, 0, 0);
            tableLayoutPanel1.Controls.Add(panelExpensas, 0, 0);
            tableLayoutPanel1.Controls.Add(panelFinanciero, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 84.6666641F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(downloadButton);
            panelButtons.Controls.Add(nextButton);
            panelButtons.Controls.Add(cancelButton);
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.Location = new Point(3, 432);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(794, 15);
            panelButtons.TabIndex = 0;
            // 
            // downloadButton
            // 
            downloadButton.BackColor = Color.MediumSpringGreen;
            downloadButton.Font = new Font("Segoe UI", 10F);
            downloadButton.Location = new Point(662, 16);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(114, 38);
            downloadButton.TabIndex = 2;
            downloadButton.Text = "Descargar";
            downloadButton.UseVisualStyleBackColor = false;
            downloadButton.Click += downloadButton_Click;
            // 
            // nextButton
            // 
            nextButton.BackColor = SystemColors.MenuHighlight;
            nextButton.Font = new Font("Segoe UI", 10F);
            nextButton.ForeColor = Color.White;
            nextButton.Location = new Point(528, 16);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(102, 38);
            nextButton.TabIndex = 1;
            nextButton.Text = "Siguiente";
            nextButton.UseVisualStyleBackColor = false;
            nextButton.Click += nextButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Font = new Font("Segoe UI", 10F);
            cancelButton.Location = new Point(396, 16);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(99, 38);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Cancelar";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // panelSelectType
            // 
            panelSelectType.Controls.Add(comboBoxTipo);
            panelSelectType.Controls.Add(label1);
            panelSelectType.Dock = DockStyle.Fill;
            panelSelectType.Location = new Point(3, 412);
            panelSelectType.Name = "panelSelectType";
            panelSelectType.Size = new Size(794, 14);
            panelSelectType.TabIndex = 1;
            // 
            // comboBoxTipo
            // 
            comboBoxTipo.Font = new Font("Segoe UI", 12F);
            comboBoxTipo.FormattingEnabled = true;
            comboBoxTipo.Location = new Point(293, 190);
            comboBoxTipo.Name = "comboBoxTipo";
            comboBoxTipo.Size = new Size(202, 36);
            comboBoxTipo.TabIndex = 1;
            comboBoxTipo.SelectedIndexChanged += comboBoxTipo_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(272, 101);
            label1.Name = "label1";
            label1.Size = new Size(262, 28);
            label1.TabIndex = 0;
            label1.Text = "Seleccione el tipo de reporte";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panelExpensas
            // 
            panelExpensas.Controls.Add(labelNoExpenses);
            panelExpensas.Controls.Add(flowLayoutPanelExpenses);
            panelExpensas.Controls.Add(label4);
            panelExpensas.Dock = DockStyle.Fill;
            panelExpensas.Location = new Point(3, 3);
            panelExpensas.Name = "panelExpensas";
            panelExpensas.Size = new Size(794, 341);
            panelExpensas.TabIndex = 6;
            // 
            // labelNoExpenses
            // 
            labelNoExpenses.AutoSize = true;
            labelNoExpenses.Font = new Font("Segoe UI", 12F);
            labelNoExpenses.Location = new Point(171, 105);
            labelNoExpenses.Name = "labelNoExpenses";
            labelNoExpenses.Size = new Size(443, 28);
            labelNoExpenses.TabIndex = 2;
            labelNoExpenses.Text = "No hay liquidaciones disponibles para descargar. ";
            labelNoExpenses.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelExpenses
            // 
            flowLayoutPanelExpenses.AutoScroll = true;
            flowLayoutPanelExpenses.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelExpenses.Font = new Font("Segoe UI", 12F);
            flowLayoutPanelExpenses.Location = new Point(252, 115);
            flowLayoutPanelExpenses.Name = "flowLayoutPanelExpenses";
            flowLayoutPanelExpenses.Size = new Size(270, 187);
            flowLayoutPanelExpenses.TabIndex = 1;
            flowLayoutPanelExpenses.WrapContents = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(223, 41);
            label4.Name = "label4";
            label4.Size = new Size(335, 28);
            label4.TabIndex = 0;
            label4.Text = "Seleccione la liquidación a descargar:";
            // 
            // panelFinanciero
            // 
            panelFinanciero.Controls.Add(periodPicker);
            panelFinanciero.Controls.Add(checkYear);
            panelFinanciero.Controls.Add(buttonPDF);
            panelFinanciero.Controls.Add(buttonExcel);
            panelFinanciero.Controls.Add(label3);
            panelFinanciero.Controls.Add(label2);
            panelFinanciero.Dock = DockStyle.Fill;
            panelFinanciero.Location = new Point(3, 350);
            panelFinanciero.Name = "panelFinanciero";
            panelFinanciero.Size = new Size(794, 56);
            panelFinanciero.TabIndex = 2;
            panelFinanciero.Visible = false;
            // 
            // periodPicker
            // 
            periodPicker.Font = new Font("Segoe UI", 12F);
            periodPicker.Location = new Point(272, 278);
            periodPicker.Name = "periodPicker";
            periodPicker.Size = new Size(223, 34);
            periodPicker.TabIndex = 5;
            // 
            // checkYear
            // 
            checkYear.AutoSize = true;
            checkYear.Font = new Font("Segoe UI", 12F);
            checkYear.Location = new Point(328, 218);
            checkYear.Name = "checkYear";
            checkYear.Size = new Size(112, 32);
            checkYear.TabIndex = 4;
            checkYear.Text = "Solo año";
            checkYear.UseVisualStyleBackColor = true;
            checkYear.CheckedChanged += checkYear_CheckedChanged;
            // 
            // buttonPDF
            // 
            buttonPDF.AutoSize = true;
            buttonPDF.Checked = true;
            buttonPDF.Font = new Font("Segoe UI", 12F);
            buttonPDF.Location = new Point(295, 103);
            buttonPDF.Name = "buttonPDF";
            buttonPDF.Size = new Size(68, 32);
            buttonPDF.TabIndex = 3;
            buttonPDF.TabStop = true;
            buttonPDF.Text = "PDF";
            buttonPDF.UseVisualStyleBackColor = true;
            // 
            // buttonExcel
            // 
            buttonExcel.AutoSize = true;
            buttonExcel.Font = new Font("Segoe UI", 12F);
            buttonExcel.Location = new Point(415, 103);
            buttonExcel.Name = "buttonExcel";
            buttonExcel.Size = new Size(76, 32);
            buttonExcel.TabIndex = 2;
            buttonExcel.Text = "Excel";
            buttonExcel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(293, 176);
            label3.Name = "label3";
            label3.Size = new Size(199, 28);
            label3.TabIndex = 1;
            label3.Text = "Seleccione el periodo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(295, 48);
            label2.Name = "label2";
            label2.Size = new Size(200, 28);
            label2.TabIndex = 0;
            label2.Text = "Seleccione el formato";
            // 
            // ReportDownloadForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "ReportDownloadForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Descargar Reportes";
            tableLayoutPanel1.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            panelSelectType.ResumeLayout(false);
            panelSelectType.PerformLayout();
            panelExpensas.ResumeLayout(false);
            panelExpensas.PerformLayout();
            panelFinanciero.ResumeLayout(false);
            panelFinanciero.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelButtons;
        private Button downloadButton;
        private Button nextButton;
        private Button cancelButton;
        private Panel panelSelectType;
        private ComboBox comboBoxTipo;
        private Label label1;
        private Panel panelFinanciero;
        private Label label2;
        private RadioButton buttonPDF;
        private RadioButton buttonExcel;
        private Label label3;
        private DateTimePicker periodPicker;
        private CheckBox checkYear;
        private Panel panelExpensas;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanelExpenses;
        private Label labelNoExpenses;
    }
}