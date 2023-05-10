using Data.REPARALO.Clients;
using Data.REPARALO.ConnectDB;
using Data.REPARALO.LIstBox;
using Data.REPARALO.RepairOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPARALO.Client
{
    public class ClientRepository : IClientRepository
    {
        private readonly DBReparalo _dbReparalo;
        public ClientRepository(DBReparalo connectionstring)
        {
            _dbReparalo = connectionstring;
        }


        public async Task<MCLIENT> POSTCLIENT(MCLIENT CLIENT)
        {
            try
            {
                _dbReparalo.MCLIENT.Add(CLIENT);
                _dbReparalo.SaveChangesAsync();
                if (CLIENT.Id < 1)
                    return null;
                return CLIENT;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<IEnumerable<MCLIENT>> GETCLIENT(string? CLIENT)
        {
            try
            {

                if (CLIENT == null)
                {
                    var Listnull = _dbReparalo.MCLIENT.Select(u => u );
                    _dbReparalo.SaveChangesAsync();
                    return Listnull;
                }
                var List = _dbReparalo.MCLIENT.Where(u =>  u.FirstName.Contains(CLIENT) || u.SecondName.Contains(CLIENT) || u.FirstLastName.Contains(CLIENT) || u.SecondLastName.Contains(CLIENT) || u.DocumentNumber.Contains(CLIENT) ).Select(u => u);
                _dbReparalo.SaveChangesAsync();
                return List;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
