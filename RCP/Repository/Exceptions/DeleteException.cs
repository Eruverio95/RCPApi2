using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Repository.Exceptions
{
  public class DeleteException : Exception
  {
    public DeleteException(string message) : base(message)
    {
    }
  }
}
