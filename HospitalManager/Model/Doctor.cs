using HospitalManager.Enum;
using HospitalManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Model
{
    public class Doctor : IPerson
    {
        public Doctor(string id, string name, Gender gender, string councilNumber, string role)
        {
            ID = id;
            Name = name;
            Gender = gender;
            CouncilNumber = councilNumber;
            Role = role;
        }
        //public string ID { get; set; }
        //public string Name { get; set; }
        //public Gender Gender { get; set; }
        public string CouncilNumber { get; set; }
        //public string Role { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Role { get; set; }
    }
}
