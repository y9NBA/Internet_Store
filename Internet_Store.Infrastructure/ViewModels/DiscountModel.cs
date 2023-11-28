using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DiscountModel
    {
        public long ID { get; set; }
        public string Name_Discount { get; set; }
        public int Size { get; set; }
        public List<Person> Person { get; set; }
    }
}
