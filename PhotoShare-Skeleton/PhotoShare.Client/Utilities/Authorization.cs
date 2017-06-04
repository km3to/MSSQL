
namespace PhotoShare.Client.Utilities
{
    using Models;
    using System.Linq;

    class Authorization
    {
        private static Authorization instance;

        private User currentUser;

        private Authorization()
        {
        }

        public static Authorization Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Authorization();
                }
                return instance;
            }
        }

        public User CurrentUser
        {
            get { return this.currentUser; }
        }

        public bool Login(string username, string password)
        {
            if (this.currentUser != null)
            {
                throw new System.ArgumentException("User has logged in already!");
            }

            using(var context = new PhotoShareContext())
            {
                User user = context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

                if (user == null)
                {
                    throw new System.ArgumentException("Either user does not exist or password does not match!");
                }
                else
                {
                    this.currentUser = user;
                    return true;
                }
            }
        }

        public string Logout()
        {
            if (this.currentUser == null)
            {
                throw new System.InvalidOperationException("There is no user Logged in.");
            }

            string name = this.currentUser.Username;
            this.currentUser = null;
            return name;
        }

        public void ValidateuserIsLoggedIn()
        {
            if (this.currentUser == null)
            {
                throw new System.InvalidOperationException("You need to be logged in for thie operation.");
            }
        }
    }
}
