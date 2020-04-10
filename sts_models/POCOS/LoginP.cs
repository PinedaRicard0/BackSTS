using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sts_models.POCOS
{
    public class LoginP
    {
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
