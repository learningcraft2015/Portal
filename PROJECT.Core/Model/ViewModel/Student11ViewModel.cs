using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Model.ViewModel
{
   public class Student11ViewModel
    {
       [Required]
        public DateTime  DOB { get; set; }
       [Required]
        public string Age { get; set; }
    }
}
