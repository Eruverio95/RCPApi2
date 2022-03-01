using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Models
{
    public class User
    {
      public User()
      {
        Measurements = new HashSet<Measurement>();
      }

      public string Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public ICollection<Measurement> Measurements { get; set; }
    }
}
