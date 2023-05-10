using Data.REPARALO.LIstBox;
using Data.REPARALO.RepairOrder;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPARALO.RepairOrder
{
    public interface IRepairOrderRepository
    {
        Task<MREPAIRORDER> POSTREPAIRORDER(MREPAIRORDER MREPAIRORDER);
        Task<IEnumerable<MREPAIRORDER>> GETREPAIRORDER(string? ORDENTYPE);
        Task<byte[]> GETPDFREPAIRORDER(int? ORDENTYPE);
    }
}
