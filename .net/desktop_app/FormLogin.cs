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
                    _authService.SetToken(responseObj["token"]);

                    this.DialogResult = DialogResult.OK;
                    inkOlvidaPass.Enabled = true;
                    btnIngresar.Enabled = true;
                    txtUsuario.Enabled = true;
                    txtPass.Enabled = true;
                    btnIngresar.Text = "Ingresar";
                }
                else
                {
                    inkOlvidaPass.Enabled = true;
                    btnIngresar.Enabled = true;
                    txtUsuario.Enabled = true;
                    txtPass.Enabled = true;
                    btnIngresar.Text = "Ingresar";
                    MessageBox.Show("Credenciales incorrectas. Intente nuevamente.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            MessageBox.Show("Lo siento, esta funci�n no esta disponible a�n.",
            "Olvid� mi contrase�a",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
