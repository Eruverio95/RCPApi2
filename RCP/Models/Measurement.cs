using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Models
{
  public class Measurement
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public int ActivityId { get; set; }
    public Activity Activity { get; set; }
    public DateTime DateTimeStart { get; set; }
    public DateTime DateTimeEnd { get; set; }
    public int Seconds { get; set; }
    public Enumerators.Enumerators.MeasurementStatus Status { get; set; }
  }
}
