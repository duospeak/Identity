using Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfigurations
{
    internal class UserEntityTypeConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("sys_user");

            builder.Ignore(x => x.DomainEvents);

            builder.HasIndex(x => x.UserName);

            builder.Property(x => x.TenantId)
                .HasColumnName("TenantID")
                .IsRequired();

            builder.Property(x => x.OrgId)
               .HasColumnName("OrgID")
               .IsRequired();

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .HasColumnType("int(11)")
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("Password")
                .IsRequired();

            builder.Property(x => x.Enable)
                .HasColumnName("Enable")
                .IsRequired();

            builder.Property(x => x.IsLocked)
                .HasColumnName("Is_Locked")
                .IsRequired();

            builder.HasQueryFilter(x => x.Enable);
        }
    }
}
