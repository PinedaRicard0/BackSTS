using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sts_models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        public int PoolId { get; set; }
        public virtual Pool Pool { get; set; }

    }
}
