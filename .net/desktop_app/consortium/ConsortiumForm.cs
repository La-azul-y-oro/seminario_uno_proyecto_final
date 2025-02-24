using desktop_app.services;
using desktop_app.models;

namespace desktop_app.consortium
{
    public partial class ConsortiumForm : Form
    {
        private readonly ApiService _apiService;
        private readonly Consortium? _consortium;

        public ConsortiumForm(ApiService apiService, Consortium? consortium = null)
        {
            InitializeComponent();

            _apiService = apiService;
            _consortium = consortium;

            if (_consortium != null)
            {
                labelForm.Text = "Actualizar Consorcio";
                btnAccept.Text = "Actualizar";
                txtName.Text = _consortium.Name;
                txtAddress.Text = _consortium.Address;
            }
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string Address = txtAddress.Text;

            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Por favor complete los datos correctamente", "Consortiumo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var newConsortium = new Consortium
                {
                    Name = Name,
                    Address = Address,
                    Active = true,
                };

                if (_consortium == null)
                {
                    await _apiService.PostAsync("consortium", newConsortium);
                }
                else
                {
                    await _apiService.PutAsync($"consortium", _consortium.Id, newConsortium);
                }

                MessageBox.Show("Guardado con éxito");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
