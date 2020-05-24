using apbd_11.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_11.Configuration
{
    public class MedicamentEfConfig : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {

            builder.HasKey(e => e.IdMedicament);
            builder.Property(e => e.IdMedicament).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Type).IsRequired().HasMaxLength(100);
            builder.ToTable("Medicament");

            var medicaments = new List<Medicament>();
            medicaments.Add(new Medicament
            {
                IdMedicament = 1,
                Name = "Weed",
                Description = "CBD",
                Type = "C21H30O2"
            });
            medicaments.Add(new Medicament
            {
                IdMedicament = 2,
                Name = "Aspirin",
                Description = "Acid",
                Type = "C9H8O4"
            });

            builder.HasData(medicaments);

        }
    }
}
