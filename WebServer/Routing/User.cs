namespace Routing
{
    public class User
    {
        private string userId;
        public string name;
        private string surname;
        private bool authorized;

        public User()
        {

            authorized = false;
        }

        public User(string userId, string name, string surname)
        {
            this.userId = userId;
            this.name = name;
            this.surname = surname;
            authorized = true;
        }
    }
}
