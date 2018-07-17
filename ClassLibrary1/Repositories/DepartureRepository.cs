using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;

namespace HometaskEntity.DAL.Repositories
{
    public class DepartureRepository : IRepository<Departure>
    {
        private AirportContext data;

        public DepartureRepository(AirportContext data)
        {
            this.data = data;
        }
        public IEnumerable<Departure> GetAll()
        {
            return data.Departures;
        }
        public Departure Get(int id)
        {
            return data.Departures.FirstOrDefault(x => x.Id == id);
        }
        public void Create(Departure departure)
        {
            data.Departures.Add(departure);
            data.SaveChanges();
        }
        public void Update(int id, Departure departure)
        {
            var item = data.Departures.FirstOrDefault(x => x.Id == id);
            item = departure;
            data.SaveChanges();
        }
        public void Delete(int id)
        {
            Departure departure = data.Departures.FirstOrDefault(x => x.Id == id);
            if (departure != null)
                data.Departures.Remove(departure);
            data.SaveChanges();
        }
    }
}
