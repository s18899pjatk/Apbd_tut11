using apbd_11.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_11.Configuration
{
    public class PrescriptonEfConfig : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {

            builder.HasKey(e => e.IdPrescription);
            builder.Property(e => e.IdPrescription).ValueGeneratedOnAdd();
            builder.ToTable("Prescription");

            var prescriptions = new List<Prescription>();
            prescriptions.Add(new Prescription
            {
                IdPrescription = 1,
                IdDoctor = 1,
                idPatient = 1,
                Date = new DateTime(),
                DueDate = new DateTime(2021, 2, 1),
            });
            prescriptions.Add(new Prescription
            {
                IdPrescription = 2,
                IdDoctor = 1,
                idPatient = 1,
                Date = new DateTime(),
                DueDate = new DateTime(2022, 3, 1),
            });
            prescriptions.Add(new Prescription
            {
                IdPrescription = 3,
                IdDoctor = 3,
                idPatient = 2,
                Date = new DateTime(2019, 11, 11),
                DueDate = new DateTime(2022, 4, 1),
            });

            builder.HasData(prescriptions);
        }
    }
}
