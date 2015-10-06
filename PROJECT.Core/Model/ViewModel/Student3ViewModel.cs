using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PROJECT.Core.Model.ViewModel
{
   public  class Student3ViewModel
    {

       [Remote("CheckUserEmail", "Student6", ErrorMessage = "{0} already exists!")]
      
        public string UserEmail { get; set; }

    
       [Required]
       public string UserName { get; set; }

    }
}
