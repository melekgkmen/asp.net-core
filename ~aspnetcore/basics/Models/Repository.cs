namespace basics.Models
{
    public class Repository
    {
        private static readonly List<Course> _courses=new List<Course>();

        static Repository()
        {
            _courses=new List<Course>()
            {
                new Course(){Id=1, Title="aspnet kursu", Description="güzel bir kurs",Image="1.jpg",Tags= new string[]{"aspnet","web geliştirme"},
                isActive=true,isHome=true},
            new Course(){Id=2, Title="php kursu", Description="güzel bir kurs",Image="2.jpg",Tags= new string[]{"php","web geliştirme"},
                isActive=false,isHome=true},
            new Course(){Id=3, Title="django kursu", Description="güzel bir kurs",Image="3.jpg",Tags= new string[]{"django","web geliştirme"},
                isActive=true,isHome=false},
            new Course(){Id=4, Title=" Javascript kursu", Description="güzel bir kurs",Image="1.jpg",Tags= new string[]{"Javascript","web geliştirme"},
                isActive=true,isHome=true},
            };
        }

        public static List<Course> Courses
        {
            get{
                return _courses;
            }
        }

        public static Course GetById(int id)
        {
            return _courses.FirstOrDefault(c=> c.Id==id);
        }
    }

    


}