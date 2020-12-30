using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SehirRehber.WebApi.Data;
using SehirRehber.WebApi.Dtos;
using SehirRehber.WebApi.Helper;
using SehirRehber.WebApi.Model;

namespace SehirRehber.WebApi.Controllers
{
    [Route("api/cities/{id}/photo")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private IPhotoRepository _photoRepository;
        private IMapper _mapper;
        private IOptions<CloudinarySettings> _cloudinaryConfig;
        private ICityRepository _cityRepository;
        private Cloudinary _cloudinary;

        public PhotosController(IPhotoRepository photoRepository, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig, ICityRepository cityRepository)
        {
            _photoRepository = photoRepository;
            _mapper = mapper;
            _cloudinaryConfig = cloudinaryConfig;
            _cityRepository = cityRepository;

            Account account = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
                );

            _cloudinary = new Cloudinary(account);
        }


        [HttpPost]
        public ActionResult AddPhotoForCity(int cityId, [FromBody] PhotoForCreationDto photoForCreationDto)
        {
            var city = _cityRepository.Get(cityId);

            if (city == null)
            {
                return BadRequest("Could not find the city");
            }

            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (currentUserId != city.UserId)
            {
                return Unauthorized();
            }

            var file = photoForCreationDto.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }

                photoForCreationDto.Url = uploadResult.Uri.ToString();
                photoForCreationDto.PublicId = uploadResult.PublicId;

                var photo = _mapper.Map<Photo>(photoForCreationDto);
                photo.City = city;

                if (!city.Photos.Any(p => p.IsMain))
                {
                    photo.IsMain = true;
                }
                city.Photos.Add(photo);

                if (_photoRepository.SaveAll())
                {
                    var photoToReturn = _mapper.Map<PhotoForCreationDto>(photo);
                    return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photoToReturn);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public ActionResult GetPhoto(int Id)
        {
            var photo = _photoRepository.Get(Id);

            if (photo == null)
            {
                return BadRequest();
            }

            var photoReturn = _mapper.Map<PhotoForCreationDto>(photo);

            return Ok(photoReturn);
        }
    }
}