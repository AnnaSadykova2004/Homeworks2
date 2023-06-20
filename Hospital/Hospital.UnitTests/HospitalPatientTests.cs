using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UnitTests
{
    [TestFixture]
    public class HospiatalPatientTests
    {
        HospitalPatient man1;

        [SetUp]
        public void Setup()
        {
            man1 = new HospitalPatient("Алексей", "Новиков", 3456789234561264, "неврологического", 105);
        }

        [Test]
        public void ConstructorHPTest()
        {
            Assert.That(man1.Department, Is.EqualTo("неврологического"));
            Assert.That(man1.RoomNumber, Is.EqualTo(105));
        }

        [Test]
        public void GetInfoTest()
        {
            var expected = "Алексей Новиков. Номер полиса: 3456789234561264. " +
                $"Пациент стационара из неврологического отделения. Проходит лечение в палате 105.";

            Assert.That(man1.GetInfo(), Is.EqualTo(expected));
        }       
    }
}
