using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Models
{
  public class MeasurementQuestionnaireAnswer
  {
    public int Id { get; set; }
    public int MeasurementId { get; set; }
    public Measurement Measurement { get; set; }
    public string Value { get; set; }
  }
}
