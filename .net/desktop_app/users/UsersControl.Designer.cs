namespace desktop_app.users
{
    partial class UsersControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            dgvEntity = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnUpdateList = new Button();
            btnCreate = new Button();
            labelEntity = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEntity).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEntity
            // 
            dgvEntity.AllowUserToAddRows = false;
            dgvEntity.AllowUserToDeleteRows = false;
            dgvEntity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEntity.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEntity.BackgroundColor = Color.WhiteSmoke;
            dgvEntity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgvEntity, 4);
            dgvEntity.Dock = DockStyle.Fill;
            dgvEntity.Location = new Point(3, 68);
            dgvEntity.Name = "dgvEntity";
            dgvEntity.ReadOnly = true;
            dgvEntity.RowHeadersWidth = 51;
            dgvEntity.Size = new Size(1120, 447);
            dgvEntity.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Gainsboro;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 240F));
            tableLayoutPanel1.Controls.Add(btnUpdateList, 1, 2);
            tableLayoutPanel1.Controls.Add(dgvEntity, 0, 1);
            tableLayoutPanel1.Controls.Add(btnCreate, 1, 0);
            tableLayoutPanel1.Controls.Add(labelEntity, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel1.Size = new Size(1126, 583);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnUpdateList
            // 
            btnUpdateList.BackColor = Color.DimGray;
            btnUpdateList.Dock = DockStyle.Fill;
            btnUpdateList.FlatAppearance.BorderSize = 0;
            btnUpdateList.FlatStyle = FlatStyle.Flat;
            btnUpdateList.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdateList.ForeColor = SystemColors.Control;
            btnUpdateList.ImageAlign = ContentAlignment.BottomLeft;
            btnUpdateList.Location = new Point(907, 528);
            btnUpdateList.Margin = new Padding(21, 10, 21, 10);
            btnUpdateList.Name = "btnUpdateList";
            btnUpdateList.Size = new Size(198, 45);
            btnUpdateList.TabIndex = 6;
            btnUpdateList.Text = "Actualizar listado";
            btnUpdateList.UseVisualStyleBackColor = false;
            btnUpdateList.Click += btnUpdateList_Click;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(16, 185, 129);
            btnCreate.Dock = DockStyle.Fill;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(916, 10);
            btnCreate.Margin = new Padding(30, 10, 30, 10);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(180, 45);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Nuevo";
            btnCreate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // labelEntity
            // 
            labelEntity.AutoSize = true;
            labelEntity.BackColor = Color.Gainsboro;
            labelEntity.Dock = DockStyle.Fill;
            labelEntity.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEntity.Location = new Point(3, 0);
            labelEntity.Name = "labelEntity";
            labelEntity.Size = new Size(880, 65);
            labelEntity.TabIndex = 5;
            labelEntity.Text = "USUARIOS";
            labelEntity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UsersControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UsersControl";
            Size = new Size(1126, 583);
            ((System.ComponentModel.ISupportInitialize)dgvEntity).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        protected DataGridView dgvEntity;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelEntity;
        private Button btnCreate;
        private Button btnUpdateList;
    }
}
