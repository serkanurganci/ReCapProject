using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        Car GetById(Car carId);
        List<Car> GetAll();
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<Car> GetByBrandId(int brandId);
        List<Car> GetByModelYear();
        List<Car> GetByPrice();
    }
}
