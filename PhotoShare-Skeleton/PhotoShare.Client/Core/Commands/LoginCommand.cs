namespace PhotoShare.Client.Core.Commands
{
    using Utilities;

    public class LoginCommand
    {
        public string Execute(string[] data)
        {
            Authorization.Instance.Login(data[0], data[1]);
            return $"User {data[0]} successfully logged in!";
        }
    }
}
