using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    class RoomsError : Exception
    {
        public void Error()
        {
            Console.WriteLine("\nAll Rooms Are Occupied\n");
        }
    }

    class SameRoomError : Exception
    {
        public void Error()
        {
            Console.WriteLine("\nRoom is already Occupied\n");
        }
    }
    class PatientManagementIO
    {
        PatientService patientService = new PatientService();

        public int Menu()
        {
            try
            {
                Console.WriteLine("Press 1 To Add Patient Details");
                Console.WriteLine("Press 2 To Display All Patients Details");
                Console.WriteLine("Press 3 To Edit Patient Details");
                Console.WriteLine("Press 4 To Delete Patient Details");
                Console.WriteLine("Press 0 To Exit");
                int input = Convert.ToInt32(Console.ReadLine());
                return input;
            }
            catch (Exception)
            {
                Console.WriteLine("\nEnter a Valid Input\n");
                return Menu();
            }
        }

        private int NumberOfPatients()
        {
            List<Patient> list1 = patientService.Patients();
            return list1.Count;
        }

        public void AddPatient()
        {
            try {
                int numberOfPatients = NumberOfPatients();
                if (numberOfPatients == 5)
                {
                    throw new RoomsError();
                }
                List<Patient> list1 = patientService.Patients();
                Console.WriteLine("Room no. Allocated");
                int roomNo = Convert.ToInt32(Console.ReadLine());
                foreach(Patient p in list1)
                {
                    if(p.RoomNo == roomNo)
                    {
                        throw new SameRoomError();
                    }
                }
                Console.WriteLine("Enter The Name Of the Patient");
                string name = Console.ReadLine();
                Console.WriteLine("Enter The Address Of the Patient");
                string address = Console.ReadLine();
                Console.WriteLine("Enter The Name Of Disease");
                string disease = Console.ReadLine();
                Console.WriteLine("Enter The Age Of the Patient");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Name oF The Doctor Assigned");
                string doctor = Console.ReadLine();
                Patient patient = patientService.AddPatient(name, address, disease, age, doctor, roomNo);
                Display(patient);
                Console.WriteLine("".PadLeft(15, '-'));
            }
            catch (RoomsError e)
            {
                e.Error();
            }
            catch (SameRoomError e)
            {
                e.Error();
            }
            catch(Exception)
            {
                Console.WriteLine("\nEnter a Valid input\n");
                AddPatient();
            }
         }

        private void Display(Patient patient)
        {
            if (patient == null)
            {
                Console.WriteLine("Patient Not Found");
            }
            else
            {
                Console.WriteLine("".PadLeft(15, '-'));
                Console.WriteLine("Room No.: " + patient.RoomNo);
                Console.WriteLine("Name: " + patient.Name);
                Console.WriteLine("Age: " + patient.Age);
                Console.WriteLine("Address: " + patient.Address);
                Console.WriteLine("Disease: " + patient.Disease);
                Console.WriteLine("Doctor Assigned: " + patient.Doctor);
            }
        }

        public void DisplayAll()
        {
            Console.WriteLine();
            patientService.DisplayAll();
            Console.WriteLine();
        }

        public void UpdatePatient()
        {
            Console.WriteLine("Press 1 To Update Age of the Patient");
            Console.WriteLine("Press 2 To Change the Doctor");
            Console.WriteLine("Press 3 To Update the Disease of the Patient");
            Console.WriteLine("Press 4 To change room number");
            Console.WriteLine("Press 0 To Exit");
            Console.WriteLine("Enter Your Choice");
            try
            {

                switch (Convert.ToByte(Console.ReadLine()))
                {

                    case 1:
                        Console.WriteLine("Enter Room No.:");
                        int RoomNo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Age:");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Display(patientService.UpdatePatientAge(RoomNo,age));
                        break;

                    case 2:
                        Console.WriteLine("Enter Room No.:");
                        int Roomno = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter The Name Of New Doctor:");
                        string doctor  = Console.ReadLine();
                        Display(patientService.UpdatePatientDoctor(Roomno,doctor));
                        break;

                    case 3:
                        Console.WriteLine("Enter Room No.:");
                        int roomno = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter The Name Of New Doctor:");
                        string disease = Console.ReadLine();
                        Display(patientService.UpdatePatientDisease(roomno, disease));
                        break;

                    case 4:
                        Console.WriteLine("Enter Name of the patient");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Disease that the patient is having");
                        string Disease = Console.ReadLine();
                        Console.WriteLine("Enter Age:");
                        int roomNo = Convert.ToInt32(Console.ReadLine());
                        Display(patientService.UpdatePatientRoomNo(name,Disease,roomNo));
                        break;

                    default:
                        Console.WriteLine("Enter a Valid Option");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a Valid Input\n");
                UpdatePatient();
            }
        }

        public void DeletePatient()
        {
            try
            {
                Console.WriteLine("Enter Room No.:");
                int roomNo = Convert.ToInt32(Console.ReadLine());
                if (patientService.DeletePatient(roomNo))
                {
                    Console.WriteLine("\nPatient Discharged\n");
                }
                else
                {
                    Console.WriteLine("Patient Not Found!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a Valid Input\n");
                DeletePatient();
            }
        }
    }
}
