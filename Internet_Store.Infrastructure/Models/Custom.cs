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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Custom()
        {
            User = new HashSet<User>();
        }

        public long ID { get; set; }

        public DateTime Date_Order { get; set; }

        public long StatusID { get; set; }

        public long GoodID { get; set; }

        public int Total_Amount { get; set; }

        public decimal Total_Price { get; set; }

        public virtual Status Status { get; set; }

        public virtual Good Good { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }
    }
}
