using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehber.WebApi.Data;
using SehirRehber.WebApi.Dtos;
using SehirRehber.WebApi.Model;

namespace SehirRehber.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private ICityRepository _citiesRepository;
        private IPhotoRepository _photoRepository;
        private IMapper _mapper;


        public CitiesController(ICityRepository citiesRepository, IMapper mapper, IPhotoRepository photoRepository)
        {
            _citiesRepository = citiesRepository;
            _mapper = mapper;
            _photoRepository = photoRepository;
        }

        public ActionResult GetCities()
        {
            //var cities = _citiesRepository.GetCities().Select(f=> new CityForListDto
            //{
            //    Description=f.Description,
            //    Id=f.Id,
            //    Name =f.Name,
            //    PhotoUrl =f.Photos.FirstOrDefault(p=>p.IsMain == true).Url
            //}).ToList();
            //return Ok(cities);

            var cities = _citiesRepository.GetCities();
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(citiesToReturn);

        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody]City city)
        {
            _citiesRepository.Add(city);
            _citiesRepository.SaveAll();
            return Ok(city);
        }

        [HttpGet]
        [Route("detail")]
        public ActionResult Detail(int id)
        {
            var city = _citiesRepository.GetCityById(id);
            var cityToReturn = _mapper.Map<CityForDetailDto>(city);
            return Ok(cityToReturn);

        }

        [HttpGet]
        [Route("Photos")]
        public ActionResult GetPhotosByCity(int id)
        {
            var photos = _photoRepository.GetPhotosByCity(id);         
            return Ok(photos);
        }

    }
}