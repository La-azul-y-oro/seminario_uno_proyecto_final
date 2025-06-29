using desktop_app.liquidation;
using desktop_app.models;
using desktop_app.report;
using desktop_app.services;

namespace desktop_app.consortium
{
    public partial class ConsortiumControl : BaseUserControl
    {
        private readonly LiquidationService _liquidationService;
        private readonly ReportService _reportService;
        public ConsortiumControl(ApiService apiService, LiquidationService liquidationService, ReportService reportService) : base(apiService)
        {
            InitializeComponent();
            _liquidationService = liquidationService;
            _reportService = reportService;

            NewClicked += (s, e) => OpenConsortiumForm(null);
            EditClicked += (s, e) => EditSelectedConsortium();
            DeleteClicked += (s, e) => DeleteSelectedConsortium();
            UpdateListClicked += async (s, e) => await LoadDataAsync();
            setLabelEntity("CONSORCIOS");

            dgvEntity.CellContentClick += dgvEntity_CellContentClick;
        }

        public override async void LoadData()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            dgvEntity.DataSource = await GetAll();
            AddActionButtons();
        }

        private async Task<List<Consortium>> GetAll()
        {
            try
            {
                return await _apiService.GetAllAsync<Consortium>("consortium");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
        }

        private void OpenConsortiumForm(Consortium? consortium)
        {
            using var form = new ConsortiumForm(_apiService, consortium);
            
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void EditSelectedConsortium()
        {
            if (dgvEntity.SelectedRows.Count > 0)
            {
                var consortium = (Consortium)dgvEntity.SelectedRows[0].DataBoundItem;
                OpenConsortiumForm(consortium);
            }
            else
            {
                MessageBox.Show("Seleccione un registro para editar.");
            }
        }

        private async void DeleteSelectedConsortium()
        {
            if (dgvEntity.SelectedRows.Count > 0)
            {
                var consortium = (Consortium)dgvEntity.SelectedRows[0].DataBoundItem;

                var confirm = MessageBox.Show($"¿Está seguro de eliminar este registro? ({consortium.Name})", "Confirmación", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    await _apiService.DeleteAsync("consortium", consortium.Id);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
            }
        }

        private void AddActionButtons()
        {
            // Verificá que no estén ya agregadas
            if (dgvEntity.Columns["btnLiquidar"] != null) return;

            var btnLiquidar = new DataGridViewButtonColumn
            {
                Name = "btnLiquidar",
                HeaderText = "Liquidación",
                Text = "Generar",
                UseColumnTextForButtonValue = true
            };

            var btnDescargar = new DataGridViewButtonColumn
            {
                Name = "btnDescargar",
                HeaderText = "Reportes",
                Text = "Descargar",
                UseColumnTextForButtonValue = true
            };

            var btnUnidades = new DataGridViewButtonColumn
            {
                Name = "btnUnidades",
                HeaderText = "Unidades",
                Text = "Gestionar",
                UseColumnTextForButtonValue = true
            };

            dgvEntity.Columns.Add(btnLiquidar);
            dgvEntity.Columns.Add(btnDescargar);
            dgvEntity.Columns.Add(btnUnidades);
        }

        private void dgvEntity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var columnName = dgvEntity.Columns[e.ColumnIndex].Name;
            var rowData = (Consortium)dgvEntity.Rows[e.RowIndex].DataBoundItem;

            switch (columnName)
            {
                case "btnLiquidar":
                    GenerateLiquidation(rowData);
                    break;

                case "btnDescargar":
                    DownloadReportAsync(rowData);
                    break;

                case "btnUnidades":
                    ManageFunctionalUnits(rowData);
                    break;
            }
        }

        private void GenerateLiquidation(Consortium consorcio)
        {
            using var form = new LiquidationForm(_liquidationService, consorcio);
            form.ShowDialog();
        }

        private async Task DownloadReportAsync(Consortium consorcio)
        {
            var list = await _liquidationService.GetAllByConsortiumIdAsync(consorcio.Id);

            using var form = new ReportDownloadForm(list, _reportService, consorcio);

            form.ShowDialog();
        }

        private void ManageFunctionalUnits(Consortium consorcio)
        {
            MessageBox.Show($"Abrir unidades funcionales de {consorcio.Name}");
        }


    }

}
