using desktop_app.dto;
using desktop_app.models;
using desktop_app.services;

namespace desktop_app.concept
{
    public partial class ConceptControl : UserControl
    {
        protected readonly ApiService? _apiService;
        private List<ConceptResponse> _concepts;

        public ConceptControl(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;

            LoadDataAsync();

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
                DataPropertyName = "Type",
                HeaderText = "Tipo",
                Name = "colTipo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            AddActionButtons();

            SetTableStyle();

            dgvEntity.DataSource = suppliers;
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

        private async Task<List<Concept>> GetAll()
        {
            try
            {
                return await _apiService.GetAllAsync<Concept>("concept");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
        }

        private void OpenConceptForm(Concept? concept)
        {
            var conceptToProcess = (concept != null) ? concept : null;

            using var form = new ConceptForm(_apiService, conceptToProcess);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadDataAsync();
            }
        }


        private async void DeleteSelectedConcept(Concept concept)
        {
            var confirm = MessageBox.Show($"¿Está seguro de eliminar este registro? ({concept.Name})", "Confirmación", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                await _apiService.DeleteAsync("concept", concept.Id);
                LoadDataAsync();
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
            var concept = row.DataBoundItem as Concept;
            if (concept == null) return;

            switch (columnName)
            {
                case "btnRemove":
                    DeleteSelectedConcept(concept);
                    break;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OpenConceptForm(null);
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            LoadDataAsync();
        }
    }
}
