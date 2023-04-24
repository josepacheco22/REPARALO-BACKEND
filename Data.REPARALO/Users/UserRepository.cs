using Data.REPARALO.ConnectDB;
using Data.REPARALO.LIstBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPARALO.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DBReparalo _dbReparalo;
        public UserRepository(DBReparalo connectionstring)
        {
            _dbReparalo = connectionstring;
        }
        public async Task<MUSER> POSTUSER(MUSER USER)
        {
            try
            {
                _dbReparalo.MUSER.Add(USER);
                _dbReparalo.SaveChangesAsync();
                if (USER.Id < 1)
                    return null;
                return USER;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<IEnumerable<MUSER>> GETUSER(string? USER)
        {
            try
            {
                if (USER == null)
                {
                    var list = _dbReparalo.MUSER.Select(u => new MUSER
                    {
                        Id = u.Id,
                        Name = u.Name
                    });
                    _dbReparalo.SaveChangesAsync();
                    return list;
                }
                var list2 = _dbReparalo.MUSER.Where(u => u.Name.Contains(USER)).Select(u => new MUSER
                {
                    Id = u.Id,
                    Name = u.Name
                });
                _dbReparalo.SaveChangesAsync();
                return list2;
            }
            catch (Exception)
            {
                return null;
            }
        }        
    }
}
