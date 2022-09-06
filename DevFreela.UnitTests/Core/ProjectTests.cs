using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Xunit;

namespace DevFreela.UnitTests.Core
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWork()
        {
            var project = new Project("Meu Teste", "Descrição do meu teste", 1, 1, 10000);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotEmpty(project.Title);
            Assert.NotEmpty(project.Description);

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
            
        }

        [Fact]
        public void TestIfProjectCancelWork()
        {
            var project = new Project("Meu Teste", "Descrição do meu teste", 1, 1, 10000);
            project.Start();

            project.Cancel();

            Assert.Equal(ProjectStatusEnum.Cancelled, project.Status);
        }

        [Fact]
        public void TestIfProjectUpdateWork()
        {
            var project = new Project("Meu Teste", "Descrição do meu teste", 1, 1, 10000);

            project.Update("Meu Teste Mudou", "Mudou a descrição", 20000);

            Assert.Equal("Meu Teste Mudou", project.Title);
            Assert.Equal("Mudou a descrição", project.Description);
            Assert.Equal(20000, project.TotalCost);
        }
    }
}
