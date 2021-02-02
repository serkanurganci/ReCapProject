using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarDataTransferManager:ICarDataTransferService
    {
        ICarDataTransferDal _carDataTransferDal;

        public CarDataTransferManager(ICarDataTransferDal carDataTransferDal)
        {
            _carDataTransferDal = carDataTransferDal;
        }
        public List<CarDataTransfer> GetCarDataTransfer(List<Car> cars, List<Brand> brands)
        {
            return _carDataTransferDal.GetCarDataTransfer(cars, brands);
        }
    }
}
