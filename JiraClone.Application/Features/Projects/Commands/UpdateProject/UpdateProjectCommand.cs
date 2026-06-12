using JiraClone.Application.Interfaces.Repositories;
using JiraClone.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Application.Features.Projects.Commands.UpdateProject
{
    public record UpdateProjectCommand(string Id, string Name, string Description) : IRequest<Unit>;


    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project == null)
            {
                throw new System.Exception("Project not found!");
            }

            project.Name = request.Name;
            project.Description = request.Description;

            _projectRepository.Update(project);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    

        }
}
