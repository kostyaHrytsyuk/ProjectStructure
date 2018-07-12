using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;

namespace DAL.Repositories
{
    class Repository<T> : IRepository<T> where T : Entity
    {
        private DataSource _context;

        public Repository(DataSource context)
        {
            _context = context;
        }
            
        public List<T> GetAll()
        {
            return (List<T>)_context.Data[typeof(T)];
        }

        public T Get(int id)
        {
            return (T)_context.Data[typeof(T)].Where(e => e.Id == id).FirstOrDefault();
        }

        public void Create(T item)
        {
            ((List<T>)_context.Data[typeof(T)]).Add(item);
        }

        public void Update(T item)
        {
            var updItem = Get(item.Id);
            updItem = item;
        }

        public void Delete(int id)
        {
            var deleteItem = Get(id);
            if (deleteItem != null)
            {
                ((List<T>)_context.Data[typeof(T)]).Remove(deleteItem);
            }
        }
    }
}
    //List<T> GetAll();
    //T Get(int id);
    //void Create(T item);
    //void Update(T item);
    //void Delete(int id);


