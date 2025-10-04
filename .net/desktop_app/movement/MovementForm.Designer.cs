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
            panelSecondary.Location = new Point(0, 109);
            panelSecondary.Name = "panelSecondary";
            panelSecondary.Size = new Size(773, 279);
            panelSecondary.TabIndex = 1;
            // 
            // txtComment
            // 
            txtComment.Location = new Point(131, 147);
            txtComment.Margin = new Padding(3, 2, 3, 2);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(601, 23);
            txtComment.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(41, 150);
            label8.Name = "label8";
            label8.Size = new Size(74, 15);
            label8.TabIndex = 10;
            label8.Text = "Descripción*";
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.BackColor = SystemColors.HotTrack;
            btnAccept.Font = new Font("Segoe UI", 11F);
            btnAccept.ForeColor = SystemColors.ControlLightLight;
            btnAccept.Location = new Point(621, 201);
            btnAccept.Margin = new Padding(9, 8, 3, 2);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(111, 38);
            btnAccept.TabIndex = 12;
            btnAccept.Text = "Crear";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Enter += btnAccept_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(434, 28);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 2;
            label7.Text = "Concepto*";
            // 
            // comboConcept
            // 
            comboConcept.FormattingEnabled = true;
            comboConcept.Location = new Point(505, 25);
            comboConcept.Margin = new Padding(3, 2, 3, 2);
            comboConcept.Name = "comboConcept";
            comboConcept.Size = new Size(227, 23);
            comboConcept.TabIndex = 3;
            // 
            // labelSupplier
            // 
            labelSupplier.AutoSize = true;
            labelSupplier.Location = new Point(42, 28);
            labelSupplier.Name = "labelSupplier";
            labelSupplier.Size = new Size(66, 15);
            labelSupplier.TabIndex = 0;
            labelSupplier.Text = "Proveedor*";
            // 
            // comboSupplier
            // 
            comboSupplier.FormattingEnabled = true;
            comboSupplier.Location = new Point(148, 25);
            comboSupplier.Margin = new Padding(3, 2, 3, 2);
            comboSupplier.Name = "comboSupplier";
            comboSupplier.Size = new Size(226, 23);
            comboSupplier.TabIndex = 1;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(389, 85);
            txtAmount.Margin = new Padding(3, 2, 3, 2);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(140, 23);
            txtAmount.TabIndex = 7;
            txtAmount.KeyPress += txtAmount_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(335, 90);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 6;
            label2.Text = "Monto*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 88);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 4;
            label1.Text = "Fecha*";
            // 
            // datePicker
            // 
            datePicker.Location = new Point(93, 85);
            datePicker.Margin = new Padding(3, 2, 3, 2);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(220, 23);
            datePicker.TabIndex = 5;
            // 
            // labelFU
            // 
            labelFU.AutoSize = true;
            labelFU.Location = new Point(41, 28);
            labelFU.Name = "labelFU";
            labelFU.Size = new Size(105, 15);
            labelFU.TabIndex = 0;
            labelFU.Text = "Unidad Funcional*";
            // 
            // comboFU
            // 
            comboFU.FormattingEnabled = true;
            comboFU.Location = new Point(147, 25);
            comboFU.Margin = new Padding(3, 2, 3, 2);
            comboFU.Name = "comboFU";
            comboFU.Size = new Size(226, 23);
            comboFU.TabIndex = 1;
            // 
            // txtReceipt
            // 
            txtReceipt.Location = new Point(587, 85);
            txtReceipt.Margin = new Padding(3, 2, 3, 2);
            txtReceipt.Name = "txtReceipt";
            txtReceipt.Size = new Size(143, 23);
            txtReceipt.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(538, 90);
            label9.Name = "label9";
            label9.Size = new Size(43, 15);
            label9.TabIndex = 8;
            label9.Text = "Recibo";
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            labelForm.Font = new Font("Segoe UI", 12F);
            labelForm.Location = new Point(308, 20);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(136, 21);
            labelForm.TabIndex = 0;
            labelForm.Text = "Crear movimiento";
            labelForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboType
            // 
            comboType.FormattingEnabled = true;
            comboType.Location = new Point(506, 66);
            comboType.Margin = new Padding(3, 2, 3, 2);
            comboType.Name = "comboType";
            comboType.Size = new Size(231, 23);
            comboType.TabIndex = 4;
            comboType.SelectedIndexChanged += comboType_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(444, 69);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 3;
            label3.Text = "Tipo*";
            // 
            // comboConsortium
            // 
            comboConsortium.FormattingEnabled = true;
            comboConsortium.Location = new Point(129, 67);
            comboConsortium.Margin = new Padding(3, 2, 3, 2);
            comboConsortium.Name = "comboConsortium";
            comboConsortium.Size = new Size(244, 23);
            comboConsortium.TabIndex = 2;
            comboConsortium.SelectedIndexChanged += comboConsortium_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 69);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 1;
            label4.Text = "Consorcio*";
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(comboConsortium);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboType);
            panel1.Controls.Add(labelForm);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(773, 123);
            panel1.TabIndex = 0;
            // 
            // MovementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(771, 382);
            Controls.Add(panelSecondary);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
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