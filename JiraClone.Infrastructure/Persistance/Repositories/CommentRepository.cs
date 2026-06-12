using JiraClone.Application.Interfaces.Repositories;
using JiraClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Infrastructure.Persistance.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Comment>> GetCommentsByTaskIdAsync(string taskId)
        {
            return await _dbSet
                .Where(c => c.TaskItemId == taskId)
                .ToListAsync();
        }
    }
}
