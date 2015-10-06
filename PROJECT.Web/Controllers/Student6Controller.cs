using PROJECT.Core.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJECT.Web.Controllers
{
    public class Student6Controller : Controller
    {
        // GET: Student6
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student3ViewModel objEntity)
        {
            if (ModelState.IsValid)
            {

                
            }
            return View(objEntity);
        }
      //  [AllowAnonymous]
        public JsonResult CheckUserEmail(string useremail)
        {

            bool ifEmailExist = false;
            try
            {
                ifEmailExist = useremail.Equals("user@gmail.com") ? true : false;
                return Json(!ifEmailExist, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }




     

    }
}