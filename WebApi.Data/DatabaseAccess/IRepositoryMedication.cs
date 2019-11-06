using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Models.Model;

namespace WebApi.Data.DatabaseAccess
{
    public interface IRepositoryMedication
    {
        IEnumerable<MedicationModel> GetMedications();

        bool CreateMedication(MedicationModel medication);

        bool DeleteMedication(Guid medicationId);
    }
}
