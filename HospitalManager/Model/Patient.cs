using HospitalManager.Enum;
using HospitalManager.Interface;

namespace HospitalManager.Model
{
    public class Patient : IPerson
    {
        public Patient(string id, string name, Gender gender,string role, string Doctorid)
        {
            ID = id;
            Name = name;
            Gender = gender;
            Role = role;
            this.DoctorId = Doctorid;
           
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }      
        public string Role { get; set; }
        public string DoctorId { get; set; }


    }
}
