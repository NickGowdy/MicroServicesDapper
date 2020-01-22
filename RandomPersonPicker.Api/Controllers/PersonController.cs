﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RandomPersonPicker.Data.Interfaces.Repositories;
using RandomPersonPicker.Domain.Models;

namespace RandomPersonPicker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }


        [HttpGet]
        public async System.Threading.Tasks.Task<IEnumerable<Person>> GetAsync()
        {
            var people = await _personRepository.Get();
            return people;
        }
    }
}