namespace desktop_app
{
    partial class BaseUserControl
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
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvEntity = new DataGridView();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            btnUpdateList = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEntity).BeginInit();
            SuspendLayout();
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
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel1.Size = new Size(1152, 555);
            tableLayoutPanel1.TabIndex = 0;
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
            dgvEntity.Location = new Point(3, 53);
            dgvEntity.Name = "dgvEntity";
            dgvEntity.ReadOnly = true;
            dgvEntity.RowHeadersWidth = 51;
            dgvEntity.Size = new Size(1146, 434);
            dgvEntity.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Crimson;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.ForeColor = SystemColors.ButtonHighlight;
            btnDelete.Location = new Point(1032, 5);
            btnDelete.Margin = new Padding(10, 5, 10, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 40);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.LightSkyBlue;
            btnUpdate.Dock = DockStyle.Fill;
            btnUpdate.Font = new Font("Segoe UI", 12F);
            btnUpdate.Location = new Point(902, 5);
            btnUpdate.Margin = new Padding(10, 5, 10, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 40);
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
            btnCreate.Location = new Point(772, 5);
            btnCreate.Margin = new Padding(10, 5, 10, 5);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(110, 40);
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
            btnUpdateList.Location = new Point(912, 495);
            btnUpdateList.Margin = new Padding(20, 5, 20, 5);
            btnUpdateList.Name = "btnUpdateList";
            btnUpdateList.Size = new Size(220, 55);
            btnUpdateList.TabIndex = 4;
            btnUpdateList.Text = "Actualizar listado";
            btnUpdateList.UseVisualStyleBackColor = true;
            // 
            // BaseUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "BaseUserControl";
            Size = new Size(1152, 555);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEntity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        protected DataGridView dgvEntity;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnUpdateList;
    }
}
