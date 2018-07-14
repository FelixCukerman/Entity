using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.DAL.Models;

namespace HometaskEntity.DAL.Repositories
{
    public class PlaneRepository : IRepository<Plane>
    {
        private AirportContext data;
        public PlaneRepository(AirportContext data)
        {
            this.data = data;
        }
        public IEnumerable<Plane> GetAll()
        {
            return data.Planes;
        }
        public Plane Get(int id)
        {
            return data.Planes.FirstOrDefault(x => x.Id == id);
        }
        public void Create(Plane plane)
        {
            data.Planes.Add(plane);
        }
        public void Update(int id, Plane plane)
        {
            var item = data.Planes.FirstOrDefault(x => x.Id == id);
            item = plane;
        }
        public void Delete(int id)
        {
            Plane plane = data.Planes.FirstOrDefault(x => x.Id == id);
            if (plane != null)
                data.Planes.Remove(plane);
        }
    }
}
