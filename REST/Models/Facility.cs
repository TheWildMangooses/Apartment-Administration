namespace REST
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Facility
    {
        public int Ap_No { get; set; }

        [Required]
        [StringLength(25)]
        public string F_Name { get; set; }

        [StringLength(10)]
        public string F_Condition { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Last_Broken { get; set; }

        public int? Times_Broken { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public byte[] Uploaded_F { get; set; }

        [StringLength(50)]
        public string Uploaded_F_Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Updated_On { get; set; }

        public bool? Approved { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? F_Value { get; set; }

        public virtual Apartment Apartment { get; set; }
    }
}
