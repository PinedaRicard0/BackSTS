using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sts_models.DTO
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Mail { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
