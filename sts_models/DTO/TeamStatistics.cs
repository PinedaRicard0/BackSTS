using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sts_models.DTO
{
    public class TeamStatistics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int TeamId { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public int Scored { get; set; }
        public int Against { get; set; }
        public int GoalDifference { get; set; }
        public int PoolId { get; set; }

        public virtual Team Team { get; set; }
        public virtual Pool Pool { get; set; }

        //TODO: Add a foreing key to new table for other instances like semi-final...

    }
}