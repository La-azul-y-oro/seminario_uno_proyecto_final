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
            tableLayoutPanel1 = new TableLayoutPanel();
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
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(txtName, 2, 1);
            tableLayoutPanel1.Controls.Add(btnAccept, 4, 3);
            tableLayoutPanel1.Controls.Add(labelPhone, 1, 2);
            tableLayoutPanel1.Controls.Add(labelCuit, 3, 1);
            tableLayoutPanel1.Controls.Add(labelMail, 3, 2);
            tableLayoutPanel1.Controls.Add(txtCUIT, 4, 1);
            tableLayoutPanel1.Controls.Add(txtPhone, 2, 2);
            tableLayoutPanel1.Controls.Add(txtMail, 4, 2);
            tableLayoutPanel1.Controls.Add(labelForm, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(751, 335);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(64, 88);
            label1.Margin = new Padding(3, 8, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 4;
            label1.Text = "Proveedor";
            // 
            // txtName
            // 
            txtName.Dock = DockStyle.Fill;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(147, 88);
            txtName.Margin = new Padding(3, 8, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(195, 25);
            txtName.TabIndex = 3;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.BackColor = SystemColors.HotTrack;
            btnAccept.Font = new Font("Segoe UI", 11F);
            btnAccept.ForeColor = SystemColors.ControlLightLight;
            btnAccept.Location = new Point(572, 248);
            btnAccept.Margin = new Padding(9, 8, 3, 2);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(105, 34);
            btnAccept.TabIndex = 1;
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
            labelPhone.Location = new Point(74, 168);
            labelPhone.Margin = new Padding(3, 8, 3, 0);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(67, 20);
            labelPhone.TabIndex = 5;
            labelPhone.Text = "Teléfono";
            labelPhone.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCuit
            // 
            labelCuit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCuit.AutoSize = true;
            labelCuit.Font = new Font("Segoe UI", 11F);
            labelCuit.ForeColor = SystemColors.ControlText;
            labelCuit.Location = new Point(436, 88);
            labelCuit.Margin = new Padding(3, 8, 3, 0);
            labelCuit.Name = "labelCuit";
            labelCuit.Size = new Size(40, 20);
            labelCuit.TabIndex = 6;
            labelCuit.Text = "CUIT";
            // 
            // labelMail
            // 
            labelMail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelMail.AutoSize = true;
            labelMail.Font = new Font("Segoe UI", 11F);
            labelMail.ForeColor = SystemColors.ControlText;
            labelMail.Location = new Point(424, 168);
            labelMail.Margin = new Padding(3, 8, 3, 0);
            labelMail.Name = "labelMail";
            labelMail.Size = new Size(52, 20);
            labelMail.TabIndex = 7;
            labelMail.Text = "E-mail";
            // 
            // txtCUIT
            // 
            txtCUIT.Dock = DockStyle.Fill;
            txtCUIT.Font = new Font("Segoe UI", 10F);
            txtCUIT.Location = new Point(482, 88);
            txtCUIT.Margin = new Padding(3, 8, 3, 2);
            txtCUIT.Name = "txtCUIT";
            txtCUIT.Size = new Size(195, 25);
            txtCUIT.TabIndex = 8;
            // 
            // txtPhone
            // 
            txtPhone.Dock = DockStyle.Fill;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(147, 168);
            txtPhone.Margin = new Padding(3, 8, 3, 2);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(195, 25);
            txtPhone.TabIndex = 9;
            // 
            // txtMail
            // 
            txtMail.Dock = DockStyle.Fill;
            txtMail.Font = new Font("Segoe UI", 10F);
            txtMail.Location = new Point(482, 168);
            txtMail.Margin = new Padding(3, 8, 3, 2);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(195, 25);
            txtMail.TabIndex = 10;
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(labelForm, 4);
            labelForm.Dock = DockStyle.Fill;
            labelForm.Font = new Font("Segoe UI", 12F);
            labelForm.Location = new Point(13, 0);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(664, 80);
            labelForm.TabIndex = 0;
            labelForm.Text = "Crear proveedor";
            labelForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SupplierForm
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 335);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "SupplierForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Concepto";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label labelForm;
        private TextBox txtName;
        private Label label1;
        private Button btnAccept;
        private Label labelPhone;
        private Label labelCuit;
        private Label labelMail;
        private TextBox txtCUIT;
        private TextBox txtPhone;
        private TextBox txtMail;
    }
}