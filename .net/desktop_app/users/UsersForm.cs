using desktop_app.services;
using desktop_app.models;
using desktop_app.dto;

namespace desktop_app.users
{
    public partial class UsersForm : Form
    {
        private readonly ApiService _apiService;
        private readonly UserResponse? _user;

        public UsersForm(ApiService apiService, UserResponse? user = null)
        {
            InitializeComponent();

            _apiService = apiService;
            _user = user;

            comboDocType.DataSource = Enum.GetValues(typeof(DocumentType));
            comboRole.DataSource = Enum.GetValues(typeof(Role));
            

            if (_user != null)
            {
                labelForm.Text = "Actualizar Usuario";
                btnAccept.Text = "Actualizar";

                labelPassword.Visible = false;
                txtPassword.Visible = false;

                txtName.Text = _user.FirstName;
                txtLastName.Text = _user.LastName;
                txtMail.Text = _user.Email;
                txtPhone.Text = _user.Phone;
                txtDocNumber.Text = _user.DocumentNumber.ToString();
                comboDocType.SelectedItem = _user.DocumentType;
                comboRole.SelectedItem = _user.Role;

            }
            else
            {
                comboDocType.SelectedIndex = -1;
                comboRole.SelectedIndex = -1;
            }
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            string FirstName = txtName.Text;
            string LastName = txtLastName.Text;
            string Phone = txtPhone.Text;
            string Email = txtMail.Text;
            string DocumentNumber = txtDocNumber.Text;
            string Password = txtPassword.Text;


            bool isFirstNameValid = !string.IsNullOrWhiteSpace(FirstName);
            bool isLastNameValid = !string.IsNullOrWhiteSpace(LastName);
            bool isDocNumberValid = !string.IsNullOrWhiteSpace(DocumentNumber) && DocumentNumber.All(char.IsDigit);
            bool isPhoneValid = !string.IsNullOrWhiteSpace(Phone) && Phone.All(char.IsDigit);
            bool isEmailValid = !string.IsNullOrWhiteSpace(Email);
            bool isPasswordValid = !string.IsNullOrWhiteSpace(Password);
            bool isDocTypeSelected = comboDocType.SelectedValue != null;
            bool isRoleSelected = comboRole.SelectedValue != null;

            if (!isFirstNameValid || !isLastNameValid || !isPhoneValid || !isEmailValid || !isDocNumberValid || !isDocTypeSelected || !isRoleSelected)
            {
                MessageBox.Show("Complete correctamente los campos", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var newUser = new UserRequest
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Phone = Phone,
                    Email = Email,
                    DocumentNumber = long.Parse(DocumentNumber),
                    DocumentType = (DocumentType)comboDocType.SelectedItem,
                    Role = (Role)comboRole.SelectedItem,
                    Password = Password,
                    Active = true
                };

                if (_user == null)
                {
                    await _apiService.PostAsync("user", newUser);
                }
                else
                {
                    await _apiService.PutAsync($"user", _user.Id, newUser);
                }

                MessageBox.Show("Guardado con éxito");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
