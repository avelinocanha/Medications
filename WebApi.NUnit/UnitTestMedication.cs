using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.Net.Http;
using WebApi.Medication.Controllers;

namespace WebApi.NUnit
{
    public class UnitTestMedication
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetMedications()
        {
            Assert.Pass();
        }
    }
}