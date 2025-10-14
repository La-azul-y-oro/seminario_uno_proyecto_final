using desktop_app.auth;
using desktop_app.concept;
using desktop_app.consortium;
using desktop_app.movement;
using desktop_app.services;
using desktop_app.supplier;
using desktop_app.users;

namespace PracticaSeminario
{
    public partial class FormMain : Form
    {
        private readonly AuthService _authService = new AuthService();
        private readonly LiquidationService _liquidationService;
        private readonly ReportService _reportService;
        private readonly FunctionalUnitService _functionalUnitService;
        private readonly UserService _userService;
        private readonly ApiService _apiService;
        private Control? _currentControl;

        public FormMain()
        {
            InitializeComponent();
            layoutPanel.Visible = false;
            _apiService = new ApiService(_authService);
            _liquidationService = new LiquidationService(_authService);
            _reportService = new ReportService(_authService);
            _functionalUnitService = new FunctionalUnitService(_authService);
            _userService = new UserService(_authService);
        }

        private void LoadUserData()
        {
            layoutPanel.Visible = true;
            string userInfo = _authService.GetUserInfo();
            labelUserInfo.Text = userInfo;
        }
        private void formMain_Shown(object sender, EventArgs e)
        {
            FormLogin appLogin = new FormLogin(_authService);
            if (appLogin.ShowDialog() == DialogResult.OK)
            {
                this.LoadUserData();
                ShowControl(new ConsortiumControl(_apiService, _liquidationService, _reportService, _functionalUnitService, _userService));
            }
            else
            {
                Application.Exit();
            }
        }

        private void ShowControl(Control control)
        {
            if (_currentControl != null)
            {
                this.Controls.Remove(_currentControl);
                _currentControl.Dispose();
            }

            _currentControl = control;
            pnlContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(control);
        }


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsmChangePass_Click(object sender, EventArgs e)
        {
            using var changePassForm = new ChangePassForm(_authService);
            ShowModalWithOverlay(changePassForm);

        }

        private void tsmiConceptos_Click(object sender, EventArgs e)
        {
            ShowControl(new ConceptControl(_apiService));
        }

        private void tsmiSupplier_Click(object sender, EventArgs e)
        {
            ShowControl(new SupplierControl(_apiService));
        }

        private void tsmiConsorcios_Click(object sender, EventArgs e)
        {
            ShowControl(new ConsortiumControl(_apiService, _liquidationService, _reportService, _functionalUnitService, _userService));
        }

        private void tsmiUsuarios_Click(object sender, EventArgs e)
        {
            ShowControl(new UsersControl(_apiService));
        }

        private void tsmiMovimientos_Click(object sender, EventArgs e)
        {
            ShowControl(new MovementControl(_apiService));
        }

        public DialogResult ShowModalWithOverlay(Form childForm)
        {
            Panel overlay = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(100, Color.GhostWhite), 
            };

            this.Controls.Add(overlay);
            overlay.BringToFront();
            overlay.Visible = true;

            childForm.StartPosition = FormStartPosition.CenterParent;

            var result = childForm.ShowDialog(this);

            this.Controls.Remove(overlay);
            overlay.Dispose();

            return result;
        }

    }
}
