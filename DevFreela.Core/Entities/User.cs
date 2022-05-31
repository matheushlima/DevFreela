using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime brithdate)
        {
            FullName = fullName;
            Email = email;
            Brithdate = brithdate;
            Active = true;

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
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project>  Freelanceprojects{ get; private set; }
        public List<ProjectComment> Comments { get; private set; }
    }
}
