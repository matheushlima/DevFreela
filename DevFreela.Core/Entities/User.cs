using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime brithdate, string password, string role)
        {
            FullName = fullName;
            Email = email;
            Brithdate = brithdate;
            Active = true;
            Password = password;
            Role = role;

            CreatedAt = DateTime.Now;
            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            Freelanceprojects = new List<Project>();
        }

        public string FullName { get; private set; }
        public string Email{ get; private set; }
        public DateTime Brithdate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public string Password { get; private set; }
        public string  Role { get; private set; }
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project>  Freelanceprojects{ get; private set; }
        public List<ProjectComment> Comments { get; private set; }
    }
}
