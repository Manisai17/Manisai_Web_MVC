using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manisai_WEB_MVC.Models;

public partial class Studentmaster
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    public string Studname { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Enter a valid email address")]
    [StringLength(50)]
    public string Emailid { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = null!;

    public bool Gender { get; set; }

    [Required(ErrorMessage = "State is required")]
    [StringLength(50)]
    public string State { get; set; } = null!;

    [Required(ErrorMessage = "City is required")]
    [StringLength(50)]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "Mobile number is required")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number must be exactly 10 digits")]
    public string Mobile { get; set; } = null!;

    public string? Address { get; set; }

    [Required(ErrorMessage = "Date of birth is required")]
    public DateOnly Dob { get; set; }

    public string? Photo { get; set; }

    public int? Fkcourseid { get; set; }

    public virtual Coursemaster? Fkcourse { get; set; }
    public virtual ICollection<Studentattemptdetail> Studentattemptdetails { get; set; } = new List<Studentattemptdetail>();
    public virtual ICollection<Studentattemptsummary> Studentattemptsummaries { get; set; } = new List<Studentattemptsummary>();
}