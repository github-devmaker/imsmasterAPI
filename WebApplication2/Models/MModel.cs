namespace WebApplication2.Models
{
    public class MModel
    {
        private string mId = "";
        private string fac = "";
        private string line = "";
        private string newModelCode = "";
        private string newModelName = "";
        private int? proId = 0;
        public string? model { get; set; }
        public string? pId { get; set; }
        public string? ptId { get; set; }
        public string? rId { get; set; }
        public string? rName { get; set; }
        public string? pName { get; set; }
        public string? ptName { get; set; }
        public string? mName { get; set; }
        public double pMidDimension { get; set; }
        public double pMaxDimension { get; set; }
        public double pMinDimension { get; set; }
        public double pCycletime { get; set; }
        public DateTime pDate { get; set; }
        public string? pUser { get; set; }
        public bool pStatus { get; set; }
        public string Fac { get => fac; set => fac = value; }
        public string Line { get => line; set => line = value; }
        public string NewModelCode { get => newModelCode; set => newModelCode = value; }
        public string NewModelName { get => newModelName; set => newModelName = value; }
        public string MId { get => mId; set => mId = value; }
        public int? ProId { get => proId; set => proId = value; }
    }
}
