using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HometaskEntity.BLL.DTOs;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.BLL.Contracts;

namespace HometaskEntity.BLL.Service
{
    public class TypePlaneService : IService<TypePlaneDTO>
    {
        IUnitOfWork unitOfWork;
        public TypePlaneService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<TypePlaneDTO> GetAll()
        {
            return Mapper.Map<List<TypePlaneDTO>>(unitOfWork.TypesPlane.GetAll());
        }
        public TypePlaneDTO GetById(int id)
        {
            return Mapper.Map<List<TypePlaneDTO>>(unitOfWork.TypesPlane.GetAll()).FirstOrDefault(x => x.Id == id);
        }
        public void Create(TypePlaneDTO typePlaneDTO)
        {
            unitOfWork.TypesPlane.Create(Mapper.Map<TypePlane>(typePlaneDTO));
        }
        public void Update(int id, TypePlaneDTO typePlaneDTO)
        {
            unitOfWork.TypesPlane.Update(id, Mapper.Map<TypePlane>(typePlaneDTO));
        }
        public void Delete(int id)
        {
            unitOfWork.TypesPlane.Delete(id);
        }
    }
}
