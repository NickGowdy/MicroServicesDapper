using System.Threading.Tasks;
using System.Transactions;
using RandomPersonPicker.Data.Repositories;
using RandomPersonPicker.Domain.Models;
using Xunit;

namespace RandomPersonPicker.Tests.Repositories
{
    public class PersonRepositoryTests
    {
        [Theory]
        [InlineData("Nick", "Gowdy")]
        public async Task GetPerson(string forename, string surname)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                // ARRANGE
                var personRepository = new PersonRepository();
                var newPersonId = await personRepository.Insert(new Person { Forename = forename, Surname = surname });

                // ACT
                var person = await personRepository.Get((int)newPersonId);

                // ASSERT
                Assert.NotNull(person);
                Assert.Equal(newPersonId, person.PersonId);
                Assert.Equal(forename, person.Forename);
                Assert.Equal(surname, person.Surname);
            }
        }
    }
}
