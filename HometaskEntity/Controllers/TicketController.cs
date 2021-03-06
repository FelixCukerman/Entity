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
    [Route("api/Ticket")]
    public class TicketController : Controller
    {
        private IService<TicketDTO> ticketService;
        public TicketController(IService<TicketDTO> ticketService)
        {
            this.ticketService = ticketService;
        }
        // GET: api/Ticket
        [HttpGet]
        public List<TicketDTO> Get()
        {
            return ticketService.GetAll();
        }

        // GET: api/Ticket/5
        [HttpGet("{id}")]
        public TicketDTO Get(int id)
        {
            return ticketService.GetAll().FirstOrDefault(x => x.Id == id);
        }
        
        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody]TicketDTO value)
        {
            ticketService.Create(value);
        }
        
        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TicketDTO value)
        {
            ticketService.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ticketService.Delete(id);
        }
    }
}
