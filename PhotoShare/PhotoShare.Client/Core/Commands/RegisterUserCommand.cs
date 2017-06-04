namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Models;
    using Service;

    public class RegisterUserCommand
    {
        public RegisterUserCommand(UserService service)
        {

        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string email = data[3];

            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

            // TODO:
            

            return "User " + user.Username + " was registered successfully!";
        }
    }
}
