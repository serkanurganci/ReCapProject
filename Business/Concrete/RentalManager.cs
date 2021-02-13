using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        public IResult Add(Rental rental)
        {
            
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(Rental rental)
        {
            
            if (GetById(rental.Id).Data.ReturnDate == null)
            {
                
                return new SuccessResult(Messages.Updated);
            }
            else
            {
                return new ErrorResult(Messages.Undelivered);
            }
            _rentalDal.Update(rental);

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Delete);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetail()
        {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),
                    Messages.Listed);
        }
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }
    }
}
