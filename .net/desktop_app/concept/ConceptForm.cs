using desktop_app.services;
using desktop_app.models;

namespace desktop_app.concept
{
    public partial class ConceptForm : Form
    {
        private readonly ApiService _apiService;
        private readonly Concept? _concept;

        public ConceptForm(ApiService apiService, Concept? concept = null)
        {
            InitializeComponent();
            InitTypes();

            _apiService = apiService;
            _concept = concept;

            if (_concept != null)
            {
                labelForm.Text = "Actualizar Concepto";
                btnAccept.Text = "Actualizar";
                txtName.Text = _concept.Name;
                comboType.SelectedItem = _concept.Type;
            }
        }

        private void InitTypes()
        {
            comboType.DataSource = Enum.GetValues(typeof(MovementType));
            comboType.SelectedIndex = -1;
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            MovementType Type = (MovementType) comboType.SelectedItem;
             
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Type.ToString()))
            {
                MessageBox.Show("Por favor complete correctamente todos los campos", "Concepto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var newConcept = new Concept
                {
                    Name = Name,
                    Type = Type,
                    Active = true
                };

                if (_concept == null)
                {
                    await _apiService.PostAsync("concept", newConcept);
                }
                else
                {
                    await _apiService.PutAsync($"concept", _concept.Id, newConcept);
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
