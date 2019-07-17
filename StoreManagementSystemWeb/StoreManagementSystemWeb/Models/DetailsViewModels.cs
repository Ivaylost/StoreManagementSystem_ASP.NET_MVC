using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Models
{
    public class DetailsViewModels
    {
        public Product Product { get; set; }

        [Range(1, 10, ErrorMessage = "Quantity should be betwееn 1 and 10 or less then avaliable quantity")]
        public int Quantity { get; set; }

        public int ProductId { get; set; }
    }
}
