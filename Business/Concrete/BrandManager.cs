using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Brand brand)
        {
            if (brand.Name.Length > 2)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            
            
        }

        public IResult Update(Brand brand)
        {
            if (brand.Name.Length > 2)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.Updated);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Delete);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == id));
        }
    }
}
