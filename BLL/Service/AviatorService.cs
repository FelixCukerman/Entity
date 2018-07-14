using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using HometaskEntity.BLL.DTOs;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.BLL.Contracts;

namespace HometaskEntity.BLL.Service
{
    public class AviatorService : IService<AviatorDTO>
    {
        IUnitOfWork unitOfWork;
        public AviatorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<AviatorDTO> GetAll()
        {
            return Mapper.Map<List<AviatorDTO>>(unitOfWork.Aviators.GetAll());
        }
        public AviatorDTO GetById(int id)
        {
            return Mapper.Map<List<AviatorDTO>>(unitOfWork.Aviators.GetAll()).FirstOrDefault(x => x.Id == id);
        }
        public void Create(AviatorDTO aviatorDTO)
        {
            unitOfWork.Aviators.Create(Mapper.Map<Aviator>(aviatorDTO));
        }
        public void Update(int id, AviatorDTO aviatorDTO)
        {
            unitOfWork.Aviators.Update(id, Mapper.Map<Aviator>(aviatorDTO));
        }
        public void Delete(int id)
        {
            unitOfWork.Aviators.Delete(id);
        }
    }
}