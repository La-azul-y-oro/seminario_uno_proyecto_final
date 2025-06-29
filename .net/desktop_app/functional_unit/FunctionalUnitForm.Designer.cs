namespace desktop_app.functional_unit
{
    partial class FunctionalUnitForm
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
            functionalformPanel = new Panel();
            btnAccept = new Button();
            labelConsorcio = new Label();
            label1 = new Label();
            labelName = new Label();
            consortiumBox = new ComboBox();
            textFactor = new TextBox();
            textName = new TextBox();
            labelTitle = new Label();
            functionalformPanel.SuspendLayout();
            SuspendLayout();
            // 
            // functionalformPanel
            // 
            functionalformPanel.Controls.Add(btnAccept);
            functionalformPanel.Controls.Add(labelConsorcio);
            functionalformPanel.Controls.Add(label1);
            functionalformPanel.Controls.Add(labelName);
            functionalformPanel.Controls.Add(consortiumBox);
            functionalformPanel.Controls.Add(textFactor);
            functionalformPanel.Controls.Add(textName);
            functionalformPanel.Controls.Add(labelTitle);
            functionalformPanel.Dock = DockStyle.Fill;
            functionalformPanel.Location = new Point(0, 0);
            functionalformPanel.Name = "functionalformPanel";
            functionalformPanel.Size = new Size(800, 450);
            functionalformPanel.TabIndex = 0;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.BackColor = SystemColors.HotTrack;
            btnAccept.Font = new Font("Segoe UI", 11F);
            btnAccept.ForeColor = SystemColors.ControlLightLight;
            btnAccept.Location = new Point(620, 345);
            btnAccept.Margin = new Padding(10, 11, 3, 3);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(120, 45);
            btnAccept.TabIndex = 7;
            btnAccept.Text = "Crear";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // labelConsorcio
            // 
            labelConsorcio.AutoSize = true;
            labelConsorcio.Font = new Font("Segoe UI", 12F);
            labelConsorcio.Location = new Point(214, 247);
            labelConsorcio.Name = "labelConsorcio";
            labelConsorcio.Size = new Size(104, 28);
            labelConsorcio.TabIndex = 6;
            labelConsorcio.Text = "Consorcio:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(248, 183);
            label1.Name = "label1";
            label1.Size = new Size(70, 28);
            label1.TabIndex = 5;
            label1.Text = "Factor:";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 12F);
            labelName.Location = new Point(229, 119);
            labelName.Name = "labelName";
            labelName.Size = new Size(89, 28);
            labelName.TabIndex = 4;
            labelName.Text = "Nombre:";
            // 
            // consortiumBox
            // 
            consortiumBox.FormattingEnabled = true;
            consortiumBox.Location = new Point(351, 247);
            consortiumBox.Name = "consortiumBox";
            consortiumBox.Size = new Size(242, 28);
            consortiumBox.TabIndex = 3;
            // 
            // textFactor
            // 
            textFactor.Location = new Point(351, 184);
            textFactor.Name = "textFactor";
            textFactor.Size = new Size(242, 27);
            textFactor.TabIndex = 2;
            textFactor.KeyPress += textFactor_KeyPress;
            // 
            // textName
            // 
            textName.Location = new Point(351, 119);
            textName.Name = "textName";
            textName.Size = new Size(242, 27);
            textName.TabIndex = 1;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 12F);
            labelTitle.Location = new Point(297, 54);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(216, 28);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Crear Unidad Funcional";
            // 
            // FunctionalUnitForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(functionalformPanel);
            Name = "FunctionalUnitForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FunctionalUnit";
            functionalformPanel.ResumeLayout(false);
            functionalformPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel functionalformPanel;
        private Label labelTitle;
        private TextBox textName;
        private Label label1;
        private Label labelName;
        private ComboBox consortiumBox;
        private TextBox textFactor;
        private Label labelConsorcio;
        private Button btnAccept;
    }
}