using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdUser
{
    public class GetByIdUserQuery : IRequest<UserViewModel>
    {
        public GetByIdUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
