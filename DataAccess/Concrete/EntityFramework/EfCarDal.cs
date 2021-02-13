using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join r in context.Colors
                        on c.ColorId equals r.Id
                    select new CarDetailDto {CarId = c.Id,BrandId = b.Id,ColorId =r.Id ,BrandName= b.Name,ModelYear = c.ModelYear,ColorName = r.Name,DailyPrice = c.DailyPrice,Description = c.Description};
                return result.ToList();
            }
        }
    }
}
