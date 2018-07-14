using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.DAL.Models;

namespace HometaskEntity.DAL.Repositories
{
    public class FlightRepository : IRepository<Flight>
    {
        private AirportContext data;
        public FlightRepository(AirportContext data)
        {
            this.data = data;
        }
        public IEnumerable<Flight> GetAll()
        {
            return data.Flights;
        }
        public Flight Get(int id)
        {
            return data.Flights.FirstOrDefault(x => x.Number == id);
        }
        public void Create(Flight flight)
        {
            data.Flights.Add(flight);
        }
        public void Update(int id, Flight flight)
        {
            var item = data.Flights.FirstOrDefault(x => x.Number == id);
            item = flight;
        }
        public void Delete(int id)
        {
            Flight flight = data.Flights.FirstOrDefault(x => x.Number == id);
            if (flight != null)
                data.Flights.Remove(flight);
        }
    }
}
