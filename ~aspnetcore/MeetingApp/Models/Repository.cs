namespace MeetingApp.Models
{
    public static class Repository
    {
        private static List<UserInfo> _users = new();

        static Repository()
        {
            _users.Add(new UserInfo()
            {
                Id=1,Name="Rabia",Email="rabia@gmail.com",Phone="05211541515", WillAttend=true
            });
            _users.Add(new UserInfo()
            {
                Id=2,Name="Göktuğ",Email="goktug@gmail.com",Phone="05211547878", WillAttend=true
            });
            _users.Add(new UserInfo()
            {
                Id=3,Name="Enes",Email="enes@gmail.com",Phone="05211544845", WillAttend=false
            });
             _users.Add(new UserInfo()
            {
                Id=4,Name="Alptuğ",Email="alptug@gmail.com",Phone="05211544845", WillAttend=true
            });
              _users.Add(new UserInfo()
            {
                Id=5,Name="Hira",Email="hira@gmail.com",Phone="05211544855", WillAttend=true
            });
        }

        public static List<UserInfo> Users
        {
            get{
                return _users;
            }
        }

        public static void CreateUser(UserInfo user)
        {
            user.Id = Users.Count + 1;
            _users.Add(user);
        }

        public static UserInfo? GetById(int id)
        {
            return _users.FirstOrDefault(user=>user.Id==id);
        }
    }
}