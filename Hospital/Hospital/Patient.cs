using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Patient
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
}
