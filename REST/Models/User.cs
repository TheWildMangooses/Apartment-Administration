namespace REST
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(15)]
        public string Username { get; set; }

        [MaxLength(50)]
        public byte[] Password { get; set; }

        public bool? IsAdmin { get; set; }

        public int? Admin_Level { get; set; }

        public int? R_No { get; set; }

        public virtual Resident Resident { get; set; }
    }
}
