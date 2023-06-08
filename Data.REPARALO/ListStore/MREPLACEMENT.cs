using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Data.REPARALO.LIstBox;

namespace Data.REPARALO.ListStore.Replacement
{
    [Table("REPLACEMENT")]
    public class MREPLACEMENT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? IdInvoice { get; set; }
        public int? MEQUIPMENTTYPEId { get; set; }
        public MEQUIPMENTTYPE? MEQUIPMENTTYPE { get; set; }
        public int? MTRADEMARKId { get; set; }
        public MTRADEMARK? MTRADEMARK { get; set; }
        public int? MREPLACEMENTTYPEId { get; set; }
        public MREPLACEMENTTYPE? MREPLACEMENTTYPE { get; set; }
        public string? Model { get; set; }
        public string? Note { get; set; }
        public int? Quantity { get; set; }
        public int? QuantityAvailable { get; set; }
        public int? AmountUsed { get; set; }
        public float? Cost { get; set; }
        public float? Labour { get; set; }
        public bool? Active { get; set; }
    }
}
