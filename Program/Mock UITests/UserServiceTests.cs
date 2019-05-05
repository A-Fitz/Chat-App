using System.Collections.Generic;
using ChatApp;
using ChatApp.Interfaces;
using ChatApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Mock_UITests
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<MessageService> mockMessageService;
        private Mock<ServerConnection> mockServerConnection;

        private readonly IUserService userService;

        public UserServiceTests()
        {
            mockServerConnection = new Mock<ServerConnection>();
            mockMessageService = new Mock<MessageService>(mockServerConnection.Object);
            userService = new UserService(mockServerConnection.Object, mockMessageService.Object);
        }

        [TestMethod]
        public void Register20CharacterUsernameReturnsSuccessMessage()
        {
            //Assemble
            mockMessageService.Setup(x => x.CheckForMessages()).Returns(true);
            mockMessageService.Setup(x => 
                x.GetMessages()).Returns(
                    new List<TCPMessage>
                    {
                        new TCPMessage
                        {
                            chatID = 0,
                            command = "SUCCESS",
                            message = "Registration Successful!"
                        }
                    }
                );

            mockMessageService.Setup(x => x.SendMessage(
                new TCPMessage
                {
                    chatID = 0,
                    command = "REGISTER",
                    message = "Thisisa20characterUNPassword1234"
                }
            ));

            //Act
            var result = userService.RegisterUser("Thisisa20characterUN", "Password1234");

            //Assert
            Assert.AreEqual(result.command, "SUCCESS");

        }

        [TestMethod]
        public void RegisterUserUnder20CharactersReturnsSuccessful()
        {
            //Assemble
            mockMessageService.Setup(x => x.CheckForMessages()).Returns(true);
            mockMessageService.Setup(x =>
                x.GetMessages()).Returns(
                    new List<TCPMessage>
                    {
                        new TCPMessage
                        {
                            chatID = 0,
                            command = "SUCCESS",
                            message = "Registration Successful!"
                        }
                    }
                );

            mockMessageService.Setup(x => x.SendMessage(
                new TCPMessage
                {
                    chatID = 0,
                    command = "REGISTER",
                    message = "Thisisa20characterUNPassword1234"
                }))
                .Callback((TCPMessage msg) => {}).Returns(EnumMessageStatus.successful);

            //Act
            var result = userService.RegisterUser("user", "password");

            //Assert
            Assert.AreEqual(result.command, "SUCCESS");
        }

        [TestMethod]
        public void RegisterUserReturnsUsernameTaken()
        {
            //Assemble
            mockMessageService.Setup(x => x.CheckForMessages()).Returns(true);
            mockMessageService.Setup(x =>
                x.GetMessages()).Returns(
                    new List<TCPMessage>
                    {
                        new TCPMessage
                        {
                            chatID = 0,
                            command = "EXCEPTION",
                            message = "Username taken."
                        }
                    }
                );

            //Act
            var result = userService.RegisterUser("user", "password");

            //Assert
            Assert.AreEqual(result.command, "EXCEPTION");
            Assert.AreEqual(result.message, "Username taken.");
        }

        [TestMethod]
        public void IncorrectLoginValuesReturnsBadLogin()
        {
            //Assemble
            mockMessageService.Setup(x => x.CheckForMessages()).Returns(true);
            mockMessageService.Setup(x =>
                x.GetMessages()).Returns(
                    new List<TCPMessage>
                    {
                        new TCPMessage
                        {
                            chatID = 0,
                            command = "EXCEPTION",
                            message = "Login failed. Username or password is incorrect."
                        }
                    }
                );

            //Act
            var result = userService.Login("user", "password");

            //Assert
            Assert.AreEqual(result.command, "EXCEPTION");
            Assert.AreEqual(result.message, "Login failed. Username or password is incorrect.");
        }


    }
}
