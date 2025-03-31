using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using skola24.Interfaces;

namespace skola24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {

        private readonly IAbsenceService _absenceService;
        public AbsenceController(IAbsenceService absenceService) {
            
            _absenceService = absenceService;


        }

        [HttpGet("TotalSchoolAbsence")]
        public async Task<IActionResult> Get([FromQuery] string schoolName) { 
        
            return Ok(await _absenceService.GetAbsenceForSchoolAsync(schoolName));

        }
    }
}
