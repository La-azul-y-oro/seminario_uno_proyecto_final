namespace desktop_app.auth
{
    public partial class ResetPassForm : Form
    {
        private readonly AuthService _authService;
        public ResetPassForm(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            string Token = textToken.Text;
            string Pass = textPass.Text;

            if (string.IsNullOrWhiteSpace(Token) || string.IsNullOrWhiteSpace(Pass))
            {
                MessageBox.Show("Por favor complete los datos correctamente", "Reestablecer Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DisabledButtons();

                var request = new ResetPasswordRequest
                {
                    Token = Token,
                    NewPassword = Pass
                };

                await _authService.ResetPasswordAsync(request);
                
                MessageBox.Show("Su contraseña se ha seteado correctamente");

                EnabledButtons();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                EnabledButtons();
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnToken_Click(object sender, EventArgs e)
        {
            string Email = textEmail.Text;

            if (string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Por favor complete los datos correctamente", "Reestablecer Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DisabledButtons();

                var request = new ForgotPasswordRequest
                {
                    Email = Email
                };

                await _authService.ForgotPasswordAsync(request);

                MessageBox.Show("Si el mail proporcionado existe estará recibiendo en el mismo el token para restaurar la contraseña.");

                EnabledButtons();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                EnabledButtons();
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void DisabledButtons()
        {
            btnReset.Enabled = false;
            btnToken.Enabled = false;
            btnReset.Text = "Cargando...";
            btnToken.Text = "Cargando...";
        }

        private void EnabledButtons()
        {
            btnReset.Enabled = true;
            btnToken.Enabled = true;
            btnReset.Text = "Resetear Contraseña";
            btnToken.Text = "Obtener token";
        }
    }
}
