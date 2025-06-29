using desktop_app.models;
using desktop_app.services;
using desktop_app.views;

namespace desktop_app.functional_unit
{
    public partial class FunctionalUnitControl : BaseUserControl
    {
        public FunctionalUnitControl(ApiService apiService) : base(apiService)
        {
            InitializeComponent();
  
                NewClicked += (s, e) => OpenFunctionalUnitForm(null);
                EditClicked += (s, e) => EditSelectedFunctionalUnit();
                DeleteClicked += (s, e) => DeleteSelectedFunctionalUnit();
                UpdateListClicked += async (s, e) => await LoadDataAsync();
                setLabelEntity("UNIDADES FUNCIONALES");
        }

        public override async void LoadData()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var units = await GetAll();

            var filtered = units
                .Where(u => u.Active)
                .Select(u => new FunctionalUnitView
                {
                    Id = u.Id,
                    Name = u.Name,
                    Balance = u.Balance,
                    Factor = u.Factor,
                    Consortium = u.Consortium?.Name ?? "Sin nombre",
                    ConsortiumId = u.ConsortiumId
                })
                .ToList();

            dgvEntity.DataSource = filtered;
            dgvEntity.Columns["ConsortiumId"].Visible = false;
        }

        private async Task<List<FunctionalUnit>> GetAll()
        {
            try
            {
                return await _apiService.GetAllAsync<FunctionalUnit>("functionalunit");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
        }

        private void OpenFunctionalUnitForm(FunctionalUnitView? functionalUnit)
        {
            using var form = new FunctionalUnitForm(_apiService, functionalUnit);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void EditSelectedFunctionalUnit()
        {
            if (dgvEntity.SelectedRows.Count > 0)
            {
                var functionalUnit = (FunctionalUnitView) dgvEntity.SelectedRows[0].DataBoundItem;
                OpenFunctionalUnitForm(functionalUnit);
            }
            else
            {
                MessageBox.Show("Seleccione un registro para editar.");
            }
        }

        private async void DeleteSelectedFunctionalUnit()
        {
            if (dgvEntity.SelectedRows.Count > 0)
            {
                var functionalUnit = (FunctionalUnitView) dgvEntity.SelectedRows[0].DataBoundItem;

                var confirm = MessageBox.Show($"¿Está seguro de eliminar este registro? ({functionalUnit.Name} - {functionalUnit.Consortium})", "Confirmación", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    await _apiService.DeleteAsync("functionalunit", functionalUnit.Id);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
            }
        }

    }

}
