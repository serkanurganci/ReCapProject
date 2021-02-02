using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDataTransferDal
    {
        List<CarDataTransfer> GetCarDataTransfer(List<Car> cars, List<Brand> brands);
    }
}
