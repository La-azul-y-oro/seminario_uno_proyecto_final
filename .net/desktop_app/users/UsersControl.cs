using desktop_app.dto;
using desktop_app.models;
using desktop_app.services;
using desktop_app.supplier;
using PracticaSeminario;

namespace desktop_app.users
{
    public partial class UsersControl : UserControl
    {
        protected readonly ApiService? _apiService;

        public UsersControl(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;

            LoadDataAsync();

            dgvEntity.CellContentClick += dgvEntity_CellContentClick;
        }

        private async Task LoadDataAsync()
        {
            var users = await GetAll();

            dgvEntity.DataSource = null;
            dgvEntity.AutoGenerateColumns = false;

            dgvEntity.Columns.Clear();

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "Nombre",
                Name = "colNombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Apellido",
                Name = "colApellido",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DocumentNumber",
                HeaderText = "Documento",
                Name = "colDocumento",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "colEmail",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Teléfono",
                Name = "colTelefono",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEntity.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Role",
                HeaderText = "Rol",
                Name = "colRol",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });


            AddActionButtons();

            SetTableStyle();

            dgvEntity.DataSource = users;
        }

        private void SetTableStyle()
        {
            dgvEntity.EnableHeadersVisualStyles = false;
            dgvEntity.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvEntity.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvEntity.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            dgvEntity.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgvEntity.DefaultCellStyle.Font = new Font("Segoe UI Semilight", 11);
        }

        private async Task<List<UserResponse>> GetAll()
        {
            try
            {
                return await _apiService.GetAllAsync<UserResponse>("user");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
        }

        private void OpenUsersForm(UserResponse? dto)
        {
            var userToProcess = (dto != null) ? dto : null;

            using var form = new UsersForm(_apiService, userToProcess);

            var parent = this.FindForm() as FormMain;

            if (parent != null)
            {
                var result = parent.ShowModalWithOverlay(form);
                if (result == DialogResult.OK)
                {
                    LoadDataAsync();
                }
            }
        }


        private async void DeleteSelectedUser(UserResponse user)
        {
            var confirm = MessageBox.Show($"¿Está seguro de eliminar este registro? ({user.FirstName}) ({user.LastName})", "Confirmación", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                await _apiService.DeleteAsync("user", user.Id);
                LoadDataAsync();
            }
        }

        private void AddActionButtons()
        {
            if (dgvEntity.Columns["btnEdit"] != null) return;

            var btnEdit = new DataGridViewButtonColumn
            {
                Name = "btnEdit",
                HeaderText = "",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                Width = 120
            };

            var btnRemove = new DataGridViewButtonColumn
            {
                Name = "btnRemove",
                HeaderText = "",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                Width = 120
            };

            dgvEntity.Columns.Add(btnEdit);
            dgvEntity.Columns.Add(btnRemove);
        }

        private void dgvEntity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columnName = dgvEntity.Columns[e.ColumnIndex].Name;
            var row = dgvEntity.Rows[e.RowIndex];
            var user = row.DataBoundItem as UserResponse;
            if (user == null) return;

            switch (columnName)
            {
                case "btnEdit":
                    OpenUsersForm(user);
                    break;

                case "btnRemove":
                    DeleteSelectedUser(user);
                    break;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OpenUsersForm(null);
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            LoadDataAsync();
        }
    }
}
