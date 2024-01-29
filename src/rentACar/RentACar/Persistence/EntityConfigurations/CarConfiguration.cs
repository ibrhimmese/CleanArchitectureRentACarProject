using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(b => b.Id);

        builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
        builder.Property(f => f.ModelId).HasColumnName("ModelId").IsRequired();
        builder.Property(f => f.Kilometer).HasColumnName("Kilometer").IsRequired();
        builder.Property(f => f.CarState).HasColumnName("State");
        builder.Property(f => f.ModelYear).HasColumnName("ModelYear");
        

        builder.HasOne(f => f.Model);

        builder.HasQueryFilter(f => !f.DeletedDate.HasValue);  //? no data
    }
}