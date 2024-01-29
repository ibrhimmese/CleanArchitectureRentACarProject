using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.UsertId).HasColumnName("UserId").IsRequired();
        builder.Property(u => u.Token).HasColumnName("Token").IsRequired();
        builder.Property(u => u.Expires).HasColumnName("Expires").IsRequired();
        builder.Property(u => u.CreatedByIp).HasColumnName("CreatedByIp").IsRequired();
        builder.Property(u => u.Revoked).HasColumnName("Revoked");
        builder.Property(u => u.RevokedByIp).HasColumnName("RevokedByIp");
        builder.Property(u => u.ReplacedByIp).HasColumnName("ReplacedByIp");
        builder.Property(u => u.ReplacedByToken).HasColumnName("ReplacedByToken");
        builder.Property(u => u.ReasonRevoked).HasColumnName("ReasonRevoked");
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasOne(u => u.User);
    }
}