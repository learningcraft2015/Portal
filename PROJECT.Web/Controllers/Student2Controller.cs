using PROJECT.Core.Helpers;
using PROJECT.Core.Model.ViewModel;
using PROJECT.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFlashMessages;
using System.IO;


namespace PROJECT.Web.Controllers
{

    public class Student2Controller : Controller
    {

        // GET: Student2
        public ActionResult Create()
        {
            Student2ViewModel objEntity = new Student2ViewModel();




            #region DatabaseDropdown
            var objCourseRepository = new CourseRepository();
            var objCourseViewModelEntity = objCourseRepository.Select(CourseFlags.SelectAll.GetHashCode(), new CourseViewModel());
            objEntity.CourseList = new SelectList(objCourseViewModelEntity.Select(model => new { model.CourseId, model.CourseTitle }), "CourseId", "CourseTitle");
            #endregion

            #region DatabaseOptionGroup

            CountryStateRepository objCountryStateRepository = new CountryStateRepository();
            var objCountryStateEntityList = objCountryStateRepository.Select(CountryStateFlags.SelectAllForOptionGroup.GetHashCode(), new CountryStateViewModel());
            objEntity.SelectCountryList = new SelectList(objCountryStateEntityList, "StateId", "StateName", "CountryName", 1);
            #endregion

            objEntity.CurrentDate = DateTime.Now;

            objEntity.CurrentDateTime = DateTime.Now;

            return View(objEntity);
        }

        [HttpPost]
        public ActionResult Create(Student2ViewModel objEntity)
        {

            Student2Repository objStudent2Repository = new Student2Repository();
            CountryStateRepository objCountryStateRepository = new CountryStateRepository();
            string fileName = string.Empty;

            if (ModelState.IsValid)
            {
                objEntity.Status = StatusEnum.Active;

                objEntity.CreatedBy = 1;//admin userid



                #region FileUpload

                if (objEntity.UploadFile != null)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(objEntity.UploadFile.FileName);
                    objEntity.FileName = fileName;

                }
                else
                {
                    objEntity.FileName = string.Empty;
                }



                #endregion
                objEntity = objStudent2Repository.Insert(objEntity);

                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {

                    #region FileUpload

                    //file name
                    if (objEntity.UploadFile != null)
                    {
                        string path = Path.Combine(Server.MapPath(ApplicationConstant.UPLOADED_STUDENT_IMAGE_PATH), fileName);
                        // WebImage.Save()
                        objEntity.UploadFile.SaveAs(path);
                    }



                    #endregion
                    //   Install-Package MvcFlashMessages
                    this.Flash("Success", "Student Insert successfully ");

                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {
                    this.Flash("Error", "Faild to Insert Student");
                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Duplicate.GetHashCode())
                {
                    this.Flash("Warning", "Student Name is Already Exist");
                    return RedirectToAction("Index");
                }


            }
            #region DatabaseDropdown
            var objCourseRepository = new CourseRepository();
            var objCourseViewModelEntity = objCourseRepository.Select(CourseFlags.SelectAll.GetHashCode(), new CourseViewModel());
            objEntity.CourseList = new SelectList(objCourseViewModelEntity.Select(model => new { model.CourseId, model.CourseTitle }), "CourseId", "CourseTitle");
            #endregion

            #region DatabaseOptionGroup


            var objCountryStateEntityList = objCountryStateRepository.Select(CountryStateFlags.SelectAllForOptionGroup.GetHashCode(), new CountryStateViewModel());
            objEntity.SelectCountryList = new SelectList(objCountryStateEntityList, "StateId", "StateName", "CountryName", 1);
            #endregion
            return View(objEntity);
        }


        public ActionResult Edit(int id)
        {
            Student2Repository objStudent2Repository = new Student2Repository();
            Student2ViewModel objEntity = new Student2ViewModel();
            CountryStateRepository objCountryStateRepository = new CountryStateRepository();

            objEntity = objStudent2Repository.Select(StudentFlags.SelectByID.GetHashCode(), new Student2ViewModel()
            {
                StudentId = id

            }).FirstOrDefault();
            if (objEntity == null)
            {

                return RedirectToAction("Index");
            }
            objEntity.CurrentTimeValue = objEntity.CurrentTime.HasValue ? objEntity.CurrentTime.Value.ToString("hh:mm tt") : string.Empty;


            #region DatabaseDropdown
            var objCourseRepository = new CourseRepository();
            var objCourseViewModelEntity = objCourseRepository.Select(CourseFlags.SelectAll.GetHashCode(), new CourseViewModel());
            objEntity.CourseList = new SelectList(objCourseViewModelEntity.Select(model => new { model.CourseId, model.CourseTitle }), "CourseId", "CourseTitle");
            #endregion

            #region DatabaseOptionGroup


            var objCountryStateEntityList = objCountryStateRepository.Select(CountryStateFlags.SelectAllForOptionGroup.GetHashCode(), new CountryStateViewModel());
            objEntity.SelectCountryList = new SelectList(objCountryStateEntityList, "StateId", "StateName", "CountryName", 1);
            #endregion
            return View(objEntity);
        }

        [HttpPost]
        public ActionResult Edit(int id, Student2ViewModel objEntity)
        {
            Student2Repository objStudent2Repository = new Student2Repository();
            CountryStateRepository objCountryStateRepository = new CountryStateRepository();
            string fileName = string.Empty;
            string oldFileName = string.Empty;

            if (ModelState.IsValid)
            {
                objEntity.Name = objEntity.Name.Trim();
                objEntity.StudentId = id;
                oldFileName = objEntity.FileName;

                #region FileUpload

                if (objEntity.UploadFile != null)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(objEntity.UploadFile.FileName);
                    objEntity.FileName = fileName;
                }


                #endregion



                objEntity = objStudent2Repository.Update(StudentFlags.UpdateByID.GetHashCode(), objEntity);
                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
                    #region FileUpload
                    //delete old file



                    //file name
                    if (objEntity.UploadFile != null)
                    {
                        if (!string.IsNullOrEmpty(objEntity.UploadFile.FileName))
                        {
                            ApplicationHelpers.DeleteFile(Path.Combine(Server.MapPath(ApplicationConstant.UPLOADED_STUDENT_IMAGE_PATH), oldFileName));
                        }
                        string path = Path.Combine(Server.MapPath(ApplicationConstant.UPLOADED_STUDENT_IMAGE_PATH), fileName);
                        // WebImage.Save()
                        objEntity.UploadFile.SaveAs(path);
                    }



                    #endregion
                    this.Flash("success", "Student Details updated successfully");
                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {

                    this.Flash("error", "Student Details failed to Update");
                }
                else if (objEntity.Result == ResultFlags.Duplicate.GetHashCode())
                {

                    this.Flash("warning", "Student Name is Already Exist");
                }
            }
            #region DatabaseDropdown
            var objCourseRepository = new CourseRepository();
            var objCourseViewModelEntity = objCourseRepository.Select(CourseFlags.SelectAll.GetHashCode(), new CourseViewModel());
            objEntity.CourseList = new SelectList(objCourseViewModelEntity.Select(model => new { model.CourseId, model.CourseTitle }), "CourseId", "CourseTitle");
            #endregion

            #region DatabaseOptionGroup


            var objCountryStateEntityList = objCountryStateRepository.Select(CountryStateFlags.SelectAllForOptionGroup.GetHashCode(), new CountryStateViewModel());
            objEntity.SelectCountryList = new SelectList(objCountryStateEntityList, "StateId", "StateName", "CountryName", 1);
            #endregion


            return View(objEntity);

        }
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

        public ActionResult Delete(int id)
        {

            int result = 0;
            Student2Repository objStudent2Repository = new Student2Repository();

            Student2ViewModel objEntity = new Student2ViewModel();
            CountryStateRepository objCountryStateRepository = new CountryStateRepository();

            objEntity = objStudent2Repository.Select(StudentFlags.SelectByID.GetHashCode(), new Student2ViewModel()
            {
                StudentId = id

            }).FirstOrDefault();
            if (objEntity == null)
            {
                //delete old file

                ApplicationHelpers.DeleteFile(Path.Combine(Server.MapPath(ApplicationConstant.UPLOADED_STUDENT_IMAGE_PATH), objEntity.FileName));
            }


            result = objStudent2Repository.Delete(StudentFlags.DeleteByID.GetHashCode(), new Student2ViewModel()
            {
                StudentId = id,

            });
            if (result == ResultFlags.Success.GetHashCode())
            {
                this.Flash("success", "Student Delete successfully");
                return RedirectToAction("Index");
            }
            else if (result == ResultFlags.Failure.GetHashCode())
            {
                this.Flash("error", "Faild to Delete Student");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}