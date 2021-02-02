using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal:IBrandDal
    {
        List<Brand> _brands;

        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand{BrandId = 1,BrandName = "HONDA"},
                new Brand{BrandId = 2,BrandName = "TOYOTA"},
                new Brand{BrandId = 3,BrandName = "FORD"},
                new Brand{BrandId = 4,BrandName = "FIAT"},
                new Brand{BrandId = 5,BrandName = "MERCEDES"}
            };
        }
        public void Add(Brand brand)
        {
            brand.BrandId = _brands.Last().BrandId + 1;
            _brands.Add(brand);
            Console.WriteLine("{0} Basarili bir sekilde sisteme eklenmistir.", brand.BrandName);
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
            Console.WriteLine("Guncelleme basarili bir sekilde gerceklestirilmistir.Guncellenen markanin yeni bilgileri asagida ki gibidir.");
            Console.WriteLine("Marka Id:{0} Marka Ismi:{1}",brandToUpdate.BrandId,brandToUpdate.BrandName);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            _brands.Remove(brandToDelete);
            Console.WriteLine("{0} Basarili bir sekilde sistemden silinmistir.", brandToDelete.BrandName);
        }

        public List<Brand> GetAllBrands()
        {
            return _brands;
        }
    }
}
