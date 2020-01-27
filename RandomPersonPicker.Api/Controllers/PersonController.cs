using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPersonPicker.Data.Interfaces.Repositories;
using RandomPersonPicker.Domain.Models;
using System;
using System.Linq;

namespace RandomPersonPicker.Api.Controllers
{
    [ApiController]
    [Route("Person")]
    public class PersonController
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetAsync()
        {
            var People = await _personRepository.Get();
            return People;
        }

        [HttpGet]
        [Route("Random")]
        public async Task<Person> Random()
        {
            var People = await _personRepository.Get();
            var PeopleIds = People.Select(x => x.PersonId);
            var Random = new Random();
            var RandomPersonId = Random.Next(PeopleIds.Min(), PeopleIds.Max());
            return People.FirstOrDefault(x => x.PersonId == RandomPersonId);
        }
    }
}
