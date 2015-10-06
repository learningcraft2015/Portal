using PROJECT.Core.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJECT.Web.Controllers
{
    public class Student10Controller : Controller
    {
      
        public ActionResult Create()
        {
            Student10ViewModel objEntity = new Student10ViewModel();

            List<ProductViewModel> objProducts = new List<ProductViewModel>();
            objProducts.Add(new ProductViewModel() { ProductId = 1, ProductName="xyz",Quantity = 10 });
            objProducts.Add(new ProductViewModel() { ProductId = 2,  ProductName="pqr",Quantity = 20 });
            objEntity.ProductList = objProducts;

            return View(objEntity);
        }
        [HttpPost]
        public ActionResult Create(Student10ViewModel objEntity)
        {
            
            if (ModelState.IsValid)
            {

                foreach (var item in objEntity.ProductList)
                {
                    objEntity.productId = item.ProductId;

                }
            }
            return View(objEntity);
        }

       
    }
}