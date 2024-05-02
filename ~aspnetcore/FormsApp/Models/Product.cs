using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name="Product Id")]     
        public int ProductId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name="Product Name")]
        public string? Name { get; set; }
        [Display(Name="Price")]
        [Required]
        [Range(0,100000)]
        public decimal? Price { get; set; }

        [Display(Name="Image")]
        public string Image { get; set; }=string.Empty;
        public bool IsActive { get; set; }

        [Display(Name="Category")]
        [Required]
        public int? CategoryId { get; set; }
    }
}