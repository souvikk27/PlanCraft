using Microsoft.EntityFrameworkCore;

namespace Plancraft.Domain.Repository.Abstraction;

public interface IRepositoryOptions<TContext> where TContext : DbContext
{
    TContext Context { get; }
}