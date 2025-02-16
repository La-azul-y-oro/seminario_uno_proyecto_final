using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using desktop_app.concept;
using desktop_app.models;
using desktop_app.services;

namespace desktop_app
{
    public partial class ConceptControl : BaseUserControl
    {
        public ConceptControl(ApiService apiService) : base(apiService)
        {
            InitializeComponent();
            NewClicked += (s, e) => OpenConceptForm(null);
            EditClicked += (s, e) => EditSelectedConcept();
            DeleteClicked += (s, e) => DeleteSelectedConcept();
            UpdateListClicked += async (s, e) => await LoadDataAsync();
        }

        public override async void LoadData()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            dgvEntity.DataSource = await getAll();
        }

        private async Task<List<Concept>> getAll()
        {
            try
            {
                return await _apiService.GetAllAsync<Concept>("concept");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Concept>();
            }
        }

        private void OpenConceptForm(Concept? concept)
        {
            using (var form = new ConceptForm(_apiService, concept))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void EditSelectedConcept()
        {
            if (dgvEntity.SelectedRows.Count > 0)
            {
                var concept = (Concept)dgvEntity.SelectedRows[0].DataBoundItem;
                OpenConceptForm(concept);
            }
            else
            {
                MessageBox.Show("Seleccione un registro para editar.");
            }
        }

        private async void DeleteSelectedConcept()
        {
            if (dgvEntity.SelectedRows.Count > 0)
            {
                var concept = (Concept)dgvEntity.SelectedRows[0].DataBoundItem;

                var confirm = MessageBox.Show($"¿Está seguro de eliminar este registro? ({concept.Name})", "Confirmación", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    await _apiService.DeleteAsync("concept", concept.Id);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
            }
        }

    }

}
