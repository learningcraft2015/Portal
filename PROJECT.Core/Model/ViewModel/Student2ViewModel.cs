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
    //Install-Package Microsoft.AspNet.Mvc -Version 5.2.3
    public class Student2ViewModel
    {
        #region Search
        public string Keyword { get; set; }


        public List<Student2ViewModel> Student2SearchList { get; set; }
        #endregion

        #region Report
        [DisplayName("To")]
        public string strToDate { get; set; }
        [DisplayName("From")]


        public string strFromDate { get; set; }

        [DisplayName("Course")]
        public Int32? filterId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public List<Student2ViewModel> Student2ReportList { get; set; }
        #endregion

        public Int32 StudentId { get; set; }

        #region StringValidation

        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "Enter Name")]
        [DisplayName("Student Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public StatusEnum Status { get; set; }

        #endregion

        #region EnumerationDropdown
        [Required(ErrorMessage = "Select Gender")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Select a valid Gender")]
        public GenderEnum Gender { get; set; }

        #endregion

        #region DatabaseDropdown

        [DisplayName("Course")]
        [Required(ErrorMessage = "Select a Course")]

        public Int32 CourseId { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Course Title")]
        public String CourseTitle { get; set; }

        [ScaffoldColumn(false)]
        public SelectList CourseList { get; set; }

        #endregion

        #region OptionGroupDatabaseDropdown

        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "Select Country & State")]
        [DisplayName("Country & State")]
        public Int32 StateId { get; set; }
        [ScaffoldColumn(false)]
        public Int32 CountryId { get; set; }

        [ScaffoldColumn(false)]
        public string StateName { get; set; }
        [ScaffoldColumn(false)]
        public string CountryName { get; set; }

        [ScaffoldColumn(false)]
        public SelectList SelectCountryList { get; set; }

        #endregion


        #region DatePicker
        //Install-Package WebGrease


        //Install-Package Bootstrap.v3.Datetimepicker.CSS
        [Required(ErrorMessage = "Select Current Date")]
        [DisplayName("Current Date")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CurrentDate { get; set; }

        #endregion

        #region TimePicker


        [DisplayName("Current Time")]
        public DateTime? CurrentTime { get; set; }

        [Required(ErrorMessage = "Enter Time")]
        [DisplayName("Current Time")]
        [RegularExpression(@"^(0?[1-9]|1[0-2]):[0-5][0-9] [aApP][mM]$", ErrorMessage = "Invalid Time.")]
        public string CurrentTimeValue
        {
            get
            {
                return CurrentTime.HasValue ? CurrentTime.Value.ToString("hh:mm tt") : string.Empty;
            }

            set
            {
                CurrentTime = DateTime.Parse(value);
            }
        }

        #endregion

        #region DateTimePicker


        [Required(ErrorMessage = "Select Current DateTime")]
        [DisplayName("Current DateTime")]
        //  [DisplayFormat(DataFormatString = "{0:MMM-dd-yyyy,hh:mm tt}", ApplyFormatInEditMode = true)]

        [DisplayFormat(DataFormatString = "{0:MMM-dd-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime CurrentDateTime { get; set; }

        #endregion

        #region Checkbox
        [Required]
        [DisplayName("Checkbox")]
        public bool Checkbox { get; set; }

        #endregion

        #region RadioButton
        [Required(ErrorMessage = "Select a option")]
        [DisplayName("Radio Button")]
        public int RadioButton { get; set; }

        #endregion

        #region FileUpload

        //Install-Package DataAnnotationsExtensions.MVC3
        //[Required(ErrorMessage = "Please Upload File")]
        [DataAnnotationsExtensions.FileExtensions("png|jpg|jpeg|gif")] //"png|jpg|jpeg|gif|doc|docx|txt|rtf|pdf"
        [Display(Name = "Upload a file")]
        [ScaffoldColumn(false)]
        public HttpPostedFileBase UploadFile { get; set; }

        [ScaffoldColumn(false)]
        public string FileName { get; set; }// file upload

        #endregion



        #region Dashboard
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }

        #endregion


        [ScaffoldColumn(false)]
        public int Result { get; set; }


    }

}
