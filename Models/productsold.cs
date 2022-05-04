using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace productdatamodule.Models
{
    public class productsold
    {
        public int id { get; set; }
        [ForeignKey("sale")]
        public int saleid { get; set; }
        public sale sale{ get; set; }
        [ForeignKey("food")]
        public int foodid { get; set; }
        public food food { get; set; }
        public double quantity { get; set; }
        public DateTime date { get; set; }
    }
}
