using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPARALO.Users
{
    public interface IUserRepository
    {
        Task<MUSER> POSTUSER(MUSER USER);
        Task<IEnumerable<MUSER>> GETUSER(string? USER);
    }
}
