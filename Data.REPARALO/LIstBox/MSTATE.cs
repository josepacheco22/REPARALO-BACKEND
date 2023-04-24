using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPARALO.LIstBox
{
    [Table("STATE")]
    public class MSTATE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int MCOUNTRYId { get; set; }
        public IEnumerable<MCITY>? MCITY { get; set; }
    }
}