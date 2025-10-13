namespace desktop_app.users
{
    partial class UsersForm
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
            comboRole = new ComboBox();
            comboDocType = new ComboBox();
            txtDocNumber = new TextBox();
            txtPassword = new TextBox();
            txtPhone = new TextBox();
            txtMail = new TextBox();
            labelPassword = new Label();
            label3 = new Label();
            label2 = new Label();
            labelConceptos = new Label();
            label1 = new Label();
            txtName = new TextBox();
            btnAccept = new Button();
            labelPhone = new Label();
            labelCuit = new Label();
            labelMail = new Label();
            txtLastName = new TextBox();
            labelForm = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(comboRole);
            panel1.Controls.Add(comboDocType);
            panel1.Controls.Add(txtDocNumber);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(txtMail);
            panel1.Controls.Add(labelPassword);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(labelConceptos);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(btnAccept);
            panel1.Controls.Add(labelPhone);
            panel1.Controls.Add(labelCuit);
            panel1.Controls.Add(labelMail);
            panel1.Controls.Add(txtLastName);
            panel1.Controls.Add(labelForm);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Segoe UI", 12F);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1077, 521);
            panel1.TabIndex = 0;
            // 
            // comboRole
            // 
            comboRole.Font = new Font("Segoe UI", 12F);
            comboRole.FormattingEnabled = true;
            comboRole.Location = new Point(252, 275);
            comboRole.Name = "comboRole";
            comboRole.Size = new Size(223, 36);
            comboRole.TabIndex = 30;
            // 
            // comboDocType
            // 
            comboDocType.Font = new Font("Segoe UI", 12F);
            comboDocType.FormattingEnabled = true;
            comboDocType.Location = new Point(252, 192);
            comboDocType.Name = "comboDocType";
            comboDocType.Size = new Size(223, 36);
            comboDocType.TabIndex = 29;
            // 
            // txtDocNumber
            // 
            txtDocNumber.Font = new Font("Segoe UI", 12F);
            txtDocNumber.Location = new Point(739, 188);
            txtDocNumber.Name = "txtDocNumber";
            txtDocNumber.Size = new Size(223, 34);
            txtDocNumber.TabIndex = 28;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(739, 357);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(223, 34);
            txtPassword.TabIndex = 27;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F);
            txtPhone.Location = new Point(252, 357);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(223, 34);
            txtPhone.TabIndex = 26;
            // 
            // txtMail
            // 
            txtMail.Font = new Font("Segoe UI", 12F);
            txtMail.Location = new Point(739, 269);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(223, 34);
            txtMail.TabIndex = 25;
            // 
            // labelPassword
            // 
            labelPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 13.8F);
            labelPassword.ForeColor = SystemColors.ControlText;
            labelPassword.Location = new Point(604, 357);
            labelPassword.Margin = new Padding(3, 11, 3, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(129, 31);
            labelPassword.TabIndex = 24;
            labelPassword.Text = "Contraseña";
            labelPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(137, 358);
            label3.Margin = new Padding(3, 11, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 31);
            label3.TabIndex = 23;
            label3.Text = "Teléfono";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(663, 269);
            label2.Margin = new Padding(3, 11, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(70, 31);
            label2.TabIndex = 22;
            label2.Text = "Email";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelConceptos
            // 
            labelConceptos.AutoSize = true;
            labelConceptos.Font = new Font("Segoe UI", 13.8F);
            labelConceptos.Location = new Point(513, 189);
            labelConceptos.Name = "labelConceptos";
            labelConceptos.Size = new Size(220, 31);
            labelConceptos.TabIndex = 21;
            labelConceptos.Text = "Número documento";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(139, 113);
            label1.Margin = new Padding(3, 11, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(98, 31);
            label1.TabIndex = 14;
            label1.Text = "Nombre";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(252, 110);
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
            btnAccept.Location = new Point(818, 441);
            btnAccept.Margin = new Padding(10, 11, 3, 3);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(144, 45);
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
            labelPhone.Location = new Point(191, 275);
            labelPhone.Margin = new Padding(3, 11, 3, 0);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(46, 31);
            labelPhone.TabIndex = 15;
            labelPhone.Text = "Rol";
            labelPhone.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCuit
            // 
            labelCuit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCuit.AutoSize = true;
            labelCuit.Font = new Font("Segoe UI", 13.8F);
            labelCuit.ForeColor = SystemColors.ControlText;
            labelCuit.Location = new Point(53, 192);
            labelCuit.Margin = new Padding(3, 11, 3, 0);
            labelCuit.Name = "labelCuit";
            labelCuit.Size = new Size(184, 31);
            labelCuit.TabIndex = 16;
            labelCuit.Text = "Tipo Documento";
            // 
            // labelMail
            // 
            labelMail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelMail.AutoSize = true;
            labelMail.Font = new Font("Segoe UI", 13.8F);
            labelMail.ForeColor = SystemColors.ControlText;
            labelMail.Location = new Point(633, 113);
            labelMail.Margin = new Padding(3, 11, 3, 0);
            labelMail.Name = "labelMail";
            labelMail.Size = new Size(100, 31);
            labelMail.TabIndex = 17;
            labelMail.Text = "Apellido";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 12F);
            txtLastName.Location = new Point(739, 113);
            txtLastName.Margin = new Padding(3, 11, 3, 3);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(223, 34);
            txtLastName.TabIndex = 20;
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            labelForm.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            labelForm.Location = new Point(466, 31);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(156, 31);
            labelForm.TabIndex = 11;
            labelForm.Text = "Crear usuario";
            labelForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 521);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "UsersForm";
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
        private TextBox txtLastName;
        private Label labelForm;
        private Label labelConceptos;
        private Label label2;
        private TextBox txtDocNumber;
        private TextBox txtPassword;
        private TextBox txtPhone;
        private TextBox txtMail;
        private Label labelPassword;
        private Label label3;
        private ComboBox comboRole;
        private ComboBox comboDocType;
    }
}