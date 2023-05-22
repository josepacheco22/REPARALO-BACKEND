using Data.REPARALO.Clients;
using Data.REPARALO.LIstBox;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPARALO.Client
{
    public interface IClientRepository
    {
        Task<MCLIENT> POSTCLIENT(MCLIENT CLIENT);
        Task<IEnumerable<MCLIENT>> GETCLIENT(string? CLIENT);
        Task<MCLIENT> PUTCLIENT(MCLIENT CLIENT);
    }
}
