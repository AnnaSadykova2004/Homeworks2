using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Patient : IComparable<Patient>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public readonly long PoliceNumber;
        public DateTime AdmissionDate;
        public DateTime DischargeDate;
        public Service Service;
        public int TreatmentCost;

        public Patient(string name, string surname, long policeNumber)
        {
            Name = name;
            Surname = surname;
            PoliceNumber = policeNumber;
        }

        public virtual string GetInfo()
        {
            return $"{Name} {Surname}. Номер полиса: {PoliceNumber}. ";
        }

        public int CompareTo(Patient other)
        {
            if (Surname != other.Surname)
                return Surname.CompareTo(other.Surname);
            else return Name.CompareTo(other.Name);
        }
    }

    public class HospitalPatient : Patient
    {
        public string Department { get; set; }
        public int RoomNumber { get; set; }
        public HospitalPatient(string name, string surname, long policeNumber, string department, int roomNumber) : base(name, surname, policeNumber)
        {
            Department = department;
            RoomNumber = roomNumber;
        }

        public override string GetInfo() => base.GetInfo() +
            $"Пациент стационара из {Department} отделения. Проходит лечение в палате {RoomNumber}.";
    }

    public class DayHospitalPatient : Patient
    {
        public DateTime ArrivalTime { get; set; }
        public DateTime LeavingTime { get; set; }

        public DayHospitalPatient(string name, string surname, long policeNumber, DateTime arrivalTime, DateTime leavingTime) : base(name, surname, policeNumber)
        {
            ArrivalTime = arrivalTime;
            LeavingTime = leavingTime;
        }

        public override string GetInfo() => base.GetInfo() +
            $"Время прихода пациента дневного стационара {ArrivalTime}. Время его ухода {LeavingTime}.";
    }

    public class AmbulatoryPatient : Patient
    {
        public string DoctorInitials { get; set; }

        public AmbulatoryPatient(string name, string surname, long policeNumber, string doctorInitials) : base(name, surname, policeNumber)
        {
            DoctorInitials = doctorInitials;
        }
        public override string GetInfo() => base.GetInfo() +
            $"Амбулаторный пациент под наблюдением {DoctorInitials}.";
    }

    public class PoliceNumberComparer : IComparer<Patient>
    {
        public int Compare(Patient x, Patient y)
        {
            return (int)y.PoliceNumber - (int)x.PoliceNumber;
        }
    }

    public class Section : IEnumerable<Patient>
    {
        public string Title { get; set; }
        public readonly int PatientsQuantity;
        List<Patient> patientsList;

        public int Count { get => patientsList.Count; }
        public Section(string title, int patientsQuantity, IEnumerable<Patient> patients)
        {
            Title = title;
            PatientsQuantity = patientsQuantity;

            patientsList = new List<Patient>(patients.Distinct());
        }

        public IEnumerator<Patient> GetEnumerator() => patientsList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
