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

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Arac Sisteme basariyla eklendi.");
            }
            else
            {
                Console.WriteLine("Lutfen aracin gunluk kirasini sifirdan buyuk bir deger giriniz.");
            }
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Araba sistemde basariyla guncellendi.");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araba sistemden basariyla silindi.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c=>c.Id == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p => p.DailyPrice>=min && p.DailyPrice<=max);
        }

        public List<Car> GetByModelYear(int year)
        {
            return _carDal.GetAll(p => p.ModelYear == year);
        }
    }
}
