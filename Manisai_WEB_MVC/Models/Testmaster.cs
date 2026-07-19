using System;
using System.Collections.Generic;

namespace Manisai_WEB_MVC.Models;

public partial class Testmaster
{
    public int Id { get; set; }

    public int? Fkcourseid { get; set; }

    public string? Testname { get; set; }

    public int? Duration { get; set; }

    public int? Totquestions { get; set; }

    public virtual Coursemaster? Fkcourse { get; set; } //Navigation type variable

    public virtual ICollection<Studentattemptsummary> Studentattemptsummaries { get; set; } = new List<Studentattemptsummary>();

    public virtual ICollection<Testquestion> Testquestions { get; set; } = new List<Testquestion>();
}
