using desktop_app.services;
using desktop_app.models;
using desktop_app.dto;

namespace desktop_app.supplier
{
    public partial class SupplierForm : Form
    {
        private readonly ApiService _apiService;
        private readonly SupplierResponse? _supplier;
        private readonly List<ConceptResponse> _concepts;

        public SupplierForm(ApiService apiService, List<ConceptResponse> concepts, SupplierResponse? supplier = null)
        {
            InitializeComponent();

            _apiService = apiService;
            _supplier = supplier;
            _concepts = concepts;

            InitConcepts();
            
            if (_supplier != null)
            {
                labelForm.Text = "Actualizar Supplier";
                btnAccept.Text = "Actualizar";
                txtName.Text = _supplier.Name;
                txtCUIT.Text = _supplier.Cuit.ToString();
                txtPhone.Text = _supplier.Phone;
                txtMail.Text = _supplier.Email;
                if (_supplier.Concepts != null)
                {
                    for (int i = 0; i < checkedConcepts.Items.Count; i++)
                    {
                        var item = (ConceptResponse)checkedConcepts.Items[i];
                        if (_supplier.Concepts.Any(c => c.Id == item.Id))
                        {
                            checkedConcepts.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        private void InitConcepts() {
            checkedConcepts.Items.Clear();
            foreach (var concept in _concepts)
            {
                checkedConcepts.Items.Add(concept, false);
            }
            checkedConcepts.DisplayMember = "Name";
            checkedConcepts.ValueMember = "Id";
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
            bool hasSelectedConcepts = checkedConcepts.CheckedItems.Count > 0;

            if (!isNameValid || !isCuitValid || !isPhoneValid || !isEmailValid || !hasSelectedConcepts)
            {
                MessageBox.Show("Complete correctamente los campos", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var selectedConceptIds = checkedConcepts.CheckedItems
                        .Cast<ConceptResponse>()
                        .Select(c => c.Id)
                        .ToList();

                var newSupplier = new SupplierRequest
                {
                    Name = Name,
                    Cuit = long.Parse(Cuit),
                    Phone = Phone,
                    Email = Email,
                    ConceptIds = selectedConceptIds
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
