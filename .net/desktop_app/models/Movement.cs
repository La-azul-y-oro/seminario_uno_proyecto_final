using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_app.models
{
    internal class Movement
    {
        public int Id { get; set; }
        public required DateTime Date { get; set; }
        public required decimal Amount { get; set; }
        public required MovementType Type { get; set; }
        public string? Receipt { get; set; }
        public required int ConsortiumId { get; set; }
        public Consortium Consortium { get; set; }
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public required int ConceptId { get; set; }
        public Concept Concept { get; set; }
        public int? FunctionalUnitId { get; set; }
        public FunctionalUnit? FunctionalUnit { get; set; }
        public bool Active { get; set; }
        public string? Comment { get; set; }
    }
}
