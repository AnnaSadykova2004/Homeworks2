using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UnitTests
{
    [TestFixture]
    public class AmbulatoryPatientTests
    {
        AmbulatoryPatient man3;

        [SetUp]

        public void Setup()
        {
            man3 = new AmbulatoryPatient("Никита", "Лебедев", 9826483265221713, "Кольцова Дмитрия Витальевича");
        }

        [Test]
        public void ConstructorAPTest()
        {
            Assert.That(man3.DoctorInitials, Is.EqualTo("Кольцова Дмитрия Витальевича"));
        }

        [Test]
        public void GetInfoTest()
        {
            var expected = "Никита Лебедев. Номер полиса: 9826483265221713. " +
                $"Амбулаторный пациент под наблюдением Кольцова Дмитрия Витальевича.";

            Assert.That(man3.GetInfo(), Is.EqualTo(expected));
        }
    }
}
