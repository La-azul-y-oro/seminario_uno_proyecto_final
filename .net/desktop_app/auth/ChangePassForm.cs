using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using api.Auth;
using desktop_app.services;

namespace desktop_app.auth
{
    public partial class ChangePassForm : Form
    {
        private AuthService _authService;
        public ChangePassForm(AuthService authService)
        {
            _authService = authService;
            InitializeComponent();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            var CurrentPass = tbCurrentPass.Text;
            var NewPass = tbNewPass.Text;
            var NewPassRepeat = tbNewPassRepeat.Text;

            var ContainsCurrent = string.IsNullOrWhiteSpace(CurrentPass) || string.IsNullOrWhiteSpace(CurrentPass);
            var ContainsNewPass = string.IsNullOrWhiteSpace(NewPass) || string.IsNullOrWhiteSpace(NewPass);
            var ContainsNewPassRepeat = string.IsNullOrWhiteSpace(NewPassRepeat) || string.IsNullOrWhiteSpace(NewPassRepeat);

            if (ContainsCurrent || ContainsNewPass || ContainsNewPassRepeat)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (NewPass != NewPassRepeat)
            {
                MessageBox.Show("Las contraseñas son diferentes", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
                var request = new ChangePasswordRequest { CurrentPassword = CurrentPass, NewPassword = NewPass };

                bool authResponse = await _authService.ChangePasswordAsync (request);

                if (authResponse)
                {
                    MessageBox.Show("Actualizada con éxito");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("La contraseña es incorrecta. Intente nuevamente.", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
