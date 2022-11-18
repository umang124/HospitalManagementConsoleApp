using HospitalManager.Interface;
using HospitalManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Service
{
    public class TestUserService : IPersonService
    {
        public void Add(IPerson person)
        {
            TestUser user = (TestUser) person;

        }

        public void DisplayPerson(string id)
        {
            throw new NotImplementedException();
        }

        public void FindAll()
        {
            throw new NotImplementedException();
        }

        public void FindAllById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
