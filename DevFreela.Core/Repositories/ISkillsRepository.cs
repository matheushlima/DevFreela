using DevFreela.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface ISkillsRepository
    {
        Task<List<Skill>> GetAllAsync();
    }
}
