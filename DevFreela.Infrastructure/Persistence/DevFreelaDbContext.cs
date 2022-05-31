using DevFreela.Core.Entities;
using System.Collections.Generic;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Descricao Projeto 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Descricao Projeto 2", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 3", "Descricao Projeto 1", 1, 1, 30000),
            };

            Users = new List<User>
            {
                new User("Matheus Henrique", "matheus@gmail.com", new System.DateTime(1998,1,1)),
                new User("Luis", "luis@gmail.com", new System.DateTime(1998,1,1)),
                new User("Antonio", "antonio@gmail.com", new System.DateTime(1998,1,1)),
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }
        public List<Project> Projects { get; set; }
        public List<User> Users{ get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }

    }
}
