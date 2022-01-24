namespace FindCarrier.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("City")]
    public partial class City
    {
        public int CityID { get; set; }

        [Required]
        [StringLength(50)]
        public string CityName { get; set; }
    }
}
