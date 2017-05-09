namespace REST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Resident
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resident()
        {
            Messages = new HashSet<Message>();
            Messages1 = new HashSet<Message>();
            Users = new HashSet<User>();
        }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(15)]
        public string L_Name { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int R_No { get; set; }

        public bool IsAdmin { get; set; }

        public int Ap_No { get; set; }

        public int Phone_No { get; set; }

        [Required]
        [StringLength(25)]
        public string E_Mail { get; set; }

        [Column(TypeName = "date")]
        public DateTime M_In { get; set; }

        [Column(TypeName = "date")]
        public DateTime? M_Out { get; set; }

        public bool? IsOwner { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
