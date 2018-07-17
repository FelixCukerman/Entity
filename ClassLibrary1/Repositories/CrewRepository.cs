using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;

namespace HometaskEntity.DAL.Repositories
{
    public class CrewRepository : IRepository<Crew>
    {
        private AirportContext data;

        public CrewRepository(AirportContext data)
        {
            this.data = data;
        }
        public IEnumerable<Crew> GetAll()
        {
            return data.Crews;
        }
        public Crew Get(int id)
        {
            return data.Crews.FirstOrDefault(x => x.Id == id);
        }
        public void Create(Crew crew)
        {
            data.Crews.Add(crew);
            data.SaveChanges();
        }
        public void Update(int id, Crew crew)
        {
            var item = data.Crews.FirstOrDefault(x => x.Id == id);
            item = crew;
            data.SaveChanges();
        }
        public void Delete(int id)
        {
            Crew crew = data.Crews.FirstOrDefault(x => x.Id == id);
            if (crew != null)
                data.Crews.Remove(crew);
            data.SaveChanges();
        }
    }
}
