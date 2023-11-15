namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Goods
    {
        public long id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }
    }
}
