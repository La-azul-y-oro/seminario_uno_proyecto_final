namespace desktop_app.consortium
{
    partial class ClientForm
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
            dvgClients = new DataGridView();
            labelAdd = new Label();
            comboClients = new ComboBox();
            btnAdd = new Button();
            labelNoData = new Label();
            comboOccupantType = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dvgClients).BeginInit();
            SuspendLayout();
            // 
            // dvgClients
            // 
            dvgClients.AllowUserToAddRows = false;
            dvgClients.AllowUserToDeleteRows = false;
            dvgClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgClients.BackgroundColor = SystemColors.ControlLight;
            dvgClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgClients.Location = new Point(52, 32);
            dvgClients.Name = "dvgClients";
            dvgClients.ReadOnly = true;
            dvgClients.RowHeadersWidth = 51;
            dvgClients.Size = new Size(958, 229);
            dvgClients.TabIndex = 1;
            // 
            // labelAdd
            // 
            labelAdd.AutoSize = true;
            labelAdd.Font = new Font("Segoe UI", 13F);
            labelAdd.Location = new Point(52, 291);
            labelAdd.Name = "labelAdd";
            labelAdd.Size = new Size(215, 30);
            labelAdd.TabIndex = 2;
            labelAdd.Text = "Usuarios disponibles:";
            // 
            // comboClients
            // 
            comboClients.Font = new Font("Segoe UI", 10F);
            comboClients.FormattingEnabled = true;
            comboClients.Location = new Point(52, 331);
            comboClients.Name = "comboClients";
            comboClients.Size = new Size(306, 31);
            comboClients.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(16, 185, 129);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(52, 368);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 45);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // labelNoData
            // 
            labelNoData.AutoSize = true;
            labelNoData.BackColor = Color.Transparent;
            labelNoData.Font = new Font("Segoe UI", 13.8F);
            labelNoData.Location = new Point(398, 125);
            labelNoData.Name = "labelNoData";
            labelNoData.Size = new Size(328, 31);
            labelNoData.TabIndex = 5;
            labelNoData.Text = "No existen usuarios vinculados";
            labelNoData.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboOccupantType
            // 
            comboOccupantType.FormattingEnabled = true;
            comboOccupantType.Location = new Point(398, 345);
            comboOccupantType.Name = "comboOccupantType";
            comboOccupantType.Size = new Size(211, 28);
            comboOccupantType.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(398, 305);
            label1.Name = "label1";
            label1.Size = new Size(55, 28);
            label1.TabIndex = 7;
            label1.Text = "Tipo:";
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1051, 450);
            Controls.Add(label1);
            Controls.Add(comboOccupantType);
            Controls.Add(labelNoData);
            Controls.Add(btnAdd);
            Controls.Add(comboClients);
            Controls.Add(labelAdd);
            Controls.Add(dvgClients);
            Name = "ClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClientForm";
            ((System.ComponentModel.ISupportInitialize)dvgClients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dvgClients;
        private Label labelAdd;
        private ComboBox comboClients;
        private Button btnAdd;
        private Label labelNoData;
        private ComboBox comboOccupantType;
        private Label label1;
    }
}