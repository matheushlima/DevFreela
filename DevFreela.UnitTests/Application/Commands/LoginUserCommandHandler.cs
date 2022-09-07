using DevFreela.Application.Commands.LoginUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class LoginUserCommandHandlerTest
    {
        [Fact]
        public async Task InputUserLogin_Executed_ReturnLoginViewModel()
        {
            //Arrange
            var user = new User("Teste", "teste@gmai.com", DateTime.Now, "123Teste", "user");

            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            userRepositoryMock.Setup(us => us.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()).Result).Returns(user);
            authServiceMock.Setup(s => s.ComputeSha256Hash(It.IsAny<string>()));
            authServiceMock.Setup(s => s.GenerateJwtToken(It.IsAny<string>(), It.IsAny<string>())).Returns("Token");

            var loginUserCommand = new LoginUserCommand { Email = user.Email, Password = user.Password };
            var loginUserCommandHandler = new LoginUserCommandHandler(authServiceMock.Object, userRepositoryMock.Object);

            //Act
            var loginUserViewModel = await loginUserCommandHandler.Handle(loginUserCommand, new System.Threading.CancellationToken());

            //Assert
            Assert.NotNull(loginUserViewModel);
            Assert.Equal(user.Email, loginUserViewModel.Email);
            Assert.Equal("Token", loginUserViewModel.Token);

            userRepositoryMock.Verify(us => us.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            authServiceMock.VerifyAll();

        }
    }
}
