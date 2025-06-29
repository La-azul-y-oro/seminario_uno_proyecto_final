using System.Collections.Generic;
using System.Linq;
using desktop_app.models;
using desktop_app.services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace desktop_app.report
{
    public partial class ReportDownloadForm : Form
    {
        private readonly List<Liquidation> _liquidationList;
        private readonly ReportService _reportService;
        private readonly Consortium _consortium;

        public ReportDownloadForm(List<Liquidation> liquidationList, ReportService reportService, Consortium consortium)
        {
            _liquidationList = liquidationList;
            _reportService = reportService;
            _consortium = consortium;

            InitializeComponent();
            InitStep1();
        }

        private void InitStep1()
        {
            nextButton.Enabled = false;
            downloadButton.Enabled = false;

            comboBoxTipo.Items.Clear();
            comboBoxTipo.Items.Add("Financiero");
            comboBoxTipo.Items.Add("Expensas");

            panelFinanciero.Visible = false;
            panelExpensas.Visible = false;

            periodPicker.Format = DateTimePickerFormat.Custom;
            periodPicker.CustomFormat = "MM/yyyy";
            periodPicker.ShowUpDown = true;
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            panelSelectType.Visible = false;

            if (comboBoxTipo.SelectedItem?.ToString() == "Financiero")
            {
                panelFinanciero.Visible = true;
                nextButton.Enabled = false;
                downloadButton.Enabled = true;
            }
            else
            {
                nextButton.Enabled = false;
                downloadButton.Enabled = true;
                panelExpensas.Visible = true;
                LoadExpensasRadioButtons();
            }
        }


        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            nextButton.Enabled = comboBoxTipo.SelectedIndex >= 0;
        }

        private void checkYear_CheckedChanged(object sender, EventArgs e)
        {
            if (checkYear.Checked)
            {
                periodPicker.CustomFormat = "yyyy";
            }
            else
            {
                periodPicker.CustomFormat = "MM/yyyy";
            }
        }

        private void LoadExpensasRadioButtons()
        {
            flowLayoutPanelExpenses.Controls.Clear();

            if (_liquidationList.Count == 0)
            {
                labelNoExpenses.Visible = true;
                return;
            }

            labelNoExpenses.Visible = false;

            foreach (var exp in _liquidationList)
            {
                var radio = new RadioButton
                {
                    Text = $"{exp.Period}",
                    AutoSize = true,
                    Tag = exp
                };

                flowLayoutPanelExpenses.Controls.Add(radio);
            }

            if (flowLayoutPanelExpenses.Controls.Count > 0 && flowLayoutPanelExpenses.Controls[0] is RadioButton firstRadio)
            {
                firstRadio.Checked = true;
            }
        }

        private async void downloadButton_Click(object sender, EventArgs e)
        {
            downloadButton.Enabled = false;
            downloadButton.Text = "Descargando...";
            try
            {
                var selectedType = comboBoxTipo.SelectedItem?.ToString();

                if (selectedType == "Financiero")
                {
                    string format = buttonPDF.Checked ? "PDF" : "EXCEL";

                    int year = periodPicker.Value.Year;
                    int? month = checkYear.Checked ? null : periodPicker.Value.Month;

                    var bytes = await _reportService.GetFinancialReportAsync(_consortium.Id, year, format, month);
                    
                    string filename = "reporte_financiero_";

                    if (month != null)
                    {
                        filename += $"{month}_";
                    }

                    filename += $"{year}";

                    SaveFile(filename, format, bytes);
                }
                else if (selectedType == "Expensas")
                {
                    var selectedRadio = flowLayoutPanelExpenses.Controls
                        .OfType<RadioButton>()
                        .FirstOrDefault(r => r.Checked);

                    if (selectedRadio?.Tag is not Liquidation selectedExpensa)
                    {
                        MessageBox.Show("Debe seleccionar una liquidación.");
                        return;
                    }

                    var date = DateTime.ParseExact(selectedExpensa.Period, "yyyy-MM", null);
                    var bytes = await _reportService.GetExpenseReportAsync(_consortium.Id, date.Year, date.Month);

                    string filename = $"liquidacion_expensas_{date.Month}_{date.Year}";

                    SaveFile(filename, "PDF", bytes);
                }

                MessageBox.Show("Archivo descargado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al descargar el reporte:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveFile(string baseName, string format, byte[] content)
        {
            var extension = format.ToLower() == "pdf" ? "pdf" : "xlsx";

            using var dialog = new SaveFileDialog
            {
                FileName = $"{baseName}.{extension}",
                Filter = extension.ToUpper() == "PDF" ? "PDF Files|*.pdf" : "Excel Files|*.xlsx"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(dialog.FileName, content);
            }
        }

    }
}
