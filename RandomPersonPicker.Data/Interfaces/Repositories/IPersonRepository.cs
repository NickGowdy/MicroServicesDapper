using System.Collections.Generic;
using System.Threading.Tasks;
using RandomPersonPicker.Domain.Models;

namespace RandomPersonPicker.Data.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        public Task<IEnumerable<Person>> Get();
        public Task<Person> Get(int personId);
        public Task<long> Insert(Person person);
        public Task<bool> Update(Person person);
    }
}
