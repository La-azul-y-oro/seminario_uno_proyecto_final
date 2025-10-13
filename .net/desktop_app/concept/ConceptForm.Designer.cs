namespace desktop_app.concept
{
    partial class ConceptForm
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
            comboType = new ComboBox();
            label2 = new Label();
            labelForm = new Label();
            txtName = new TextBox();
            label1 = new Label();
            btnAccept = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(comboType);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(labelForm);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnAccept);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(963, 392);
            panel1.TabIndex = 0;
            // 
            // comboType
            // 
            comboType.Font = new Font("Segoe UI", 12F);
            comboType.FormattingEnabled = true;
            comboType.Location = new Point(461, 204);
            comboType.Margin = new Padding(3, 4, 3, 4);
            comboType.Name = "comboType";
            comboType.Size = new Size(258, 36);
            comboType.TabIndex = 11;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(366, 201);
            label2.Margin = new Padding(3, 11, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 31);
            label2.TabIndex = 10;
            label2.Text = "Tipo";
            label2.UseWaitCursor = true;
            // 
            // labelForm
            // 
            labelForm.Anchor = AnchorStyles.Bottom;
            labelForm.AutoSize = true;
            labelForm.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            labelForm.Location = new Point(383, 44);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(175, 31);
            labelForm.TabIndex = 5;
            labelForm.Text = "Crear concepto";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(461, 135);
            txtName.Margin = new Padding(3, 11, 3, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(258, 34);
            txtName.TabIndex = 7;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(202, 135);
            label1.Margin = new Padding(3, 11, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(237, 31);
            label1.TabIndex = 8;
            label1.Text = "Nombre del concepto";
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.BackColor = Color.FromArgb(16, 185, 129);
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnAccept.ForeColor = Color.White;
            btnAccept.Location = new Point(735, 305);
            btnAccept.Margin = new Padding(10, 11, 3, 3);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(146, 45);
            btnAccept.TabIndex = 6;
            btnAccept.Text = "Crear";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // ConceptForm
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 392);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ConceptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Concepto";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label labelForm;
        private TextBox txtName;
        private Label label1;
        private Button btnAccept;
        private ComboBox comboType;
    }
}