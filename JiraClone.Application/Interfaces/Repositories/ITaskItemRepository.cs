using JiraClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Application.Interfaces.Repositories
{
    public interface ITaskItemRepository : IGenericRepository<TaskItem>
    {
    }
}
