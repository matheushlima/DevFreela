﻿using DevFreela.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task SaveChangesAsync();
        Task AddAsync(Project project);
        Task AddCommentAsync(ProjectComment projectComment);
    }
}
