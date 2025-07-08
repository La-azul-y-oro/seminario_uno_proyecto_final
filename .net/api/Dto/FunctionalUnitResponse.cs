namespace api.Dto
{
    public class FunctionalUnitResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Balance { get; set; }
        public required decimal Factor { get; set; }
    }
}
