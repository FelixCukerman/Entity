﻿using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using HometaskEntity.BLL.DTOs;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.BLL.Contracts;

namespace HometaskEntity.BLL.Service
{
    public class FlightService : IService<FlightDTO>
    {
        IUnitOfWork unitOfWork;
        public FlightService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<FlightDTO> GetAll()
        {
            return Mapper.Map<List<FlightDTO>>(unitOfWork.Flights.GetAll());
        }
        public FlightDTO GetById(int id)
        {
            return Mapper.Map<List<FlightDTO>>(unitOfWork.Flights.GetAll()).FirstOrDefault(x => x.Number == id);
        }
        public void Create(FlightDTO flightDTO)
        {
            unitOfWork.Flights.Create(Mapper.Map<Flight>(flightDTO));
        }
        public void Update(int id, FlightDTO flightDTO)
        {
            unitOfWork.Flights.Update(id, Mapper.Map<Flight>(flightDTO));
        }
        public void Delete(int id)
        {
            unitOfWork.Flights.Delete(id);
        }
    }
}
