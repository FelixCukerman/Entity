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
            var aviators = Mapper.Map<List<AviatorDTO>>(unitOfWork.Aviators.GetAll());
            if (aviators.Count > 0 && aviators != null)
                return aviators;
            else
                throw new System.Exception("Bad request");
        }
        public AviatorDTO GetById(int id)
        {
            var item = unitOfWork.Aviators.GetAll().FirstOrDefault(x => x.Id == id);
            if (item != null)
                return Mapper.Map<List<AviatorDTO>>(unitOfWork.Aviators.GetAll()).FirstOrDefault(x => x.Id == id);
            else
                throw new System.Exception("Bad request");
        }
        public void Create(AviatorDTO aviatorDTO)
        {
            if (aviatorDTO == null)
                throw new System.Exception("Bad request");
            var aviators = Mapper.Map<List<AviatorDTO>>(unitOfWork.Aviators.GetAll());
            foreach(var item in aviators)
            {
                if(item.Name == aviatorDTO.Name && item.Surname == aviatorDTO.Surname && item.Experience == aviatorDTO.Experience && item.DateOfBirthday == aviatorDTO.DateOfBirthday)
                {
                    throw new System.Exception("duplication of an object");
                }
                unitOfWork.Aviators.Create(Mapper.Map<Aviator>(aviatorDTO));
            }

            unitOfWork.Aviators.Create(Mapper.Map<Aviator>(aviatorDTO));
        }
        public void Update(int id, AviatorDTO aviatorDTO)
        {
            var item = unitOfWork.Aviators.GetAll().FirstOrDefault(x => x.Id == id);
            if (aviatorDTO == null || item != null)
                throw new System.Exception("Bad request");
            var aviators = Mapper.Map<List<AviatorDTO>>(unitOfWork.Aviators.GetAll());
            foreach (var aviator in aviators)
            {
                if (aviator.Name == aviatorDTO.Name && aviator.Surname == aviatorDTO.Surname && aviator.Experience == aviatorDTO.Experience && aviator.DateOfBirthday == aviatorDTO.DateOfBirthday)
                {
                    throw new System.Exception("Duplication of an object");
                }
                unitOfWork.Aviators.Update(id, Mapper.Map<Aviator>(aviatorDTO));
            }
        }
        public void Delete(int id)
        {
            var item = unitOfWork.Aviators.GetAll().FirstOrDefault(x => x.Id == id);
            if (item != null)
                unitOfWork.Aviators.Delete(id);
        }
    }
}