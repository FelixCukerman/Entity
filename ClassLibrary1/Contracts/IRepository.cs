using System;
using System.Collections.Generic;
using System.Text;

namespace HometaskEntity.DAL.Contracts
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(int id, T item);
        void Delete(int id);
    }
}
