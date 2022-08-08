using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    class PatientManagementApp
    {
        static void Main(string[] args)
        {
            PatientManagementIO patientManagement = new PatientManagementIO();
            bool flag = true;
            while (flag)
            {
                switch (patientManagement.Menu())
                {
                    case 1:
                        patientManagement.AddPatient();
                        break;

                    case 2:
                        patientManagement.DisplayAll();
                        break;

                    case 3:
                        patientManagement.UpdatePatient();
                        break;

                    case 4:
                        patientManagement.DeletePatient();
                        break;

                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}
