using apbd_11.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_11.Configuration
{
    public class Prescription_MedicamentEfConfig : IEntityTypeConfiguration<Prescription_Medicament>
    {
        public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
        {

            builder.HasKey(e => new { e.IdMedicament, e.IdPrescription });
            builder.Property(e => e.Details).IsRequired().HasMaxLength(100);
            builder.ToTable("Prescription_Medicament");
            builder.HasOne(p => p.Prescription)
                .WithMany(pm => pm.Prescription_Medicaments)
                .HasForeignKey(p => p.IdPrescription);
            builder.HasOne(m => m.Medicament)
                .WithMany(pm => pm.Prescription_Medicaments)
                .HasForeignKey(m => m.IdMedicament);

            var prscr_medic = new List<Prescription_Medicament>();
            prscr_medic.Add(new Prescription_Medicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Details = "dope"
            });
            prscr_medic.Add(new Prescription_Medicament
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Details = "fassafsaf",
                Dose = 2
            });

            builder.HasData(prscr_medic);
        }

    }
}
