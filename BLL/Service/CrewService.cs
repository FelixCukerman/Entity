using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using HometaskEntity.BLL.DTOs;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.BLL.Contracts;

namespace HometaskEntity.BLL.Service
{
    public class CrewService : IService<CrewDTO>
    {
        IUnitOfWork unitOfWork;
        public CrewService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<CrewDTO> GetAll()
        {
            return Mapper.Map<List<CrewDTO>>(unitOfWork.Crews.GetAll());
        }
        public CrewDTO GetById(int id)
        {
            return Mapper.Map<List<CrewDTO>>(unitOfWork.Aviators.GetAll()).FirstOrDefault(x => x.Id == id);
        }
        public void Create(CrewDTO crewDTO)
        {
            unitOfWork.Crews.Create(Mapper.Map<Crew>(crewDTO));
        }
        public void Update(int id, CrewDTO crewDTO)
        {
            unitOfWork.Crews.Update(id, Mapper.Map<Crew>(crewDTO));
        }
        public void Delete(int id)
        {
            unitOfWork.Crews.Delete(id);
        }
    }
}
