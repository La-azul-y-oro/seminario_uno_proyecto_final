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
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(918, 495);
            panel1.TabIndex = 0;
            // 
            // comboRole
            // 
            comboRole.FormattingEnabled = true;
            comboRole.Location = new Point(200, 252);
            comboRole.Name = "comboRole";
            comboRole.Size = new Size(190, 28);
            comboRole.TabIndex = 30;
            // 
            // comboDocType
            // 
            comboDocType.FormattingEnabled = true;
            comboDocType.Location = new Point(200, 169);
            comboDocType.Name = "comboDocType";
            comboDocType.Size = new Size(190, 28);
            comboDocType.TabIndex = 29;
            // 
            // txtDocNumber
            // 
            txtDocNumber.Location = new Point(668, 166);
            txtDocNumber.Name = "txtDocNumber";
            txtDocNumber.Size = new Size(179, 27);
            txtDocNumber.TabIndex = 28;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(624, 337);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(223, 27);
            txtPassword.TabIndex = 27;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(200, 334);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(223, 27);
            txtPhone.TabIndex = 26;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(624, 249);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(223, 27);
            txtMail.TabIndex = 25;
            // 
            // labelPassword
            // 
            labelPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 11F);
            labelPassword.ForeColor = SystemColors.ControlText;
            labelPassword.Location = new Point(462, 336);
            labelPassword.Margin = new Padding(3, 11, 3, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(108, 25);
            labelPassword.TabIndex = 24;
            labelPassword.Text = "Contraseña";
            labelPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(28, 336);
            label3.Margin = new Padding(3, 11, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 23;
            label3.Text = "Teléfono";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(462, 251);
            label2.Margin = new Padding(3, 11, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 25);
            label2.TabIndex = 22;
            label2.Text = "Email";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelConceptos
            // 
            labelConceptos.AutoSize = true;
            labelConceptos.Font = new Font("Segoe UI", 11F);
            labelConceptos.Location = new Point(462, 167);
            labelConceptos.Name = "labelConceptos";
            labelConceptos.Size = new Size(182, 25);
            labelConceptos.TabIndex = 21;
            labelConceptos.Text = "Número documento";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(28, 88);
            label1.Margin = new Padding(3, 11, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 14;
            label1.Text = "Nombre";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(200, 87);
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
            btnAccept.Location = new Point(727, 410);
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
            labelPhone.Location = new Point(28, 251);
            labelPhone.Margin = new Padding(3, 11, 3, 0);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(38, 25);
            labelPhone.TabIndex = 15;
            labelPhone.Text = "Rol";
            labelPhone.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCuit
            // 
            labelCuit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCuit.AutoSize = true;
            labelCuit.Font = new Font("Segoe UI", 11F);
            labelCuit.ForeColor = SystemColors.ControlText;
            labelCuit.Location = new Point(28, 168);
            labelCuit.Margin = new Padding(3, 11, 3, 0);
            labelCuit.Name = "labelCuit";
            labelCuit.Size = new Size(152, 25);
            labelCuit.TabIndex = 16;
            labelCuit.Text = "Tipo Documento";
            // 
            // labelMail
            // 
            labelMail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelMail.AutoSize = true;
            labelMail.Font = new Font("Segoe UI", 11F);
            labelMail.ForeColor = SystemColors.ControlText;
            labelMail.Location = new Point(462, 88);
            labelMail.Margin = new Padding(3, 11, 3, 0);
            labelMail.Name = "labelMail";
            labelMail.Size = new Size(82, 25);
            labelMail.TabIndex = 17;
            labelMail.Text = "Apellido";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(624, 83);
            txtLastName.Margin = new Padding(3, 11, 3, 3);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(223, 30);
            txtLastName.TabIndex = 20;
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            labelForm.Font = new Font("Segoe UI", 12F);
            labelForm.Location = new Point(352, 26);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(127, 28);
            labelForm.TabIndex = 11;
            labelForm.Text = "Crear usuario";
            labelForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 495);
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