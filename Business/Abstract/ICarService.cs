using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        Car GetById(int id);
        List<Car> GetCarsByColorId(int id);
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        List<Car> GetByModelYear(int year);
        List<CarDetailDto> GetCarDetails();

    }
}
