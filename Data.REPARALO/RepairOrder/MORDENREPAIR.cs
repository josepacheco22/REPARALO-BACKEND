using Data.REPARALO.Clients;
using Data.REPARALO.LIstBox;
using Data.REPARALO.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data.REPARALO.RepairOrder
{
    [Table("REPAIRORDER")]
    public class MREPAIRORDER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? MORDENTYPEId { get; set; }
        public MORDENTYPE? MORDENTYPE { get; set; }
        public int? MUSERAssignedId { get; set; }
        public MUSER? MUSERAssigned { get; set; }
        public int? MUSERCreatedId { get; set; }
        public MUSER? MUSERCreated { get; set; }
        public DateTime? DeadLine { get; set; }
        public int? MCLIENTId { get; set; }
        public MCLIENT? MCLIENT { get; set; }
        public int? MTRADEMARKId { get; set; }
        public MTRADEMARK? MTRADEMARK { get; set; }
        public string? Model { get; set; }
        public int? MEQUIPMENTTYPEId { get; set; }
        public MEQUIPMENTTYPE? MEQUIPMENTTYPE { get; set; }
        //public int? MCOLOURId { get; set; }
        //public MCOLOUR? MCOLOUR { get; set; }
        public string? CODE { get; set; }
        public string? IMEI1 { get; set; }
        public string? IMEI2 { get; set; }
        public string? Accessories { get; set; }
        public string? Symptoms { get; set; }
        public string? State { get; set; }
        public bool? Active { get; set; }
    }
}
