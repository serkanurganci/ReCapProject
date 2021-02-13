using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    { 
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string BrandName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }
    }
}
