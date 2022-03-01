using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RCP.Repository.Interfaces
{
  public interface IRepository<T> where T : class
  {
    IQueryable<T> Queryable { get; }
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
  }
}
