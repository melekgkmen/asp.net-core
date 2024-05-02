using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models
{
    public class UserInfo
    {
        public int Id { get; set; }

       /* [Required (ErrorMessage ="Namespace required")]*/
        public string? Name { get; set; }

        [Required(ErrorMessage ="Phone field is required")]
        public string? Phone { get; set; }

        [Required(ErrorMessage ="Email field is required")]
        [EmailAddress(ErrorMessage ="Incorrect email")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Please indicate participation status")]
        public bool WillAttend { get; set; }

    }
}