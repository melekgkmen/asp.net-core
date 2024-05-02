using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Student
    {
        [Key]
        public int StudentId {get; set;}
        public string? StudentName {get; set;}
        public string? StudentSurname {get; set;}
        public string NameSurname { get
        {
            return this.StudentName+" "+StudentSurname;
        }}
        public string? Email {get; set;}
        public int Phone {get; set;}

        public ICollection<Record> Records {get; set;} = new List<Record>();
        


    }
}