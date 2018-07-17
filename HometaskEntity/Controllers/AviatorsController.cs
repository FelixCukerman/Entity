using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HometaskEntity.BLL.Contracts;
using HometaskEntity.BLL.Service;
using HometaskEntity.BLL.DTOs;

namespace HometaskEntity.Controllers
{
    [Produces("application/json")]
    [Route("api/Aviators")]
    public class AviatorsController : Controller
    {
        private IService<AviatorDTO> aviatorService { get; set; }
        public AviatorsController(IService<AviatorDTO> aviatorService)
        {
            this.aviatorService = aviatorService;
        }

        // GET: api/Aviators
        [HttpGet]
        public List<AviatorDTO> Get()
        {
            var aviators = aviatorService.GetAll();
            if (aviators.Count != 0 || aviators != null)
                return aviators;
            else
                throw new Exception("Bad request");
        }

        // GET: api/Aviators/5
        [HttpGet("{id}")]
        public AviatorDTO Get(int id)
        {
            var aviator = aviatorService.GetAll().FirstOrDefault(x => x.Id == id);
            if (aviator != null || id > 0)
                return aviator;
            else
                throw new Exception("Bad request");
        }
        
        // POST: api/Aviators
        [HttpPost]
        public HttpResponseMessage Post([FromBody]AviatorDTO value)
        {
            if (ModelState.IsValid && value != null)
            {
                aviatorService.Create(value);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }
        
        // PUT: api/Aviators/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]AviatorDTO value)
        {
            aviatorService.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var aviator = aviatorService.GetAll().FirstOrDefault(x => x.Id == id);
            if (aviator != null || id > 0)
                aviatorService.Delete(id);
            else
                throw new Exception("Bad request");

        }
    }
}