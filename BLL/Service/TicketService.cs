using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using HometaskEntity.BLL.DTOs;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.BLL.Contracts;

namespace HometaskEntity.BLL.Service
{
    public class TicketService : IService<TicketDTO>
    {
        IUnitOfWork unitOfWork;
        public TicketService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<TicketDTO> GetAll()
        {
            return Mapper.Map<List<TicketDTO>>(unitOfWork.Tickets.GetAll());
        }
        public TicketDTO GetById(int id)
        {
            return Mapper.Map<List<TicketDTO>>(unitOfWork.Tickets.GetAll()).FirstOrDefault(x => x.Id == id);
        }
        public void Create(TicketDTO ticketDTO)
        {
            unitOfWork.Tickets.Create(Mapper.Map<Ticket>(ticketDTO));
        }
        public void Update(int id, TicketDTO ticketDTO)
        {
            unitOfWork.Tickets.Update(id, Mapper.Map<Ticket>(ticketDTO));
        }
        public void Delete(int id)
        {
            unitOfWork.Tickets.Delete(id);
        }
    }
}
