using Data.REPARALO.ConnectDB;
using Data.REPARALO.JSON;
using Data.REPARALO.LIstBox;
using Data.REPARALO.OrdenReparacion;
using Data.REPARALO.RepairOrder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiRestREPARALO.Controllers.RepairOrder
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairOrder : ControllerBase
    {
        public DEFAULT VDEFAULT = new DEFAULT();
        public IConfiguration _configuration;
        private readonly IRepairOrderRepository _IRepairOrderRepository;
        public RepairOrder(DBReparalo dbreparalo, IConfiguration configuration)
        {
            _IRepairOrderRepository = new RepairOrderRepository(dbreparalo);
            _configuration = configuration;
        }
        [HttpPost]
        //[Route("CITY")]
        public async Task<IActionResult> POSTREPAIRORDER([FromBody] MREPAIRORDER REPAIRORDE)
        {
            try
            {
                if (REPAIRORDE == null)
                    return Ok(new { state = 400, Message = "Objeto nulo o vacio", result = new { } });
                if (!ModelState.IsValid)
                    return Ok(new { state = 410, Message = "Objeto invalido", result = new { } });
                var created = await _IRepairOrderRepository.POSTREPAIRORDER(REPAIRORDE);
                if (created == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                
                return Ok(new { state = 200, Message = "Proceso completo", result = new { list = created } });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpGet]
        //[Route("CITY")]
        //[Route("CITY={CITY}")]
        public async Task<IActionResult> GETREPAIRORDER(string? REPAIRORDE)
        {
            try
            {
                if (REPAIRORDE == null)
                {
                    var Listnull = await _IRepairOrderRepository.GETREPAIRORDER(REPAIRORDE);
                    if (Listnull == null)
                        return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                    return Ok(new { state = 200, Message = "Proceso completo", result = new { list = Listnull } });
                }
                var List = await _IRepairOrderRepository.GETREPAIRORDER(REPAIRORDE);
                if (List == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                return Ok(new { state = 200, Message = "Proceso completo", result = new { list = List } });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
    }
}
