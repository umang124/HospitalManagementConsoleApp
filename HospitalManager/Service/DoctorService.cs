using HospitalManager.Interface;
using HospitalManager.Model;
using Newtonsoft.Json;

namespace HospitalManager.Service
{
    public class DoctorService : IPersonService
    {
        private List<Doctor> _getdoctors { get; set; } = new();
        public void Add(IPerson person)
        {
            Doctor doctor = (Doctor)person;

            if (File.Exists(@"Doctor.json") && new FileInfo(@"Doctor.json").Length != 0)
            {
                string getjson = string.Empty;
                getjson = File.ReadAllText(@"Doctor.json");
                var doct = JsonConvert.DeserializeObject<List<Doctor>>(getjson);

                if (doct.Any(x => x.CouncilNumber == doctor.CouncilNumber))
                {
                    Console.WriteLine("Doctor already exists with same council number");
                }
                else
                {
                    doct.Add(doctor);
                    string json = JsonConvert.SerializeObject(doct);
                    File.WriteAllText(@"Doctor.json", json);
                    Console.WriteLine("Doctor Added");
                }
               
            }
            else
            {
                _getdoctors.Add(doctor);
                string json = JsonConvert.SerializeObject(_getdoctors);
                File.WriteAllText(@"Doctor.json", json);

                Console.WriteLine("Doctor Added");
            }
            
        }
        public void DisplayPerson(string id)
        {
            if (File.Exists(@"Doctor.json"))
            {
                string getjson = File.ReadAllText(@"Doctor.json");
                var doctors = JsonConvert.DeserializeObject<List<Doctor>>(getjson);

                var doctor = doctors.FirstOrDefault(p => p.ID == id);

                //var doctorLinq = (from d in _doctors
                //                  where d.ID == id
                //                  select d).FirstOrDefault();
                if (doctor == null)
                {
                    Console.WriteLine("Doctor not found");
                }
                else
                {
                    Console.WriteLine("Council Number: " + doctor.CouncilNumber + "\nName: " + doctor.Name + "\nGender: " + doctor.Gender + "\nId: " + doctor.ID);
                }
            }
            else
            {
                Console.WriteLine("There are no doctors");
            }

        }
        public void FindAll()
        {
            if (File.Exists(@"Doctor.json"))
            {
                string getjson = File.ReadAllText(@"Doctor.json");
                var doctors = JsonConvert.DeserializeObject<List<Doctor>>(getjson);

                foreach (Doctor doc in doctors)
                {
                    Console.WriteLine("Council Number: " + doc.CouncilNumber + "\nName: " + doc.Name + "\nGender: " + doc.Gender + "\nId: " + doc.ID + "\n");
                }
            }
            else
            {
                Console.WriteLine("There are no doctors");
            }
            
        }
        public void FindAllById(string id)
        {
            if (File.Exists(@"Patient.json") && File.Exists(@"Doctor.json"))
            {
                string getpatientjson = File.ReadAllText(@"Patient.json");
                var patients = JsonConvert.DeserializeObject<List<Patient>>(getpatientjson);

                var getpatient = patients.FirstOrDefault(x => x.ID == id);
                if (getpatient == null)
                {
                    Console.WriteLine("Doctor not found");
                }
                else
                {
                    var d_id = getpatient.DoctorId;
                    string getdoctorjson = File.ReadAllText(@"Doctor.json");
                    var doctors = JsonConvert.DeserializeObject<List<Doctor>>(getdoctorjson);

                    var getdoctor = doctors.FirstOrDefault(x => x.ID == d_id);
                    if (getdoctor != null)
                    {
                        Console.WriteLine("Council Number: " + getdoctor.CouncilNumber + "\nName: " + getdoctor.Name + "\nGender: " + getdoctor.Gender + "\nId: " + getdoctor.ID + "\n");
                    }
                }
            }
        }
    }
}
