using SehirRehber.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehber.WebApi.Data
{
    public interface ICityRepository : IAppRepository<City>
    {
        List<City> GetCities();

        City GetCityById(int cityId);
    }
}
