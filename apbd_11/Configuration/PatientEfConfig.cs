using apbd_11.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_11.Configuration
{
    public class PatientEfConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {

            builder.HasKey(e => e.IdPatient);
            builder.Property(e => e.IdPatient).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired();
            builder.ToTable("Patient");
            builder.HasMany(d => d.Prescriptions)
                  .WithOne(p => p.Patient)
                  .HasForeignKey(p => p.idPatient)
                  .IsRequired();

            var patients = new List<Patient>();
            patients.Add(new Patient
            {
                IdPatient = 1,
                FirstName = "Bruce",
                LastName = "Johns",
                BirthDate = new DateTime(1991, 1, 1)
            });
            patients.Add(new Patient
            {
                IdPatient = 2,
                FirstName = "Mike",
                LastName = "Tenesy",
                BirthDate = new DateTime(1999, 2, 3)
            });
            patients.Add(new Patient
            {
                IdPatient = 3,
                FirstName = "James",
                LastName = "McDonalds",
                BirthDate = new DateTime(1999, 2, 3)
            });
            builder.HasData(patients);

        }
    }
}
