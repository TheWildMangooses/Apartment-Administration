namespace REST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int B_No { get; set; }

        [Required]
        [MaxLength(50)]
        public byte[] Address { get; set; }

        public int? No_Ap { get; set; }

        [StringLength(10)]
        public string D_Pipe_C { get; set; }
    }
}
