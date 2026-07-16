using System;
using System.Collections.Generic;

namespace Manisai_WEB_MVC.Models;

public partial class Studentmaster
{
    public int Id { get; set; }

    public string Studname { get; set; } = null!;

    public string Emailid { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Gender { get; set; }

    public string State { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string? Address { get; set; }

    public DateOnly Dob { get; set; }

    public string? Photo { get; set; }

    public int? Fkcourseid { get; set; }

    public virtual Coursemaster? Fkcourse { get; set; }

    public virtual ICollection<Studentattemptdetail> Studentattemptdetails { get; set; } = new List<Studentattemptdetail>();

    public virtual ICollection<Studentattemptsummary> Studentattemptsummaries { get; set; } = new List<Studentattemptsummary>();
}
