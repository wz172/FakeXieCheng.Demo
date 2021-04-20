﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.DTOS
{
    public class RegisterUserDto
    {
        [Required,MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required,Compare(nameof(Password),ErrorMessage ="两次密码输入不一致")]
        public string AffirmPassword { get; set; }
    }
}
