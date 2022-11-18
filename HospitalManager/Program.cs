using HospitalManager.Enum;
using HospitalManager.Model;
using HospitalManager.Service;

namespace HospitalManager
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("1. Add Information");
            Console.WriteLine("2. Display Information");
            Console.WriteLine("11. Display all Doctors");
            Console.WriteLine("12. Display all Patients");
            Console.WriteLine("x. for exit");

            DoctorService _doctorService = new();
            PatientService _patientService = new();

            while (true)
            {
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("\n # Select Role - a. Doctor b. Patient");
                        string addrole = Console.ReadLine();
                        if (addrole != null)
                        {
                            if (addrole.Equals("a"))
                            {
                                Console.WriteLine("Doctor Name: ");
                                string doctorName = Console.ReadLine();

                                Console.WriteLine("Doctor Gender: 1. Male \n2. Female \n3. Others ");
                                string getdoctorGender = Console.ReadLine();

                                Gender doctorGender = Gender.Male;

                                if (getdoctorGender.Equals("2"))
                                {
                                    doctorGender = Gender.Female;
                                }
                                else if (getdoctorGender.Equals("3"))
                                {
                                    doctorGender = Gender.Others;
                                }

                                Console.WriteLine("Council Number: ");
                                string dCouncilNumber = Console.ReadLine();

                                string d_role = "Doctor";
                                string d_id = DateTime.Now.ToString("mmss");

                                Doctor doctor = new Doctor(d_id, doctorName, doctorGender, dCouncilNumber, d_role);
                                _doctorService.Add(doctor);

                            }
                            else if (addrole.Equals("b"))
                            {
                                Console.WriteLine("Patient Name: ");
                                string patientName = Console.ReadLine();

                                Console.WriteLine("Patient Gender:1. Male \n2. Female \n3. Others ");
                                string getpatientGender = Console.ReadLine();
                                Gender patientGender;

                                if (getpatientGender.Equals("1"))
                                {
                                    patientGender = Gender.Male;
                                }
                                else if (getpatientGender.Equals("2"))
                                {
                                    patientGender = Gender.Female;
                                }
                                else if (getpatientGender.Equals("3"))
                                {
                                    patientGender = Gender.Others;
                                }
                                else
                                {
                                    patientGender = Gender.Null;
                                }

                                Console.WriteLine("Doctor Id: ");
                                string pDoctorId = Console.ReadLine();

                                string p_role = "Patient";
                                string p_id = DateTime.Now.ToString("mmss");

                                Patient patient = new Patient(p_id, patientName, patientGender, p_role, pDoctorId);
                                _patientService.Add(patient);
                            }
                        }

                        break;

                    case "2":
                        Console.WriteLine("\n # Select Role - a. Doctor b. Patient");
                        var displayrole = Console.ReadLine();

                        if (displayrole != null)
                        {
                            if (displayrole.Equals("a"))
                            {
                                Console.WriteLine("\n6. Your Information ");
                                Console.WriteLine("\n8. To Display all Patients");

                                string number = Console.ReadLine();

                                if (number.Equals("6"))
                                {
                                    Console.WriteLine("\nEnter your Id: ");
                                    string d_id = Console.ReadLine();
                                    if (d_id != null)
                                    {
                                        _doctorService.DisplayPerson(d_id);
                                    }
                                }
                                else if (number.Equals("8"))
                                {
                                    Console.WriteLine("\nEnter your Id: ");
                                    string d_id = Console.ReadLine();
                                    _patientService.FindAllById(d_id);
                                }
                            }
                            if (displayrole.Equals("b"))
                            {
                                //Console.WriteLine("Enter your Id: ");
                                //string p_id = Console.ReadLine();
                                //if (p_id != null)
                                //{
                                //    _patientService.DisplayPerson(p_id);
                                //}

                                Console.WriteLine("\n6. Your Information ");
                                Console.WriteLine("\n8. To Display Doctor Information");

                                string number = Console.ReadLine();

                                if (number.Equals("6"))
                                {
                                    Console.WriteLine("Enter your Id: ");
                                    string p_id = Console.ReadLine();
                                    if (p_id != null)
                                    {
                                        _patientService.DisplayPerson(p_id);
                                    }
                                }
                                else if (number.Equals("8"))
                                {
                                    Console.WriteLine("\nEnter your Id: ");
                                    string d_id = Console.ReadLine();
                                    _doctorService.FindAllById(d_id);
                                }
                            }
                        }

                        break;
                    case "11":
                        _doctorService.FindAll();
                        break;
                    case "12":
                        _patientService.FindAll();
                        break;

                    case "x":
                        return;

                    default:
                        Console.WriteLine("Please select valid operation");
                        break;

                }
                Console.WriteLine("=======================");
                Console.WriteLine("\nSelect Operation");
                Console.WriteLine("1. Add Information");
                Console.WriteLine("2. Display Information By role");
                Console.WriteLine("11. Display all Doctors");
                Console.WriteLine("12. Display all Patients");
                Console.WriteLine("x. for exit");
            }

        }
    }
}
