namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Review()
        {
            Good = new HashSet<Good>();
        }

        public long ID { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Description { get; set; }

        public long CustomerID { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Good> Good { get; set; }
    }
}
