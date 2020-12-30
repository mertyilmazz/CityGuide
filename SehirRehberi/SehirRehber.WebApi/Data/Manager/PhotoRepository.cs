using SehirRehber.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehber.WebApi.Data
{
    public class PhotoRepository : AppRepository<Photo>, IPhotoRepository
    {
        private DataContext _context;
        public PhotoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Photo GetPhoto(int id)
        {
            var photo = _context.Photos.FirstOrDefault(f => f.Id == id);
            return photo;
        }

        public List<Photo> GetPhotosByCity(int cityId)
        {
            var photos = _context.Photos.Where(p => p.CityId == cityId).ToList();
            return photos;
        }
    }
}
