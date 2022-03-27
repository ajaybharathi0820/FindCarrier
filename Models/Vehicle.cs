namespace FindCarrier.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class Vehicle
    {
        public int VehicleID { get; set; }

        [Required]
        [StringLength(50)]
        public string VehicleName { get; set; }

        [Required]
        [StringLength(10)]
        public string VehicleNo { get; set; }

        [Required]
        public string BodyType { get; set; }

        [Required]
        public int LoadCapacity { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        
        public string UserId { get; set; }

        [NotMapped]
        public List<BodyType> bodyTypes { get; set; }

        
    }
}
