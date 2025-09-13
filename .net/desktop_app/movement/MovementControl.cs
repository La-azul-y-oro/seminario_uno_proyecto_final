using desktop_app.dto;
using desktop_app.models;
using desktop_app.services;

namespace desktop_app.movement
{
    public partial class MovementControl : UserControl
    {
        protected readonly ApiService? _apiService;
        private List<ConsortiumResponse> _consortiums;
        private List<ConceptResponse> _concepts;
        private List<SupplierResponse> _suppliers;
        private List<FunctionalUnitResponse> _functionalUnits;

        public MovementControl(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;

            LoadDataAsync();
            GetAllConsortiums();
            GetAllFunctionalUnits();
            GetAllSuppliers();
            GetAllConcepts();

            dgvEntity.CellContentClick += dgvEntity_CellContentClick;
        }

        private async Task LoadDataAsync()
        {
            var movements = await GetAll();

            dgvEntity.DataSource = null;
            dgvEntity.AutoGenerateColumns = false;

            dgvEntity.Columns.Clear();

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Fecha",
                Name = "colFecha",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Amount",
                HeaderText = "Monto",
                Name = "colMonto",
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
                DataPropertyName = "ConsortiumName",
                HeaderText = "Consorcio",
                Name = "colConsorcio",
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
            dgvEntity.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvEntity.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgvEntity.DefaultCellStyle.Font = new Font("Segoe UI", 10);
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

        private async Task GetAllFunctionalUnits()
        {
            try
            {
                _functionalUnits = await _apiService.GetAllAsync<FunctionalUnitResponse>("functionalunit");
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

        private void OpenMovementForm(MovementResponse? dto)
        {
            var movementToProcess = (dto != null) ? dto : null;

            using var form = new MovementForm(_apiService, _concepts, _consortiums, _functionalUnits, _suppliers, movementToProcess);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadDataAsync();
            }
        }


        private async void DeleteSelectedMovement(MovementResponse movement)
        {
            var confirm = MessageBox.Show($"¿Está seguro de eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                await _apiService.DeleteAsync("movement", movement.Id);
                LoadDataAsync();
            }
        }

        private void AddActionButtons()
        {
            if (dgvEntity.Columns["btnEdit"] != null) return;

            var btnEdit = new DataGridViewButtonColumn
            {
                Name = "btnEdit",
                HeaderText = "",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                Width = 120
            };

            var btnRemove = new DataGridViewButtonColumn
            {
                Name = "btnRemove",
                HeaderText = "",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                Width = 120
            };

            dgvEntity.Columns.Add(btnEdit);
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
                case "btnEdit":
                    OpenMovementForm(movement);
                    break;

                case "btnRemove":
                    DeleteSelectedMovement(movement);
                    break;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OpenMovementForm(null);
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            LoadDataAsync();
        }
    }
}
