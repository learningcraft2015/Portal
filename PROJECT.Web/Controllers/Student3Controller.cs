using PROJECT.Core.Helpers;
using PROJECT.Core.Model.ViewModel;
using PROJECT.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFlashMessages;
using System.Data.SqlTypes;

namespace PROJECT.Web.Controllers
{


    public class Student3Controller : Controller
    {
        // GET: Student3
        public ActionResult Search(string Keyword)
        {
            if (!string.IsNullOrWhiteSpace(Keyword) || !string.IsNullOrEmpty(Keyword))
            {
                Keyword = Keyword.Trim();
            }
            var objEntity = new Student2ViewModel()
            {
                Keyword = Keyword
            };


            var objStudent2Repository = new Student2Repository();
            // objEntity.Student2SearchList = new List<Student2ViewModel>();

            objEntity.Student2SearchList = objStudent2Repository.Search(StudentFlags.SelectAllByKeyword.GetHashCode(), objEntity);



            if (objEntity.Student2SearchList.Count >= 0 && !string.IsNullOrWhiteSpace(Keyword))
            {

                this.Flash("Success", string.Format("Your search for '{0}' returns {1} result(s).", Keyword, objEntity.Student2SearchList.Count().ToString()));
            }
            else if (objEntity.Student2SearchList.Count == 0)
            {
                this.Flash("Warning", string.Format(@"Your search returns {0} result(s)", 0));
                //flash message
            }

            return View(objEntity);
        }


        public ActionResult Report(string strFromDate, string strToDate, int filterId = 0)
        {
            Student2ViewModel objEntity = new Student2ViewModel();
            var objStudent2Repository = new Student2Repository();
            objEntity.Student2ReportList = new List<Student2ViewModel>();

            if (string.IsNullOrEmpty(strFromDate))
            {
                objEntity.FromDate = null;


            }
            else
            {
                objEntity.strFromDate = strFromDate;
                objEntity.FromDate = Convert.ToDateTime(strFromDate);
            }
            if (string.IsNullOrEmpty(strToDate))
            {
                objEntity.ToDate = null;


            }
            else
            {
                objEntity.strToDate = strToDate;
                objEntity.ToDate = Convert.ToDateTime(strToDate);
            }

            objEntity.CourseId = filterId;
            objEntity.filterId = filterId;

            #region DatabaseDropdown

            var objCourseRepository = new CourseRepository();
            var objCourseViewModelEntity = objCourseRepository.Select(CourseFlags.SelectAll.GetHashCode(), new CourseViewModel());
            objEntity.CourseList = new SelectList(objCourseViewModelEntity.Select(model => new { model.CourseId, model.CourseTitle }), "CourseId", "CourseTitle");

            #endregion

            if (objEntity.FromDate.HasValue && objEntity.ToDate.HasValue && objEntity.FromDate > objEntity.ToDate)
            {
                this.Flash("Warning", "From Date is smaller than To Date.");
                return View(objEntity);

            }





            objEntity.Student2ReportList = objStudent2Repository.Report(StudentFlags.SelectAllByReport.GetHashCode(), objEntity);


            if (objEntity.Student2ReportList.Count == 0 && (!string.IsNullOrEmpty(strFromDate) || !string.IsNullOrEmpty(strToDate) || filterId > 0))
            {
                this.Flash("Warning", "No matching records found.");
            }


            return View(objEntity);

        }


        public ActionResult Dashboard()
        {


            var objEntity = new UserDashboardViewModel();
            var objStudent2Repository = new Student2Repository();


            #region RecentMembersDashboard

            objEntity.Student2RecentMembersList = objStudent2Repository.Select(StudentFlags.SelectAllByRecentMembers.GetHashCode(), new Student2ViewModel()
            {


                CreatedBy = 1 //Admin UserId or login UserId


            });

            #endregion
            #region RecentActiveMembersDashboard

            objEntity.Student2RecentActiveMembersList = objStudent2Repository.Select(StudentFlags.SelectAllByRecentActiveMembers.GetHashCode(), new Student2ViewModel()
            {


                CreatedBy = 1 //Admin UserId or login UserId


            });

            #endregion









            if (objEntity.Student2RecentMembersList.Count == 0)
            {
                // this.Flash("Warning", string.Format(@"Your search returns {0} result(s)", 0));
                //flash message
            }

            return View(objEntity);
        }


    }
}