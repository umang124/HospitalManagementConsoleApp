using HospitalManager.Interface;
using HospitalManager.Model;
using Newtonsoft.Json;
using System.Numerics;

namespace HospitalManager.Service
{
    public class PatientService : IPersonService
    {
        private List<Patient> _getpatients = new();
        public void Add(IPerson person)
        {
            Patient patient = (Patient)person;
            if (File.Exists(@"Patient.json") && new FileInfo(@"Patient.json").Length != 0)
            {
                string getpatientjson = string.Empty;
                getpatientjson = File.ReadAllText(@"Patient.json");
                var patients = JsonConvert.DeserializeObject<List<Patient>>(getpatientjson);

                string getdoctorjson = File.ReadAllText(@"Doctor.json");
                var doctors = JsonConvert.DeserializeObject<List<Doctor>>(getdoctorjson);

                if (doctors.Any(x => x.ID == patient.DoctorId))
                {
                    patients.Add(patient);
                    string json = JsonConvert.SerializeObject(patients);
                    File.WriteAllText(@"Patient.json", json);
                    Console.WriteLine("Patient Added");
                }
                else
                {
                    Console.WriteLine("Doctor not found, Cannot add Patient");
                }       
            }
            else
            {
                string getdoctorjson = File.ReadAllText(@"Doctor.json");
                var doctors = JsonConvert.DeserializeObject<List<Doctor>>(getdoctorjson);

                if (doctors.Any(x => x.ID == patient.DoctorId))
                {
                    _getpatients.Add(patient);
                    string json = JsonConvert.SerializeObject(_getpatients);
                    File.WriteAllText(@"Patient.json", json);
                    Console.WriteLine("Patient Added");
                }
                else
                {
                    Console.WriteLine("Doctor not found, Cannot add Patient");
                }               
            }
        }
        public void DisplayPerson(string id)
        {
            if (File.Exists(@"Patient.json"))
            {
                string getjson = File.ReadAllText(@"Patient.json");
                var patients = JsonConvert.DeserializeObject<List<Patient>>(getjson);

                var patient = patients.FirstOrDefault(p => p.ID == id);

                if (patient != null)
                {
                    Console.WriteLine("PatientId: " + patient.ID + "\nPatientName: "
                        + patient.Name + "\nPatientGender: " + patient.Gender + "\nDoctorId: " + patient.DoctorId);
                }

                else
                {
                    Console.WriteLine("Patient not found");
                }
            }
            else
            {
                Console.WriteLine("There are not patients");
            }
            

        }
        public void FindAllById(string doctorId)
        {
            if (File.Exists(@"Patient.json") && File.Exists(@"Doctor.json"))
            {
                string getjson = File.ReadAllText(@"Patient.json");
                var getPatients = JsonConvert.DeserializeObject<List<Patient>>(getjson);

                var patients = getPatients.Where(x => x.DoctorId == doctorId).ToList();
                if (patients.Count != 0)
                {
                    foreach (Patient patient in patients)
                    {
                        Console.WriteLine("PatientId: " + patient.ID + "\nPatientName: "
                        + patient.Name + "\nPatientGender: " + patient.Gender + "\nDoctorId: " + patient.DoctorId + "\n");
                    }
                }
                else
                {
                    Console.WriteLine("Patient not found");
                }
            }
            else
            {
                Console.WriteLine("There are no patients");
            }
            
        }
        public void FindAll()
        {
            if (File.Exists(@"Patient.json"))
            {
                string getjson = File.ReadAllText(@"Patient.json");
                var patients = JsonConvert.DeserializeObject<List<Patient>>(getjson);

                foreach (Patient patient in patients)
                {
                    Console.WriteLine("PatientId: " + patient.ID + "\nPatientName: "
                        + patient.Name + "\nPatientGender: " + patient.Gender + "\nDoctorId: " + patient.DoctorId + "\n");
                }
            }
            else
            {
                Console.WriteLine("There are no Patients");
            }
           
        }
    }
}
