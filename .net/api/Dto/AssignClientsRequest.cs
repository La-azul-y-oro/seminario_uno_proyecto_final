namespace api.Dto
{
    public class AssignClientsRequest
    {
        public int FunctionalId { get; set; }
        public List<int> ClientsIds { get; set; } = new List<int>();
    }
}
