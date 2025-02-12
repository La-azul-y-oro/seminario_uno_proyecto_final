namespace api.Models
{
    public class FunctionalUnit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long Balance { get; set; }

        public long Factor { get; set; }

        public int ConsortiumId { get; set; }

        public bool Active { get; set; } = true;
}
}
