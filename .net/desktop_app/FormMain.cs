using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using desktop_app;
using desktop_app.services;

namespace PracticaSeminario
{
    public partial class FormMain : Form
    {
        private readonly ApiService _apiService = new ApiService();
        public FormMain()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formMain_Shown(object sender, EventArgs e)
        {
            FormLogin appLogin = new FormLogin();
            if (appLogin.ShowDialog() == DialogResult.OK)
            {
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
    }
}
