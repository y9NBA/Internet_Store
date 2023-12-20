namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Custom")]
    public partial class Custom
    {
        public long ID { get; set; }

        public DateTime Date_Order { get; set; }

        public int Total_Amount { get; set; }

        public decimal Total_Price { get; set; }

        public long StatusID { get; set; }

        public long GoodID { get; set; }

        public long CustomerID { get; set; }

        public virtual Status Status { get; set; }

        public virtual Good Good { get; set; }

        public virtual User User { get; set; }
    }
}
