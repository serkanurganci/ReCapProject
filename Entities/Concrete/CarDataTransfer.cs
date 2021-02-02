using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class CarDataTransfer:IEntity
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
