using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace productdatamodule.Models
{
    public class cart
    {
        public int id { get; set; }


        public string customerid { get; set; }

        [ForeignKey("food")]
        public int foodid { get; set; }
        public food food { get; set; }
        [ForeignKey("category")]
        public int categoryid { get; set; }
        public category category { get; set; }
        public double quantity { get; set; }
        public double price { get; set; }
    }
}