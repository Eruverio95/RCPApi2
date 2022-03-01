using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Repository.Exceptions
{
  public class QuestionnaireException : Exception
  {
    public QuestionnaireException(string message) : base(message)
    {
    }
  }
}
