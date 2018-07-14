using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using HometaskEntity.BLL.DTOs;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.BLL.Contracts;

namespace HometaskEntity.BLL.Service
{
    public class StewardessService : IService<StewardessDTO>
    {
        IUnitOfWork unitOfWork;
        public StewardessService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<StewardessDTO> GetAll()
        {
            return Mapper.Map<List<StewardessDTO>>(unitOfWork.Stewardesses.GetAll());
        }
        public StewardessDTO GetById(int id)
        {
            return Mapper.Map<List<StewardessDTO>>(unitOfWork.Stewardesses.GetAll()).FirstOrDefault(x => x.Id == id);
        }
        public void Create(StewardessDTO stewardessDTO)
        {
            unitOfWork.Stewardesses.Create(Mapper.Map<Stewardess>(stewardessDTO));
        }
        public void Update(int id, StewardessDTO stewardessDTO)
        {
            unitOfWork.Stewardesses.Update(id, Mapper.Map<Stewardess>(stewardessDTO));
        }
        public void Delete(int id)
        {
            unitOfWork.Stewardesses.Delete(id);
        }
    }
}
