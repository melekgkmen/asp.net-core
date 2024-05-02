using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name = "Name Surname")]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage ="Especifique un máximo de 10 caracteres", MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="your password does not match")]
        [Display(Name ="Password Again")]
        public string? ConfirmPassword { get; set; }
    }
}