using apbd_11.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_11.Configuration
{
    public class DoctorEfConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {

            builder.HasKey(e => e.IdDoctor);
            builder.Property(e => e.IdDoctor).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.ToTable("Doctor");
            builder.HasMany(d => d.Prescriptions)
                .WithOne(p => p.Doctor)
                .HasForeignKey(p => p.IdDoctor)
                .IsRequired();

            var doctors = new List<Doctor>();
            doctors.Add(new Doctor
            {
                IdDoctor = 1,
                FirstName = "James",
                LastName = "Brown",
                Email = "adqwrq@dasas.com"
            });
            doctors.Add(new Doctor
            {
                IdDoctor = 2,
                FirstName = "Sam",
                LastName = "Smith",
                Email = "dsadc@dasas.com"
            });

            doctors.Add(new Doctor
            {
                IdDoctor = 3,
                FirstName = "Josha",
                LastName = "Bush",
                Email = "fasfacccv@dasas.com"
            });
            builder.HasData(doctors);
        }
    }
}
