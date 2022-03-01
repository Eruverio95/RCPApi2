using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Enumerators
{
  public class Enumerators
  {
    public enum MeasurementStatus
    {
      Active,
      Suspended,
      Ended,
      Error,
      RequiredQuestionnaire
    }

    public enum QuestionType
    {
      Text,
      List
    }

    //public enum QuestionValidator
    //{
    //  None,
    //  CustomerNumber,
    //  Amount,
    //  Date,
    //  Integer
    //}

    public enum UserRoles
    {
      Administrator = 1,
      User = 2
    }
  }
}
