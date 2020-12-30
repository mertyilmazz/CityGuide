using SehirRehber.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehber.WebApi.Data
{
    public interface IAppRepository<T> where T:class
    {
        void Add(T entity);

        void Delete(T entity);

        bool SaveAll();

        List<T> Get(T entity);          

        T Get(int id);
    }
}
