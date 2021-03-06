﻿using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using HometaskEntity.BLL.DTOs;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.BLL.Contracts;

namespace HometaskEntity.BLL.Service
{
    public class PlaneService : IService<PlaneDTO>
    {
        IUnitOfWork unitOfWork;
        public PlaneService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<PlaneDTO> GetAll()
        {
            return Mapper.Map<List<PlaneDTO>>(unitOfWork.Planes.GetAll());
        }
        public PlaneDTO GetById(int id)
        {
            return Mapper.Map<List<PlaneDTO>>(unitOfWork.Planes.GetAll()).FirstOrDefault(x => x.Id == id);
        }
        public void Create(PlaneDTO planeDTO)
        {
            unitOfWork.Planes.Create(Mapper.Map<Plane>(planeDTO));
        }
        public void Update(int id, PlaneDTO planeDTO)
        {
            unitOfWork.Planes.Update(id, Mapper.Map<Plane>(planeDTO));
        }
        public void Delete(int id)
        {
            unitOfWork.Planes.Delete(id);
        }
    }
}
