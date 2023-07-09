using ApiRestREPARALO.JSON;
using Data.REPARALO.ConnectDB;
using Data.REPARALO.LIstBox;
using Data.REPARALO.OrdenReparacion;
using Data.REPARALO.RepairOrder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

                var objet = VDEFAULT.Read();
                objet.REPAIRORDER = created.Id;
                VDEFAULT.Write(objet);
                return Ok(new { state = 200, Message = "Proceso completo", result = new { list = created } });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GETREPAIRORDER(string? REPAIRORDE)
        {
            try
            {
                var obejt = VDEFAULT.Read();
                if (REPAIRORDE == null)
                {
                    var Listnull = await _IRepairOrderRepository.GETREPAIRORDER(REPAIRORDE);
                    if (Listnull == null)
                        return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                    return Ok(new { state = 200, Message = "Proceso completo", result = new { REPAIRORDER = obejt.REPAIRORDER, list = Listnull } });
                }
                var List = await _IRepairOrderRepository.GETREPAIRORDER(REPAIRORDE);
                if (List == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                return Ok(new { state = 200, Message = "Proceso completo", result = new { REPAIRORDER = obejt.REPAIRORDER, list = List } });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
        [HttpGet]
        [Route("PDF")]
        public async Task<IActionResult> GETPDFREPAIRORDER(int? REPAIRORDE)
        {
            try
            {
                if (REPAIRORDE == null)
                {
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                }
                var Object = await _IRepairOrderRepository.GETPDFREPAIRORDER(REPAIRORDE);
                if (Object == null)
                    return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });


                //Stream stream = new MemoryStream(Object);
                //return Ok(new { state = 200, Message = "Proceso completo", result = new { list = File(stream,"application/pdf","detalleventa.pdf") } });
                return Ok(new { state = 200, Message = "Proceso completo", result = new { list = Object } });
            }
            catch (Exception ex)
            {
                return Ok(new { state = 430, Message = ex.ToString(), result = new { } });
            }
        }
    }
}
