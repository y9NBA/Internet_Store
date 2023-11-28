using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ReviewModel
    {
        public long ID { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public string Description { get; set; }

        public long CustomerID { get; set; }

        public User User { get; set; }

        public List<Good> Good { get; set; }
    }
}
