namespace REST.Models_log
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Residents_log
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string L_Name { get; set; }

        public int? R_No { get; set; }

        public int? Ap_No { get; set; }

        public int? Phone_No { get; set; }

        [StringLength(50)]
        public string E_Mail { get; set; }

        [Column(TypeName = "date")]
        public DateTime? M_In { get; set; }

        [Column(TypeName = "date")]
        public DateTime? M_Out { get; set; }

        public bool? IsOwner { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        public int? Parent_Resident { get; set; }

        public bool? IsActive { get; set; }

        [Key]
        public int PKEY { get; set; }
    }
}
