using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Services
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int _count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
           
        }

        public List<Person> FindAll()
        {
            List<Person> pessoas = new List<Person>();

            for (int i = 0; i < 3; i++)
            {
                pessoas.Add(CreateFakePerson(i));
            }

            return pessoas;
        }

        private Person CreateFakePerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Vanderlei" + i,
                LastName = "Branco" + i,
                Address = "Paranaguá-PR",
                Gender = "Masculino"
            };
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Vanderlei",
                LastName = "Branco",
                Address = "Paranaguá-PR",
                Gender = "Masculino"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref _count);
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
