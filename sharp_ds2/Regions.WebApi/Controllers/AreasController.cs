using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Regions.WebApi.Models;
using System.Linq;
using System;
using Regions.WebApi.Infrastructure;

namespace Regions.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AreasController : Controller
    {
        private readonly RegionsContext context;

        public  AreasController(RegionsContext context)
        {
            this.context = context;
            foreach(var area in context.Areas){
                area.Localities = context.Localities.
                    Where(t => t.AreaId == area.Id).ToHashSet();
            }
        }

        [HttpGet]
        public IEnumerable<Area> GetAll()
        {
            return context.Areas.ToList();
        }

        [HttpGet("{id}", Name = "GetArea")]
        public IActionResult GetById(long id)
        {
            var item = context.Areas.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Area item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            context.Areas.Add(item);
            context.SaveChanges();
            return CreatedAtRoute("GetArea", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Area item)
        {
            Console.WriteLine("{0}, {1}", id, item.Id);
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var area = context.Areas.FirstOrDefault(t => t.Id == id);
            if (area == null)
            {
                return NotFound();
            }
            area.Name = item.Name;
            area.RegionId = item.RegionId;
            context.Areas.Update(area);
            context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var area = context.Areas.FirstOrDefault(t => t.Id == id);
            if (area == null)
            {
                return NotFound();
            }

            context.Areas.Remove(area);
            context.SaveChanges();
            return new NoContentResult();
        }
    }
}