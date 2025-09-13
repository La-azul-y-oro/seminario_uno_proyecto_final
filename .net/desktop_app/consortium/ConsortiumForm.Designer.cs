namespace desktop_app.consortium
{
    partial class ConsortiumForm
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
            labelForm = new Label();
            txtName = new TextBox();
            label1 = new Label();
            btnAccept = new Button();
            labelAddress = new Label();
            txtAddress = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 17F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.Controls.Add(labelForm, 1, 0);
            tableLayoutPanel1.Controls.Add(txtName, 2, 2);
            tableLayoutPanel1.Controls.Add(label1, 1, 2);
            tableLayoutPanel1.Controls.Add(btnAccept, 4, 3);
            tableLayoutPanel1.Controls.Add(labelAddress, 3, 2);
            tableLayoutPanel1.Controls.Add(txtAddress, 4, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 109F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 109F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 109F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 109F));
            tableLayoutPanel1.Size = new Size(992, 451);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(labelForm, 4);
            labelForm.Dock = DockStyle.Fill;
            labelForm.Font = new Font("Segoe UI", 12F);
            labelForm.Location = new Point(20, 0);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(934, 109);
            labelForm.TabIndex = 0;
            labelForm.Text = "Crear consorcio";
            labelForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            txtName.Dock = DockStyle.Fill;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(161, 229);
            txtName.Margin = new Padding(3, 11, 3, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(323, 30);
            txtName.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(74, 229);
            label1.Margin = new Padding(3, 11, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 4;
            label1.Text = "Nombre";
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.BackColor = SystemColors.HotTrack;
            btnAccept.Font = new Font("Segoe UI", 11F);
            btnAccept.ForeColor = SystemColors.ControlLightLight;
            btnAccept.Location = new Point(834, 338);
            btnAccept.Margin = new Padding(10, 11, 3, 3);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(120, 45);
            btnAccept.TabIndex = 1;
            btnAccept.Text = "Crear";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // labelAddress
            // 
            labelAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAddress.AutoSize = true;
            labelAddress.Font = new Font("Segoe UI", 11F);
            labelAddress.ForeColor = SystemColors.ControlText;
            labelAddress.Location = new Point(533, 229);
            labelAddress.Margin = new Padding(3, 11, 3, 0);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(92, 25);
            labelAddress.TabIndex = 5;
            labelAddress.Text = "Dirección";
            // 
            // txtAddress
            // 
            txtAddress.Dock = DockStyle.Fill;
            txtAddress.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAddress.Location = new Point(631, 229);
            txtAddress.Margin = new Padding(3, 11, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(323, 29);
            txtAddress.TabIndex = 6;
            // 
            // ConsortiumForm
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 451);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ConsortiumForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consorcio";
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
        private Label labelAddress;
        private TextBox txtAddress;
    }
}