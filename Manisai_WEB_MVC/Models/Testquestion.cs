using System;
using System.Collections.Generic;

namespace Manisai_WEB_MVC.Models;

public partial class Testquestion
{
    public int Id { get; set; }

    public int? Fktestid { get; set; }

    public string? Question { get; set; }

    public string? Answer1 { get; set; }

    public string? Answer2 { get; set; }

    public string? Answer3 { get; set; }

    public string? Answer4 { get; set; }

    public int? Correctans { get; set; }

    public string? Explanation { get; set; }

    public virtual Testmaster? Fktest { get; set; }

    public virtual ICollection<Studentattemptdetail> Studentattemptdetails { get; set; } = new List<Studentattemptdetail>();
}
