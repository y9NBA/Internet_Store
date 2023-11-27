using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PersonModel
    {
        public long ID { get; set; }
        public string Last_name { get; set; }
        public string First_name { get; set; }
        public string Middle_name { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Number_phone { get; set; }
        public string Email { get; set; }
        public long DiscountID { get; set; }
        public virtual User User { get; set; }
    }
}
