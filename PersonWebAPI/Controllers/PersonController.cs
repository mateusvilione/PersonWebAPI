﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonWebAPI.Data;
using PersonWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    }
}