using desktop_app.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_app.dto
{
    internal class MovementRequest
    {
        public int Id { get; set; }
        public required DateTime Date { get; set; }
        public required decimal Amount { get; set; }
        public required MovementType Type { get; set; }
        public string? Receipt { get; set; }
        public required int ConsortiumId { get; set; }
        public int? SupplierId { get; set; }
        public required int ConceptId { get; set; }
        public int? FunctionalUnitId { get; set; }
        public bool? Active { get; set; }
        public string? Comment { get; set; }
    }
}
