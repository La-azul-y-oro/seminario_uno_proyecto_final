using desktop_app.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_app.dto
{
    public class MovementResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public MovementType Type { get; set; }
        public string? Receipt { get; set; }
        public int ConsortiumId { get; set; }
        public string ConsortiumName { get; set; }
        public int? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public int ConceptId { get; set; }
        public string ConceptName { get; set; }
        public int? FunctionalUnitId { get; set; }
        public string? FunctionalUnitName { get; set; }
        public bool Active { get; set; }
        public string? Comment { get; set; }
    }
}
