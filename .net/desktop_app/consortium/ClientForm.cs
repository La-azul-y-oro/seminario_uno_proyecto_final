using desktop_app.dto;
using desktop_app.models;
using desktop_app.services;

namespace desktop_app.consortium
{
    public partial class ClientForm : Form
    {
        private readonly UserService _userService;
        private readonly FunctionalUnitService _functionalUnitService;
        private FunctionalUnitResponse _unit;
        private List<Client> _allClients;

        public event Action<ICollection<Client>> ClientsUpdatedEvent;
        private ICollection<Client> _ClientsUpdated;
        public ClientForm(UserService userService, FunctionalUnitService functionalUnitService, List<Client> allClients, FunctionalUnitResponse unit)
        {
            InitializeComponent();
            _userService = userService;
            _functionalUnitService = functionalUnitService;
            _allClients = allClients;
            _unit = unit;

            Text = "Unidad " + unit.Name;

            InitializeGrid();
            InitializeData();
            InitComboBoxClient();
            InitComboBoxType();
        }

        private void InitializeGrid()
        {
            dvgClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                Visible = false
            });

            dvgClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Nombre"
            });

            dvgClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLastName",
                HeaderText = "Apellido"
            });

            dvgClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmail",
                HeaderText = "Email"
            });

            dvgClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTipo",
                HeaderText = "Tipo"
            });

            var colAcciones = new DataGridViewButtonColumn
            {
                Name = "colRemove",
                HeaderText = "Acciones",
                Text = "Remover",
                UseColumnTextForButtonValue = true
            };
            dvgClients.Columns.Add(colAcciones);

            dvgClients.CellContentClick += dvgClients_CellContentClick;
        }

        private async void dvgClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var colName = dvgClients.Columns[e.ColumnIndex].Name;

            if (colName == "colRemove")
            {
                var row = dvgClients.Rows[e.RowIndex];
                var client = row.Tag as Client;

                if (client == null) return;

                try
                {
                    _unit.Clients.Remove(client);

                    await _functionalUnitService.UpdateClientsAsync(new AssignClientsRequest
                    {
                        FunctionalId = (int)_unit.Id,
                        Clients = _unit.Clients
                            .Select(c => new ClientFunctionalUnitDto
                            {
                                ClientId = c.Id,
                                OccupantType = (OccupantType) c.OccupantType 
                            })
                            .ToList()
                    });


                    MessageBox.Show("El cliente fue correctamente removido.");

                    InitializeData();
                    InitComboBoxClient();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al remover cliente: {ex.Message}");
                }
            }
        }


        private void InitializeData()
        {
            dvgClients.Rows.Clear();

            if (_unit.Clients != null && _unit.Clients.Any())
            {
                dvgClients.Visible = true;
                labelNoData.Visible = false;
                foreach (var client in _unit.Clients)
                {
                    int rowIndex = dvgClients.Rows.Add(
                        client.Id,
                        client.FirstName,
                        client.LastName,
                        client.Email,
                        client.OccupantType
                        );
                    dvgClients.Rows[rowIndex].Tag = client;
                }
            }
            else
            {
                labelNoData.Visible = true;
                dvgClients.Visible = false;
            }
        }

        private void InitComboBoxClient()
        {
            var placeholder = new Client { Id = -1, FirstName = "-- Seleccionar cliente --", LastName = null, Email = null };

            var assignedClientIds = _unit.Clients.Select(c => c.Id).ToHashSet();
            var availableClients = _allClients
                .Where(c => !assignedClientIds.Contains(c.Id))
                .ToList();
            availableClients.Insert(0, placeholder);

            comboClients.DataSource = availableClients
                .Select(c => new ClientComboItem
                {
                    Id = c.Id,
                    FullName = c.FirstName + " " + c.LastName
                })
                .ToList();
            comboClients.DisplayMember = "FullName";
            comboClients.ValueMember = "Id";
        }

        private void InitComboBoxType()
        {
            comboOccupantType.DataSource = Enum.GetValues(typeof(OccupantType));
            comboOccupantType.SelectedIndex = -1;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboClients.SelectedIndex <= 0) return; // 0 es "Seleccionar cliente…"

            var selectedClientCombo = comboClients.SelectedItem as ClientComboItem;
            var selectedType = comboOccupantType.SelectedItem;

            if (selectedClientCombo == null || selectedType == null) {
                MessageBox.Show($"Por favor complete ambos campos");
                return;
            }
            

            var client = _allClients.Find(c => c.Id == selectedClientCombo.Id);
            client.OccupantType = (OccupantType) selectedType;


            if (_unit.Clients.Any(c => c.Id == client.Id))
            {
                MessageBox.Show("Este cliente ya está asignado.");
                return;
            }

            try
            {
                _unit.Clients.Add(client);

                await _functionalUnitService.UpdateClientsAsync(new AssignClientsRequest
                {
                    FunctionalId = (int)_unit.Id,
                    Clients = _unit.Clients
                            .Select(c => new ClientFunctionalUnitDto
                            {
                                ClientId = c.Id,
                                OccupantType = (OccupantType) c.OccupantType
                            })
                            .ToList()
                });

                MessageBox.Show("El cliente fue correctamente asignado.");

                InitializeData();
                InitComboBoxClient();
                InitComboBoxType();
            }
            catch (Exception ex)
            {
                _unit.Clients.Remove(client);
                MessageBox.Show($"Error al agregar cliente: {ex.Message}");
            }
        }
    }
}

public class ClientComboItem
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
}
