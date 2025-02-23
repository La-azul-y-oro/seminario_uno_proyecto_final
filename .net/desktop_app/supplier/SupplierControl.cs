using desktop_app.models;
using desktop_app.services;

namespace desktop_app.supplier
{
    public partial class SupplierControl : BaseUserControl
    {
        public SupplierControl(ApiService apiService) : base(apiService)
        {
            InitializeComponent();
  
                NewClicked += (s, e) => OpenSupplierForm(null);
                EditClicked += (s, e) => EditSelectedSupplier();
                DeleteClicked += (s, e) => DeleteSelectedSupplier();
                UpdateListClicked += async (s, e) => await LoadDataAsync();
                setLabelEntity("PROVEEDORES");
        }

        public override async void LoadData()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            dgvEntity.DataSource = await GetAll();
        }

        private async Task<List<Supplier>> GetAll()
        {
            try
            {
                return await _apiService.GetAllAsync<Supplier>("supplier");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
        }

        private void OpenSupplierForm(Supplier? supplier)
        {
            using var form = new SupplierForm(_apiService, supplier);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void EditSelectedSupplier()
        {
            if (dgvEntity.SelectedRows.Count > 0)
            {
                var supplier = (Supplier)dgvEntity.SelectedRows[0].DataBoundItem;
                OpenSupplierForm(supplier);
            }
            else
            {
                MessageBox.Show("Seleccione un registro para editar.");
            }
        }

        private async void DeleteSelectedSupplier()
        {
            if (dgvEntity.SelectedRows.Count > 0)
            {
                var supplier = (Supplier)dgvEntity.SelectedRows[0].DataBoundItem;

                var confirm = MessageBox.Show($"¿Está seguro de eliminar este registro? ({supplier.Name})", "Confirmación", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    await _apiService.DeleteAsync("supplier", supplier.Id);
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
