using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Repository.Exceptions
{
  public class MeasurementException : Exception
  {
    public MeasurementException(string message) : base(message)
    {
    }
  }
}
