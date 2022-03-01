using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Repository.Exceptions
{
  public class UpdateException : Exception
  {
    public UpdateException(string message) : base(message)
    {
    }
  }
}
