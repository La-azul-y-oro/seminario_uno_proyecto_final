using desktop_app.dto;
using desktop_app.models;
using desktop_app.services;

namespace desktop_app.consortium
{
    public partial class FunctionalUnitForm : Form
    {
        private readonly ConsortiumResponse _consortium;
        private readonly FunctionalUnitService _functionalUnitService;
        private readonly UserService _userService;
        private List<Client> _clients;

        public event Action<ICollection<FunctionalUnitResponse>> UnitsUpdated;
        private ICollection<FunctionalUnitResponse> _functionalUnitsUpdate;
        public FunctionalUnitForm(ConsortiumResponse consortium, FunctionalUnitService functionalUnitService, UserService userService)
        {
            InitializeComponent();
            InitializePanelList();

            _consortium = consortium;
            _functionalUnitService = functionalUnitService;
            _userService = userService;

            GetAllClients();

            panelInicial.Visible = true;

            comboBoxNomenclatura.Items.Add(new ComboOption { Label = "Piso + Letra (1A, 1B, 1C...)", Value = "pisoLetra" });
            comboBoxNomenclatura.Items.Add(new ComboOption { Label = "Piso + Número (101, 102, 103...)", Value = "pisoNumero" });
            comboBoxNomenclatura.SelectedIndex = 0;

            textFloor.KeyPress += OnlyAllowDigits;
            textUnits.KeyPress += OnlyAllowDigits;
            textFactor.KeyPress += OnlyAllowDecimal;

            if (_consortium.FunctionalUnits != null && _consortium.FunctionalUnits.Any())
            {
                panelInicial.Visible = false;
                panelAsistida.Visible = false;
                panelList.Visible = true;

                LoadFunctionalUnits(_consortium.FunctionalUnits);
            }
            else
            {
                panelInicial.Visible = true;
                panelAsistida.Visible = false;
                panelList.Visible = false;
            }
        }

        private async void GetAllClients()
        {
            _clients = await _userService.GetAllClients();
        }

        private void LoadFunctionalUnits(ICollection<FunctionalUnitResponse> units)
        {
            dgvUnits.Rows.Clear();

            foreach (var unit in units)
            {
                int rowIndex = dgvUnits.Rows.Add(unit.Id, unit.Name, unit.Factor, unit.Balance);
                dgvUnits.Rows[rowIndex].Tag = unit;

                if (!dgvUnits.Columns.Contains("colUsuarios"))
                {
                    var colUsuarios = new DataGridViewButtonColumn
                    {
                        Name = "colUsuarios",
                        HeaderText = "Usuarios",
                        Text = "Gestionar",
                        UseColumnTextForButtonValue = true
                    };
                    dgvUnits.Columns.Add(colUsuarios);
                }
            }
        }

        private void InitializePanelList()
        {
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                Visible = false
            });

            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Nombre"
            });

            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFactor",
                HeaderText = "Factor (%)"
            });

            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBalance",
                HeaderText = "Balance ($)",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.LightGray
                }
            });

            var colAcciones = new DataGridViewButtonColumn
            {
                Name = "colRemove",
                HeaderText = "Acciones",
                Text = "Remover",
                UseColumnTextForButtonValue = true
            };
            dgvUnits.Columns.Add(colAcciones);

            dgvUnits.CellContentClick += dgvUnits_CellContentClick;
        }

        private void btnAsistida_Click(object sender, EventArgs e)
        {
            panelInicial.Visible = false;
            panelAsistida.Visible = true;
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            panelInicial.Visible = false;
            panelList.Visible = true;
        }

        private void buttonAsistida_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textFloor.Text, out int floors) || floors <= 0 ||
                !int.TryParse(textUnits.Text, out int units) || units <= 0 ||
                !double.TryParse(textFactor.Text, out double factor) || factor <= 0)
            {
                MessageBox.Show("Todos los campos deben tener valores numéricos positivos.", "Unidades Funcionales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedNomenclatura = (ComboOption)comboBoxNomenclatura.SelectedItem;
            if (selectedNomenclatura == null)
            {
                MessageBox.Show("Debe seleccionar una nomenclatura.", "Unidades Funcionales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomenclatura = selectedNomenclatura.Value;

            var unitsList = GenerateUnits();
            showUnits(unitsList);
        }

        private void showUnits(List<FunctionalUnit> unitsList)
        {
            panelAsistida.Visible = false;
            panelList.Visible = true;

            dgvUnits.Rows.Clear();

            foreach (var u in unitsList)
            {
                dgvUnits.Rows.Add(u.Name, u.Factor, u.Balance);
            }
        }
       
        private List<FunctionalUnit> GenerateUnits()
        {
            int floors = int.Parse(textFloor.Text);
            int units = int.Parse(textUnits.Text);
            double factor = double.Parse(textFactor.Text);

            var selectedNomenclatura = (ComboOption)comboBoxNomenclatura.SelectedItem;
            string nomenclatura = selectedNomenclatura.Value;

            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var unitsList = new List<FunctionalUnit>();

            for (int floor = 1; floor <= floors; floor++)
            {
                for (int i = 0; i < units; i++)
                {
                    string name;
                    if (nomenclatura == "pisoLetra")
                        name = $"{floor}{letters[i]}";
                    else // pisoNumero
                        name = $"{floor * 100 + i + 1}";

                    unitsList.Add(new FunctionalUnit { Name = name, Factor = (decimal)factor, Balance = 0 });
                }
            }

            return unitsList;
        }
        
        private void OnlyAllowDigits(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void OnlyAllowDecimal(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') &&
                (tb.Text.Contains('.') || tb.Text.Contains(',')))
            {
                e.Handled = true;
            }
        }

        private async void buttonSaveList_Click(object sender, EventArgs e)
        {
            await SaveUnitsAsync();
        }

        private async Task SaveUnitsAsync()
        {
            double totalFactor = 0;

            var unitsToCreate = new List<FunctionalUnitRequest>();
            var unitsToUpdate = new List<FunctionalUnitRequest>();
            var currentRowIds = new HashSet<int>();

            foreach (DataGridViewRow row in dgvUnits.Rows)
            {
                if (row.IsNewRow) continue;

                var name = row.Cells["colName"].Value?.ToString()?.Trim();
                var factorStr = row.Cells["colFactor"].Value?.ToString();
                var idObj = row.Cells["colId"].Value;

                if (string.IsNullOrWhiteSpace(name) || !double.TryParse(factorStr, out double factor))
                {
                    MessageBox.Show("Todos los campos deben estar completos y válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                totalFactor += factor;

                // Detectar si es una unidad nueva (sin Id) o una existente
                if (idObj == null || !int.TryParse(idObj.ToString(), out int id) || id == 0)
                {
                    unitsToCreate.Add(new FunctionalUnitRequest
                    {
                        Name = name,
                        Factor = (decimal)factor,
                        ConsortiumId = _consortium.Id
                    });
                }
                else
                {
                    currentRowIds.Add(id);

                    var original = _consortium.FunctionalUnits.FirstOrDefault(u => u.Id == id);
                    if (original == null || original.Name != name || original.Factor != (decimal)factor)
                    {
                        unitsToUpdate.Add(new FunctionalUnitRequest
                        {
                            Id = id,
                            Name = name,
                            Factor = (decimal)factor,
                            ConsortiumId = _consortium.Id
                        });
                    }
                }
            }

            if (Math.Abs(totalFactor - 100) > 0.01)
            {
                MessageBox.Show($"La suma de los factores debe ser exactamente 100. Actualmente: {totalFactor}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Detectar cuáles fueron eliminadas (las que estaban y ya no están)
            var unitsToDelete = _consortium.FunctionalUnits
                .Where(u => u.Id.HasValue && !currentRowIds.Contains(u.Id.Value))
                .Select(u => u.Id.Value)
                .ToList();

            var batch = new FunctionalUnitBatch
            {
                ConsortiumId = _consortium.Id,
                Create = unitsToCreate,
                Update = unitsToUpdate,
                Delete = unitsToDelete
            };

            try
            {
                _functionalUnitsUpdate = await _functionalUnitService.ProcessBatchAsync(batch);
                MessageBox.Show(
                    "Unidades guardadas correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                UnitsUpdated?.Invoke(_functionalUnitsUpdate);
                LoadFunctionalUnits(_functionalUnitsUpdate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar unidades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUnits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var colName = dgvUnits.Columns[e.ColumnIndex].Name;

            if (colName == "colRemove")
            {
                if (!dgvUnits.Rows[e.RowIndex].IsNewRow)
                {
                    var balanceObj = dgvUnits.Rows[e.RowIndex].Cells["colBalance"].Value;

                    if (balanceObj != null && double.TryParse(balanceObj.ToString(), out double balance))
                    {
                        if (Math.Abs(balance) > 0.01) // Evitamos errores de coma flotante
                        {
                            MessageBox.Show("No se pueden borrar las unidades con balance distinto de 0 (cero).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    dgvUnits.Rows.RemoveAt(e.RowIndex);
                }
            }
            else if (colName == "colUsuarios")
            {
                var row = dgvUnits.Rows[e.RowIndex];
                var functionalUnit = row.Tag as FunctionalUnitResponse;

                if(functionalUnit == null) {
                    MessageBox.Show(
                        "La unidad funcional aún no se encuentra confirmada. Por favor actualice el listado de unidades funcionales antes de asignar clientes.",
                        "Unidades Funcionales",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;

                }

                using var form = new ClientForm(_userService, _functionalUnitService, _clients, functionalUnit);

                form.ClientsUpdatedEvent += (updatedUsers) =>
                {
                    functionalUnit.Clients = updatedUsers;
                };

                form.ShowDialog();
              }
        }
    }

    public class ComboOption
    {
        public string Label { get; set; }
        public string Value { get; set; }

        public override string ToString() => Label;
    }
}
