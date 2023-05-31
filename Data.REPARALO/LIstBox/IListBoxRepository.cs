using Data.REPARALO.LIstBox;
using Data.REPARALO.OrdenReparacion;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPARALO.LIstBox
{
    public interface IListBoxRepository
    {
        Task<MCITY> POSTCITY(MCITY CITY); 
        Task<IEnumerable<MCITY>> GETCITY(string? CITY);
        Task<MCOUNTRY> POSTCOUNTRY(MCOUNTRY COUNTRY);
        Task<IEnumerable<MCOUNTRY>> GETCOUNTRY(string? COUNTRY);
        Task<MDOCUMENTTYPE> POSTDOCUMENTTYPE(MDOCUMENTTYPE DOCUMENTTYPE);
        Task<IEnumerable<MDOCUMENTTYPE>> GETDOCUMENTTYPE(string? DOCUMENTTYPE);
        Task<MEQUIPMENTTYPE> POSTEQUIPMENTTYPE(MEQUIPMENTTYPE EQUIPMENTTYPE);
        Task<IEnumerable<MEQUIPMENTTYPE>> GETEQUIPMENTTYPE(string? EQUIPMENTTYPE);
        Task<MORDENTYPE> POSTORDENTYPE(MORDENTYPE ORDENTYPE);
        Task<IEnumerable<MORDENTYPE>> GETORDENTYPE(string? ORDENTYPE);
        Task<MSTATE> POSTSTATE(MSTATE STATE);
        Task<IEnumerable<MSTATE>> GETSTATE(string? STATE);
        Task<MSTATE> GETSTATEId(int? STATE);
        Task<MTRADEMARK> POSTTRADEMARK(MTRADEMARK TRADEMARK);
        Task<IEnumerable<MTRADEMARK>> GETTRADEMARK(string? TRADEMARK);


        Task<MREPLACEMENTTYPE> POSTREPLACEMENTTYPE(MREPLACEMENTTYPE REPLACEMENTTYPE);
        Task<IEnumerable<MREPLACEMENTTYPE>> GETREPLACEMENTTYPE(string? REPLACEMENTTYPE);
        Task<MACCESSORYTYPE> POSTACCESSORYTYPE(MACCESSORYTYPE ACCESSORYTYPE);
        Task<IEnumerable<MACCESSORYTYPE>> GETACCESSORYTYPE(string? ACCESSORYTYPE);
    }   
}
