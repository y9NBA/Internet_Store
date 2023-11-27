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
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Last_name { get; set; }

        [Required]
        [StringLength(50)]
        public string First_name { get; set; }

        [Required]
        [StringLength(50)]
        public string Middle_name { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(12)]
        public string Number_phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public long DiscountID { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual User User { get; set; }
    }
}
