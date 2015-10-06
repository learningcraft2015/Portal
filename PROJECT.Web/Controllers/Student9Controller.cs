using PROJECT.Core.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJECT.Web.Controllers
{
    public class Student9Controller : Controller
    {
        public ActionResult Create()
        {
            Student9ViewModel objEntity = new Student9ViewModel();


            List<SelectListItem> objStateList = new List<SelectListItem>();
            objStateList.Add(new SelectListItem { Text = "---Select---", Value = "0" });     
            objStateList.Add(new SelectListItem { Text = "India", Value = "1" });
            objStateList.Add(new SelectListItem { Text = "Srilanka", Value = "2" });
            objStateList.Add(new SelectListItem { Text = "China", Value = "3" });
            objStateList.Add(new SelectListItem { Text = "Austrila", Value = "4" });
            objStateList.Add(new SelectListItem { Text = "USA", Value = "5" });
            objStateList.Add(new SelectListItem { Text = "UK", Value = "6" });

            objEntity.CountryList = new SelectList(objStateList, "Value", "Text");


       
            return View(objEntity);
        }

        public JsonResult GetStates(string id)
        {
            List<SelectListItem> objStateList = new List<SelectListItem>();
            switch (id)
            {
                case "1":
                    objStateList.Add(new SelectListItem { Text = "---Select---", Value = "0" });
                    objStateList.Add(new SelectListItem { Text = "ANDAMAN & NIKOBAR ISLANDS", Value = "1" });
                    objStateList.Add(new SelectListItem { Text = "ANDHRA PRADESH", Value = "2" });
                    objStateList.Add(new SelectListItem { Text = "ARUNACHAL PRADESH", Value = "3" });
                    objStateList.Add(new SelectListItem { Text = "ASSAM", Value = "4" });
                    objStateList.Add(new SelectListItem { Text = "BIHAR", Value = "5" });
                    objStateList.Add(new SelectListItem { Text = "CHANDIGARH", Value = "6" });
                    objStateList.Add(new SelectListItem { Text = "CHHATTISGARH", Value = "7" });
                    objStateList.Add(new SelectListItem { Text = "DADRA & NAGAR HAVELI", Value = "8" });
                    objStateList.Add(new SelectListItem { Text = "DAMAN & DIU", Value = "9" });
                    objStateList.Add(new SelectListItem { Text = "GOA", Value = "10" });
                    objStateList.Add(new SelectListItem { Text = "GUJARAT", Value = "11" });
                    objStateList.Add(new SelectListItem { Text = "HARYANA", Value = "12" });
                    objStateList.Add(new SelectListItem { Text = "HIMACHAL PRADESH", Value = "13" });
                    objStateList.Add(new SelectListItem { Text = "JAMMU & KASHMIR", Value = "14" });
                    objStateList.Add(new SelectListItem { Text = "JHARKHAND", Value = "15" });
                    objStateList.Add(new SelectListItem { Text = "KARNATAKA", Value = "16" });
                    objStateList.Add(new SelectListItem { Text = "KERALA", Value = "17" });
                    objStateList.Add(new SelectListItem { Text = "LAKSHADWEEP", Value = "18" });
                    objStateList.Add(new SelectListItem { Text = "MADHYA PRADESH", Value = "19" });
                    objStateList.Add(new SelectListItem { Text = "MAHARASHTRA", Value = "20" });
                    objStateList.Add(new SelectListItem { Text = "MANIPUR", Value = "21" });
                    objStateList.Add(new SelectListItem { Text = "MEGHALAYA", Value = "22" });
                    objStateList.Add(new SelectListItem { Text = "MIZORAM", Value = "23" });
                    objStateList.Add(new SelectListItem { Text = "NAGALAND", Value = "24" });
                    objStateList.Add(new SelectListItem { Text = "NCT OF DELHI", Value = "25" });
                    objStateList.Add(new SelectListItem { Text = "ORISSA", Value = "26" });
                    objStateList.Add(new SelectListItem { Text = "PUDUCHERRY", Value = "27" });
                    objStateList.Add(new SelectListItem { Text = "PUNJAB", Value = "28" });
                    objStateList.Add(new SelectListItem { Text = "RAJASTHAN", Value = "29" });
                    objStateList.Add(new SelectListItem { Text = "SIKKIM", Value = "30" });
                    objStateList.Add(new SelectListItem { Text = "TAMIL NADU", Value = "31" });
                    objStateList.Add(new SelectListItem { Text = "TRIPURA", Value = "32" });
                    objStateList.Add(new SelectListItem { Text = "UTTAR PRADESH", Value = "33" });
                    objStateList.Add(new SelectListItem { Text = "UTTARAKHAND", Value = "34" });
                    objStateList.Add(new SelectListItem { Text = "WEST BENGAL", Value = "35" });

                    break;
                case "2":

                    break;
                case "3":

                    break;
                default:
                    objStateList.Add(new SelectListItem { Text = "---Select---", Value = "0" });
                    break;
            }
            return Json(new SelectList(objStateList, "Value", "Text"));
        }

        public JsonResult GetCity(string id)
        {
            List<SelectListItem> objCityList = new List<SelectListItem>();
            switch (id)
            {
                case "20":
                    objCityList.Add(new SelectListItem { Text = "Select", Value = "0" });
                    objCityList.Add(new SelectListItem { Text = "MUMBAI", Value = "1" });
                    objCityList.Add(new SelectListItem { Text = "PUNE", Value = "2" });
                    objCityList.Add(new SelectListItem { Text = "KOLHAPUR", Value = "3" });
                    objCityList.Add(new SelectListItem { Text = "RATNAGIRI", Value = "4" });
                    objCityList.Add(new SelectListItem { Text = "NAGPUR", Value = "5" });
                    objCityList.Add(new SelectListItem { Text = "JALGAON", Value = "6" });
                    break;
                default:
                    objCityList.Add(new SelectListItem { Text = "---Select---", Value = "0" });
                    break;

            }

            return Json(new SelectList(objCityList, "Value", "Text"));
        }

        [HttpPost]
        public ActionResult Create(Student9ViewModel objEntity)
        {

            if (ModelState.IsValid)
            {
                
            }

            #region Rebinding after posting

            List<SelectListItem> objCountryList = new List<SelectListItem>();
            objCountryList.Add(new SelectListItem { Text = "Select", Value = "0" });
            objCountryList.Add(new SelectListItem { Text = "India", Value = "1" });
            objCountryList.Add(new SelectListItem { Text = "Srilanka", Value = "2" });
            objCountryList.Add(new SelectListItem { Text = "China", Value = "3" });
            objCountryList.Add(new SelectListItem { Text = "Austrila", Value = "4" });
            objCountryList.Add(new SelectListItem { Text = "USA", Value = "5" });
            objCountryList.Add(new SelectListItem { Text = "UK", Value = "6" });

          
            #endregion

            objEntity.CountryList = new SelectList(objCountryList,"Value", "Text");

            return View(objEntity);
        }
    }
}