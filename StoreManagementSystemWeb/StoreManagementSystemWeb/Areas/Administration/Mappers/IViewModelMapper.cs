using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagementSystemWeb.Data.Models;

namespace StoreManagementSystemWeb.Areas.Administration.Mappers
{
    public interface IViewModelMapper<TEntity, TViewModel>
    {
        TViewModel MapFrom(TEntity entity);
    }
}
