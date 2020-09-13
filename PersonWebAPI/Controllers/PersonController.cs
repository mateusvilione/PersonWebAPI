using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonWebAPI.Data;
using PersonWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using PersonWebAPI.ViewModels.PersonViewModels;

namespace PersonWebAPI.Controllers
{
    [ApiController]
    [Route("v1/person")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Person>>> Index(
            [FromServices] DataContext context,
            [FromQuery] string? name = null,
            [FromQuery] string? cpf = null,
            [FromQuery] string? dataBirth = null,
            [FromQuery] string? contryBirth = null,
            [FromQuery] string? stateBirth = null,
            [FromQuery] string? cityBirth = null)
        {
            var people = await context.People.ToListAsync();

            if (name != null)
                people = people.Where(x => x.Name.Contains(name)).ToList();
            if (cpf != null)
                people = people.Where(x => x.Cpf.Contains(cpf)).ToList();
            if (dataBirth != null)
                people = people.Where(x => x.DataBirth == DateTime.Parse(dataBirth)).ToList();
            if (contryBirth != null)
                people = people.Where(x => x.ContryBirth.Contains(contryBirth)).ToList();
            if (stateBirth != null)
                people = people.Where(x => x.StateBirth.Contains(stateBirth)).ToList();
            if (cityBirth != null)
                people = people.Where(x => x.CityBirth.Contains(cityBirth)).ToList();
            
            return people;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Person>> Show([FromServices] DataContext context, int id)
        {
            var person = await context.People.FindAsync(id);

            if (person == null) {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Person>> Store(
            [FromServices] DataContext context,
            [FromBody] CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                var newPerson = new Person
                {
                    Name = person.Name,
                    Cpf = person.Cpf,
                    DataBirth = person.DataBirth,
                    ContryBirth = person.ContryBirth,
                    StateBirth = person.StateBirth,
                    CityBirth = person.CityBirth,
                    FatherName = person.FatherName,
                    MotherName = person.MotherName,
                    Email = person.Email
                };

                context.People.Add(newPerson);
                await context.SaveChangesAsync();
                return newPerson;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Person>> Update(
            [FromServices] DataContext context,
            [FromBody] EditorPersonViewModel person,
            int id)
        {
            var editPerson = context.People.Find(id); ;

            if (editPerson != null && ModelState.IsValid)
            {
                editPerson.Name = person.Name;
                editPerson.FatherName = person.FatherName;
                editPerson.MotherName = person.MotherName;
                editPerson.Email = person.Email;

                context.Entry<Person>(editPerson).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return editPerson;
            }
            else
            {
                return NotFound(ModelState);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<ActionResult<Person>> Destroy([FromServices] DataContext context, int id)
        {
            var person = await context.People.FindAsync(id);

            if (person != null)
            {
                context.People.Remove(person);
                await context.SaveChangesAsync();

                return person;
            }
            else {
                return NotFound();
            }
        }
    }
}