using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT.Core.Model.ViewModel;

namespace PROJECT.Web.Controllers
{
    public class Student11Controller : Controller
    {
        // GET: Student11
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student11ViewModel objEntity)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(objEntity);
        }
    }
}