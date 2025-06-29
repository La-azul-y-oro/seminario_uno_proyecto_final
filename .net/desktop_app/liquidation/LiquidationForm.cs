using desktop_app.services;
using desktop_app.dto;
using desktop_app.models;
using System.Windows.Forms;

namespace desktop_app.liquidation
{
    public partial class LiquidationForm : Form
    {
        private readonly LiquidationService _liquidationService;
        private readonly Consortium _consortium;

        public LiquidationForm(LiquidationService liquidationService, Consortium consortium)
        {
            InitializeComponent();

            _liquidationService = liquidationService;
            _consortium = consortium;

            labelForm.Text = "Generar liquidación";
            btnAccept.Text = "Generar";
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            string period = periodPicker.Text;
            string expiredDate = expirationDatePicker.Text;

            if (string.IsNullOrWhiteSpace(period) || string.IsNullOrWhiteSpace(expiredDate))
            {
                MessageBox.Show("Por favor complete los datos correctamente", "Consortiumo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var liquidationRequest = new LiquidationRequest();
                liquidationRequest.ConsortiumId = _consortium.Id;
                liquidationRequest.Month = periodPicker.Value.Month;
                liquidationRequest.Year = periodPicker.Value.Year;
                liquidationRequest.ExpirationDate = expirationDatePicker.Value.Date;

                await _liquidationService.GenerateLiquidationAsync(liquidationRequest);

                MessageBox.Show("Liquidación generada con éxito");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void LiquidationForm_Load(object sender, EventArgs e)
        {
            periodPicker.Format = DateTimePickerFormat.Custom;
            periodPicker.CustomFormat = "MMMM yyyy";
            periodPicker.ShowUpDown = true;
            periodPicker.MaxDate = DateTime.Today;
            periodPicker.Value = DateTime.Today;

            expirationDatePicker.Format = DateTimePickerFormat.Short;
            expirationDatePicker.MinDate = DateTime.Today.AddDays(1);
            expirationDatePicker.Value = DateTime.Today.AddDays(1);
        }
    }
}
