﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehber.WebApi.Dtos
{
    public class CityForListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string PhotoUrl { get; set; }

    }
}
