using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Regions.WebApi.Models;
using System.Linq;
using System;
using Regions.WebApi.Infrastructure;

namespace Regions.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LocalitiesController : Controller
    {
        private readonly RegionsContext context;

        public  LocalitiesController(RegionsContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Locality> GetAll()
        {  
            return context.Localities.ToList();
        }

        [HttpGet("{id}", Name = "GetLocality")]
        public IActionResult GetById(long id)
        {
            var item = context.Localities.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Locality item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            context.Localities.Add(item);
            context.SaveChanges();
            return CreatedAtRoute("GetLocality", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Locality item)
        {
            Console.WriteLine("{0}, {1}", id, item.Id);
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var locality = context.Localities.FirstOrDefault(t => t.Id == id);
            if (locality == null)
            {
                return NotFound();
            }
            locality.Name = item.Name;
            locality.AreaId = item.AreaId;
            locality.Population = item.Population;
            locality.Type = locality.Type;
            context.Localities.Update(locality);
            context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var locality = context.Localities.FirstOrDefault(t => t.Id == id);
            if (locality == null)
            {
                return NotFound();
            }

            context.Localities.Remove(locality);
            context.SaveChanges();
            return new NoContentResult();
        }
    }
}