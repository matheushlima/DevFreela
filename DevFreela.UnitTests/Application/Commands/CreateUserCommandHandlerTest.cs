using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTest
    {
        [Fact]
        public async Task InputDataUser_Executed_InsertUser()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            authServiceMock.Setup(s => s.ComputeSha256Hash("456546876"));

            var createUserCommand = new CreateUserCommand 
            { 
                FullName = "Teste Teste Teste", 
                Brithdate = DateTime.Now, 
                Email = "teste@gmail.com", 
                Password = "teste123",
                Role = "user"
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

            //Act
            await createUserCommandHandler.Handle(createUserCommand, new System.Threading.CancellationToken());

            //Assert
            userRepositoryMock.Verify(ur => ur.AddAsync(It.IsAny<User>()), Times.Once);
            authServiceMock.Verify(s => s.ComputeSha256Hash(It.IsAny<string>()), Times.Once);
        }
    }
}
