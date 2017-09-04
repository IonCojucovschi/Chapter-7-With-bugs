using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Repository;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository _repository;

        public ProductController(IProductRepository reposit)
        {
            _repository = reposit;
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = _repository.GettAll();
            return View(products);
        }
        public ViewResult List(string category,int page=1) {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = _repository.Pagin(page,category),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = 4,///PAgeSize  numarul max de obiecte pe o pagina
                    TotalItems = category == null ? _repository.Count() : _repository.GettAll().Where(e => e.Category == category).Count()
                },
                CurrentCategory=category
            };
            //variabila model reprezinta o compozitie dintr-un element pageproducts
            //si informatia desepre pagina dupa cum se vede mai sus.

            var products = _repository.Pagin(page,category);
            return View(model);
        }
    }
}