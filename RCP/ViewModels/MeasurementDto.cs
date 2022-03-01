using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.ViewModels
{
  public class MeasurementCommandDto
  {
    public string UserId { get; set; }
    public int ActivityId { get; set; }
    public DateTime DateTimeStart { get; set; }
    public DateTime? DateTimeEnd { get; set; }
    public int Seconds { get; set; }
    public int Status { get; set; }
  }

  public class MeasurementQueryDto
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public int ActivityId { get; set; }
    public DateTime DateTimeStart { get; set; }
    public DateTime? DateTimeEnd { get; set; }
    public int Seconds { get; set; }
    public int Status { get; set; }
  }
}
