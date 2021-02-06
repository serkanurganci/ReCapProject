using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.Name.Length > 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Marka sisteme basariyla eklendi.");
            }
            else
            {
                Console.WriteLine("Lutfen marka ismini en az iki karakter olacak sekilde giriniz.");
            }
            
            
        }

        public void Update(Brand brand)
        {
            if (brand.Name.Length > 2)
            {
                _brandDal.Update(brand);
                Console.WriteLine("Marka sistemde basariyla guncellendi.");
            }
            else
            {
                Console.WriteLine("Lutfen marka ismini en az iki karakter olacak sekilde giriniz.");
            }
            
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Marka sistemden basariyla silindi.");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get();
        }
    }
}
