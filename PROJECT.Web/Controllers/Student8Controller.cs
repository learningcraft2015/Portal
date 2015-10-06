using PROJECT.Core.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJECT.Web.Controllers
{
    public class Student8Controller : Controller
    {
        // GET: Student8
        public ActionResult Create()
        {
          
         
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student8ViewModel objEntity)
        {
            if (ModelState.IsValid)
            {
                 
            }
            return View(objEntity);
        }

        public ActionResult Details()
        {
            Student8ViewModel objEntity = new Student8ViewModel();
            objEntity.Title = "asdasd";
            objEntity.Description = "sdfsd<b>asdasda</b>  sdfsd<br/>dfg<br/>df<br/>fg<br/>fdg<br/>dfg<br/>dfg<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>xzxcvxc<h2>xcvxcv</h2>";
            return View(objEntity);
        }
    }
}