using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    class Patient
    {
        string _Name, _Address, _Disease, _Doctor;
        int _Age, _RoomNo;

        public Patient(string name, string address, string disease, int age, string doctor, int roomNo)
        {
            this._Name = name;
            this._Address = address;
            this._Age = age;
            this._Disease = disease;
            this._Doctor = doctor;
            this._RoomNo = roomNo;
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string Disease
        {
            get { return _Disease; }
            set { _Disease = value; }
        }

        public string Doctor
        {
            get { return _Doctor; }
            set { _Doctor = value; }
        }

        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        
        public int RoomNo
        {
            get { return _RoomNo; }
            set { _RoomNo = value; }
        }
    }
}
