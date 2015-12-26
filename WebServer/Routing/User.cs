namespace Routing
{
    public class User
    {
        private string userId;
        public string login;
        private string password;
        private bool authorized;

        public User()
        {

            authorized = false;
        }

        public User(string userId, string login, string password)
        {
            this.userId = userId;
            this.login = login;
            this.password = password;
            authorized = true;
        }
    }
}
