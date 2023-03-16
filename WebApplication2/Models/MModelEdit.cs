namespace WebApplication2.Models
{
    public class mModelEdit
    {
        private string mId = "";
        private string pId = "";
        private string ptId = "";
        private string rId = "";
        private double midDimension = 0;
        private double minDimension = 0;
        private double maxDimension = 0;
        private string newModelCode = "";
        private string newModelName = "";
        private string fac = "";
        private string line = "";
        public string MId { get => mId; set => mId = value; }
        public string PId { get => pId; set => pId = value; }
        public string PtId { get => ptId; set => ptId = value; }
        public string RId { get => rId; set => rId = value; }
        public double MidDimension { get => midDimension; set => midDimension = value; }
        public double MinDimension { get => minDimension; set => minDimension = value; }
        public double MaxDimension { get => maxDimension; set => maxDimension = value; }
        public string NewModelCode { get => newModelCode; set => newModelCode = value; }
        public string NewModelName { get => newModelName; set => newModelName = value; }
        public string Fac { get => fac; set => fac = value; }
        public string Line { get => line; set => line = value; }
    }
}
