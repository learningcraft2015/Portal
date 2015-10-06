using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Model.ViewModel
{
   public class Student10ViewModel
    {
        public DateTime  ExpectedDate { get; set; }
        public int VendorId { get; set; }

        public int productId { get; set; }
        public List<ProductViewModel> ProductList { get; set; }
    }
}
