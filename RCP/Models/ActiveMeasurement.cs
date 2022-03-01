using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Models
{
  public class ActiveMeasurement
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public DateTime DateTimeStart { get; set; }
    public int MeasurementId { get; set; }
    public Measurement Measurement { get; set; }
  }
}
