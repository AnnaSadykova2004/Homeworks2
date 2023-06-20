using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UnitTests
{
    [TestFixture]
    public class SectionTests
    {
        Section section;

        HospitalPatient[] hospitalPatients;

        [SetUp]
        public void Setup()
        {
            var анатолий = new HospitalPatient("Анатолий", "Фролов", 2378752381606532, "неврологического", 107);

            var николай = new HospitalPatient("Николай", "Некрасов", 3478862392607632, "терапевтического", 103);

            var егор = new HospitalPatient("Егор", "Аверин", 4578972353608732, "кардиологического", 115);

            //var екатерина = new HospitalPatient("Екатерина", "Павлова", 5673879453624365, "кардиологического", 115);

            //var ольга = new HospitalPatient("Ольга", "Никобенко", 5673879453624365, "терапевтического", 103);

            hospitalPatients = new HospitalPatient[] { анатолий, николай, егор };

            section = new Section("Первое отделение", 3, hospitalPatients);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(section.Title, Is.EqualTo("Первое отделение"));
            Assert.That(section.PatientsQuantity, Is.EqualTo(3));
        }

        [Test]
        public void CountTest()
        {
            Assert.That(section.Count, Is.EqualTo(3));
        }

        [Test]
        public void IEnumerableTest()
        {
            var i = 0;

            foreach (var hospitalPatient in section)
                Assert.That(hospitalPatient, Is.SameAs(hospitalPatients[i++]));
        }
    }
}
