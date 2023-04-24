using Data.REPARALO.ConnectDB;
using Data.REPARALO.JSON;
using Data.REPARALO.LIstBox;
using Data.REPARALO.OrdenReparacion;
using Data.REPARALO.Users;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestREPARALO.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : Controller
    {
        public DEFAULT VDEFAULT = new DEFAULT();
        public IConfiguration _configuration;
        private readonly IUserRepository _IUserRepository;
        public Users(DBReparalo dbreparalo, IConfiguration configuration)
        {
            _IUserRepository = new UserRepository(dbreparalo);
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GETLISTUSER")]
        [Route("GETLISTUSER={USER}")]
        public async Task<IActionResult> GETLISTUSER(string? USER)
        {
            try
            {
                if (USER == null)
                {
                    var Listnull = await _IUserRepository.GETUSER(USER);
                    if (Listnull == null)
                        return Ok(new { state = 420, Message = "No fue posible completar la acción", result = new { } });
                    return Ok(new { state = 200, Message = "Proceso completo", result = new  { list = Listnull } });
                }
                var List = await _IUserRepository.GETUSER(USER);
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
