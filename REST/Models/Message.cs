namespace REST
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int R_No { get; set; }

        [Column("Message", TypeName = "text")]
        public string Message1 { get; set; }

        public DateTime? Date_Time { get; set; }

        public int Sent_To { get; set; }

        public byte[] Uploaded_File { get; set; }

        [StringLength(50)]
        public string Uploaded_File_Name { get; set; }

        public virtual Resident Resident { get; set; }

        public virtual Resident Resident1 { get; set; }
    }
}
