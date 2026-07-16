using System;
using System.Collections.Generic;

namespace Manisai_WEB_MVC.Models;

public partial class Coursemaster
{
    public int Id { get; set; }

    public string Coursename { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Modules { get; set; } = null!;

    public int Duration { get; set; }

    public virtual ICollection<Studentmaster> Studentmasters { get; set; } = new List<Studentmaster>();

    public virtual ICollection<Testmaster> Testmasters { get; set; } = new List<Testmaster>();
}
