using desktop_app.services;

namespace desktop_app
{
    public partial class BaseUserControl : UserControl
    {
        public event EventHandler? NewClicked;
        public event EventHandler? EditClicked;
        public event EventHandler? DeleteClicked;
        public event EventHandler? UpdateListClicked;

        protected readonly ApiService? _apiService;

        public BaseUserControl(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
                btnCreate.Click += (s, e) => NewClicked?.Invoke(this, EventArgs.Empty);
                btnUpdate.Click += (s, e) => EditClicked?.Invoke(this, EventArgs.Empty);
                btnDelete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);
                btnUpdateList.Click += (s, e) => UpdateListClicked?.Invoke(this, EventArgs.Empty);
                this.LoadData();
        }

        public virtual void LoadData() { /* Para sobreescribir en módulos específicos */ }

        public void setLabelEntity(string entity)
        {
            this.labelEntity.Text = entity;
        }
    }
}
