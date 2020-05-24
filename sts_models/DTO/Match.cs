using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sts_models.DTO
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int TeamOneId { get; set; }
        [Required]
        public int TeamTwoId { get; set; }
        public int TeamOneGoals { get; set; }
        public int TeamTwoGoals { get; set; }
        [DataType(DataType.Date)]
        public DateTime? GameDate { get; set; }
        public int? FieldId { get; set; }
        public int? PoolId { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }

        [ForeignKey("TeamOneId")]
        public virtual Team TeamOne { get; set; }
        [ForeignKey("TeamTwoId")]
        public virtual Team TeamTwo { get; set; }
        public virtual Pool Pool { get; set; }
        public virtual Field Field { get; set; }
    }
}
