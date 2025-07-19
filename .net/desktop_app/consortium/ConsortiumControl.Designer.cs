namespace desktop_app.consortium
{
    partial class ConsortiumControl
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
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            btnUpdateList = new Button();
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
            dgvEntity.BackgroundColor = Color.FromArgb(224, 252, 254);
            dgvEntity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgvEntity, 4);
            dgvEntity.Dock = DockStyle.Fill;
            dgvEntity.Location = new Point(3, 54);
            dgvEntity.Name = "dgvEntity";
            dgvEntity.ReadOnly = true;
            dgvEntity.RowHeadersWidth = 51;
            dgvEntity.Size = new Size(1120, 461);
            dgvEntity.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableLayoutPanel1.Controls.Add(dgvEntity, 0, 1);
            tableLayoutPanel1.Controls.Add(btnDelete, 3, 0);
            tableLayoutPanel1.Controls.Add(btnUpdate, 2, 0);
            tableLayoutPanel1.Controls.Add(btnCreate, 1, 0);
            tableLayoutPanel1.Controls.Add(btnUpdateList, 2, 2);
            tableLayoutPanel1.Controls.Add(labelEntity, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel1.Size = new Size(1126, 583);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Crimson;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.ForeColor = SystemColors.ButtonHighlight;
            btnDelete.Location = new Point(1006, 5);
            btnDelete.Margin = new Padding(10, 5, 10, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 41);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.LightSkyBlue;
            btnUpdate.Dock = DockStyle.Fill;
            btnUpdate.Font = new Font("Segoe UI", 12F);
            btnUpdate.Location = new Point(876, 5);
            btnUpdate.Margin = new Padding(10, 5, 10, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 41);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Actualizar";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.MidnightBlue;
            btnCreate.Dock = DockStyle.Fill;
            btnCreate.Font = new Font("Segoe UI", 12F);
            btnCreate.ForeColor = SystemColors.ButtonHighlight;
            btnCreate.Location = new Point(746, 5);
            btnCreate.Margin = new Padding(10, 5, 10, 5);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(110, 41);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Nuevo";
            btnCreate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCreate.UseVisualStyleBackColor = false;
            // 
            // btnUpdateList
            // 
            tableLayoutPanel1.SetColumnSpan(btnUpdateList, 2);
            btnUpdateList.Dock = DockStyle.Fill;
            btnUpdateList.Font = new Font("Segoe UI", 12F);
            btnUpdateList.ImageAlign = ContentAlignment.BottomLeft;
            btnUpdateList.Location = new Point(887, 523);
            btnUpdateList.Margin = new Padding(21, 5, 21, 5);
            btnUpdateList.Name = "btnUpdateList";
            btnUpdateList.Size = new Size(218, 55);
            btnUpdateList.TabIndex = 4;
            btnUpdateList.Text = "Actualizar listado";
            btnUpdateList.UseVisualStyleBackColor = true;
            // 
            // labelEntity
            // 
            labelEntity.AutoSize = true;
            labelEntity.Dock = DockStyle.Fill;
            labelEntity.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEntity.Location = new Point(3, 0);
            labelEntity.Name = "labelEntity";
            labelEntity.Size = new Size(730, 51);
            labelEntity.TabIndex = 5;
            labelEntity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ConsortiumControlDos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ConsortiumControlDos";
            Size = new Size(1126, 583);
            ((System.ComponentModel.ISupportInitialize)dgvEntity).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        protected DataGridView dgvEntity;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnCreate;
        private Button btnUpdateList;
        private Label labelEntity;
    }
}
