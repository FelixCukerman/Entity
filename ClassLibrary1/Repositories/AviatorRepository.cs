using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.DAL.Models;

namespace HometaskEntity.DAL.Repositories
{
    public class AviatorRepository : IRepository<Aviator>
    {
        private AirportContext data;
        public AviatorRepository(AirportContext data)
        {
            this.data = data;
        }
        public IEnumerable<Aviator> GetAll()
        {
            return data.Aviators;
        }
        public Aviator Get(int id)
        {
            return data.Aviators.FirstOrDefault(x => x.Id == id);
        }
        public void Create(Aviator aviator)
        {
            data.Aviators.Add(aviator);
            data.SaveChanges();
        }
        public void Update(int id, Aviator aviator)
        {
            var item = data.Aviators.FirstOrDefault(x => x.Id == id);
            item = aviator;
            data.SaveChanges();
        }
        public void Delete(int id)
        {
            Aviator aviator = data.Aviators.FirstOrDefault(x => x.Id == id);
            if (aviator != null)
                data.Aviators.Remove(aviator);
            data.SaveChanges();
        }
    }
}