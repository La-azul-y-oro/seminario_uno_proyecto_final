namespace PracticaSeminario
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.txtUsuario.Text == "Admin" && this.txtPass.Text == "admin")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Las credenciales no son v�lidas."
                , "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
