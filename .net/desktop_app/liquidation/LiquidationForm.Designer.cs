namespace desktop_app.liquidation
{
    partial class LiquidationForm
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
            labelForm = new Label();
            periodoLabel = new Label();
            btnAccept = new Button();
            labelExpirationDate = new Label();
            periodPicker = new DateTimePicker();
            expirationDatePicker = new DateTimePicker();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 17F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.Controls.Add(labelForm, 1, 0);
            tableLayoutPanel1.Controls.Add(periodoLabel, 1, 2);
            tableLayoutPanel1.Controls.Add(btnAccept, 4, 3);
            tableLayoutPanel1.Controls.Add(labelExpirationDate, 3, 2);
            tableLayoutPanel1.Controls.Add(periodPicker, 2, 2);
            tableLayoutPanel1.Controls.Add(expirationDatePicker, 4, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 109F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 109F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 109F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 109F));
            tableLayoutPanel1.Size = new Size(992, 451);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(labelForm, 4);
            labelForm.Dock = DockStyle.Fill;
            labelForm.Font = new Font("Segoe UI", 12F);
            labelForm.Location = new Point(20, 0);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(934, 109);
            labelForm.TabIndex = 0;
            labelForm.Text = "Generar liquidación";
            labelForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // periodoLabel
            // 
            periodoLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            periodoLabel.AutoSize = true;
            periodoLabel.Font = new Font("Segoe UI", 11F);
            periodoLabel.ForeColor = SystemColors.ControlText;
            periodoLabel.Location = new Point(78, 229);
            periodoLabel.Margin = new Padding(3, 11, 3, 0);
            periodoLabel.Name = "periodoLabel";
            periodoLabel.Size = new Size(77, 25);
            periodoLabel.TabIndex = 4;
            periodoLabel.Text = "Periodo";
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.BackColor = SystemColors.HotTrack;
            btnAccept.Font = new Font("Segoe UI", 11F);
            btnAccept.ForeColor = SystemColors.ControlLightLight;
            btnAccept.Location = new Point(834, 338);
            btnAccept.Margin = new Padding(10, 11, 3, 3);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(120, 45);
            btnAccept.TabIndex = 1;
            btnAccept.Text = "Generar";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // labelExpirationDate
            // 
            labelExpirationDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelExpirationDate.AutoSize = true;
            labelExpirationDate.Font = new Font("Segoe UI", 11F);
            labelExpirationDate.ForeColor = SystemColors.ControlText;
            labelExpirationDate.Location = new Point(477, 229);
            labelExpirationDate.Margin = new Padding(3, 11, 3, 0);
            labelExpirationDate.Name = "labelExpirationDate";
            labelExpirationDate.Size = new Size(195, 25);
            labelExpirationDate.TabIndex = 5;
            labelExpirationDate.Text = "Fecha de vencimiento";
            // 
            // periodPicker
            // 
            periodPicker.Location = new Point(161, 229);
            periodPicker.Margin = new Padding(3, 11, 3, 3);
            periodPicker.Name = "periodPicker";
            periodPicker.Size = new Size(276, 27);
            periodPicker.TabIndex = 7;
            // 
            // expirationDatePicker
            // 
            expirationDatePicker.Dock = DockStyle.Fill;
            expirationDatePicker.Location = new Point(678, 229);
            expirationDatePicker.Margin = new Padding(3, 11, 3, 3);
            expirationDatePicker.Name = "expirationDatePicker";
            expirationDatePicker.Size = new Size(276, 27);
            expirationDatePicker.TabIndex = 8;
            // 
            // LiquidationForm
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 451);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LiquidationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Liquidación";
            Load += LiquidationForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label labelForm;
        private Label periodoLabel;
        private Button btnAccept;
        private Label labelExpirationDate;
        private DateTimePicker periodPicker;
        private DateTimePicker expirationDatePicker;
    }
}