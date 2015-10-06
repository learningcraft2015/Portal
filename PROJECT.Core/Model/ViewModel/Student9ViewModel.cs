using PROJECT.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PROJECT.Core.Model.ViewModel
{
    public class Student9ViewModel
    {
        [Range(1, Int32.MaxValue, ErrorMessage = "Select Country")]
        public int CountryId { get; set; }
            [Range(1, Int32.MaxValue, ErrorMessage = "Select State")]
        public int StateId { get; set; }
            [Range(1, Int32.MaxValue, ErrorMessage = "Select City")]
        public int CityId { get; set; }
        public SelectList CountryList { get; set; }
        public SelectList StateList { get; set; }
        public SelectList CityList { get; set; }
        public Student9ViewModel()
        {
            CountryList = new SelectList(
    new List<SelectListItem>
    {
        new SelectListItem { Selected = true, Text ="---Select---", Value = "0"}     
    }, "Value", "Text", 0);
            StateList = new SelectList(
   new List<SelectListItem>
    {
        new SelectListItem { Selected = true, Text ="---Select---", Value = "0"}     
    }, "Value", "Text", 0);
            CityList = new SelectList(
   new List<SelectListItem>
    {
        new SelectListItem { Selected = true, Text ="---Select---", Value = "0"}     
    }, "Value", "Text", 0);


        }
    }
}
