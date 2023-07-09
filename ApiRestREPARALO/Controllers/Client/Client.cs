using ApiRestREPARALO.Controllers.RepairOrder;
using ApiRestREPARALO.JSON;
using Data.REPARALO.Client;
using Data.REPARALO.Clients;
using Data.REPARALO.ConnectDB;
using Data.REPARALO.RepairOrder;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

namespace ApiRestREPARALO.Controllers.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class Client : ControllerBase
    {
        public DEFAULT VDEFAULT = new DEFAULT();
        public IConfiguration _configuration;
        private readonly IClientRepository _IClientRepository;
        public Client(DBReparalo dbreparalo, IConfiguration configuration)
        {
            _IClientRepository = new ClientRepository(dbreparalo);
            _configuration = configuration;
        }
        [HttpPost]
        //[Route("CITY")]
        public async Task<IActionResult> POSTCLIENT([FromBody] MCLIENT CLIENT)
        {
            try
            {
                if (CLIENT == null)
                    return Ok(new { state = 400, Message = "Objeto nulo o vacio", result = new { } });
                if (!ModelState.IsValid)
                    return Ok(new { state = 410, Message = "Objeto invalido", result = new { } });
                var created = await _IClientRepository.POSTCLIENT(CLIENT);
                if (created == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var objet = VDEFAULT.Read();
                objet.CLIENT = created.Id;
                if(created.MDOCUMENTTYPEId != null)
                    objet.DOCUMENTTYPE = created.MDOCUMENTTYPEId;
                if (created.MCOUNTRYId != null)
                    objet.COUNTRY = created.MCOUNTRYId;
                if (created.MSTATEId != null)
                    objet.STATE = created.MSTATEId;
                if (created.MCITYId != null)
                    objet.CITY = created.MCITYId;
                VDEFAULT.Write(objet);
                return Ok(new { state = 200, Message = "Proceso completo", result = new { list = created } });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GETCLIENT(string? CLIENT)
        {
            try
            {
                var obejt = VDEFAULT.Read();
                if (CLIENT == null)
                {
                    var Listnull = await _IClientRepository.GETCLIENT(CLIENT);
                    if (Listnull == null)
                        return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                    return Ok(new { state = 200, Message = "Proceso completo", result = new { CLIENT = obejt.CLIENT, list = Listnull } });
                }
                var List = await _IClientRepository.GETCLIENT(CLIENT);
                if (List == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                return Ok(new { state = 200, Message = "Proceso completo", result = new { CLIENT = obejt.CLIENT,  list = List } });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpPut]
        public async Task<IActionResult> PUTCLIENT([FromBody] MCLIENT CLIENT)
        {
            try
            {
                if (CLIENT == null)
                    return Ok(new { state = 400, Message = "Objeto nulo o vacio", result = new { } });
                if (!ModelState.IsValid)
                    return Ok(new { state = 410, Message = "Objeto invalido", result = new { } });
                var created = await _IClientRepository.PUTCLIENT(CLIENT);
                if (created == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                var objet = VDEFAULT.Read();
                objet.CLIENT = created.Id;
                if (created.MDOCUMENTTYPEId != null)
                    objet.DOCUMENTTYPE = created.MDOCUMENTTYPEId;
                if (created.MCOUNTRYId != null)
                    objet.COUNTRY = created.MCOUNTRYId;
                if (created.MSTATEId != null)
                    objet.STATE = created.MSTATEId;
                if (created.MCITYId != null)
                    objet.CITY = created.MCITYId;
                VDEFAULT.Write(objet);
                return Ok(new { state = 200, Message = "Proceso completo", result = new { list = created } });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
    }
}
