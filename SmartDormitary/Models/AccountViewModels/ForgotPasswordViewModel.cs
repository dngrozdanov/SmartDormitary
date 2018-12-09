﻿using System.ComponentModel.DataAnnotations;

namespace SmartDormitary.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required] [EmailAddress] public string Email { get; set; }
    }
}