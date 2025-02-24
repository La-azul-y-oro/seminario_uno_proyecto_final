using desktop_app.models;
using desktop_app.services;

namespace desktop_app.consortium
{
    public partial class ConsortiumControl : BaseUserControl
    {
        public ConsortiumControl(ApiService apiService) : base(apiService)
        {
            InitializeComponent();
            NewClicked += (s, e) => OpenConsortiumForm(null);
            EditClicked += (s, e) => EditSelectedConsortium();
            DeleteClicked += (s, e) => DeleteSelectedConsortium();
            UpdateListClicked += async (s, e) => await LoadDataAsync();
            setLabelEntity("CONSORCIOS");
        }

        public override async void LoadData()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            dgvEntity.DataSource = await GetAll();
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

    }

}
