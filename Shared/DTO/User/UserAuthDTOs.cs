﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO;

public struct SignUpDTO
{
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string Lastname { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
    public string UserName { get; set; }
}

public struct LoginDTO
{
    [Required]
    public string EmailOrUsername { get; set; }
    [Required]
    public string Password { get; set; }
    public bool isPersist { get; set; }
}
