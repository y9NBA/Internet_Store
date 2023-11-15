namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            User = new HashSet<User>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Last_name { get; set; }

        [Required]
        [StringLength(50)]
        public string First_name { get; set; }

        [Required]
        [StringLength(50)]
        public string Middle_name { get; set; }

        [StringLength(50)]
        public string Number_phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }
    }
}
