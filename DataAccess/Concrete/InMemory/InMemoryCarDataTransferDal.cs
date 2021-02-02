using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDataTransferDal : ICarDataTransferDal
    {
        public List<CarDataTransfer> GetCarDataTransfer(List<Car> cars, List<Brand> brands)
        {
            var dataTransferList = from car in cars
                join brand in brands on car.BrandId equals brand.BrandId
                select new CarDataTransfer
                {
                    Id = car.Id,
                    DailyPrice = car.DailyPrice,
                    Description = car.Description,
                    BrandName = brand.BrandName
                };

            return dataTransferList.ToList();
        }
    }
}
