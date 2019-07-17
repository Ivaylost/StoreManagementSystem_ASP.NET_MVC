using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreManagementSystemWeb.Areas.Administration.Mappers;
using StoreManagementSystemWeb.Areas.Administration.Models;
using StoreManagementSystemWeb.Areas.Models;
using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagementSystemWeb.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService supplierService;
        private readonly IViewModelMapper<Supplier, SupplierViewModel> supplierMapper;
        private readonly IViewModelMapper<IReadOnlyCollection<Supplier>, AdminViewModel> homeViewModelMapper;


        public SupplierController(
            ISupplierService supplierService,
            IViewModelMapper<Supplier, SupplierViewModel> supplierMapper,
            IViewModelMapper<IReadOnlyCollection<Supplier>, AdminViewModel> homeViewModelMapper)
        {
            this.supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            this.supplierMapper = supplierMapper ?? throw new ArgumentNullException(nameof(supplierMapper));
            this.homeViewModelMapper = homeViewModelMapper ?? throw new ArgumentNullException(nameof(homeViewModelMapper));
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SupplierViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var supplier = this.supplierService.CreateSupplier(model.SupplierName, model.IdentificationalNumber, model.RespresentedBy,
                    model.Adress, model.PhoneNumber);

                return RedirectToAction("AllSuppliers", "Supplier");
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return View(model);
            }

        }


        public IActionResult AllSuppliers()
        {
            var suppliers = this.supplierService.GetAllSuppliers();

            var model = this.homeViewModelMapper.MapFrom(suppliers);

            return View("AllSuppliers", model);
        }
        [HttpGet]
        public IActionResult AddSupplier(int Id)
        {
            var suppliers = this.supplierService.GetAllSuppliers();

            var model = new AddSupplierViewModel
            {
                ProductId = Id,
                //SupplierName = supplierName,
                Suppliers = suppliers.Select(x => new SelectListItem(x.SupplierName, x.Id.ToString()))
            };
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSupplier(AddSupplierViewModel model)
        {
            //Logic
            var productSupplier = this.supplierService.AddSupplier(model.ProductId, model.SupplierId);

            return RedirectToAction("AllProducts", "Product");

        }


    }
}