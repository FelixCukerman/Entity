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
    [Route("api/Crew")]
    public class CrewController : Controller
    {
        private IService<CrewDTO> crewService { get; set; }
        public CrewController(IService<CrewDTO> crewService)
        {
            this.crewService = crewService;
        }

        // GET: api/Crew
        [HttpGet]
        public List<CrewDTO> Get()
        {
            return crewService.GetAll();
        }

        // GET: api/Crew/5
        [HttpGet("{id}")]
        public CrewDTO Get(int id)
        {
            return crewService.GetAll().FirstOrDefault(x => x.Id == id);
        }
        
        // POST: api/Crew
        [HttpPost]
        public void Post([FromBody]CrewDTO value)
        {
            crewService.Create(value);
        }
        
        // PUT: api/Crew/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CrewDTO value)
        {
            crewService.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            crewService.Delete(id);
        }
    }
}
