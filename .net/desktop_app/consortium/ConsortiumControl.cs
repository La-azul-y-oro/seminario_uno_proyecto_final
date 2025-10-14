using desktop_app.dto;
using desktop_app.liquidation;
using desktop_app.models;
using desktop_app.report;
using desktop_app.services;
using PracticaSeminario;

namespace desktop_app.consortium
{
    public partial class ConsortiumControl : UserControl
    {
        protected readonly ApiService? _apiService;

        private readonly LiquidationService _liquidationService;
        private readonly ReportService _reportService;
        private readonly FunctionalUnitService _functionalUnitService;
        private readonly UserService _userService;

        public ConsortiumControl(ApiService apiService, LiquidationService liquidationService, ReportService reportService, FunctionalUnitService functionalUnitService, UserService userService)
        {
            InitializeComponent();
            _apiService = apiService;
            _liquidationService = liquidationService;
            _reportService = reportService;
            _functionalUnitService = functionalUnitService;
            _userService = userService;

            this.Load += ConsortiumControl_Load;
            dgvEntity.CellContentClick += dgvEntity_CellContentClick;
        }

        private async void ConsortiumControl_Load(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var consorcios = await GetAll();

            dgvEntity.DataSource = null;
            dgvEntity.AutoGenerateColumns = false;

            dgvEntity.Columns.Clear();

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nombre",
                Name = "colNombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "Dirección",
                Name = "colDireccion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            AddActionButtons();
            SetTableStyle();

            dgvEntity.DataSource = consorcios;
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

        private async Task<List<ConsortiumResponse>> GetAll()
        {
            try
            {
                return await _apiService.GetAllAsync<ConsortiumResponse>("consortium");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
        }

        private void OpenConsortiumForm(ConsortiumResponse? dto)
        {
            var consortiumToProcess = (dto != null) ? GenerateConsortium(dto) : null;

            using var form = new ConsortiumForm(_apiService, consortiumToProcess);

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

        private async void DeleteSelectedConsortium(ConsortiumResponse consortium)
        {
            var confirm = MessageBox.Show($"¿Está seguro de eliminar este registro? ({consortium.Name})", "Confirmación", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                await _apiService.DeleteAsync("consortium", consortium.Id);
                LoadDataAsync();
            }
        }

        private void AddActionButtons()
        {
            if (dgvEntity.Columns["btnLiquidar"] != null) return;

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

            var btnUnidades = new DataGridViewButtonColumn
            {
                Name = "btnUnidades",
                HeaderText = "Unidades",
                Text = "Gestionar",
                UseColumnTextForButtonValue = true,
                Width = 120
            };

            var btnLiquidar = new DataGridViewButtonColumn
            {
                Name = "btnLiquidar",
                HeaderText = "Liquidación",
                Text = "Generar",
                UseColumnTextForButtonValue = true,
                Width = 120
            };

            var btnDescargar = new DataGridViewButtonColumn
            {
                Name = "btnDescargar",
                HeaderText = "Reportes",
                Text = "Descargar",
                UseColumnTextForButtonValue = true,
                Width = 120
            };

            dgvEntity.Columns.Add(btnEdit);
            dgvEntity.Columns.Add(btnRemove);
            dgvEntity.Columns.Add(btnUnidades);
            dgvEntity.Columns.Add(btnLiquidar);
            dgvEntity.Columns.Add(btnDescargar);
        }

        private void dgvEntity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columnName = dgvEntity.Columns[e.ColumnIndex].Name;
            var row = dgvEntity.Rows[e.RowIndex];
            var consortium = row.DataBoundItem as ConsortiumResponse;
            if (consortium == null) return;

            switch (columnName)
            {
                case "btnEdit":
                    OpenConsortiumForm(consortium);
                    break;

                case "btnRemove":
                    DeleteSelectedConsortium(consortium);
                    break;

                case "btnLiquidar":
                    GenerateLiquidation(consortium);
                    break;

                case "btnDescargar":
                    DownloadReportAsync(consortium);
                    break;

                case "btnUnidades":
                    ShowFunctionalUnits(consortium);
                    break;
            }
        }

        private void ShowFunctionalUnits(ConsortiumResponse consortium)
        {
            using var form = new FunctionalUnitForm(consortium, _functionalUnitService, _userService);

            form.UnitsUpdated += (updatedUnits) =>
            {
                consortium.FunctionalUnits = updatedUnits;
            };

            var parent = this.FindForm() as FormMain;
            parent?.ShowModalWithOverlay(form);
        }

        private void GenerateLiquidation(ConsortiumResponse dto)
        {
            var consortium = GenerateConsortium(dto);

            using var form = new LiquidationForm(_liquidationService, consortium);
            
            var parent = this.FindForm() as FormMain;
            parent?.ShowModalWithOverlay(form);
        }

        private async Task DownloadReportAsync(ConsortiumResponse dto)
        {
            var consortium = GenerateConsortium(dto);

            var list = await _liquidationService.GetAllByConsortiumIdAsync(consortium.Id);

            using var form = new ReportDownloadForm(list, _reportService, consortium);

            var parent = this.FindForm() as FormMain;
            parent?.ShowModalWithOverlay(form);
        }

        private Consortium GenerateConsortium(ConsortiumResponse dto)
        {
            return new Consortium
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address
            };
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OpenConsortiumForm(null);
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            _ = LoadDataAsync(); 
        }

    }
}
