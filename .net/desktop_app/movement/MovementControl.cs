using desktop_app.dto;
using desktop_app.services;
using PracticaSeminario;

namespace desktop_app.movement
{
    public partial class MovementControl : UserControl
    {
        protected readonly ApiService? _apiService;
        private List<ConsortiumResponse> _consortiums;
        private List<ConceptResponse> _concepts;
        private List<SupplierResponse> _suppliers;

        public MovementControl(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;

            LoadDataAsync();
            GetAllConsortiums();
            GetAllSuppliers();
            GetAllConcepts();

            dgvEntity.CellContentClick += dgvEntity_CellContentClick;
        }

        private async Task LoadDataAsync()
        {
            var movements = await GetAll();

            movements = movements
               .OrderByDescending(m => m.Id)
               .ToList();

            dgvEntity.DataSource = null;
            dgvEntity.AutoGenerateColumns = false;

            dgvEntity.Columns.Clear();

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ConsortiumName",
                HeaderText = "Consorcio",
                Name = "colConsorcio",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Fecha",
                Name = "colFecha",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = "Tipo",
                Name = "colTipo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Amount",
                HeaderText = "Monto ($)",
                Name = "colMonto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ConceptName",
                HeaderText = "Concepto",
                Name = "colConcepto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FunctionalUnitName",
                HeaderText = "Unidad Funcional",
                Name = "colUnidadFuncional",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SupplierName",
                HeaderText = "Proveedor",
                Name = "colProveedor",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Receipt",
                HeaderText = "Recibo",
                Name = "colRecibo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Comment",
                HeaderText = "Comentario",
                Name = "colComentario",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            AddActionButtons();

            SetTableStyle();

            dgvEntity.DataSource = movements;
        }

        private void SetTableStyle()
        {
            dgvEntity.EnableHeadersVisualStyles = false;
            dgvEntity.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvEntity.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvEntity.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            dgvEntity.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgvEntity.DefaultCellStyle.Font = new Font("Segoe UI Semilight", 11);
        }

        private async Task<List<MovementResponse>> GetAll()
        {
            try
            {
                return await _apiService.GetAllAsync<MovementResponse>("movement");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
        }
        private async Task GetAllConsortiums()
        {
            try
            {
                _consortiums = await _apiService.GetAllAsync<ConsortiumResponse>("consortium");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task GetAllSuppliers()
        {
            try
            {
                _suppliers = await _apiService.GetAllAsync<SupplierResponse>("supplier");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task GetAllConcepts()
        {
            try
            {
                _concepts = await _apiService.GetAllAsync<ConceptResponse>("concept");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenMovementForm()
        {
            using var form = new MovementForm(_apiService, _concepts, _consortiums, _suppliers);

            var parent = this.FindForm() as FormMain;

            if (parent != null)
            {
                var result = parent.ShowModalWithOverlay(form);
                if (result == DialogResult.OK)
                {
                    LoadDataAsync();
                }
            }
        }


        private async void DeleteSelectedMovement(MovementResponse movement)
        {
            var confirm = MessageBox.Show($"¿Está seguro de eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await _apiService.DeleteAsync("movement", movement.Id);
                    LoadDataAsync();
                }
                catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    MessageBox.Show(
                        "No se permiten procesar movimientos para un periodo ya liquidado.",
                        "Ha ocurrido un error al guardar el movimiento.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddActionButtons()
        {
            if (dgvEntity.Columns["btnRemove"] != null) return;

            var btnRemove = new DataGridViewButtonColumn
            {
                Name = "btnRemove",
                HeaderText = "",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                Width = 120
            };

            dgvEntity.Columns.Add(btnRemove);
        }

        private void dgvEntity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columnName = dgvEntity.Columns[e.ColumnIndex].Name;
            var row = dgvEntity.Rows[e.RowIndex];
            var movement = row.DataBoundItem as MovementResponse;
            if (movement == null) return;

            switch (columnName)
            {
                case "btnRemove":
                    DeleteSelectedMovement(movement);
                    break;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OpenMovementForm();
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            LoadDataAsync();
        }
    }
}
