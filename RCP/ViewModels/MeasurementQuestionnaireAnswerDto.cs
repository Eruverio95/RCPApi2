using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.ViewModels
{
  public class MeasurementQuestionnaireAnswerCommandDto
  {
    public int MeasurementId { get; set; }
    public string Value { get; set; }
  }

  public class MeasurementQuestionnaireAnswerQueryDto
  {
    public int Id { get; set; }
    public int MeasurementId { get; set; }
    public string Value { get; set; }
  }
}
