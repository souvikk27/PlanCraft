using Microsoft.EntityFrameworkCore;
using Plancraft.Domain.Repository.Abstraction;

namespace Plancraft.Domain.Repository.Unit;

public class RepositoryOptions<TContext> : IRepositoryOptions<TContext> where TContext : DbContext
{
    private readonly TContext _context;

    public RepositoryOptions(TContext context)
    {
        _context = context;
    }

    public TContext Context => _context;
}