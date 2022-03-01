using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCP.Models;

namespace RCP.Data.ModelBuilders
{
  public class ActiveMeasurementModelBuilder
  {
    public static void Build(ModelBuilder builder)
    {
      var entity = builder.Entity<ActiveMeasurement>();

      entity.ToTable("ActiveMeasurements");
      entity.HasKey(k => k.Id);
      entity.Property<int>(p => p.Id).IsRequired().HasColumnName("Id");
      entity.Property<string>(p => p.UserId).IsRequired().HasColumnName("UserId").HasMaxLength(8);
      entity.Property<DateTime>(p => p.DateTimeStart).IsRequired().HasColumnName("DateTimeStart").HasColumnType("datetime");
      entity.Property<int>(p => p.MeasurementId).IsRequired().HasColumnName("MeasurementId");
    }
  }
}
