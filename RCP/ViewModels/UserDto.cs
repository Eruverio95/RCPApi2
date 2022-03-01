using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.ViewModels
{
    public class UserCommandDto
    {
      public string FirstName { get; set; }
        public string LastName { get; set; }    
    }

    public class UserQueryDto
    {
      public string Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
    }
}
