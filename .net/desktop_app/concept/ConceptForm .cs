using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using desktop_app.services;
using System.Xml.Linq;
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

            _apiService = apiService;
            _concept = concept;

            if (_concept != null)
            {
                labelForm.Text = "Actualizar Concepto";
                btnAccept.Text = "Actualizar";
                txtName.Text = _concept.Name;
            }
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                var newConcept = new Concept
                {
                    Name = txtName.Text,
                    Active = true,
                };

                if (_concept == null)
                {
                    await _apiService.PostAsync("concept", newConcept);
                }
                else
                {
                    await _apiService.PutAsync($"concept",_concept.Id, newConcept);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
