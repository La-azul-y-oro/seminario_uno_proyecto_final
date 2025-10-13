namespace PracticaSeminario
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUsuario = new TextBox();
            txtPass = new TextBox();
            inkOlvidaPass = new LinkLabel();
            btnIngresar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(318, 58);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(406, 38);
            label1.TabIndex = 0;
            label1.Text = "Administración de Consorcios";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 13.8F);
            label2.Location = new Point(318, 216);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 31);
            label2.TabIndex = 1;
            label2.Text = "Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 13.8F);
            label3.Location = new Point(280, 341);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(134, 31);
            label3.TabIndex = 2;
            label3.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 13F);
            txtUsuario.Location = new Point(430, 213);
            txtUsuario.Margin = new Padding(5);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(201, 36);
            txtUsuario.TabIndex = 3;
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Segoe UI", 13F);
            txtPass.Location = new Point(430, 333);
            txtPass.Margin = new Padding(5);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(201, 36);
            txtPass.TabIndex = 4;
            // 
            // inkOlvidaPass
            // 
            inkOlvidaPass.AutoSize = true;
            inkOlvidaPass.BackColor = Color.Transparent;
            inkOlvidaPass.Font = new Font("Segoe UI Black", 13.8F);
            inkOlvidaPass.ForeColor = SystemColors.ActiveCaption;
            inkOlvidaPass.LinkColor = Color.FromArgb(16, 185, 129);
            inkOlvidaPass.Location = new Point(207, 463);
            inkOlvidaPass.Margin = new Padding(5, 0, 5, 0);
            inkOlvidaPass.Name = "inkOlvidaPass";
            inkOlvidaPass.Size = new Size(253, 31);
            inkOlvidaPass.TabIndex = 5;
            inkOlvidaPass.TabStop = true;
            inkOlvidaPass.Text = "Olvidé mi contraseña";
            inkOlvidaPass.LinkClicked += inkOlvidaPass_LinkClicked;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(16, 185, 129);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.Transparent;
            btnIngresar.Location = new Point(645, 456);
            btnIngresar.Margin = new Padding(5);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Padding = new Padding(0, 5, 0, 5);
            btnIngresar.Size = new Size(173, 55);
            btnIngresar.TabIndex = 6;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // FormLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1026, 546);
            Controls.Add(btnIngresar);
            Controls.Add(inkOlvidaPass);
            Controls.Add(txtPass);
            Controls.Add(txtUsuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsuario;
        private TextBox txtPass;
        private LinkLabel inkOlvidaPass;
        private Button btnIngresar;
    }
}
