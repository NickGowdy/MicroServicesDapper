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
        public async Task SaveAndGetPerson(string forename, string surname)
        {
            using (var TransactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                // ARRANGE
                var PersonRepository = new PersonRepository();
                var NewPersonId = await PersonRepository.Insert(new Person { Forename = forename, Surname = surname });

                // ACT
                var Person = await PersonRepository.Get((int)NewPersonId);

                // ASSERT
                Assert.NotNull(Person);
                Assert.Equal(NewPersonId, Person.PersonId);
                Assert.Equal(forename, Person.Forename);
                Assert.Equal(surname, Person.Surname);
            }
        }
    }
}
