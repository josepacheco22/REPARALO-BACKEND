using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.REPARALO.LIstBox;

namespace Data.REPARALO.Clients
{
    [Table("CLIENT")]
    public class MCLIENT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? MDOCUMENTTYPEId { get; set; }
        public MDOCUMENTTYPE? MDOCUMENTTYPE { get; set; }
        public string? DocumentNumber { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? FirstLastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        public int? MCOUNTRYId { get; set; }
        public MCOUNTRY? MCOUNTRY { get; set; }
        public int? MSTATEId { get; set; }
        public MSTATE? MSTATE { get; set; }
        public int? MCITYId { get; set; }
        public MCITY? MCITY { get; set; }
        public string? Address { get; set; }
        public bool? Active { get; set; }
    }
}
