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
            panel1.Size = new Size(858, 447);
            panel1.TabIndex = 0;
            // 
            // checkedConcepts
            // 
            checkedConcepts.FormattingEnabled = true;
            checkedConcepts.IntegralHeight = false;
            checkedConcepts.Location = new Point(510, 165);
            checkedConcepts.Name = "checkedConcepts";
            checkedConcepts.Size = new Size(302, 180);
            checkedConcepts.TabIndex = 23;
            // 
            // labelConceptos
            // 
            labelConceptos.AutoSize = true;
            labelConceptos.Font = new Font("Segoe UI", 11F);
            labelConceptos.Location = new Point(403, 165);
            labelConceptos.Name = "labelConceptos";
            labelConceptos.Size = new Size(101, 25);
            labelConceptos.TabIndex = 21;
            labelConceptos.Text = "Conceptos";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(48, 87);
            label1.Margin = new Padding(3, 11, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 14;
            label1.Text = "Proveedor";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(153, 87);
            txtName.Margin = new Padding(3, 11, 3, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(226, 30);
            txtName.TabIndex = 13;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.BackColor = SystemColors.HotTrack;
            btnAccept.Font = new Font("Segoe UI", 11F);
            btnAccept.ForeColor = SystemColors.ControlLightLight;
            btnAccept.Location = new Point(692, 376);
            btnAccept.Margin = new Padding(10, 11, 3, 3);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(120, 45);
            btnAccept.TabIndex = 12;
            btnAccept.Text = "Crear";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // labelPhone
            // 
            labelPhone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 11F);
            labelPhone.ForeColor = SystemColors.ControlText;
            labelPhone.Location = new Point(66, 249);
            labelPhone.Margin = new Padding(3, 11, 3, 0);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(84, 25);
            labelPhone.TabIndex = 15;
            labelPhone.Text = "Teléfono";
            labelPhone.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCuit
            // 
            labelCuit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCuit.AutoSize = true;
            labelCuit.Font = new Font("Segoe UI", 11F);
            labelCuit.ForeColor = SystemColors.ControlText;
            labelCuit.Location = new Point(98, 167);
            labelCuit.Margin = new Padding(3, 11, 3, 0);
            labelCuit.Name = "labelCuit";
            labelCuit.Size = new Size(52, 25);
            labelCuit.TabIndex = 16;
            labelCuit.Text = "CUIT";
            // 
            // labelMail
            // 
            labelMail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelMail.AutoSize = true;
            labelMail.Font = new Font("Segoe UI", 11F);
            labelMail.ForeColor = SystemColors.ControlText;
            labelMail.Location = new Point(438, 87);
            labelMail.Margin = new Padding(3, 11, 3, 0);
            labelMail.Name = "labelMail";
            labelMail.Size = new Size(66, 25);
            labelMail.TabIndex = 17;
            labelMail.Text = "E-mail";
            // 
            // txtCUIT
            // 
            txtCUIT.Font = new Font("Segoe UI", 10F);
            txtCUIT.Location = new Point(156, 166);
            txtCUIT.Margin = new Padding(3, 11, 3, 3);
            txtCUIT.Name = "txtCUIT";
            txtCUIT.Size = new Size(223, 30);
            txtCUIT.TabIndex = 18;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(156, 249);
            txtPhone.Margin = new Padding(3, 11, 3, 3);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(223, 30);
            txtPhone.TabIndex = 19;
            // 
            // txtMail
            // 
            txtMail.Font = new Font("Segoe UI", 10F);
            txtMail.Location = new Point(510, 87);
            txtMail.Margin = new Padding(3, 11, 3, 3);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(223, 30);
            txtMail.TabIndex = 20;
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            labelForm.Font = new Font("Segoe UI", 12F);
            labelForm.Location = new Point(352, 26);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(155, 28);
            labelForm.TabIndex = 11;
            labelForm.Text = "Crear proveedor";
            labelForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 447);
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