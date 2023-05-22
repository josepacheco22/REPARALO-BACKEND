using Data.REPARALO.ConnectDB;
using Data.REPARALO.JSON;
using Data.REPARALO.LIstBox;
using Data.REPARALO.OrdenReparacion;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace ApiRestREPARALO.Controllers.ListBox
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListBox : ControllerBase
    {
        public DEFAULT VDEFAULT = new DEFAULT();
        public IConfiguration _configuration;
        private readonly IListBoxRepository _IListBoxRepository;
        public ListBox(DBReparalo dbreparalo, IConfiguration configuration)
        {
            _IListBoxRepository = new ListBoxRepository(dbreparalo);
            _configuration = configuration;
        }
        [HttpPost]
        [Route("CITY")]
        public async Task<IActionResult> POSTCITY([FromBody] MCITY CITY)
        {
            try
            {
                if (CITY == null)
                    return Ok(new { state = 400, Message = "Objeto nulo o vacio", result = new { } });
                if (!ModelState.IsValid)
                    return Ok(new { state = 410, Message = "Objeto invalido", result = new { } });
                var created = await _IListBoxRepository.POSTCITY(CITY);
                if (created == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var objet = VDEFAULT.Read();
                var Country = await _IListBoxRepository.GETSTATEId(created.MSTATEId);
                objet.COUNTRY = Country.MCOUNTRYId;
                objet.STATE = created.MSTATEId;
                objet.CITY = created.Id;
                VDEFAULT.Write(objet);
                return Ok(new { state = 200, Message = "Proceso completo", result = new { COUNTRY = objet.COUNTRY, STATE = objet.STATE, CITY = objet.CITY, list = created } });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpGet]
        [Route("CITY")]
        [Route("CITY={CITY}")]
        public async Task<IActionResult> GETCITY(string? CITY)
        {
            try
            {
                if (CITY == null)
                {
                    var list = await _IListBoxRepository.GETCITY(CITY);
                    if (list == null)
                        return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                    return Ok(new { state = 200, Message = "Proceso completo", result = list });
                }
                var obejt = await _IListBoxRepository.GETCITY(CITY);
                if (obejt == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                return Ok(new { state = 200, Message = "Proceso completo", result = obejt });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpPost]
        [Route("COUNTRY")]
        public async Task<IActionResult> POSTCOUNTRY([FromBody] MCOUNTRY COUNTRY)
        {
            try
            {
                if (COUNTRY == null)
                    return Ok(new { state = 400, Message = "Objeto nulo o vacio", result = new { } });
                if (!ModelState.IsValid)
                    return Ok(new { state = 410, Message = "Objeto invalido", result = new { } });
                var created = await _IListBoxRepository.POSTCOUNTRY(COUNTRY);
                if (created == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var objet = VDEFAULT.Read();
                objet.COUNTRY = COUNTRY.Id;
                objet.STATE = 0;
                objet.CITY = 0;
                VDEFAULT.Write(objet);
                return Ok(new { state = 200, Message = "Proceso completo", result = created });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpGet]
        [Route("COUNTRY")]
        [Route("COUNTRY={COUNTRY}")]
        public async Task<IActionResult> GETCOUNTRY(string? COUNTRY)
        {
            try
            {
                if (COUNTRY == null)
                {
                    var Listnull = await _IListBoxRepository.GETCOUNTRY(COUNTRY);
                    if (Listnull == null)
                        return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                    var objetnull = VDEFAULT.Read();
                    return Ok(new { state = 200, Message = "Proceso completo", result = new { COUNTRY = objetnull.COUNTRY, STATE = objetnull.STATE, CITY = objetnull.CITY, list = Listnull } });
                }
                var List = await _IListBoxRepository.GETCOUNTRY(COUNTRY);
                if (List == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var objet = VDEFAULT.Read();
                return Ok(new { state = 200, Message = "Proceso completo", result = new { COUNTRY = objet.COUNTRY, STATE=  objet.STATE, CITY = objet.CITY, list = List } });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpPost]
        [Route("DOCUMENTTYPE")]
        public async Task<IActionResult> POSTDOCUMENTTYPE([FromBody] MDOCUMENTTYPE DOCUMENTTYPE)
        {
            try
            {
                if (DOCUMENTTYPE == null)
                return Ok(new { state=400, Message="Objeto nulo o vacio", result = new { } });
            if (!ModelState.IsValid)
                return Ok(new { state = 410, Message = "Objeto invalido", result = new { } });
            var created = await _IListBoxRepository.POSTDOCUMENTTYPE(DOCUMENTTYPE);
            if (created == null)
                return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
            var objet = VDEFAULT.Read();
            objet.DOCUMENTTYPE = created.Id;
            VDEFAULT.Write(objet);
                return Ok(new { state = 200, Message = "Proceso completo", result = created });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpGet]
        [Route("DOCUMENTTYPE")]
        [Route("DOCUMENTTYPE={DOCUMENTTYPE}")]
        public async Task<IActionResult> GETDOCUMENTTYPE(string? DOCUMENTTYPE)
        {
            try
            {
                if (DOCUMENTTYPE == null)
                {
                    var ListNull = await _IListBoxRepository.GETDOCUMENTTYPE(DOCUMENTTYPE);
                    if (ListNull == null)
                        return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                    var objetNull = VDEFAULT.Read();
                    return Ok(new { state = 200, Message = "Proceso completo", result = new { DOCUMENTTYPE = objetNull.DOCUMENTTYPE, list = ListNull } });
                }
                var List = await _IListBoxRepository.GETDOCUMENTTYPE(DOCUMENTTYPE);
                if (List == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var obejt = VDEFAULT.Read();
                return Ok(new { state = 200, Message = "Proceso completo", result = new { DOCUMENTTYPE = obejt.DOCUMENTTYPE, list = List } });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpPost]
        [Route("EQUIPMENTTYPE")]
        public async Task<IActionResult> POSTEQUIPMENTTYPE([FromBody] MEQUIPMENTTYPE EQUIPMENTTYPE)
        {
            try
            {
                if (EQUIPMENTTYPE == null)
                return Ok(new { state = 400, Message = "Objeto nulo o vacio", result = new { } });
            if (!ModelState.IsValid)
                return Ok(new { state = 410, Message = "Objeto invalido", result = new { } });
            var created = await _IListBoxRepository.POSTEQUIPMENTTYPE(EQUIPMENTTYPE);
            if (created == null)
                return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var objet = VDEFAULT.Read();
                objet.EQUIPMENTTYPE = created.Id;
                VDEFAULT.Write(objet);
                return Ok(new { state = 200, Message = "Proceso completo", result = created });
        }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpGet]
        [Route("EQUIPMENTTYPE")]
        [Route("EQUIPMENTTYPE={EQUIPMENTTYPE}")]
        public async Task<IActionResult> GETEQUIPMENTTYPE(string? EQUIPMENTTYPE)
        {
            try
            {
                if (EQUIPMENTTYPE == null)
                {
                    var ListNull = await _IListBoxRepository.GETEQUIPMENTTYPE(EQUIPMENTTYPE);
                    if (ListNull == null)
                        return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                    var objetNull = VDEFAULT.Read();
                    return Ok(new { state = 200, Message = "Proceso completo", result = new { EQUIPMENTTYPE = objetNull.EQUIPMENTTYPE, list = ListNull } });
                }
                var List = await _IListBoxRepository.GETEQUIPMENTTYPE(EQUIPMENTTYPE);
                if (List == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var obejt = VDEFAULT.Read();
                return Ok(new { state = 200, Message = "Proceso completo", result = new { EQUIPMENTTYPE = obejt.EQUIPMENTTYPE, list = List } });


            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpPost]
        [Route("ORDENTYPE")]
        public async Task<IActionResult> POSTORDENTYPE([FromBody] MORDENTYPE ORDENTYPE)
        {
            try
            {
                if (ORDENTYPE == null)
                    return Ok(new { state = 400, Message = "Objeto nulo o vacio", result = new { } });
                if (!ModelState.IsValid)
                    return Ok(new { state = 410, Message = "Objeto invalido", result = new { } });
                var created = await _IListBoxRepository.POSTORDENTYPE(ORDENTYPE);
                if (created == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var objet = VDEFAULT.Read();
                objet.ORDENTYPE = created.Id;
                VDEFAULT.Write(objet);
                return Ok(new { state = 200, Message = "Proceso completo", result = created });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpGet]
        [Route("ORDENTYPE")]
        [Route("ORDENTYPE={ORDENTYPE}")]
        public async Task<IActionResult> GETORDENTYPE(string? ORDENTYPE)
        {
            try
            {
                if (ORDENTYPE == null)
                {
                    var ListNull = await _IListBoxRepository.GETORDENTYPE(ORDENTYPE);
                    if (ListNull == null)
                        return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                    var objetNull = VDEFAULT.Read();
                    return Ok(new { state = 200, Message = "Proceso completo", result = new { ORDENTYPE = objetNull.ORDENTYPE, list = ListNull } });
                }
                var List = await _IListBoxRepository.GETORDENTYPE(ORDENTYPE);
                if (List == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var objet = VDEFAULT.Read();
                return Ok(new { state = 200, Message = "Proceso completo", result = new { ORDENTYPE = objet.ORDENTYPE, list = List }});
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpPost]
        [Route("STATE")]
        public async Task<IActionResult> POSTSTATE([FromBody] MSTATE STATE)
        {
            try
            {
                if (STATE == null)
                return Ok(new { state = 400, Message = "Objeto nulo o vacio", result = new { } });
            if (!ModelState.IsValid)
                return Ok(new { state = 410, Message = "Objeto invalido", result = new { } });
            var created = await _IListBoxRepository.POSTSTATE(STATE);
            if (created == null)
                return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var objet = VDEFAULT.Read();
                objet.COUNTRY = created.MCOUNTRYId;
                objet.STATE = created.Id;
                objet.CITY = 0;
                VDEFAULT.Write(objet);
                return Ok(new { state = 200, Message = "Proceso completo", result = created });
        }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpGet]
        [Route("STATE")]
        [Route("STATE={STATE}")]
        public async Task<IActionResult> GETSTATE(string? STATE)
        {
            try
            {
                if (STATE == null)
                {
                    var Listnull = await _IListBoxRepository.GETSTATE(STATE);
                    if (Listnull == null)
                        return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                    var objetnull = VDEFAULT.Read();
                    return Ok(new { state = 200, Message = "Proceso completo", result = new { COUNTRY = objetnull.COUNTRY, STATE = objetnull.STATE, CITY = objetnull.CITY, list = Listnull } });
                }
                var List = await _IListBoxRepository.GETSTATE(STATE);
                if (List == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var objet = VDEFAULT.Read();
                return Ok(new { state = 200, Message = "Proceso completo", result = new { COUNTRY = objet.COUNTRY, STATE = objet.STATE, CITY = objet.CITY, list = List } });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpPost]
        [Route("TRADEMARK")]
        public async Task<IActionResult> POSTTRADEMARK([FromBody] MTRADEMARK TRADEMARK)
        {
            try
            {
                if (TRADEMARK == null)
                return Ok(new { state = 400, Message = "Objeto nulo o vacio", result = new { } });
                if (!ModelState.IsValid)
                    return Ok(new { state = 410, Message = "Objeto invalido", result = new { } });
                var created = await _IListBoxRepository.POSTTRADEMARK(TRADEMARK);
                if (created == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var objet = VDEFAULT.Read();
                objet.TRADEMARK = created.Id;
                VDEFAULT.Write(objet);
                return Ok(new { state = 200, Message = "Proceso completo", result = created });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpGet]
        [Route("TRADEMARK")]
        [Route("TRADEMARK={TRADEMARK}")]
        public async Task<IActionResult> GETTRADEMARK(string? TRADEMARK)
        {
            try
            {
                if (TRADEMARK == null)
                {
                    var ListNull = await _IListBoxRepository.GETTRADEMARK(TRADEMARK);
                    if (ListNull == null)
                        return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                    var objetNull = VDEFAULT.Read();
                    return Ok(new { state = 200, Message = "Proceso completo", result = new { TRADEMARK = objetNull.TRADEMARK, list = ListNull } });
                }
                var List = await _IListBoxRepository.GETTRADEMARK(TRADEMARK);
                if (List == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var obejt = VDEFAULT.Read();
                return Ok(new { state = 200, Message = "Proceso completo", result = new { TRADEMARK = obejt.TRADEMARK, list = List } });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }

        
            

    }
}
