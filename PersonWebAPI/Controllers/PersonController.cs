﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonWebAPI.Data;
using PersonWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace PersonWebAPI.Controllers
{
    [ApiController]
    [Route("v1/person")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Person>>> Index([FromServices] DataContext context)
        {
            var people = await context.People.ToListAsync();
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
            [FromBody] Person model)
        {
            if (ModelState.IsValid)
            {
                context.People.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Person>> Update(
            [FromServices] DataContext context,
            [FromBody] Person person,
            int id)
        {
            var exist = context.People.Any(x => x.Id == id);

            if (exist && ModelState.IsValid)
            {
                context.Entry<Person>(person).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return person;
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


