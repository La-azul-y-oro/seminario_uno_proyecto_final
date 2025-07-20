using desktop_app.dto;
using desktop_app.models;
using desktop_app.services;
using desktop_app.supplier;

namespace desktop_app.supplier
{
    public partial class SupplierControl : UserControl
    {
        protected readonly ApiService? _apiService;
        private List<ConceptResponse> _concepts;

        public SupplierControl(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;

            LoadDataAsync();
            GetAllConcepts();

            dgvEntity.CellContentClick += dgvEntity_CellContentClick;
        }

        private async Task LoadDataAsync()
        {
            var suppliers = await GetAll();

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
                DataPropertyName = "Cuit",
                HeaderText = "Cuit",
                Name = "colCuit",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Teléfono",
                Name = "colPhone",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "colEmail",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCategorias",
                HeaderText = "Categorías",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            AddActionButtons();

            dgvEntity.CellFormatting += (s, e) =>
            {
                if (dgvEntity.Columns[e.ColumnIndex].Name == "colCategorias")
                {
                    var supplier = dgvEntity.Rows[e.RowIndex].DataBoundItem as SupplierResponse;
                    if (supplier?.Concepts != null)
                    {
                        e.Value = string.Join(", ", supplier.Concepts.Select(c => c.Name));
                    }
                }
            };

            SetTableStyle();

            dgvEntity.DataSource = suppliers;
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

        private async Task<List<SupplierResponse>> GetAll()
        {
            try
            {
                return await _apiService.GetAllAsync<SupplierResponse>("supplier");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
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

        private void OpenSupplierForm(SupplierResponse? dto)
        {
            var supplierToProcess = (dto != null) ? dto : null;

            using var form = new SupplierForm(_apiService, _concepts, supplierToProcess);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadDataAsync();
            }
        }


        private async void DeleteSelectedSupplier(SupplierResponse supplier)
        {
            var confirm = MessageBox.Show($"¿Está seguro de eliminar este registro? ({supplier.Name})", "Confirmación", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                await _apiService.DeleteAsync("supplier", supplier.Id);
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
            var supplier = row.DataBoundItem as SupplierResponse;
            if (supplier == null) return;

            switch (columnName)
            {
                case "btnEdit":
                    OpenSupplierForm(supplier);
                    break;

                case "btnRemove":
                    DeleteSelectedSupplier(supplier);
                    break;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OpenSupplierForm(null);
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            LoadDataAsync();
        }
    }
}
