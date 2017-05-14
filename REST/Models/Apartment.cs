namespace REST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Apartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Apartment()
        {
            Facilities = new HashSet<Facility>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ap_No { get; set; }

        public int? IsFree { get; set; }

        public int? Floor { get; set; }

        [StringLength(4)]
        public string Number { get; set; }

        public int? B_No { get; set; }

        public int? Size { get; set; }

        public int? No_Rooms { get; set; }

        public int? BBR { get; set; }

        public int? Fordelingstal { get; set; }

        [Column(TypeName = "image")]
        public byte[] Ap_Drawing { get; set; }

        [Column(TypeName = "money")]
        public decimal? Rent { get; set; }

        public byte[] Uploaded_Doc { get; set; }

        [StringLength(50)]
        public string Uploaded_Doc_Name { get; set; }

        public DateTime? Uploaded_Doc_Date { get; set; }

        [StringLength(50)]
        public string Ap_Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facility> Facilities { get; set; }
    }
}
