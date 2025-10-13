using System.Text.Json;
using api.Auth;
using desktop_app.auth;

namespace PracticaSeminario
{
    public partial class FormLogin : Form
    {
        private AuthService _authService;
        public FormLogin(AuthService authService)
        {
            _authService = authService;
            InitializeComponent();
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPass.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                inkOlvidaPass.Enabled = false;
                btnIngresar.Enabled = false;
                txtUsuario.Enabled = false;
                txtPass.Enabled = false;
                btnIngresar.Text = "Cargando...";
                String? authResponse = await _authService.LoginAsync(new LoginDto { Username = usuario, Password = password });

                if (authResponse != null && !string.IsNullOrWhiteSpace(authResponse))
                {
                    var responseObj = JsonSerializer.Deserialize<Dictionary<string, string>>(authResponse);
                    var token = responseObj["token"];

                    if (_authService.GetRole(token).Equals("ADMIN"))
                    {
                        _authService.SetToken(responseObj["token"]);

                        this.DialogResult = DialogResult.OK;
                        resetElements();
                    }
                    else
                    {
                        ShowInvalidCredentials();
                    }
                }
                else
                {
                    ShowInvalidCredentials();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void inkOlvidaPass_LinkClicked(object sender,
        LinkLabelLinkClickedEventArgs e)
        {
            using var form = new ResetPassForm(_authService);
            form.ShowDialog();
        }

        private void ShowInvalidCredentials()
        {
            resetElements();
            MessageBox.Show("Credenciales incorrectas. Intente nuevamente.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void resetElements()
        {
            inkOlvidaPass.Enabled = true;
            btnIngresar.Enabled = true;
            txtUsuario.Enabled = true;
            txtPass.Enabled = true;
            btnIngresar.Text = "Ingresar";
        }
    }
}
