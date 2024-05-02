using efcoreApp.Data;

namespace efcoreApp.Models
{
    public class CourseViewModel
    {
        public int CourseId {get; set;}
        public string? Title {get; set;}

        public int? TeacherId { get; set; }
        public ICollection<Record> Records {get; set;}= new List<Record>();
    }

}