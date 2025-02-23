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
            tlpChangePass.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpChangePass.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
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
            lableTitle.Location = new Point(34, 0);
            lableTitle.Margin = new Padding(4, 0, 4, 0);
            lableTitle.Name = "lableTitle";
            lableTitle.Size = new Size(754, 70);
            lableTitle.TabIndex = 0;
            lableTitle.Text = "Cambiar contraseña";
            lableTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCurrentPass
            // 
            labelCurrentPass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCurrentPass.AutoSize = true;
            labelCurrentPass.Location = new Point(129, 75);
            labelCurrentPass.Margin = new Padding(3, 5, 3, 0);
            labelCurrentPass.Name = "labelCurrentPass";
            labelCurrentPass.Size = new Size(152, 25);
            labelCurrentPass.TabIndex = 1;
            labelCurrentPass.Text = "Contraseña actual";
            // 
            // labelNewPass
            // 
            labelNewPass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelNewPass.AutoSize = true;
            labelNewPass.Location = new Point(128, 177);
            labelNewPass.Margin = new Padding(3, 5, 3, 0);
            labelNewPass.Name = "labelNewPass";
            labelNewPass.Size = new Size(153, 25);
            labelNewPass.TabIndex = 2;
            labelNewPass.Text = "Nueva contraseña";
            // 
            // labelNewPassRepeat
            // 
            labelNewPassRepeat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelNewPassRepeat.AutoSize = true;
            labelNewPassRepeat.Location = new Point(71, 279);
            labelNewPassRepeat.Margin = new Padding(3, 5, 3, 0);
            labelNewPassRepeat.Name = "labelNewPassRepeat";
            labelNewPassRepeat.Size = new Size(210, 25);
            labelNewPassRepeat.TabIndex = 3;
            labelNewPassRepeat.Text = "Repetir nueva contraseña";
            // 
            // tbCurrentPass
            // 
            tlpChangePass.SetColumnSpan(tbCurrentPass, 2);
            tbCurrentPass.Dock = DockStyle.Fill;
            tbCurrentPass.Location = new Point(287, 75);
            tbCurrentPass.Margin = new Padding(3, 5, 3, 3);
            tbCurrentPass.Name = "tbCurrentPass";
            tbCurrentPass.PasswordChar = '*';
            tbCurrentPass.Size = new Size(502, 31);
            tbCurrentPass.TabIndex = 4;
            // 
            // tbNewPass
            // 
            tlpChangePass.SetColumnSpan(tbNewPass, 2);
            tbNewPass.Dock = DockStyle.Fill;
            tbNewPass.Location = new Point(287, 177);
            tbNewPass.Margin = new Padding(3, 5, 3, 3);
            tbNewPass.Name = "tbNewPass";
            tbNewPass.PasswordChar = '*';
            tbNewPass.Size = new Size(502, 31);
            tbNewPass.TabIndex = 5;
            // 
            // tbNewPassRepeat
            // 
            tlpChangePass.SetColumnSpan(tbNewPassRepeat, 2);
            tbNewPassRepeat.Dock = DockStyle.Fill;
            tbNewPassRepeat.Location = new Point(287, 279);
            tbNewPassRepeat.Margin = new Padding(3, 5, 3, 3);
            tbNewPassRepeat.Name = "tbNewPassRepeat";
            tbNewPassRepeat.PasswordChar = '*';
            tbNewPassRepeat.Size = new Size(502, 31);
            tbNewPassRepeat.TabIndex = 6;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Right;
            btnSend.BackColor = SystemColors.HotTrack;
            btnSend.ForeColor = SystemColors.ControlLightLight;
            btnSend.Location = new Point(667, 391);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(122, 40);
            btnSend.TabIndex = 7;
            btnSend.Text = "Enviar";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // ChangePassForm
            // 
            AcceptButton = btnSend;
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
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