namespace api.Dto
{
    public class AssignClientsRequest
    {
        public int FunctionalId { get; set; }
        public List<ClientFunctionalUnitDto> Clients { get; set; } = new List<ClientFunctionalUnitDto>();
    }
}
