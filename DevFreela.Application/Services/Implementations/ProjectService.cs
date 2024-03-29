﻿using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var project = _dbContext.Projects;

            var projectViewModel = project
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CratedAt))
                .ToList();

            return projectViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer )
                .SingleOrDefault(p => p.Id == id);

            if(project == null) return null;

            var projectViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName, 
                project.Freelancer.FullName
                );

            return projectViewModel;
        }
    }
}
