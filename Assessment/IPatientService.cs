using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    interface IPatientService
    {
        Patient AddPatient(string name, string address, string disease, int age, string doctor, int roomNo);
        List<Patient> Patients();
        Patient UpdatePatientRoomNo(string name, string disease, int roomNo);
        Patient UpdatePatientAge(int roomNo, int age);
        Patient UpdatePatientDisease(int roomNo, string disease);
        Patient UpdatePatientDoctor(int roomNo, string doctor);
        void DisplayAll();
        bool DeletePatient(int roomNo);

    }
}
