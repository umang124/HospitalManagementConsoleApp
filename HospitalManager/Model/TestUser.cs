using HospitalManager.Enum;
using HospitalManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Model
{
    public class TestUser : IPerson
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Role { get; set; }
    }
}
