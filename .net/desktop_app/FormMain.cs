using desktop_app.auth;
using desktop_app.concept;
using desktop_app.consortium;
using desktop_app.services;
using desktop_app.supplier;

namespace PracticaSeminario
{
    public partial class FormMain : Form
    {
        private readonly AuthService _authService = new AuthService();
        private readonly LiquidationService _liquidationService;
        private readonly ReportService _reportService;
        private readonly ApiService _apiService;
        private Control? _currentControl;

        public FormMain()
        {
            InitializeComponent();
            _apiService = new ApiService(_authService);
            _liquidationService = new LiquidationService(_authService);
            _reportService = new ReportService(_authService);
        }

        private void LoadUserData()
        {
            string userInfo = _authService.GetUserInfo();
            labelUserInfo.Text = userInfo;
        }
        private void formMain_Shown(object sender, EventArgs e)
        {
            FormLogin appLogin = new FormLogin(_authService);
            if (appLogin.ShowDialog() == DialogResult.OK)
            {
                this.LoadUserData();
                ShowControl(new ConceptControl(_apiService));
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
            var changePassForm = new ChangePassForm(_authService);
            changePassForm.ShowDialog();

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
            ShowControl(new ConsortiumControl(_apiService, _liquidationService, _reportService));
        }

        private void tsmiUsuarios_Click(object sender, EventArgs e)
        {
            // a implementar
            // ShowControl(new UserControl(_apiService));
        }
    }
}
