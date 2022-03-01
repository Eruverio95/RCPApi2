using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.ViewModels
{
  public class ActiveMeasurementCommandDto
  {
    public string UserId { get; set; }
    public DateTime DateTimeStart { get; set; }
    public int MeasurementId { get; set; }
  }

  public class ActiveMeasurementQueryDto
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public DateTime DateTimeStart { get; set; }
    public int MeasurementId { get; set; }
  }
}