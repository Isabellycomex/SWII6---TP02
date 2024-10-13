using System.ComponentModel.DataAnnotations;

namespace CustomsSystem.Models
{
    public class Container
    {
        public int Id { get; set; }

        [Required]
        public int BillOfLadingId { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo {0} deve ter exatamente 11 caracteres" )]
        public string Number { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Size { get; set; }
    }
}
