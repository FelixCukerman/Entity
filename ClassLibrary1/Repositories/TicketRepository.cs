using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.DAL.Models;

namespace HometaskEntity.DAL.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        private AirportContext data;

        public TicketRepository(AirportContext data)
        {
            this.data = data;
        }
        public IEnumerable<Ticket> GetAll()
        {
            return data.Tickets;
        }
        public Ticket Get(int id)
        {
            return data.Tickets.FirstOrDefault(x => x.Id == id);
        }
        public void Create(Ticket ticket)
        {
            data.Tickets.Add(ticket);
        }
        public void Update(int id, Ticket ticket)
        {
            var item = data.Tickets.FirstOrDefault(x => x.Id == id);
            item = ticket;
        }
        public void Delete(int id)
        {
            Ticket ticket = data.Tickets.FirstOrDefault(x => x.Id == id);
            if (ticket != null)
                data.Tickets.Remove(ticket);
        }
    }
}
