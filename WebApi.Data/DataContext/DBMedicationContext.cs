using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Models.Model;

namespace WebApi.Data.DataContext
{
    public class DBMedicationContext : DbContext
    {
        public DBMedicationContext(DbContextOptions<DBMedicationContext> options)
            : base(options)
        { }

        public DBMedicationContext() { }

        public DbSet<MedicationModel> Medications { get; set; }
    }
}
