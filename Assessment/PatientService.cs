using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    class PatientService : IPatientService
    {
        List<Patient> patients = new List<Patient>();

        public Patient AddPatient(string name, string address, string disease, int age, string doctor, int roomNo)
        {
            Patient p = new Patient(name, address, disease, age, doctor,roomNo);
            patients.Add(p);
            return p;
        }

        public List<Patient> Patients()
        {
            return patients;
        }

        public Patient GetPatientByRoomNo(int roomNo)
        {
            if (patients.Count != 0)
            {
                foreach (Patient patient in patients)
                {
                    if (patient.RoomNo == roomNo)
                    {
                        return patient;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public Patient UpdatePatientRoomNo(string name, string disease, int roomNo)
        {
            if (patients.Count != 0)
            {
                foreach (Patient patient in patients)
                {
                    if (patient.Name == name && patient.Disease == disease)
                    {
                        patient.RoomNo= roomNo;
                        return patient;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
        public Patient UpdatePatientAge(int roomNo, int age)
        {
            if (patients.Count != 0)
            {
                foreach (Patient patient in patients)
                {
                    if (patient.RoomNo == roomNo)
                    {
                        patient.Age = age;
                        return patient;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public Patient UpdatePatientDisease(int roomNo, string disease)
        {
            if (patients.Count != 0)
            {
                foreach (Patient patient in patients)
                {
                    if (patient.RoomNo == roomNo)
                    {
                        patient.Disease = disease;
                        return patient;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public Patient UpdatePatientDoctor(int roomNo, string doctor)
        {
            if (patients.Count != 0)
            {
                foreach (Patient patient in patients)
                {
                    if (patient.RoomNo == roomNo)
                    {
                        patient.Doctor = doctor;
                        return patient;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public void DisplayAll()
        {
            if (patients.Count == 0)
            {
                Console.WriteLine("There are no Patients");
            }
            else
            {
                Console.WriteLine("All Students are show below:");
                foreach (Patient patient in patients)
                {
                    Console.WriteLine("".PadLeft(15, '-'));
                    Console.WriteLine("Room No: " + patient.RoomNo);
                    Console.WriteLine("Name: " + patient.Name);
                    Console.WriteLine("Age: " + patient.Age);
                    Console.WriteLine("Address: " + patient.Address);
                    Console.WriteLine("Disease: " + patient.Disease);
                    Console.WriteLine("Doctor Assigned: " + patient.Doctor);
                }
            }
        }

        public bool DeletePatient(int roomNo)
        {
            if (patients.Count > 0)
            {
                Patient patient = GetPatientByRoomNo(roomNo);
                if (patient != null)
                {
                    patients.Remove(patient);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
