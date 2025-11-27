using api.Models;
using System.Text.Json.Serialization;

namespace api.Dto
{
    public class ClientFunctionalUnit
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Balance { get; set; }
        public required decimal Factor { get; set; }
        public required string Consortium { get; set; }
        public required string ConsortiumAddress { get; set; }
        public required int ConsortiumId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OccupantType OccupantType { get; set; }
        public ICollection<LiquidationDTO> Liquidations { get; set; } = new List<LiquidationDTO>();
    }
}
