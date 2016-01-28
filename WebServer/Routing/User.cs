namespace Routing
{
    public class User
    {
        private string userId;
        private string name;
        private string surname;
        private bool authorized;

        public User()
        {
            authorized = false;
        }

        public bool Authorized
        {
            get { return authorized; }
            set { authorized = value; }
        }

        public string Name { get { return name; } }

        public void SetUser(string userId, string name, string surname)
        {
            this.userId = userId;
            this.name = name;
            this.surname = surname;
            authorized = true;
        }
    }
}
