using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                //Bir veri tabanindan geliyormus gibi simule ediyoruz.
                new Car{Id = 1,BrandId = 1,ColorId = 1,ModelYear=2008,DailyPrice = 100,Description = "RENT A CAR KASKOLUDUR.BAKIMLIDIR"},
                new Car{Id = 2,BrandId = 2,ColorId = 2,ModelYear=2014,DailyPrice = 200,Description = "AZ YAKAR, UZMEZ."},
                new Car{Id = 3,BrandId = 3,ColorId = 2,ModelYear=2013,DailyPrice = 180,Description = "OTOMATIK VITES,SORUNSUZDUR"},
                new Car{Id = 4,BrandId = 3,ColorId = 3,ModelYear=2012,DailyPrice = 250,Description = "TAM BIR UZUN YOL ARACIDIR"},
                new Car{Id = 5,BrandId = 4,ColorId = 3,ModelYear=2018,DailyPrice = 400,Description = "SUNROOFLU VE EN DOLUSUDUR."},
            };
        }


        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            car.Id = _cars.Last().Id + 1;
            _cars.Add(car);
            Console.WriteLine("Araciniz {0} TL fiyat etiketi ile basariyla eklendi.",car.DailyPrice);
        }

        public void Update(Car car)
        {
            //guncellemek icin gonderilen car objesinin id sini tum car objelerinin bulundugu _cars objesinde ara esleseni carToUpdate
            //isimli yeni car nesnesine tuttur.
            Car carToUpdate = null;
            carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            //gonderilen bilgiler ile car objesini guncelle
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            Console.WriteLine("\n Arac basariyla guncellenmistir. Guncellenen arac bilgileri asagida ki gibidir: \n");
            Console.WriteLine("Model:{0}  Fiyat:{1} Açıklama:{2}\n", carToUpdate.ModelYear, carToUpdate.DailyPrice, carToUpdate.Description);
        }

        public void Delete(Car car)
        {
            //gonderilen urun id'sine sahip olan urunu listede bul ve sil
            Car carToDelete = null;

            carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
            Console.WriteLine("Silinmesini istediginiz {0} model araba basariyla silindi.", carToDelete.ModelYear);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public Car GetById(Car car)
        {
            return _cars.SingleOrDefault(c => c.Id == car.Id);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
        public List<Car> GetByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetByPrice()
        {
            return _cars.OrderByDescending(c => c.DailyPrice).ToList();
        }

        public List<Car> GetByModelYear()
        {
            return _cars.OrderByDescending(c => c.ModelYear).ToList();
        }
    }
}
