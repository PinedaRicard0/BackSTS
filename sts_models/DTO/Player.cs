using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sts_models.DTO
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(60)]
        public string NickName { get; set; }

        public int? Dorsal { get; set; }

        [Required]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
