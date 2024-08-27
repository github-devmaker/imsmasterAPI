using System;
using System.Collections.Generic;

namespace imsmasterApi.Models;

public partial class McEtdModelDetail
{
    public string MId { get; set; } = null!;

    public string PId { get; set; } = null!;

    public string PtId { get; set; } = null!;

    public string RId { get; set; } = null!;

    public double PMidDimension { get; set; }

    public double PMaxDimension { get; set; }

    public double PMinDimension { get; set; }

    public double PCycletime { get; set; }

    public DateTime PDate { get; set; }

    public string PUser { get; set; } = null!;

    public bool PStatus { get; set; }
}
