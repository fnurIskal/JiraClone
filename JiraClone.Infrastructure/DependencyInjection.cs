using JiraClone.Application.Interfaces;
using JiraClone.Application.Interfaces.Repositories;
using JiraClone.Infrastructure.Persistance;
using JiraClone.Infrastructure.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IProjectRepository,ProjectRepository>();
            services.AddScoped<ITaskItemRepository,TaskItemRepository>();
            services.AddScoped<ICommentRepository,CommentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
