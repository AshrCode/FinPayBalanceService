using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UserAccount
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public float Balance { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Currency { get; set; } = "AED";
    }
}
