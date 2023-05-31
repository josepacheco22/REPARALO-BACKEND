using Data.REPARALO.LIstBox;
using Data.REPARALO.ListStore.Replacement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPARALO.ListStore
{
    public interface IListStoreRepository
    {
        Task<MACCESSORY> POSTACCESSORY(MACCESSORY ACCESSORY);
        Task<IEnumerable<MACCESSORY>> GETACCESSORY(string? ACCESSORY);
        Task<MREPLACEMENT> POSTREPLACEMENT(MREPLACEMENT REPLACEMENT);
        Task<IEnumerable<MREPLACEMENT>> GETREPLACEMENT(string? REPLACEMENT);
    }
}
