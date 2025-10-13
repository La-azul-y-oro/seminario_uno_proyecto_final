namespace desktop_app.supplier
{
    partial class SupplierForm
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
            panel1 = new Panel();
            checkedConcepts = new CheckedListBox();
            labelConceptos = new Label();
            label1 = new Label();
            txtName = new TextBox();
            btnAccept = new Button();
            labelPhone = new Label();
            labelCuit = new Label();
            labelMail = new Label();
            txtCUIT = new TextBox();
            txtPhone = new TextBox();
            txtMail = new TextBox();
            labelForm = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(checkedConcepts);
            panel1.Controls.Add(labelConceptos);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(btnAccept);
            panel1.Controls.Add(labelPhone);
            panel1.Controls.Add(labelCuit);
            panel1.Controls.Add(labelMail);
            panel1.Controls.Add(txtCUIT);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(txtMail);
            panel1.Controls.Add(labelForm);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(968, 480);
            panel1.TabIndex = 0;
            // 
            // checkedConcepts
            // 
            checkedConcepts.Font = new Font("Segoe UI", 12F);
            checkedConcepts.FormattingEnabled = true;
            checkedConcepts.IntegralHeight = false;
            checkedConcepts.Location = new Point(598, 184);
            checkedConcepts.Name = "checkedConcepts";
            checkedConcepts.Size = new Size(302, 180);
            checkedConcepts.TabIndex = 23;
            // 
            // labelConceptos
            // 
            labelConceptos.AutoSize = true;
            labelConceptos.Font = new Font("Segoe UI", 13.8F);
            labelConceptos.Location = new Point(470, 184);
            labelConceptos.Name = "labelConceptos";
            labelConceptos.Size = new Size(122, 31);
            labelConceptos.TabIndex = 21;
            labelConceptos.Text = "Conceptos";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(72, 106);
            label1.Margin = new Padding(3, 11, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 31);
            label1.TabIndex = 14;
            label1.Text = "Proveedor";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(195, 106);
            txtName.Margin = new Padding(3, 11, 3, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(226, 34);
            txtName.TabIndex = 13;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.BackColor = Color.FromArgb(16, 185, 129);
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnAccept.ForeColor = Color.White;
            btnAccept.Location = new Point(755, 405);
            btnAccept.Margin = new Padding(10, 11, 3, 3);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(145, 45);
            btnAccept.TabIndex = 12;
            btnAccept.Text = "Crear";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // labelPhone
            // 
            labelPhone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 13.8F);
            labelPhone.ForeColor = SystemColors.ControlText;
            labelPhone.Location = new Point(83, 268);
            labelPhone.Margin = new Padding(3, 11, 3, 0);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(100, 31);
            labelPhone.TabIndex = 15;
            labelPhone.Text = "Teléfono";
            labelPhone.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCuit
            // 
            labelCuit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCuit.AutoSize = true;
            labelCuit.Font = new Font("Segoe UI", 13.8F);
            labelCuit.ForeColor = SystemColors.ControlText;
            labelCuit.Location = new Point(121, 186);
            labelCuit.Margin = new Padding(3, 11, 3, 0);
            labelCuit.Name = "labelCuit";
            labelCuit.Size = new Size(62, 31);
            labelCuit.TabIndex = 16;
            labelCuit.Text = "CUIT";
            // 
            // labelMail
            // 
            labelMail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelMail.AutoSize = true;
            labelMail.Font = new Font("Segoe UI", 13.8F);
            labelMail.ForeColor = SystemColors.ControlText;
            labelMail.Location = new Point(498, 106);
            labelMail.Margin = new Padding(3, 11, 3, 0);
            labelMail.Name = "labelMail";
            labelMail.Size = new Size(79, 31);
            labelMail.TabIndex = 17;
            labelMail.Text = "E-mail";
            // 
            // txtCUIT
            // 
            txtCUIT.Font = new Font("Segoe UI", 12F);
            txtCUIT.Location = new Point(195, 185);
            txtCUIT.Margin = new Padding(3, 11, 3, 3);
            txtCUIT.Name = "txtCUIT";
            txtCUIT.Size = new Size(223, 34);
            txtCUIT.TabIndex = 18;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F);
            txtPhone.Location = new Point(195, 268);
            txtPhone.Margin = new Padding(3, 11, 3, 3);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(223, 34);
            txtPhone.TabIndex = 19;
            // 
            // txtMail
            // 
            txtMail.Font = new Font("Segoe UI", 12F);
            txtMail.Location = new Point(598, 105);
            txtMail.Margin = new Padding(3, 11, 3, 3);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(302, 34);
            txtMail.TabIndex = 20;
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            labelForm.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            labelForm.Location = new Point(401, 28);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(186, 31);
            labelForm.TabIndex = 11;
            labelForm.Text = "Crear proveedor";
            labelForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 480);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SupplierForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proveedor";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtName;
        private Button btnAccept;
        private Label labelPhone;
        private Label labelCuit;
        private Label labelMail;
        private TextBox txtCUIT;
        private TextBox txtPhone;
        private TextBox txtMail;
        private Label labelForm;
        private Label labelConceptos;
        private CheckedListBox checkedConcepts;
    }
}