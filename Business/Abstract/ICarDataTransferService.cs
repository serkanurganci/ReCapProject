using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    interface ICarDataTransferService
    {
        List<CarDataTransfer> GetCarDataTransfer(List<Car> cars, List<Brand> brands);
    }
}
