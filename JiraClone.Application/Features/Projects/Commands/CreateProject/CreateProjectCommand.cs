using JiraClone.Application.Interfaces;
using JiraClone.Application.Interfaces.Repositories;
using JiraClone.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Application.Features.Projects.Commands.CreateProject
{
    public record CreateProjectCommand(string Name, string Description, string CreatedBy) : IRequest<string>
    {


        public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, string>
        {
            private readonly IProjectRepository _projectRepository;
            private readonly IUnitOfWork _unitOfWork;

            public CreateProjectCommandHandler(IProjectRepository projectRepository,IUnitOfWork unitOfWork)
            {
                _projectRepository = projectRepository;
                _unitOfWork = unitOfWork;
            }
            public async Task<string> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
            {
                var project = new Project
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    Description = request.Description,
                    CreatedById = request.CreatedBy,
                    CreatedDate = DateTime.Now,
                };

                await _projectRepository.AddAsync(project);
                await _unitOfWork.SaveChangesAsync();

                return project.Id;

            }
        }
    }
}
