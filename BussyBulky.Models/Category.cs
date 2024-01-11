using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BussyBulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order"), Range(1, 100, ErrorMessage = "Display Order is out of range (1-100)")]
        public int DisplayOrder { get; set; }
    }
}
