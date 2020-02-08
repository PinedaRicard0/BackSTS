using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sts_models.DTO
{
    public class Field
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }
    }
}
