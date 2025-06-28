namespace api.Dto
{
    public class FunctionalUnitRequest
    {
        public required string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Factor { get; set; }
        public int ConsortiumId { get; set; }
    }
}
