using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Data.DataContext;
using WebApi.Models.Model;

namespace WebApi.Data.DatabaseAccess
{
    public class RepositoryMedication : IRepositoryMedication
    {
        /// <summary>
        /// Gets all medications
        /// </summary>
        /// <returns>An enumerable of all medications</returns>
        public IEnumerable<MedicationModel> GetMedications()
        {
            using (var context = new DBMedicationContext())
            {
                return context.Medications.ToList();
            }
        }

        /// <summary>
        /// Creates a medication record
        /// </summary>
        /// <param name="medication">The object to be saved</param>
        /// <returns>If true, object sucessful saved</returns>
        public bool CreateMedication(MedicationModel medication)
        {
            using (var context = new DBMedicationContext())
            {
                medication.Id = Guid.NewGuid();
                context.Medications.Add(medication);
                context.Entry(medication).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                var saved = context.SaveChanges();

                return saved > 0;
            }
        }

        /// <summary>
        /// Deletes a medication record
        /// </summary>
        /// <param name="medication">The id of the object to be deleted</param>
        /// <returns>If true, object sucessful saved</returns>
        public bool DeleteMedication(Guid medicationId)
        {
            using (var context = new DBMedicationContext())
            {
                var medicationDelete = context.Medications.FirstOrDefault(s => s.Id == medicationId);

                if (medicationDelete == null)
                {
                    return false;
                }

                context.Medications.Remove(medicationDelete);
                context.Entry(medicationDelete).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                var saved = context.SaveChanges();

                return saved > 0;
            }
        }
    }
}
