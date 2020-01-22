using System;
using RandomPersonPicker.Data.Repositories;

namespace RandomPersonPicker.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var personRepo = new PersonRepository();
            var people = personRepo.Get();
            var person = personRepo.Get(1);
        }
    }
}
