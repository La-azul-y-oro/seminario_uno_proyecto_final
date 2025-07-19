namespace desktop_app.dto
{
    public class FunctionalUnitBatch
    {
        public int ConsortiumId { get; set; }
        public List<int> Delete { get; set; } = new List<int>();
        public List<FunctionalUnitRequest> Update { get; set; } = new List<FunctionalUnitRequest>();
        public List<FunctionalUnitRequest> Create { get; set; } = new List<FunctionalUnitRequest>();
    }
}
