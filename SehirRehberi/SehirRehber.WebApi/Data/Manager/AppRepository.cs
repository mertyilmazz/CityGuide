using SehirRehber.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehber.WebApi.Data
{
    public class AppRepository<T> : IAppRepository<T> where T : class
    {

        private DataContext _context;

        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public List<T> Get(T entity)
        {
            var data = _context.Set<T>().ToList();
            return data;          
        }

        public T Get(int id)
        {
            var data = _context.Set<T>().Find(id);
            return data;
        }       

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
