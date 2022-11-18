namespace HospitalManager.Interface
{
    public interface IPersonService
    {
        void Add(IPerson person);
        void DisplayPerson(string id);
        void FindAll();
        void FindAllById(string id);
    }
}
