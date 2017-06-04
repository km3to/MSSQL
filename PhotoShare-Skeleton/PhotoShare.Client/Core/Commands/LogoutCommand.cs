namespace PhotoShare.Client.Core.Commands
{
    using Utilities;

    public class LogoutCommand
    {
        public string Execute()
        {
            string name = Authorization.Instance.Logout();

            return $"User {name} successfully logged out!";
        }
    }
}
