using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HometaskEntity.BLL.Service;
using HometaskEntity.BLL.DTOs;
using HometaskEntity.BLL.Contracts;

namespace HometaskEntity.Controllers
{
    [Produces("application/json")]
    [Route("api/Plane")]
    public class PlaneController : Controller
    {
        private IService<PlaneDTO> planeService;
        public PlaneController(IService<PlaneDTO> planeService)
        {
            this.planeService = planeService;
        }
        // GET: api/Plane
        [HttpGet]
        public List<PlaneDTO> Get()
        {
            return planeService.GetAll();
        }

        // GET: api/Plane/5
        [HttpGet("{id}")]
        public PlaneDTO Get(int id)
        {
            return planeService.GetAll().FirstOrDefault(x => x.Id == id);
        }
        
        // POST: api/Plane
        [HttpPost]
        public void Post([FromBody]PlaneDTO value)
        {
            planeService.Create(value);
        }
        
        // PUT: api/Plane/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PlaneDTO value)
        {
            planeService.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            planeService.Delete(id);
        }
    }
}
