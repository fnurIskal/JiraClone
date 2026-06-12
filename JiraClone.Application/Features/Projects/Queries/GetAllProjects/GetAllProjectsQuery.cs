using JiraClone.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Application.Features.Projects.Queries.GetAllProjects
{
    public record GetAllProjectsQuery() : IRequest<IEnumerable<GetAllProjectsResponse>>;
    public record GetAllProjectsResponse(string Id, string Name, string Description, DateTime CreatedDate);
    
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery,IEnumerable<GetAllProjectsResponse>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<GetAllProjectsResponse>> Handle(GetAllProjectsQuery request,CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllAsync();

            var response = projects.Select(p => new GetAllProjectsResponse(
                p.Id,
                p.Name,
                p.Description,
                p.CreatedDate
                ));

                return response;
        }
    }
}
