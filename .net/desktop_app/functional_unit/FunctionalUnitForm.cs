using System.Xml.Linq;
using desktop_app.dto;
using desktop_app.models;
using desktop_app.services;
using desktop_app.views;

namespace desktop_app.functional_unit
{
    public partial class FunctionalUnitForm : Form
    {
        private readonly ApiService _apiService;
        private readonly FunctionalUnitView? _functionalUnit;

        public FunctionalUnitForm(ApiService apiService, FunctionalUnitView? functionalUnit = null)
        {
            InitializeComponent();

            _apiService = apiService;
            _functionalUnit = functionalUnit;

            if (_functionalUnit != null)
            {
                labelTitle.Text = "Actualizar Unidad Funcional";
                btnAccept.Text = "Actualizar";
                textName.Text = _functionalUnit.Name;
                textFactor.Text = _functionalUnit.Factor.ToString();
                consortiumBox.Enabled = false;
                consortiumBox.DataSource = new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(_functionalUnit.ConsortiumId, _functionalUnit.Consortium)
                };
                consortiumBox.DisplayMember = "Value";
                consortiumBox.ValueMember = "Key";
            }
            else
            {
                consortiumBox.DisplayMember = "Name";
                consortiumBox.ValueMember = "Id";
                LoadConsortiums();
            }
        }


        private async void LoadConsortiums()
        {
            try
            {
                var consortiums = await _apiService.GetAllAsync<Consortium>("consortium");
                consortiumBox.DataSource = consortiums;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar consorcios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
            string factorText = textFactor.Text;
            int consortiumId = (int)consortiumBox.SelectedValue;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(factorText))
            {
                MessageBox.Show("Por favor complete todos los datos", "Unidades Funcionales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(factorText, out decimal factor))
            {
                MessageBox.Show("El valor del factor no es válido", "Unidades Funcionales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var functionalUnit = new FunctionalUnitRequest
                {
                    Name = name,
                    Factor = factor,
                    ConsortiumId = consortiumId
                };

                if (_functionalUnit == null)
                {
                    await _apiService.PostAsync("functionalunit", functionalUnit);
                }
                else
                {
                    await _apiService.PutAsync("functionalunit", _functionalUnit.Id, functionalUnit);
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


        private void textFactor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            var textBox = sender as TextBox;
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (textBox?.Text.Contains(",") == true || textBox?.Text.Contains(".") == true))
            {
                e.Handled = true;
            }
        }
    }
}
