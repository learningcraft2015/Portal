using PROJECT.Core.Helpers;
using PROJECT.Core.Model.ViewModel;
using PROJECT.Core.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcFlashMessages;


namespace PROJECT.Web.Controllers
{
    public class Student4Controller : Controller
    {
        // GET: Student4
        public ActionResult Index()
        {
            var objStudent2Repository = new Student2Repository();
            List<Student2ViewModel> objEntityList = objStudent2Repository.Select(StudentFlags.SelectAll.GetHashCode(), new Student2ViewModel());
            if (objEntityList.Count == 0)
            {
                this.Flash("Error", "No Students");

            }
            return View(objEntityList);
        }

        public ActionResult Details(int id)
        {
            Student2Repository objStudent2Repository = new Student2Repository();
            Student2ViewModel objEntity = new Student2ViewModel();

            objEntity = objStudent2Repository.Select(StudentFlags.SelectByID.GetHashCode(), new Student2ViewModel()
            {
                StudentId = id
            }).FirstOrDefault();
            if (objEntity == null)
            {

                return RedirectToAction("Index");
            }

            return View(objEntity);
        }
    }
}