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
            panel1.Controls.Add(comboType);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(labelForm);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnAccept);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(843, 400);
            panel1.TabIndex = 0;
            // 
            // comboType
            // 
            comboType.FormattingEnabled = true;
            comboType.Location = new Point(547, 187);
            comboType.Name = "comboType";
            comboType.Size = new Size(226, 23);
            comboType.TabIndex = 11;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(502, 190);
            label2.Margin = new Padding(3, 8, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 10;
            label2.Text = "Tipo";
            label2.UseWaitCursor = true;
            // 
            // labelForm
            // 
            labelForm.Anchor = AnchorStyles.Bottom;
            labelForm.AutoSize = true;
            labelForm.Font = new Font("Segoe UI", 12F);
            labelForm.Location = new Point(356, 62);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(115, 21);
            labelForm.TabIndex = 5;
            labelForm.Text = "Crear concepto";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(203, 185);
            txtName.Margin = new Padding(3, 8, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(219, 25);
            txtName.TabIndex = 7;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(42, 186);
            label1.Margin = new Padding(3, 8, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(155, 20);
            label1.TabIndex = 8;
            label1.Text = "Nombre del concepto";
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.BackColor = SystemColors.HotTrack;
            btnAccept.Font = new Font("Segoe UI", 11F);
            btnAccept.ForeColor = SystemColors.ControlLightLight;
            btnAccept.Location = new Point(702, 310);
            btnAccept.Margin = new Padding(9, 8, 3, 2);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(105, 34);
            btnAccept.TabIndex = 6;
            btnAccept.Text = "Crear";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // ConceptForm
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 400);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
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