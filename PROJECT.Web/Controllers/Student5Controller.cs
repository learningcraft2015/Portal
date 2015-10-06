using PROJECT.Core.Helpers;
using PROJECT.Core.Model.ViewModel;
using PROJECT.Core.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcFlashMessages;

namespace PROJECT.Web.Controllers
{
    public class Student5Controller : Controller
    {
        // GET: Student5
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult ListGalleryTop4()
        {
            var objStudent2Repository = new Student2Repository();
            List<Student2ViewModel> objEntityList = objStudent2Repository.Select(StudentFlags.SelectTop4ByRecentDate.GetHashCode(), new Student2ViewModel());
            if (objEntityList.Count == 0)
            {
                this.Flash("Error", "No Students");

            }


            return PartialView("_PartialListGalleryTop4", objEntityList);
        }

        [ChildActionOnly]
        public ActionResult ListGalleryTop4Random()
        {
            var objStudent2Repository = new Student2Repository();
            List<Student2ViewModel> objEntityList = objStudent2Repository.Select(StudentFlags.SelectTop4ByRandom.GetHashCode(), new Student2ViewModel());
            if (objEntityList.Count == 0)
            {
                this.Flash("Error", "No Students");

            }


            return PartialView("_PartialListGalleryTop4Random", objEntityList);
        }

    }
}