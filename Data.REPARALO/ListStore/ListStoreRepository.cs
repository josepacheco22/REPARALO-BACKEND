using Data.REPARALO.ConnectDB;
using Data.REPARALO.LIstBox;
using Data.REPARALO.ListStore.Replacement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPARALO.ListStore
{
    public class ListStoreRepository : IListStoreRepository
    {
        private readonly DBReparalo _dbReparalo;
        public ListStoreRepository(DBReparalo connectionstring)
        {
            _dbReparalo = connectionstring;
        }
        public async Task<IEnumerable<MACCESSORY>> GETACCESSORY(string? ACCESSORY)
        {
            try
            {
                if (ACCESSORY == null)
                {
                    var list = _dbReparalo.MACCESSORY.Select(u => u);
                    _dbReparalo.SaveChangesAsync();
                    return list;
                }
                var list2 = _dbReparalo.MACCESSORY.Where(u => u.Code.Contains(ACCESSORY)).Select(u => u);
                _dbReparalo.SaveChangesAsync();
                return list2;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<MACCESSORY> POSTACCESSORY(MACCESSORY ACCESSORY)
        {
            try
            {
                _dbReparalo.MACCESSORY.Add(ACCESSORY);
                _dbReparalo.SaveChangesAsync();
                if (ACCESSORY.Id < 1)
                    return null;
                return ACCESSORY;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<IEnumerable<MREPLACEMENT>> GETREPLACEMENT(string? REPLACEMENT)
        {
            try
            {
                if (REPLACEMENT == null)
                {
                    var list = _dbReparalo.MREPLACEMENT.Select(u => u);
                    _dbReparalo.SaveChangesAsync();
                    return list;
                }
                var list2 = _dbReparalo.MREPLACEMENT.Where(u => u.Model.Contains(REPLACEMENT)).Select(u => u);
                _dbReparalo.SaveChangesAsync();
                return list2;
            }
            catch (Exception)
            {
                return null;
            }
        }        
        public async Task<MREPLACEMENT> POSTREPLACEMENT(MREPLACEMENT REPLACEMENT)
        {
            try
            {
                _dbReparalo.MREPLACEMENT.Add(REPLACEMENT);
                _dbReparalo.SaveChangesAsync();
                if (REPLACEMENT.Id < 1)
                    return null;
                return REPLACEMENT;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
