namespace efcoreApp.Data
{
    public class Course
    {
        public int CourseId {get; set;}
        public string? Title {get; set;}

        public int? TeacherId { get; set; }

        public Teacher Teacher { get; set; }=null!;

        public ICollection<Record> Records { get; set; }=new List<Record>();

    }
}