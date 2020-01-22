using System;
using System.Threading.Tasks;
using RandomPersonPicker.Data.Repositories;

namespace RandomPersonPicker.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var personRepo = new PersonRepository();

            var PeopleTask = personRepo.Get();
            var PersonTask = personRepo.Get(1);

            await Task.WhenAll(PeopleTask, PersonTask);

            var People = PeopleTask.Result;
            var Person = PersonTask.Result;
        }
    }
}
