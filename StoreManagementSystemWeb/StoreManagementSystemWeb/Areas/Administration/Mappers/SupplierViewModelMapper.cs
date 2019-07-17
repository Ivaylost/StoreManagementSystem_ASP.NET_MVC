using StoreManagementSystemWeb.Areas.Administration.Models;
using StoreManagementSystemWeb.Areas.Models;
using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Areas.Administration.Mappers
{
    public class SupplierViewModelMapper: IViewModelMapper<Supplier, SupplierViewModel>
    {
        public SupplierViewModel MapFrom(Supplier entity)
     => new SupplierViewModel
     {
         Id = entity.Id,
         SupplierName = entity.SupplierName,
         IdentificationalNumber = entity.IdentificationNumber,
         RespresentedBy = entity.RepresentedBy,
         Adress = entity.Address,
         PhoneNumber = entity.PhoneNumber,
     };
    }
}
