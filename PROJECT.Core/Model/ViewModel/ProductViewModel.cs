using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Model.ViewModel
{
  public  class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Decimal Quantity { get; set; }
        public bool IsSelected { get; set; }

    }
}
