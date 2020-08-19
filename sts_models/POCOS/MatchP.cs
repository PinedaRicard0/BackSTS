using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sts_models.POCOS
{
    public class MatchP
    {
        public int Id { get; set; }
        [Required]
        public int TeamOneId { get; set; }
        public string TeamOneName { get; set; }
        [Required]
        public int TeamTwoId { get; set; }
        public string TeamTwoName { get; set; }
        public int TeamOneGoals { get; set; }
        public int TeamTwoGoals { get; set; }
        [DataType(DataType.Date)]
        public DateTime? GameDate { get; set; }
        public int? FieldId { get; set; }
        public string FieldName { get; set; }
        public int? PoolId { get; set; }
        public string PoolName { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
    }
}
