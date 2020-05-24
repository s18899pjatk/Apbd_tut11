using apbd_11.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_11.Entities
{
    public class DoctorDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        public DoctorDbContext()
        {

        }

        public DoctorDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoctorEfConfig());
            modelBuilder.ApplyConfiguration(new MedicamentEfConfig());
            modelBuilder.ApplyConfiguration(new PatientEfConfig());
            modelBuilder.ApplyConfiguration(new Prescription_MedicamentEfConfig());
            modelBuilder.ApplyConfiguration(new PrescriptonEfConfig());
        }
    }
}
