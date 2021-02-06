using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Brand{Id = 1,Name = "HONDA"},
                new Brand{Id = 2,Name = "TOYOTA"},
                new Brand{Id = 3,Name = "FORD"},
                new Brand{Id = 4,Name = "FIAT"},
                new Brand{Id = 5,Name = "MERCEDES"}
            };
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Brand brand)
        {
            brand.Id = _brands.Last().Id + 1;
            _brands.Add(brand);
            Console.WriteLine("{0} Basarili bir sekilde sisteme eklenmistir.", brand.Name);
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.Id == brand.Id);
            brandToUpdate.Name = brand.Name;
            Console.WriteLine("Guncelleme basarili bir sekilde gerceklestirilmistir.Guncellenen markanin yeni bilgileri asagida ki gibidir.");
            Console.WriteLine("Marka Id:{0} Marka Ismi:{1}",brandToUpdate.Id, brandToUpdate.Name);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.Name == brand.Name);
            _brands.Remove(brandToDelete);
            Console.WriteLine("{0} Basarili bir sekilde sistemden silinmistir.", brandToDelete.Name);
        }

        public List<Brand> GetAllBrands()
        {
            return _brands;
        }
    }
}
