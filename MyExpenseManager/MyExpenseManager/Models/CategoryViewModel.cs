using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyExpenseManager.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "required")]
        [DisplayName("Category Name")]
        public string Name { get; set; }
    }
}