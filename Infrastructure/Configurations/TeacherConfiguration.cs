using Domain.Students;
using Domain.Theachers;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal sealed class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable(nameof(Teacher));

            builder.HasKey(x => x.Id);

            var dniConverter = new ValueConverter<DNI, int>(d => d.Value, v => DNI.Create(v).Value);
            var nameConverter = new ValueConverter<Name, string>(n => n.Value, v => Name.Create(v).Value);
            var lastNameConverter = new ValueConverter<LastName, string>(ln => ln.Value, v => LastName.Create(v).Value);
            var emailConverter = new ValueConverter<Email, string>(e => e.Value, v => Email.Create(v).Value);
            var phoneConverter = new ValueConverter<PhoneNumber, string>(p => p.Value, v => PhoneNumber.Create(v).Value);


            builder.Property(x => x.DNId)
                .HasConversion(dniConverter)
                .IsRequired()
                .HasMaxLength(10);
            builder.HasIndex(x => x.DNId);

            builder.Property(x => x.Name)
                    .HasConversion(nameConverter)
                    .IsRequired()
                    .HasMaxLength(200);

            builder.Property(x => x.LastName)
                .HasConversion(lastNameConverter)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Email)
                .HasConversion(emailConverter)
                .IsRequired()
                .HasMaxLength(400);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.PhoneNumber)
                .HasConversion(phoneConverter)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("datetime2")
                .IsRequired();
        }
    }
}
