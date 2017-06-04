namespace PhotoShare.Client.Core
{
    using Commands;
    using System;
    using System.Linq;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string commandAsString = commandParameters[0].ToLower();
            string[] arguments = commandParameters.Skip(1).ToArray();

            switch (commandAsString)
            {
                case "login":
                    var loginCmd = new LoginCommand();
                    return loginCmd.Execute(arguments);
                case "logout":
                    var logoutCmd = new LogoutCommand();
                    return logoutCmd.Execute();
                case "addtag":
                    var addTagCmd = new AddTagCommand();
                    return addTagCmd.Execute(arguments);
                default:
                    throw new InvalidOperationException($"Command {commandParameters[0]} not valid!");
            }
        }
    }
}
