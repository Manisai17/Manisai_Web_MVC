using System;
using System.Collections.Generic;

namespace Manisai_WEB_MVC.Models;

public partial class Studentattemptsummary
{
    public int Id { get; set; }

    public int? Fkstudid { get; set; }

    public int? Fktestid { get; set; }

    public DateOnly? Attemptdate { get; set; }

    public bool? Result { get; set; }

    public virtual Studentmaster? Fkstud { get; set; }

    public virtual Testmaster? Fktest { get; set; }
}
