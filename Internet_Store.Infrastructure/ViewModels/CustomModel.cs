using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CustomModel
    {
        public long ID { get; set; }

        public DateTime Date_Order { get; set; }

        public Status Status { get; set; }
        public Good Good { get; set; }

        public int Total_Amount { get; set; }

        public decimal Total_Price { get; set; }

        public virtual List<User> User { get; set; }  
    }
}
