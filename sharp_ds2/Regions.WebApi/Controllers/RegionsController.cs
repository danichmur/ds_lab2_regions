using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Regions.WebApi.Models;
using System.Linq;
using System;
using Regions.WebApi.Infrastructure;

namespace Regions.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RegionsController : Controller
    {
        private readonly RegionsContext context;

        public  RegionsController(RegionsContext context)
        {
            this.context = context;
            foreach(var region in context.Regions){
                region.Areas = context.Areas.
                    Where(t => t.RegionId == region.Id).ToHashSet();
                foreach(var area in context.Areas){
                    area.Localities = context.Localities.
                    Where(t => t.AreaId == area.Id).ToHashSet();
                }
            }
        }

        [HttpGet]
        public IEnumerable<Region> GetAll()
        {
            return context.Regions.ToList();
        }

        [HttpGet("{id}", Name = "GetRegion")]
        public IActionResult GetById(long id)
        {
            var item = context.Regions.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Region region)
        {
            if (region == null)
            {
                return BadRequest();
            }
            context.Regions.Add(region);
            context.SaveChanges();
            return Ok(region.Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Region item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var region = context.Regions.FirstOrDefault(t => t.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            region.Name = item.Name;
            region.Capital = item.Capital;
            context.Regions.Update(region);
            context.SaveChanges();
            return new ObjectResult(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var region = context.Regions.FirstOrDefault(t => t.Id == id);
            if (region == null)
            {
                return NotFound();
            }

            context.Regions.Remove(region);
            context.SaveChanges();
            return new NoContentResult();
        }
    }
}