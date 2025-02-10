namespace api.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string lastName { get; set; }
        public int documentNumber { get; set; }
        public string telephoneNumber { get; set; }
        public Role role { get; set; }
        public DocumentType documentType { get; set; }
    }
}
