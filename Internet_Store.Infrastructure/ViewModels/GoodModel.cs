using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GoodModel
    {
        public long ID { get; set; }
        
        public string Name { get; set; }        
        
        public string Description { get; set; }
        
        public int Amount { get; set; }
        
        public decimal Price { get; set; }
        
        public long TypeID { get; set; }

        public virtual List<Custom> Customs { get; set; }

        public virtual Type Type { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public virtual User Seller { get; set; }
    }
}
