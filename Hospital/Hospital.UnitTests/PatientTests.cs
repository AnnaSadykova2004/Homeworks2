using System.Diagnostics.Metrics;

namespace Hospital.UnitTests
{
    [TestFixture]
    public class PatientTests
    {
        static Patient patient;

        [SetUp]
        public void Setup()
        {
            patient = new Patient("Петр", "Иванов", 1378652370605432);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(patient.Name, Is.EqualTo("Петр"));
            Assert.That(patient.Surname, Is.EqualTo("Иванов"));
            Assert.That(patient.PoliceNumber, Is.EqualTo(1378652370605432));
        }

        [Test]
        public void GetInfo_Patient_ValueString()
        {
            string expectedInfo = "Петр Иванов. ";
            expectedInfo += "Номер полиса: 1378652370605432. ";

            Assert.That(patient.GetInfo(), Is.EqualTo(expectedInfo));
        }

        [Test]
        public void CompareToTest()
        {
            var анатолий = new HospitalPatient("Анатолий", "Фролов", 2378752381606532, "неврологического", 107);

            var николай = new HospitalPatient("Николай", "Некрасов", 3478862392607632, "терапевтического", 103);

            var егор = new HospitalPatient("Егор", "Аверин", 4578972353608732, "кардиологического", 115);

            Assert.That(николай.CompareTo(анатолий), Is.LessThan(0));
            Assert.That(егор.CompareTo(егор), Is.EqualTo(0));
        }
    }
}