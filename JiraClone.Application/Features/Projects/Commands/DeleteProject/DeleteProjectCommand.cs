using JiraClone.Application.Interfaces.Repositories;
using JiraClone.Application.Interfaces;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Application.Features.Projects.Commands.DeleteProject
{
    public record DeleteProjectCommand(string Id) : IRequest<Unit>;

        public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand,Unit>
    {

        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request,CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project == null)
            {
                throw new System.Exception("Project not found!");
            }

            _projectRepository.Delete(project);

            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }

    }
}
