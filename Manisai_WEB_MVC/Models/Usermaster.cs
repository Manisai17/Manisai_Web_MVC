using System;
using System.Collections.Generic;

namespace Manisai_WEB_MVC.Models;

public partial class Usermaster
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
