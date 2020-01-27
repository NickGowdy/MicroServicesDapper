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
        [InlineData("Nick", "Gowdy", "Matthew", "Green")]
        public async Task CrudPerson(string forename, string surname, string updatedForename, string updatedSurname)
        {
            using (var TransactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                // ARRANGE
                var PersonRepository = new PersonRepository();
                var PersonId = await PersonRepository.Insert(new Person { Forename = forename, Surname = surname });

                // ACT
                var Person = await PersonRepository.Get(PersonId);

                // ASSERT
                Assert.NotNull(Person);
                Assert.Equal(PersonId, Person.PersonId);
                Assert.Equal(forename, Person.Forename);
                Assert.Equal(surname, Person.Surname);

                // ACT
                var hasUpdated = await PersonRepository.Update(new Person {PersonId = PersonId, Forename = updatedForename, Surname = updatedSurname });
                var updatedPerson = await PersonRepository.Get(PersonId);

                // ASSERT
                Assert.True(hasUpdated);
                Assert.NotNull(updatedPerson);
                Assert.Equal(PersonId, updatedPerson.PersonId);
                Assert.Equal(updatedForename, updatedPerson.Forename);
                Assert.Equal(updatedSurname, updatedPerson.Surname);

                // ACT
                await PersonRepository.Delete(PersonId);
                var DeletedPerson = await PersonRepository.Get(PersonId);

                // ASSERT
                Assert.Null(DeletedPerson);
            }
        }
    }
}
