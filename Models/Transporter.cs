namespace FindCarrier.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transporter")]
    public partial class Transporter
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Transporter()
        //{
        //    Vehicles = new HashSet<Vehicle>();
        //}

        public int TransporterID { get; set; }

        [Required]
        [StringLength(50)]
        public string TransportName { get; set; }

        [Required]
        [StringLength(50)]
        public string OwnerName { get; set; }

        [Required]
        [StringLength(10)]
        public string ContactNo { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        public string UserId { get; set; }

        [NotMapped]
        public List<City> cities { get; set; }
        [NotMapped]
        public List<State> states { get; set; }

        
    }
}
