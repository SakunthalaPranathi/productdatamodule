using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace productdatamodule.Models
{
    public class food
    {
        public int id { get; set; }
        [ForeignKey("category")]

        public int categoryid { get; set; }
        public category category { get; set; }
        public string foodname { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
}
