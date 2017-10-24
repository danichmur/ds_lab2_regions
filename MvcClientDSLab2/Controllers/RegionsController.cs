using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcClientDSLab2.Models;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;  

namespace MvcClientDSLab2.Controllers
{
    public class RegionsController : Controller
    {
        string Baseurl = "http://localhost:5000/";
        public async Task<ActionResult> Info(int? regionId, int? areaId)  
        {
            List<Region> RegInfo = new List<Region>();  
              
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(Baseurl);  
                client.DefaultRequestHeaders.Clear();  
                HttpResponseMessage Res = await client.GetAsync("api/regions");  
                if (Res.IsSuccessStatusCode)  
                {  
                    var RegResponse = Res.Content.ReadAsStringAsync().Result;  
                    RegInfo = JsonConvert.DeserializeObject<List<Region>>(RegResponse);  
                } 
                ViewBag.regionId = regionId;
                ViewBag.areaId = areaId;
                
                return View(RegInfo.ToList());  
            }  
        }
        // GET: Regions
        public async Task<ActionResult> Index()  
        {  
            List<Region> RegInfo = new List<Region>();  
              
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(Baseurl);  
                client.DefaultRequestHeaders.Clear();  
                HttpResponseMessage Res = await client.GetAsync("api/regions");  
                if (Res.IsSuccessStatusCode)  
                {  
                    var RegResponse = Res.Content.ReadAsStringAsync().Result;  
                    RegInfo = JsonConvert.DeserializeObject<List<Region>>(RegResponse);  
                } 
                return View(RegInfo.ToList());  
            }  
        }   

        // GET: Regions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            Region region = null;
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(Baseurl);  
                client.DefaultRequestHeaders.Clear();  
                HttpResponseMessage Res = await client.GetAsync("api/regions/" + id);  
                if (Res.IsSuccessStatusCode)  
                {  
                    var RegResponse = Res.Content.ReadAsStringAsync().Result;  
                    region = JsonConvert.DeserializeObject<Region>(RegResponse);  
  
                } 
                return View(region);  
            }  
        }

        // GET: Regions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<ActionResult> Create([Bind("Name,Capital")] Region item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            
            using (var client = new HttpClient())  
            {
                client.BaseAddress = new Uri(Baseurl);  
                client.DefaultRequestHeaders.Clear();  
                HttpResponseMessage response = await client.PostAsJsonAsync("api/regions", item);
                response.EnsureSuccessStatusCode();
            }          
            return View("Details", item); 
        }


        // GET: Regions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Region region = null;
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(Baseurl);  
                client.DefaultRequestHeaders.Clear();  
                HttpResponseMessage Res = await client.GetAsync("api/regions/" + id);  
                if (Res.IsSuccessStatusCode)  
                {  
                    var RegResponse = Res.Content.ReadAsStringAsync().Result;  
                    region = JsonConvert.DeserializeObject<Region>(RegResponse);  
  
                } 
                return View(region);  
            }  
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Capital")] Region region)
        {
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(Baseurl);  
                client.DefaultRequestHeaders.Clear();  
                HttpResponseMessage Res = await client.PutAsJsonAsync($"api/regions/{region.Id}", region);  
                if (Res.IsSuccessStatusCode)  
                {  
                    var RegResponse = Res.Content.ReadAsStringAsync().Result;  
                    region = JsonConvert.DeserializeObject<Region>(RegResponse);  
  
                } 
                return View("Details", region); 
            }  
        }

        // GET: Regions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Region region = null;
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(Baseurl);  
                client.DefaultRequestHeaders.Clear();  
                HttpResponseMessage Res = await client.GetAsync("api/regions/" + id);  
                if (Res.IsSuccessStatusCode)  
                {  
                    var RegResponse = Res.Content.ReadAsStringAsync().Result;  
                    region = JsonConvert.DeserializeObject<Region>(RegResponse);  
  
                } 
                return View(region);  
            }  
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(Baseurl);  
                client.DefaultRequestHeaders.Clear();  
                HttpResponseMessage response = await client.DeleteAsync($"api/regions/{id}");
                
            }  
            List<Region> RegInfo = new List<Region>();  
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(Baseurl);  
                client.DefaultRequestHeaders.Clear();  
                HttpResponseMessage Res = await client.GetAsync("api/regions");  
                if (Res.IsSuccessStatusCode)  
                {  
                    var RegResponse = Res.Content.ReadAsStringAsync().Result;  
                    RegInfo = JsonConvert.DeserializeObject<List<Region>>(RegResponse);  
                } 
                return View("Index", RegInfo.ToList());  
            }              
        }
    }
}
