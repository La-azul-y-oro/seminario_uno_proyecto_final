using desktop_app.services;
using desktop_app.models;

namespace desktop_app.supplier
{
    public partial class SupplierForm : Form
    {
        private readonly ApiService _apiService;
        private readonly Supplier? _supplier;

        public SupplierForm(ApiService apiService, Supplier? supplier = null)
        {
            InitializeComponent();

            _apiService = apiService;
            _supplier = supplier;

            if (_supplier != null)
            {
                labelForm.Text = "Actualizar Supplier";
                btnAccept.Text = "Actualizar";
                txtName.Text = _supplier.Name;
                txtCUIT.Text = _supplier.Cuit.ToString();
                txtPhone.Text = _supplier.Phone;
                txtMail.Text = _supplier.Email;
            }
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string Cuit = txtCUIT.Text;
            string Phone = txtPhone.Text;
            string Email = txtMail.Text;

            bool isNameValid = !string.IsNullOrWhiteSpace(Name);
            bool isCuitValid = !string.IsNullOrWhiteSpace(Cuit) && Cuit.All(char.IsDigit) && Cuit.Length == 11;
            bool isPhoneValid = !string.IsNullOrWhiteSpace(Phone) && Phone.All(char.IsDigit);
            bool isEmailValid = !string.IsNullOrWhiteSpace(Email);


            if (!isNameValid || !isCuitValid || !isPhoneValid || !isEmailValid)
            {
                MessageBox.Show("Complete correctamente los campos", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var newSupplier = new Supplier
                {
                    Name = Name,
                    Cuit = long.Parse(Cuit),
                    Phone = Phone,
                    Email = Email,
                    Active = true,
                };

                if (_supplier == null)
                {
                    await _apiService.PostAsync("supplier", newSupplier);
                }
                else
                {
                    await _apiService.PutAsync($"supplier", _supplier.Id, newSupplier);
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
