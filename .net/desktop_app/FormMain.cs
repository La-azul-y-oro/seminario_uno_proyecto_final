using System.Windows.Forms;
using desktop_app;
using desktop_app.auth;
using desktop_app.services;

namespace PracticaSeminario
{
    public partial class FormMain : Form
    {
        private readonly AuthService _authService = new AuthService();
        private readonly ApiService _apiService;
        public FormMain()
        {
            InitializeComponent();
            _apiService = new ApiService(_authService);
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
                this.ShowControl(new ConceptControl(_apiService));
            }
            else
            {
                Application.Exit();
            }
        }

        private void ShowControl(UserControl control)
        {
            pnlContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(control);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
