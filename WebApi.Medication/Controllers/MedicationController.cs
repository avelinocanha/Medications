using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Data.DatabaseAccess;
using WebApi.Models.Model;

namespace WebApi.Medication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationController : ControllerBase
    {
        private readonly ILogger<MedicationController> _logger;
        private readonly IRepositoryMedication _repositoryMedication;

        public MedicationController(ILogger<MedicationController> logger,
            IRepositoryMedication repositoryMedication)
        {
            _logger = logger;
            _repositoryMedication = repositoryMedication;
        }

        /// <summary>
        /// Gets all medications
        /// </summary>
        /// <returns>An enumerable of all medications</returns>
        [HttpGet]
        [Route("getmedications")]
        public IEnumerable<MedicationModel> GetMedications()
        {
            try
            {
                var medications = _repositoryMedication.GetMedications();
                _logger.LogInformation("Get medications");

                return medications;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Creates a medication
        /// </summary>
        /// <returns>Boolean if created or not/returns>
        [HttpPost]
        [Route("createmedication")]
        public bool CreateMedication(MedicationModel medication)
        {
            try
            {
                var created = _repositoryMedication.CreateMedication(medication);
                _logger.LogInformation("Create medication " + medication.Name);

                return created;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Deletes a medication
        /// </summary>
        /// <returns>Boolean if deleted or not/returns>
        [HttpDelete]
        [Route("deletemedication/{medicationId}")]
        public bool DeleteMedication(Guid medicationId)
        {
            try
            {
                var created = _repositoryMedication.DeleteMedication(medicationId);
                _logger.LogInformation("Deleted medication " + medicationId);

                return created;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
