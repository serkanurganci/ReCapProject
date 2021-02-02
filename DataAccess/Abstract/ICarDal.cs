using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        Car GetById(Car carId);
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetByBrand(int brandId);
        List<Car> GetByPrice();
        List<Car> GetByModelYear();
    }
}
