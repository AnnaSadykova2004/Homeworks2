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

    }
}