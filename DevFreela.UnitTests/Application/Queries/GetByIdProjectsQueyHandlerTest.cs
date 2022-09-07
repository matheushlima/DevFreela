using DevFreela.Application.Queries.GetByIdProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetByIdProjectsQueyHandlerTest
    {
        [Fact]
        public async Task TwoProjects_Executed_ReturnOneById()
        {
            //Arrange
            var projects = new List<Project>
            {
                new Project("Teste", "Descrição Teste", 1, 2, 20000),
                new Project("Teste", "Descrição Teste", 5, 3, 10000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();

            projectRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()).Result).Returns(projects.SingleOrDefault(p => p.IdClient == 5));

            var getByIdProjectsQuery = new GetByIdProjectsQuery(5);
            var getByIdProjectsQueryHandler = new GetByIdProjectsQueyHandler(projectRepositoryMock.Object);

            //Act
            var projectViewModel = await getByIdProjectsQueryHandler.Handle(getByIdProjectsQuery, new System.Threading.CancellationToken());

            //Assert
            Assert.NotNull(projectViewModel);
            Assert.Equal(10000, projectViewModel.TotalCost);

            projectRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);

        }
    }
}
