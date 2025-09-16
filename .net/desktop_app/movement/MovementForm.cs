using desktop_app.services;
using desktop_app.models;
using desktop_app.dto;

namespace desktop_app.movement
{
    public partial class MovementForm : Form
    {
        private readonly ApiService _apiService;
        private readonly MovementResponse? _movement;
        private readonly List<ConceptResponse> _concepts;
        private readonly List<ConsortiumResponse> _consortiums;
        private readonly List<FunctionalUnitResponse> _functionalUnits;
        private readonly List<SupplierResponse> _suppliers;

        public MovementForm(ApiService apiService, List<ConceptResponse> concepts, List<ConsortiumResponse> consortiums,
            List<FunctionalUnitResponse> functionalUnits, List<SupplierResponse> suppliers, MovementResponse? movement = null)
        {
            InitializeComponent();

            _apiService = apiService;
            _movement = movement;
            _concepts = concepts;
            _consortiums = consortiums;
            _functionalUnits = functionalUnits;
            _suppliers = suppliers;

            InitConsortiums();
            InitFunctionalUnits();
            InitSuppliers();
            InitConcepts();
            InitTypes();

            if (_movement != null)
            {
                LoadMovement();               
            }
        }

        private void InitConcepts()
        {
            comboConcept.DataSource = _concepts;
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

        private void InitFunctionalUnits()
        {
            comboFU.DataSource = _functionalUnits;
            comboFU.DisplayMember = "Name";
            comboFU.ValueMember = "Id";
            comboFU.SelectedIndex = -1;
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

        private void LoadMovement()
        {
            labelForm.Text = "Actualizar Movimiento";
            btnAccept.Text = "Actualizar";

            dateTimePicker1.Value = _movement.Date;
            txtAmount.Text = _movement.Amount.ToString();
            txtComment.Text = _movement.Comment;
            txtReceipt.Text = _movement.Receipt;

            comboType.SelectedItem = _movement.Type;
            comboConsortium.SelectedValue = _movement.ConsortiumId;
            comboFU.SelectedValue = _movement.FunctionalUnitId;
            comboSupplier.SelectedValue = _movement.SupplierId;
            comboConcept.SelectedValue = _movement.ConceptId;
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            bool isAmountValid = decimal.TryParse(txtAmount.Text, out decimal amount);
            bool isTypeSelected = comboType.SelectedItem != null;
            bool isConsortiumSelected = comboConsortium.SelectedValue != null;
            bool isFunctionalUnitSelected = comboFU.SelectedValue != null;
            bool isSupplierSelected = comboSupplier.SelectedValue != null;
            bool isConceptSelected = comboConcept.SelectedValue != null;

            if (!isAmountValid || !isTypeSelected || !isConsortiumSelected ||
                !isFunctionalUnitSelected || !isSupplierSelected || !isConceptSelected)
            {
                MessageBox.Show("Complete correctamente los campos",
                                "Movimiento",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newMovement = new MovementRequest
                {
                    Date = dateTimePicker1.Value,
                    Amount = amount,
                    Comment = txtComment.Text,
                    Receipt = txtReceipt.Text,
                    Type = (MovementType)comboType.SelectedItem,
                    ConsortiumId = (int)comboConsortium.SelectedValue,
                    FunctionalUnitId = (int)comboFU.SelectedValue,
                    SupplierId = (int)comboSupplier.SelectedValue,
                    ConceptId = (int)comboConcept.SelectedValue,
                    Active = true
                };

                if (_movement == null)
                {
                    await _apiService.PostAsync("movement", newMovement);
                }
                else
                {
                    await _apiService.PutAsync("movement", _movement.Id, newMovement);
                }

                MessageBox.Show("Movimiento guardado con éxito");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
