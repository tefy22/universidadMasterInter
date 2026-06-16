using Domain.Roles;
using Domain.Students;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DNId)
                .HasConversion(u => u.Value, v => DNI.Create(v).Value)
                .IsRequired()
                .HasMaxLength(10);
            builder.HasIndex(x => x.DNId);

            builder.Property(x => x.Name)
                    .HasConversion(n => n!.Value, v => Name.Create(v).Value)
                    .IsRequired()
                    .HasMaxLength(200);

            builder.Property(x => x.LastName)
                .HasConversion(n => n.Value, v => LastName.Create(v).Value)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Email)
                .HasConversion(e => e!.Value, v => Email.Create(v).Value)
                .IsRequired()
                .HasMaxLength(400);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.PhoneNumber)
                .HasConversion(e => e.Value, v => PhoneNumber.Create(v).Value)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(u => u.Password)
                .HasConversion(e => e.Value, v => Password.Create(v).Value)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.RolId)
                .HasColumnName("RolId")
                .IsRequired();
           
            builder.Property(x => x.Status)
                   .HasConversion<int>() // guarda como int en la BD
                   .HasDefaultValue(StatusDetails.Active)
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.HasOne<Rol>()
                .WithMany()
                .HasForeignKey(x => x.RolId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.Property<uint>("Version").IsRowVersion();
        }
    }
}
