﻿using System;
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
    [Route("api/Stewardess")]
    public class StewardessController : Controller
    {
        private IService<StewardessDTO> stewardessService;
        public StewardessController(IService<StewardessDTO> stewardessService)
        {
            this.stewardessService = stewardessService;
        }
        // GET: api/Stewardess
        [HttpGet]
        public List<StewardessDTO> Get()
        {
            return stewardessService.GetAll();
        }

        // GET: api/Stewardess/5
        [HttpGet("{id}")]
        public StewardessDTO Get(int id)
        {
            return stewardessService.GetAll().FirstOrDefault(x => x.Id == id);
        }
        
        // POST: api/Stewardess
        [HttpPost]
        public void Post([FromBody]StewardessDTO value)
        {
            stewardessService.Create(value);
        }
        
        // PUT: api/Stewardess/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]StewardessDTO value)
        {
            stewardessService.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            stewardessService.Delete(id);
        }
    }
}
