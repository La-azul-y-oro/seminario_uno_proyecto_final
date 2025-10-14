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
            panelFinanciero = new Panel();
            periodPicker = new DateTimePicker();
            checkYear = new CheckBox();
            buttonPDF = new RadioButton();
            buttonExcel = new RadioButton();
            label3 = new Label();
            label2 = new Label();
            panelExpensas = new Panel();
            labelNoExpenses = new Label();
            flowLayoutPanelExpenses = new FlowLayoutPanel();
            label4 = new Label();
            panelSelectType = new Panel();
            comboBoxTipo = new ComboBox();
            label1 = new Label();
            panelButtons = new Panel();
            downloadButton = new Button();
            nextButton = new Button();
            cancelButton = new Button();
            panelFinanciero.SuspendLayout();
            panelExpensas.SuspendLayout();
            panelSelectType.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelFinanciero
            // 
            panelFinanciero.Controls.Add(periodPicker);
            panelFinanciero.Controls.Add(checkYear);
            panelFinanciero.Controls.Add(buttonPDF);
            panelFinanciero.Controls.Add(buttonExcel);
            panelFinanciero.Controls.Add(label3);
            panelFinanciero.Controls.Add(label2);
            panelFinanciero.Location = new Point(0, 249);
            panelFinanciero.Name = "panelFinanciero";
            panelFinanciero.Size = new Size(794, 377);
            panelFinanciero.TabIndex = 2;
            panelFinanciero.Visible = false;
            // 
            // periodPicker
            // 
            periodPicker.Font = new Font("Segoe UI", 12F);
            periodPicker.Location = new Point(194, 275);
            periodPicker.Name = "periodPicker";
            periodPicker.Size = new Size(404, 34);
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
            buttonPDF.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonPDF.Location = new Point(295, 103);
            buttonPDF.Name = "buttonPDF";
            buttonPDF.Size = new Size(70, 32);
            buttonPDF.TabIndex = 3;
            buttonPDF.TabStop = true;
            buttonPDF.Text = "PDF";
            buttonPDF.UseVisualStyleBackColor = true;
            // 
            // buttonExcel
            // 
            buttonExcel.AutoSize = true;
            buttonExcel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonExcel.Location = new Point(415, 103);
            buttonExcel.Name = "buttonExcel";
            buttonExcel.Size = new Size(82, 32);
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
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.Location = new Point(276, 50);
            label2.Name = "label2";
            label2.Size = new Size(246, 31);
            label2.TabIndex = 0;
            label2.Text = "Seleccione el formato";
            // 
            // panelExpensas
            // 
            panelExpensas.Controls.Add(labelNoExpenses);
            panelExpensas.Controls.Add(flowLayoutPanelExpenses);
            panelExpensas.Controls.Add(label4);
            panelExpensas.Location = new Point(6, 644);
            panelExpensas.Name = "panelExpensas";
            panelExpensas.Size = new Size(794, 300);
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
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label4.Location = new Point(185, 41);
            label4.Name = "label4";
            label4.Size = new Size(413, 31);
            label4.TabIndex = 0;
            label4.Text = "Seleccione la liquidación a descargar:";
            // 
            // panelSelectType
            // 
            panelSelectType.Controls.Add(comboBoxTipo);
            panelSelectType.Controls.Add(label1);
            panelSelectType.Location = new Point(0, 3);
            panelSelectType.Name = "panelSelectType";
            panelSelectType.Size = new Size(794, 228);
            panelSelectType.TabIndex = 1;
            // 
            // comboBoxTipo
            // 
            comboBoxTipo.Font = new Font("Segoe UI", 12F);
            comboBoxTipo.FormattingEnabled = true;
            comboBoxTipo.Location = new Point(237, 141);
            comboBoxTipo.Name = "comboBoxTipo";
            comboBoxTipo.Size = new Size(294, 36);
            comboBoxTipo.TabIndex = 1;
            comboBoxTipo.SelectedIndexChanged += comboBoxTipo_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label1.Location = new Point(227, 73);
            label1.Name = "label1";
            label1.Size = new Size(320, 31);
            label1.TabIndex = 0;
            label1.Text = "Seleccione el tipo de reporte";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(downloadButton);
            panelButtons.Controls.Add(nextButton);
            panelButtons.Controls.Add(cancelButton);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 977);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(800, 78);
            panelButtons.TabIndex = 0;
            // 
            // downloadButton
            // 
            downloadButton.BackColor = Color.FromArgb(16, 185, 129);
            downloadButton.FlatAppearance.BorderSize = 0;
            downloadButton.FlatStyle = FlatStyle.Flat;
            downloadButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            downloadButton.ForeColor = Color.White;
            downloadButton.Location = new Point(636, 3);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(140, 45);
            downloadButton.TabIndex = 2;
            downloadButton.Text = "Descargar";
            downloadButton.UseVisualStyleBackColor = false;
            downloadButton.Click += downloadButton_Click;
            // 
            // nextButton
            // 
            nextButton.BackColor = SystemColors.MenuHighlight;
            nextButton.FlatAppearance.BorderSize = 0;
            nextButton.FlatStyle = FlatStyle.Flat;
            nextButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            nextButton.ForeColor = Color.White;
            nextButton.Location = new Point(469, 3);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(140, 45);
            nextButton.TabIndex = 1;
            nextButton.Text = "Siguiente";
            nextButton.UseVisualStyleBackColor = false;
            nextButton.Click += nextButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = SystemColors.ActiveBorder;
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            cancelButton.Location = new Point(28, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(140, 45);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Cancelar";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // ReportDownloadForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 1055);
            Controls.Add(panelFinanciero);
            Controls.Add(panelExpensas);
            Controls.Add(panelSelectType);
            Controls.Add(panelButtons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ReportDownloadForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Descargar Reportes";
            panelFinanciero.ResumeLayout(false);
            panelFinanciero.PerformLayout();
            panelExpensas.ResumeLayout(false);
            panelExpensas.PerformLayout();
            panelSelectType.ResumeLayout(false);
            panelSelectType.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelFinanciero;
        private DateTimePicker periodPicker;
        private CheckBox checkYear;
        private RadioButton buttonPDF;
        private RadioButton buttonExcel;
        private Label label3;
        private Label label2;
        private Panel panelExpensas;
        private Label labelNoExpenses;
        private FlowLayoutPanel flowLayoutPanelExpenses;
        private Label label4;
        private Panel panelSelectType;
        private ComboBox comboBoxTipo;
        private Label label1;
        private Panel panelButtons;
        private Button downloadButton;
        private Button nextButton;
        private Button cancelButton;
    }
}