using DevFreela.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetByIdProject
{
    public class GetByIdProjectsQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetByIdProjectsQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
