using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Model.ViewModel
{
    public class CountryStateViewModel
    {
        [ScaffoldColumn(false)]
        public int CountryId { get; set; }

        [Required]
        [DisplayName("Country Name")]
        [ScaffoldColumn(false)]
        public string CountryName { get; set; }

        [ScaffoldColumn(false)]
        public int StateId { get; set; }

        [Required]
        [DisplayName("State Name")]
        [ScaffoldColumn(false)]

        public string StateName { get; set; }
    }
}
