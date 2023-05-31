using Data.REPARALO.ConnectDB;
using Data.REPARALO.LIstBox;
using Google.Protobuf.WellKnownTypes;
using SelectPdf;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.REPARALO.OrdenReparacion
{
    public class ListBoxRepository : IListBoxRepository
    {
        private readonly DBReparalo _dbReparalo;
        public ListBoxRepository(DBReparalo connectionstring)
        {
            _dbReparalo = connectionstring;
        }
        public async Task<MCITY> POSTCITY(MCITY CITY)
        {
            try
            {
                _dbReparalo.MCITY.Add(CITY);
                _dbReparalo.SaveChangesAsync();
                if (CITY.Id < 1)
                    return null;
                return CITY;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<IEnumerable<MCITY>> GETCITY(string? CITY)
        {
            try
            {
                if (CITY == null)
                {
                    var list = _dbReparalo.MCITY.Select(u => new MCITY { Id = u.Id, Name = u.Name });
                    _dbReparalo.SaveChangesAsync();
                    return list;
                }
                var list2 = _dbReparalo.MCITY.Where(u => u.Name.Contains(CITY)).Select(u => new MCITY { Id = u.Id, Name = u.Name });
                _dbReparalo.SaveChangesAsync();
                return list2;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<MCOUNTRY> POSTCOUNTRY(MCOUNTRY COUNTRY)
        {
            try
            {
                _dbReparalo.MCOUNTRY.Add(COUNTRY);
                _dbReparalo.SaveChangesAsync();
                if (COUNTRY.Id < 1)
                    return null;
                return COUNTRY;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<IEnumerable<MCOUNTRY>> GETCOUNTRY(string? COUNTRY)
        {   
            try
            {
                if (COUNTRY == null)
                {
                    var list = _dbReparalo.MCOUNTRY.Select(u => new MCOUNTRY
                    {
                        Id = u.Id,
                        Name = u.Name,
                        MSTATE = u.MSTATE.Select(u => new MSTATE
                        {
                            Id = u.Id,
                            Name = u.Name,
                            MCITY = u.MCITY.Select(u => new MCITY { Id = u.Id, Name = u.Name })
                        })
                    });
                    _dbReparalo.SaveChangesAsync();
                    return list;
                }
                var list2 = _dbReparalo.MCOUNTRY.Where(u => u.Name.Contains(COUNTRY)).Select(u => new MCOUNTRY
                {
                    Id = u.Id,
                    Name = u.Name,
                    MSTATE = u.MSTATE.Select(u => new MSTATE
                    {
                        Id = u.Id,
                        Name = u.Name,
                        MCITY = u.MCITY.Select(u => new MCITY { Id = u.Id, Name = u.Name })
                    })
                });
                _dbReparalo.SaveChangesAsync();
                return list2;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<MDOCUMENTTYPE> POSTDOCUMENTTYPE(MDOCUMENTTYPE DOCUMENTTYPE)
        {
            try
            {
                _dbReparalo.MDOCUMENTTYPE.Add(DOCUMENTTYPE);
                _dbReparalo.SaveChangesAsync();
                if (DOCUMENTTYPE.Id < 1)
                    return null;
                return DOCUMENTTYPE;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<IEnumerable<MDOCUMENTTYPE>> GETDOCUMENTTYPE(string? DOCUMENTTYPE)
        {
            try
            {
                if (DOCUMENTTYPE == null)
                {
                    var list = _dbReparalo.MDOCUMENTTYPE.Select(u => u);
                    _dbReparalo.SaveChangesAsync();
                    return list;
                }
                var list2 = _dbReparalo.MDOCUMENTTYPE.Select(u => u).Where(u => u.Name.Contains(DOCUMENTTYPE));
                _dbReparalo.SaveChangesAsync();
                return list2;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<MEQUIPMENTTYPE> POSTEQUIPMENTTYPE(MEQUIPMENTTYPE EQUIPMENTTYPE)
        {
            try
            {
                _dbReparalo.MEQUIPMENTTYPE.Add(EQUIPMENTTYPE);
                _dbReparalo.SaveChangesAsync();
                if (EQUIPMENTTYPE.Id < 1)
                    return null;
                return EQUIPMENTTYPE;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<IEnumerable<MEQUIPMENTTYPE>> GETEQUIPMENTTYPE(string? EQUIPMENTTYPE)
        {
            try
            {
                if (EQUIPMENTTYPE == null)
                {
                    var list = _dbReparalo.MEQUIPMENTTYPE.Select(u => u);
                    _dbReparalo.SaveChangesAsync();
                    return list;
                }
                var list2 = _dbReparalo.MEQUIPMENTTYPE.Select(u => u).Where(u => u.Name.Contains(EQUIPMENTTYPE));
                _dbReparalo.SaveChangesAsync();
                return list2;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<MORDENTYPE> POSTORDENTYPE(MORDENTYPE ORDENTYPE)
        {
            try
            {
                _dbReparalo.MORDENTYPE.Add(ORDENTYPE);
                _dbReparalo.SaveChangesAsync();
                if (ORDENTYPE.Id < 1)
                    return null;
                return ORDENTYPE;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<IEnumerable<MORDENTYPE>> GETORDENTYPE(string? ORDENTYPE)
        {
            try
            {
                if (ORDENTYPE == null)
                {
                    var list = _dbReparalo.MORDENTYPE.Select(u => u);
                    _dbReparalo.SaveChangesAsync();
                    return list;
                }
                var list2 = _dbReparalo.MORDENTYPE.Select(u => u).Where(u => u.Name.Contains(ORDENTYPE));
                _dbReparalo.SaveChangesAsync();
                return list2;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<MSTATE> POSTSTATE(MSTATE STATE)
        {
            try
            {
                _dbReparalo.MSTATE.Add(STATE);
                _dbReparalo.SaveChangesAsync();
                if (STATE.Id < 1)
                    return null;
                return STATE;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<IEnumerable<MSTATE>> GETSTATE(string? STATE)
        {
            try
            {
                if (STATE == null)
                {
                    var list = _dbReparalo.MSTATE.Select(u => new MSTATE
                        {
                            Id = u.Id,
                            Name = u.Name,
                            MCITY = u.MCITY.Select(u => new MCITY { Id = u.Id, Name = u.Name })
                        });
                    _dbReparalo.SaveChangesAsync();
                    return list;
                }
                var list2 = _dbReparalo.MSTATE.Where(u => u.Name.Contains(STATE)).Select(u => new MSTATE
                {
                    Id = u.Id,
                    Name = u.Name,
                    MCITY = u.MCITY.Select(u => new MCITY { Id = u.Id, Name = u.Name })
                });
                _dbReparalo.SaveChangesAsync();
                return list2;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<MSTATE> GETSTATEId(int? STATE)
        {
            try
            {
                if (STATE == null)
                    return null;
                if (STATE < 1)
                    return null;
                var list2 = _dbReparalo.MSTATE.Where(u => u.Id == STATE).FirstOrDefault();
                _dbReparalo.SaveChangesAsync();
                return list2;

            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<MTRADEMARK> POSTTRADEMARK(MTRADEMARK TRADEMARK)
        {
            try
            {
                _dbReparalo.MTRADEMARK.Add(TRADEMARK);
                _dbReparalo.SaveChangesAsync();
                if (TRADEMARK.Id < 1)
                    return null;
                return TRADEMARK;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<IEnumerable<MTRADEMARK>> GETTRADEMARK(string? TRADEMARK)
        {
            try
            {
                if (TRADEMARK == null)
                {
                    var list = _dbReparalo.MTRADEMARK.Select(u => u);
                    _dbReparalo.SaveChangesAsync();
                    return list;
                }
                var list2 = _dbReparalo.MTRADEMARK.Select(u => u).Where(u => u.Name.Contains(TRADEMARK));
                _dbReparalo.SaveChangesAsync();
                return list2;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<MREPLACEMENTTYPE> POSTREPLACEMENTTYPE(MREPLACEMENTTYPE REPLACEMENTTYPE)
        {
            try
            {
                _dbReparalo.MREPLACEMENTTYPE.Add(REPLACEMENTTYPE);
                _dbReparalo.SaveChangesAsync();
                if (REPLACEMENTTYPE.Id < 1)
                    return null;
                return REPLACEMENTTYPE;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<MREPLACEMENTTYPE>> GETREPLACEMENTTYPE(string? REPLACEMENTTYPE)
        {
            try
            {
                if (REPLACEMENTTYPE == null)
                {
                    var list = _dbReparalo.MREPLACEMENTTYPE.Select(u => u);
                    _dbReparalo.SaveChangesAsync();
                    return list;
                }
                var list2 = _dbReparalo.MREPLACEMENTTYPE.Select(u => u).Where(u => u.Name.Contains(REPLACEMENTTYPE));
                _dbReparalo.SaveChangesAsync();
                return list2;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<MACCESSORYTYPE> POSTACCESSORYTYPE(MACCESSORYTYPE ACCESSORYTYPE)
        {
            try
            {
                _dbReparalo.MACCESSORYTYPE.Add(ACCESSORYTYPE);
                _dbReparalo.SaveChangesAsync();
                if (ACCESSORYTYPE.Id < 1)
                    return null;
                return ACCESSORYTYPE;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<IEnumerable<MACCESSORYTYPE>> GETACCESSORYTYPE(string? ACCESSORYTYPE)
        {
            try
            {
                if (ACCESSORYTYPE == null)
                {
                    var list = _dbReparalo.MACCESSORYTYPE.Select(u => u);
                    _dbReparalo.SaveChangesAsync();
                    return list;
                }
                var list2 = _dbReparalo.MACCESSORYTYPE.Select(u => u).Where(u => u.Name.Contains(ACCESSORYTYPE));
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
