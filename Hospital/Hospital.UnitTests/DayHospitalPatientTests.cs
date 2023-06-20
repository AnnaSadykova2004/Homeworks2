using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UnitTests
{
    [TestFixture]
    public class DayHospitalPatientTests
    {
        DayHospitalPatient man2;

        [SetUp]
        public void Setup()
        {
            man2 = new DayHospitalPatient("Виктор", "Скворцов", 7456381284533791, DateTime.Parse("01.04.2023 12:00:00"), DateTime.Parse("01.04.2023 14:00:00"));
        }

        [Test]
        public void ConstructorDHPTest()
        {
            Assert.That(man2.ArrivalTime, Is.EqualTo(DateTime.Parse("01.04.2023 12:00:00")));
            Assert.That(man2.LeavingTime, Is.EqualTo(DateTime.Parse("01.04.2023 14:00:00")));
        }

        [Test]
        public void GetInfoTest()
        {
            var expected = "Виктор Скворцов. Номер полиса: 7456381284533791. " +
                $"Время прихода пациента дневного стационара 01.04.2023 12:00:00. Время его ухода 01.04.2023 14:00:00.";

            Assert.That(man2.GetInfo(), Is.EqualTo(expected));
        }
    }
}
