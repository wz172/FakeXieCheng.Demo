using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.DTOS
{
    public class LogInDto
    {
        [MaxLength(50),Required]
        public string Email { get; set; }

        [Required,MaxLength(15)]
        public string Password { get; set; }
    }
}
