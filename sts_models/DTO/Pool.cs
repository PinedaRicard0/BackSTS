using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sts_models.DTO
{
    public class Pool
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(1)]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [MaxLength(15)]
        public string Status { get; set; }

        public virtual Category Category { get; set; }
    }
}
