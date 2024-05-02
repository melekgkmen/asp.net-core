using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string NameSurname { get
        {
            return this.Name+" "+Surname;
        }}
        public string? Email { get; set; }
        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =false)]
        public DateTime SartingDate { get; set; }
        public ICollection<Course> Courses { get; set; }=new List<Course>();

    }
}