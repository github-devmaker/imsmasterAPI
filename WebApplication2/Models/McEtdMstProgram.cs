using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class McEtdMstProgram
{
    public int ProId { get; set; }

    public string ProName { get; set; } = null!;

    public string? Yc { get; set; }
}
