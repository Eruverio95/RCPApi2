using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCP.Data;
using RCP.Repository.Interfaces;

namespace RCP.Repository
{
  public class Repository<T> : IRepository<T> where T : class
  {
    protected readonly RCPDbContext set;

    protected readonly DbSet<T> _set;

    public Repository(RCPDbContext context)
    {
      set = context;
      _set = context.Set<T>();
    }

    public IQueryable<T> Queryable => AsQueryable();

    protected virtual IQueryable<T> AsQueryable()
    {
      return _set.AsQueryable();
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
      return await set.SaveChangesAsync(cancellationToken) > 0;
    }
  }
}
