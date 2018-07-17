using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.DAL.Models;

namespace HometaskEntity.DAL.Repositories
{
    public class TypePlaneRepository : IRepository<TypePlane>
    {
        private AirportContext data;

        public TypePlaneRepository(AirportContext data)
        {
            this.data = data;
        }
        public IEnumerable<TypePlane> GetAll()
        {
            return data.TypesPlane;
        }
        public TypePlane Get(int id)
        {
            return data.TypesPlane.FirstOrDefault(x => x.Id == id);
        }
        public void Create(TypePlane typePlane)
        {
            data.TypesPlane.Add(typePlane);
            data.SaveChanges();
        }
        public void Update(int id, TypePlane typePlane)
        {
            var item = data.TypesPlane.FirstOrDefault(x => x.Id == id);
            item = typePlane;
            data.SaveChanges();
        }
        public void Delete(int id)
        {
            TypePlane typePlane = data.TypesPlane.FirstOrDefault(x => x.Id == id);
            if (typePlane != null)
                data.TypesPlane.Remove(typePlane);
            data.SaveChanges();
        }
    }
}
