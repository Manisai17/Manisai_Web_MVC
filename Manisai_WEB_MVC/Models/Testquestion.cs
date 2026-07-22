using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manisai_WEB_MVC.Models;

public partial class Testquestion
{
    public int Id { get; set; }

    public int? Fktestid { get; set; }

    [Required(ErrorMessage = "Question text is required")]
    [StringLength(1000)]
    public string Question { get; set; } = null!;

    [Required(ErrorMessage = "Answer 1 is required")]
    [StringLength(500)]
    public string Answer1 { get; set; } = null!;

    [Required(ErrorMessage = "Answer 2 is required")]
    [StringLength(500)]
    public string Answer2 { get; set; } = null!;

    [Required(ErrorMessage = "Answer 3 is required")]
    [StringLength(500)]
    public string Answer3 { get; set; } = null!;

    [Required(ErrorMessage = "Answer 4 is required")]
    [StringLength(500)]
    public string Answer4 { get; set; } = null!;

    [Required(ErrorMessage = "Correct answer is required")]
    [Range(1, 4, ErrorMessage = "Correct answer must be between 1 and 4")]
    public int Correctans { get; set; }

    public string? Explanation { get; set; }

    public virtual Testmaster? Fktest { get; set; }

    public virtual ICollection<Studentattemptdetail> Studentattemptdetails { get; set; } = new List<Studentattemptdetail>();
}