using Microsoft.EntityFrameworkCore;
using SehirRehber.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehber.WebApi.Data
{
    public class CityRepository : AppRepository<City>, ICityRepository
    {
        private DataContext _context;
        public CityRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public List<City> GetCities()
        {
            var cities = _context.Cities.Include(c => c.Photos).ToList();
            return cities;
        }

        public City GetCityById(int cityId)
        {
            var city = _context.Cities.Include(c => c.Photos).FirstOrDefault(c => c.Id == cityId);
            return city;
        }
    }
}
