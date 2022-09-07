using DevFreela.Application.Commands.CreateComment;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateCommentCommandHandlerTest
    {
        [Fact]
        public async Task InputData_Executed_InsertComment()
        {
            //Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var createComment = new CreateCommentCommand 
            { 
                Content = "Teste", 
                IdProject = 1, 
                IdUser = 2
            };

            var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepositoryMock.Object);

            //Act
            var ret = await createCommentCommandHandler.Handle(createComment, new System.Threading.CancellationToken());

            //Assert
            projectRepositoryMock.Verify(pr => pr.AddCommentAsync(It.IsAny<ProjectComment>()), Times.Once);
        }
    }
}
