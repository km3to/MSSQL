namespace PhotoShare.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Client.Core.Commands;
    using Client;

    [TestClass]
    public class RegisterCommandTests
    {
        [TestMethod]
        public void Register_NewUser_Should_SuccessMessage()
        {
            string[] commandParameters = new string[] { "username", "passw0rd", "passw0rd" , "user@u.com" };

            RegisterUserCommand registerUser = new RegisterUserCommand();
            string result = registerUser.Execute(commandParameters);

            Assert.AreEqual($"User {commandParameters[0]} was registered successfully!", result);
        }
    }
}
