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

            var peopleTask = personRepo.Get();
            var personTask = personRepo.Get(1);

            await Task.WhenAll(peopleTask, personTask);

            var people = peopleTask.Result;
            var person = personTask.Result;
        }
    }
}
