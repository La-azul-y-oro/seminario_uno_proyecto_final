namespace desktop_app.movement
{
    partial class MovementForm
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
            panelSecondary = new Panel();
            txtComment = new TextBox();
            label8 = new Label();
            btnAccept = new Button();
            label7 = new Label();
            comboConcept = new ComboBox();
            labelSupplier = new Label();
            comboSupplier = new ComboBox();
            txtAmount = new TextBox();
            label2 = new Label();
            label1 = new Label();
            datePicker = new DateTimePicker();
            labelFU = new Label();
            comboFU = new ComboBox();
            txtReceipt = new TextBox();
            label9 = new Label();
            labelForm = new Label();
            comboType = new ComboBox();
            label3 = new Label();
            comboConsortium = new ComboBox();
            label4 = new Label();
            panel1 = new Panel();
            panelSecondary.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelSecondary
            // 
            panelSecondary.BackColor = Color.WhiteSmoke;
            panelSecondary.Controls.Add(txtComment);
            panelSecondary.Controls.Add(label8);
            panelSecondary.Controls.Add(btnAccept);
            panelSecondary.Controls.Add(label7);
            panelSecondary.Controls.Add(comboConcept);
            panelSecondary.Controls.Add(labelSupplier);
            panelSecondary.Controls.Add(comboSupplier);
            panelSecondary.Controls.Add(txtAmount);
            panelSecondary.Controls.Add(label2);
            panelSecondary.Controls.Add(label1);
            panelSecondary.Controls.Add(datePicker);
            panelSecondary.Controls.Add(labelFU);
            panelSecondary.Controls.Add(comboFU);
            panelSecondary.Controls.Add(txtReceipt);
            panelSecondary.Controls.Add(label9);
            panelSecondary.Font = new Font("Segoe UI", 13.8F);
            panelSecondary.Location = new Point(0, 145);
            panelSecondary.Margin = new Padding(3, 4, 3, 4);
            panelSecondary.Name = "panelSecondary";
            panelSecondary.Size = new Size(1054, 368);
            panelSecondary.TabIndex = 1;
            // 
            // txtComment
            // 
            txtComment.Font = new Font("Segoe UI", 12F);
            txtComment.Location = new Point(207, 184);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(792, 34);
            txtComment.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F);
            label8.Location = new Point(47, 184);
            label8.Name = "label8";
            label8.Size = new Size(144, 31);
            label8.TabIndex = 10;
            label8.Text = "Descripción*";
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.BackColor = Color.FromArgb(16, 185, 129);
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnAccept.ForeColor = Color.White;
            btnAccept.Location = new Point(851, 265);
            btnAccept.Margin = new Padding(10, 11, 3, 3);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(148, 51);
            btnAccept.TabIndex = 12;
            btnAccept.Text = "Crear";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Enter += btnAccept_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F);
            label7.Location = new Point(601, 42);
            label7.Name = "label7";
            label7.Size = new Size(122, 31);
            label7.TabIndex = 2;
            label7.Text = "Concepto*";
            // 
            // comboConcept
            // 
            comboConcept.Font = new Font("Segoe UI", 12F);
            comboConcept.FormattingEnabled = true;
            comboConcept.Location = new Point(740, 37);
            comboConcept.Name = "comboConcept";
            comboConcept.Size = new Size(259, 36);
            comboConcept.TabIndex = 3;
            // 
            // labelSupplier
            // 
            labelSupplier.AutoSize = true;
            labelSupplier.Font = new Font("Segoe UI", 13.8F);
            labelSupplier.Location = new Point(47, 42);
            labelSupplier.Name = "labelSupplier";
            labelSupplier.Size = new Size(128, 31);
            labelSupplier.TabIndex = 0;
            labelSupplier.Text = "Proveedor*";
            // 
            // comboSupplier
            // 
            comboSupplier.Font = new Font("Segoe UI", 12F);
            comboSupplier.FormattingEnabled = true;
            comboSupplier.Location = new Point(256, 41);
            comboSupplier.Name = "comboSupplier";
            comboSupplier.Size = new Size(258, 36);
            comboSupplier.TabIndex = 1;
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 12F);
            txtAmount.Location = new Point(520, 114);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(171, 34);
            txtAmount.TabIndex = 7;
            txtAmount.KeyPress += txtAmount_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F);
            label2.Location = new Point(422, 114);
            label2.Name = "label2";
            label2.Size = new Size(92, 31);
            label2.TabIndex = 6;
            label2.Text = "Monto*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F);
            label1.Location = new Point(47, 111);
            label1.Name = "label1";
            label1.Size = new Size(83, 31);
            label1.TabIndex = 4;
            label1.Text = "Fecha*";
            // 
            // datePicker
            // 
            datePicker.Font = new Font("Segoe UI", 12F);
            datePicker.Location = new Point(147, 111);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(251, 34);
            datePicker.TabIndex = 5;
            // 
            // labelFU
            // 
            labelFU.AutoSize = true;
            labelFU.Font = new Font("Segoe UI", 13.8F);
            labelFU.Location = new Point(47, 42);
            labelFU.Name = "labelFU";
            labelFU.Size = new Size(203, 31);
            labelFU.TabIndex = 0;
            labelFU.Text = "Unidad Funcional*";
            // 
            // comboFU
            // 
            comboFU.Font = new Font("Segoe UI", 12F);
            comboFU.FormattingEnabled = true;
            comboFU.Location = new Point(256, 41);
            comboFU.Name = "comboFU";
            comboFU.Size = new Size(258, 36);
            comboFU.TabIndex = 1;
            // 
            // txtReceipt
            // 
            txtReceipt.Font = new Font("Segoe UI", 12F);
            txtReceipt.Location = new Point(825, 113);
            txtReceipt.Name = "txtReceipt";
            txtReceipt.Size = new Size(174, 34);
            txtReceipt.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13.8F);
            label9.Location = new Point(721, 114);
            label9.Name = "label9";
            label9.Size = new Size(83, 31);
            label9.TabIndex = 8;
            label9.Text = "Recibo";
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            labelForm.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            labelForm.Location = new Point(422, 24);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(207, 31);
            labelForm.TabIndex = 0;
            labelForm.Text = "Crear movimiento";
            labelForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboType
            // 
            comboType.Font = new Font("Segoe UI", 12F);
            comboType.FormattingEnabled = true;
            comboType.Location = new Point(736, 89);
            comboType.Name = "comboType";
            comboType.Size = new Size(263, 36);
            comboType.TabIndex = 4;
            comboType.SelectedIndexChanged += comboType_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F);
            label3.Location = new Point(654, 94);
            label3.Name = "label3";
            label3.Size = new Size(69, 31);
            label3.TabIndex = 3;
            label3.Text = "Tipo*";
            // 
            // comboConsortium
            // 
            comboConsortium.Font = new Font("Segoe UI", 12F);
            comboConsortium.FormattingEnabled = true;
            comboConsortium.Location = new Point(178, 91);
            comboConsortium.Name = "comboConsortium";
            comboConsortium.Size = new Size(397, 36);
            comboConsortium.TabIndex = 2;
            comboConsortium.SelectedIndexChanged += comboConsortium_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F);
            label4.Location = new Point(47, 92);
            label4.Name = "label4";
            label4.Size = new Size(125, 31);
            label4.TabIndex = 1;
            label4.Text = "Consorcio*";
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(comboConsortium);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboType);
            panel1.Controls.Add(labelForm);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1051, 164);
            panel1.TabIndex = 0;
            // 
            // MovementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1049, 500);
            Controls.Add(panelSecondary);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MovementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movimiento";
            Enter += btnAccept_Click;
            panelSecondary.ResumeLayout(false);
            panelSecondary.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSecondary;
        private Label label1;
        private DateTimePicker datePicker;
        private Label labelFU;
        private ComboBox comboFU;
        private TextBox txtReceipt;
        private Label label9;
        private Label labelForm;
        private ComboBox comboType;
        private Label label3;
        private ComboBox comboConsortium;
        private Label label4;
        private Panel panel1;
        private TextBox txtComment;
        private Label label8;
        private Button btnAccept;
        private Label label7;
        private ComboBox comboConcept;
        private Label labelSupplier;
        private ComboBox comboSupplier;
        private TextBox txtAmount;
        private Label label2;
    }
}