using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CourceRazor.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("category Name")]
        [MaxLength(10)]
        public string? Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }

    }
}
