using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCP.Models;

namespace RCP.Data.ModelBuilders
{
  public class MeasurementModelBuilder
  {
    public static void Build(ModelBuilder builder)
    {
      var entity = builder.Entity<Measurement>();

      entity.ToTable("Measurements");
      entity.HasKey(k => k.Id);
      entity.Property<int>(p => p.Id).IsRequired().HasColumnName("Id");
      entity.Property<string>(p => p.UserId).IsRequired().HasColumnName("UserId").HasMaxLength(8);
      entity.Property<int>(p => p.ActivityId).IsRequired().HasColumnName("ActivityId");
      entity.Property<DateTime>(p => p.DateTimeStart).IsRequired().HasColumnName("DateTimeStart").HasColumnType("datetime");
      entity.Property<DateTime>(p => p.DateTimeEnd).HasColumnName("DateTimeEnd").HasColumnType("datetime");
      entity.Property<int>(p => p.Seconds).IsRequired().HasColumnName("Seconds");
      entity.Property<Enumerators.Enumerators.MeasurementStatus>(p => p.Status).IsRequired().HasColumnName("Status")
        .HasColumnType("int").HasDefaultValue(Enumerators.Enumerators.MeasurementStatus.RequiredQuestionnaire);
    }
  }
}
