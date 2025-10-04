using desktop_app.services;
using desktop_app.models;
using desktop_app.dto;

namespace desktop_app.movement
{
    public partial class MovementForm : Form
    {
        private readonly ApiService _apiService;
        private readonly List<ConceptResponse> _concepts;
        private readonly List<ConsortiumResponse> _consortiums;
        private readonly List<SupplierResponse> _suppliers;
        private string lastSelectType;

        public MovementForm(ApiService apiService, List<ConceptResponse> concepts, List<ConsortiumResponse> consortiums,
            List<SupplierResponse> suppliers)
        {
            InitializeComponent();

            _apiService = apiService;
            _concepts = concepts;
            _consortiums = consortiums;
            _suppliers = suppliers;

            InitConsortiums();
            InitSuppliers();
            InitTypes();

            panelSecondary.Visible = false;
            this.ActiveControl = comboConsortium;
        }

        private void InitConcepts(string type)
        {
            comboConcept.DataSource = null;

            comboConcept.DataSource = _concepts.Where(c => c.Type.ToString().Equals(type)).ToList();
            comboConcept.DisplayMember = "Name";
            comboConcept.ValueMember = "Id";
            comboConcept.SelectedIndex = -1;
        }

        private void InitConsortiums()
        {
            comboConsortium.DataSource = _consortiums;
            comboConsortium.DisplayMember = "Name";
            comboConsortium.ValueMember = "Id";
            comboConsortium.SelectedIndex = -1;
        }

        private void InitFunctionalUnits(int consortiumId)
        {
            comboFU.DataSource = null;

            var consortium = _consortiums.FirstOrDefault(c => c.Id == consortiumId);

            if (consortium != null)
            {
                comboFU.DataSource = consortium.FunctionalUnits;
                comboFU.DisplayMember = "Name";
                comboFU.ValueMember = "Id";
                comboFU.SelectedIndex = -1;
            }
        }

        private void InitSuppliers()
        {
            comboSupplier.DataSource = _suppliers;
            comboSupplier.DisplayMember = "Name";
            comboSupplier.ValueMember = "Id";
            comboSupplier.SelectedIndex = -1;
        }

        private void InitTypes()
        {
            comboType.DataSource = Enum.GetValues(typeof(MovementType));
            comboType.SelectedIndex = -1;
        }

        private void comboConsortium_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerifiedFields();
            var selected = comboConsortium.SelectedItem;
            if(selected != null)
            {
                var consortium = (ConsortiumResponse) selected;
                InitFunctionalUnits(consortium.Id);
            }
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerifiedFields();
            var selected = comboType.SelectedItem?.ToString();
            if (lastSelectType != selected)
            {
                lastSelectType = selected;
                resetFormValues();
            }


            if (selected == "EGRESO")
            {
                comboSupplier.Visible = true;
                labelSupplier.Visible = true;

                comboFU.Visible = false;
                labelFU.Visible = false;

                InitConcepts("EGRESO");
            }
            else if (selected == "INGRESO")
            {
                comboSupplier.Visible = false;
                labelSupplier.Visible = false;

                comboFU.Visible = true;
                labelFU.Visible = true;
                InitConcepts("INGRESO");
            }
            else
            {
                comboSupplier.Visible = false;
                labelSupplier.Visible = false;
                comboFU.Visible = false;
                labelFU.Visible = false;
            }
        }

        private void VerifiedFields()
        {
            bool consortiumSelected = comboConsortium.SelectedIndex >= 0;
            bool typeSelected = comboType.SelectedIndex >= 0;

            panelSecondary.Visible = consortiumSelected && typeSelected;
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            var typeSelected = comboType.SelectedItem?.ToString();

            bool isAmountValid = decimal.TryParse(txtAmount.Text, out decimal amount);
            bool isConsortiumSelected = comboConsortium.SelectedValue != null;
            bool isFunctionalUnitSelected = comboFU.SelectedValue != null;
            bool isSupplierSelected = comboSupplier.SelectedValue != null;
            bool isConceptSelected = comboConcept.SelectedValue != null;
            bool isDescriptionValid = !string.IsNullOrWhiteSpace(txtComment.Text);

            if (typeSelected == "EGRESO")
            {
                if (!isAmountValid || !isConsortiumSelected || !isSupplierSelected || !isConceptSelected || !isDescriptionValid)
                {
                    MessageBox.Show("Complete correctamente los campos",
                                    "Movimiento",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (!isAmountValid || !isConsortiumSelected || !isFunctionalUnitSelected || !isConceptSelected || !isDescriptionValid)
                {
                    MessageBox.Show("Complete correctamente los campos",
                                    "Movimiento",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
            }

            var confirmResult = MessageBox.Show(
                "El movimiento no podrá ser editado, solo eliminado por un administrador siempre y cuando no sea un EGRESO vinculado a un período liquidado. ¿Desea continuar?",
                "Confirmar acción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (confirmResult == DialogResult.No)
                return;

            try
            {
                var newMovement = new MovementRequest
                {
                    Date = datePicker.Value,
                    Amount = amount,
                    Comment = txtComment.Text,
                    Receipt = txtReceipt.Text,
                    Type = (MovementType)comboType.SelectedItem,
                    ConsortiumId = (int)comboConsortium.SelectedValue,
                    FunctionalUnitId = (typeSelected == "EGRESO") ? null : (int)comboFU.SelectedValue,
                    SupplierId = (typeSelected == "EGRESO") ? (int)comboSupplier.SelectedValue : null,
                    ConceptId = (int)comboConcept.SelectedValue,
                    Active = true
                };

                await _apiService.PostAsync("movement", newMovement);

                MessageBox.Show("Movimiento guardado con éxito");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                MessageBox.Show(
                    "No se permiten procesar movimientos para un periodo ya liquidado.",
                    "Ha ocurrido un error al guardar el movimiento.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetFormValues()
        {
            comboConcept.SelectedIndex = -1;
            comboSupplier.SelectedIndex = -1;
            comboFU.SelectedIndex = -1;
            datePicker.Value = DateTime.Today;
            txtAmount.Clear();
            txtComment.Clear();
            txtReceipt.Clear();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = Convert.ToChar(
                System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
            );

            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == decimalSeparator && !((TextBox)sender).Text.Contains(decimalSeparator))
                return;

            e.Handled = true;
        }
    }
}
