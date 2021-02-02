using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public Car GetById(Car carId)
        {
            return _carDal.GetById(carId);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _carDal.GetByBrand(brandId);
        }

        public List<Car> GetByModelYear()
        {
            return _carDal.GetByModelYear();
        }

        public List<Car> GetByPrice()
        {
            return _carDal.GetByPrice();
        }
    }
}
