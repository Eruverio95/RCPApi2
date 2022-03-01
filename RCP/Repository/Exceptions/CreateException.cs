using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Repository.Exceptions
{
  public class CreateException : Exception
  {
    public CreateException(string message) : base(message)
    {
    }
  }
}
