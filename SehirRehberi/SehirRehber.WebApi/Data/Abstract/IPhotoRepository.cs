using SehirRehber.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehber.WebApi.Data
{
    public interface IPhotoRepository : IAppRepository<Photo>
    {
        Photo GetPhoto(int id);

        List<Photo> GetPhotosByCity(int cityId);
    }
}
