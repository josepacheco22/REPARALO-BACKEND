using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Data.REPARALO.LIstBox;

namespace Data.REPARALO.ListStore
{
    [Table("ACCESSORY")]
    public class MACCESSORY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Code { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }
        public string? IdInvoice { get; set; }
        public int? MTRADEMARKId { get; set; }
        public MTRADEMARK? MTRADEMARK { get; set; }
        public int? MACCESSORYTYPEId { get; set; }
        public MACCESSORYTYPE? MACCESSORYTYPE { get; set; }
        public int? Type { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public int? Quantity { get; set; }
        public int? Cost { get; set; }
        public bool? Active { get; set; }

    }
}
