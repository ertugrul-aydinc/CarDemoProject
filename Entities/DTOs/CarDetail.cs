using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetail:IDto
    {
        public int DailyPrice { get; set; }
        public string Description { get; set; }

        public string ColorName { get; set; }

        public string BrandName { get; set; }

    }
}
