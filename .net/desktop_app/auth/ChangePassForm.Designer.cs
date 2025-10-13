namespace desktop_app.auth
{
    partial class ChangePassForm
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
            tlpChangePass = new TableLayoutPanel();
            lableTitle = new Label();
            labelCurrentPass = new Label();
            labelNewPass = new Label();
            labelNewPassRepeat = new Label();
            tbCurrentPass = new TextBox();
            tbNewPass = new TextBox();
            tbNewPassRepeat = new TextBox();
            btnSend = new Button();
            tlpChangePass.SuspendLayout();
            SuspendLayout();
            // 
            // tlpChangePass
            // 
            tlpChangePass.ColumnCount = 5;
            tlpChangePass.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tlpChangePass.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.53088F));
            tlpChangePass.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.0919838F));
            tlpChangePass.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpChangePass.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tlpChangePass.Controls.Add(lableTitle, 1, 0);
            tlpChangePass.Controls.Add(labelCurrentPass, 1, 1);
            tlpChangePass.Controls.Add(labelNewPass, 1, 2);
            tlpChangePass.Controls.Add(labelNewPassRepeat, 1, 3);
            tlpChangePass.Controls.Add(tbCurrentPass, 2, 1);
            tlpChangePass.Controls.Add(tbNewPass, 2, 2);
            tlpChangePass.Controls.Add(tbNewPassRepeat, 2, 3);
            tlpChangePass.Controls.Add(btnSend, 3, 4);
            tlpChangePass.Dock = DockStyle.Fill;
            tlpChangePass.Location = new Point(0, 0);
            tlpChangePass.Margin = new Padding(4, 5, 4, 5);
            tlpChangePass.Name = "tlpChangePass";
            tlpChangePass.RowCount = 5;
            tlpChangePass.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tlpChangePass.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpChangePass.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpChangePass.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpChangePass.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tlpChangePass.Size = new Size(822, 447);
            tlpChangePass.TabIndex = 0;
            // 
            // lableTitle
            // 
            lableTitle.AutoSize = true;
            tlpChangePass.SetColumnSpan(lableTitle, 3);
            lableTitle.Dock = DockStyle.Fill;
            lableTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lableTitle.Location = new Point(34, 0);
            lableTitle.Margin = new Padding(4, 0, 4, 0);
            lableTitle.Name = "lableTitle";
            lableTitle.Size = new Size(753, 70);
            lableTitle.TabIndex = 0;
            lableTitle.Text = "Cambiar contraseña";
            lableTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCurrentPass
            // 
            labelCurrentPass.AutoSize = true;
            labelCurrentPass.Font = new Font("Segoe UI", 13.8F);
            labelCurrentPass.Location = new Point(33, 75);
            labelCurrentPass.Margin = new Padding(3, 5, 3, 0);
            labelCurrentPass.Name = "labelCurrentPass";
            labelCurrentPass.Size = new Size(197, 31);
            labelCurrentPass.TabIndex = 1;
            labelCurrentPass.Text = "Contraseña actual";
            // 
            // labelNewPass
            // 
            labelNewPass.AutoSize = true;
            labelNewPass.Font = new Font("Segoe UI", 13.8F);
            labelNewPass.Location = new Point(33, 177);
            labelNewPass.Margin = new Padding(3, 5, 3, 0);
            labelNewPass.Name = "labelNewPass";
            labelNewPass.Size = new Size(197, 31);
            labelNewPass.TabIndex = 2;
            labelNewPass.Text = "Nueva contraseña";
            // 
            // labelNewPassRepeat
            // 
            labelNewPassRepeat.AutoSize = true;
            labelNewPassRepeat.Font = new Font("Segoe UI", 13.8F);
            labelNewPassRepeat.Location = new Point(33, 279);
            labelNewPassRepeat.Margin = new Padding(3, 5, 3, 0);
            labelNewPassRepeat.Name = "labelNewPassRepeat";
            labelNewPassRepeat.Size = new Size(272, 31);
            labelNewPassRepeat.TabIndex = 3;
            labelNewPassRepeat.Text = "Repetir nueva contraseña";
            // 
            // tbCurrentPass
            // 
            tlpChangePass.SetColumnSpan(tbCurrentPass, 2);
            tbCurrentPass.Dock = DockStyle.Fill;
            tbCurrentPass.Font = new Font("Segoe UI", 12F);
            tbCurrentPass.Location = new Point(311, 75);
            tbCurrentPass.Margin = new Padding(3, 5, 3, 3);
            tbCurrentPass.Name = "tbCurrentPass";
            tbCurrentPass.PasswordChar = '*';
            tbCurrentPass.Size = new Size(477, 34);
            tbCurrentPass.TabIndex = 4;
            // 
            // tbNewPass
            // 
            tlpChangePass.SetColumnSpan(tbNewPass, 2);
            tbNewPass.Dock = DockStyle.Fill;
            tbNewPass.Font = new Font("Segoe UI", 12F);
            tbNewPass.Location = new Point(311, 177);
            tbNewPass.Margin = new Padding(3, 5, 3, 3);
            tbNewPass.Name = "tbNewPass";
            tbNewPass.PasswordChar = '*';
            tbNewPass.Size = new Size(477, 34);
            tbNewPass.TabIndex = 5;
            // 
            // tbNewPassRepeat
            // 
            tlpChangePass.SetColumnSpan(tbNewPassRepeat, 2);
            tbNewPassRepeat.Dock = DockStyle.Fill;
            tbNewPassRepeat.Font = new Font("Segoe UI", 12F);
            tbNewPassRepeat.Location = new Point(311, 279);
            tbNewPassRepeat.Margin = new Padding(3, 5, 3, 3);
            tbNewPassRepeat.Name = "tbNewPassRepeat";
            tbNewPassRepeat.PasswordChar = '*';
            tbNewPassRepeat.Size = new Size(477, 34);
            tbNewPassRepeat.TabIndex = 6;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Right;
            btnSend.BackColor = Color.FromArgb(16, 185, 129);
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(631, 385);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(157, 52);
            btnSend.TabIndex = 7;
            btnSend.Text = "Enviar";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // ChangePassForm
            // 
            AcceptButton = btnSend;
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(822, 447);
            Controls.Add(tlpChangePass);
            Font = new Font("Segoe UI", 13F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "ChangePassForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cambiar contraseña";
            tlpChangePass.ResumeLayout(false);
            tlpChangePass.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpChangePass;
        private Label lableTitle;
        private Label labelCurrentPass;
        private Label labelNewPass;
        private Label labelNewPassRepeat;
        private TextBox tbCurrentPass;
        private TextBox tbNewPass;
        private TextBox tbNewPassRepeat;
        private Button btnSend;
    }
}