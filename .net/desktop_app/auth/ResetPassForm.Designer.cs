namespace desktop_app.auth
{
    partial class ResetPassForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPassForm));
            panel = new Panel();
            labelTitle = new Label();
            labelToken = new Label();
            labelNewPass = new Label();
            labelEmail = new Label();
            textToken = new TextBox();
            textPass = new TextBox();
            textEmail = new TextBox();
            btnReset = new Button();
            btnToken = new Button();
            labelSeparator = new Label();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(labelSeparator);
            panel.Controls.Add(btnToken);
            panel.Controls.Add(btnReset);
            panel.Controls.Add(textEmail);
            panel.Controls.Add(textPass);
            panel.Controls.Add(textToken);
            panel.Controls.Add(labelEmail);
            panel.Controls.Add(labelNewPass);
            panel.Controls.Add(labelToken);
            panel.Controls.Add(labelTitle);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(885, 528);
            panel.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 12F);
            labelTitle.Location = new Point(327, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(221, 28);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Recupero de contraseña";
            // 
            // labelToken
            // 
            labelToken.AutoSize = true;
            labelToken.Font = new Font("Segoe UI", 11F);
            labelToken.Location = new Point(212, 81);
            labelToken.Name = "labelToken";
            labelToken.Size = new Size(61, 25);
            labelToken.TabIndex = 2;
            labelToken.Text = "Token";
            // 
            // labelNewPass
            // 
            labelNewPass.AutoSize = true;
            labelNewPass.Font = new Font("Segoe UI", 11F);
            labelNewPass.Location = new Point(215, 189);
            labelNewPass.Name = "labelNewPass";
            labelNewPass.Size = new Size(164, 25);
            labelNewPass.TabIndex = 3;
            labelNewPass.Text = "Nueva contraseña";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 11F);
            labelEmail.Location = new Point(212, 372);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(58, 25);
            labelEmail.TabIndex = 4;
            labelEmail.Text = "Email";
            // 
            // textToken
            // 
            textToken.Font = new Font("Segoe UI", 11F);
            textToken.Location = new Point(215, 109);
            textToken.Name = "textToken";
            textToken.Size = new Size(429, 32);
            textToken.TabIndex = 5;
            // 
            // textPass
            // 
            textPass.Font = new Font("Segoe UI", 11F);
            textPass.Location = new Point(215, 226);
            textPass.Name = "textPass";
            textPass.PasswordChar = '*';
            textPass.Size = new Size(429, 32);
            textPass.TabIndex = 6;
            // 
            // textEmail
            // 
            textEmail.Font = new Font("Segoe UI", 11F);
            textEmail.Location = new Point(215, 403);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(429, 32);
            textEmail.TabIndex = 7;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 11F);
            btnReset.Location = new Point(339, 277);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(196, 45);
            btnReset.TabIndex = 8;
            btnReset.Text = "Resetear contraseña";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnToken
            // 
            btnToken.Font = new Font("Segoe UI", 11F);
            btnToken.Location = new Point(339, 454);
            btnToken.Name = "btnToken";
            btnToken.Size = new Size(196, 45);
            btnToken.TabIndex = 9;
            btnToken.Text = "Obtener Token";
            btnToken.UseVisualStyleBackColor = true;
            btnToken.Click += btnToken_Click;
            // 
            // labelSeparator
            // 
            labelSeparator.AutoSize = true;
            labelSeparator.BackColor = SystemColors.InactiveCaption;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            labelSeparator.Font = new Font("Segoe UI", 1F);
            labelSeparator.Location = new Point(43, 339);
            labelSeparator.Name = "labelSeparator";
            labelSeparator.Size = new Size(812, 5);
            labelSeparator.TabIndex = 1;
            labelSeparator.Text = resources.GetString("labelSeparator.Text");
            // 
            // ResetPassForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 528);
            Controls.Add(panel);
            MaximizeBox = false;
            Name = "ResetPassForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recupero Contraseña";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Label labelTitle;
        private TextBox textPass;
        private TextBox textToken;
        private Label labelEmail;
        private Label labelNewPass;
        private Label labelToken;
        private Button btnToken;
        private Button btnReset;
        private TextBox textEmail;
        private Label labelSeparator;
    }
}