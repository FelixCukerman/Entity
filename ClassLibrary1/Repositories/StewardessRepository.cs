using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;

namespace HometaskEntity.DAL.Repositories
{
    public class StewardessRepository : IRepository<Stewardess>
    {
        private AirportContext data;

        public StewardessRepository(AirportContext data)
        {
            this.data = data;
        }
        public IEnumerable<Stewardess> GetAll()
        {
            return data.Stewardesses;
        }
        public Stewardess Get(int id)
        {
            return data.Stewardesses.FirstOrDefault(x => x.Id == id);
        }
        public void Create(Stewardess stewardess)
        {
            data.Stewardesses.Add(stewardess);
        }
        public void Update(int id, Stewardess stewardess)
        {
            var item = data.Stewardesses.FirstOrDefault(x => x.Id == id);
            item = stewardess;
        }
        public void Delete(int id)
        {
            Stewardess stewardess = data.Stewardesses.FirstOrDefault(x => x.Id == id);
            if (stewardess != null)
                data.Stewardesses.Remove(stewardess);
        }
    }
}
