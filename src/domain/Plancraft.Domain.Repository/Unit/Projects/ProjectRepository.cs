using Microsoft.EntityFrameworkCore;
using Plancraft.Domain.Models;
using Plancraft.Domain.Repository.Abstraction;
using System.Linq.Expressions;

namespace Plancraft.Domain.Repository.Unit.Projects
{
    public class ProjectRepository : RepositoryBase<Project, PlancraftContext>
    {
        public ProjectRepository(IRepositoryOptions<PlancraftContext> options) : base(options)
        {
        }

        public override Expression<Func<PlancraftContext, DbSet<Project>>> DataSet() => o => o.Projects;
        public override Expression<Func<Project, object>> Key() => o => o.ProjectId;
    }
}
