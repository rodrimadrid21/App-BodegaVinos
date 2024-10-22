using BodegaVinos.Entities;
using BodegaVinos.Services;
using Microsoft.AspNetCore.Mvc;

namespace BodegaVinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CataController : ControllerBase
    {
        private readonly CataService _cataService;

        public CataController(CataService cataService)
        {
            _cataService = cataService;
        }

        //crear una nueva cata
        [HttpPost]
        public async Task<IActionResult> CreateCata([FromBody] Cata cata)
        {
            if (cata == null || cata.Vinos.Count == 0)
            {
                return BadRequest("La cata debe tener vinos asociados.");
            }

            await _cataService.AddCataAsync(cata);
            return Ok("Cata creada con éxito.");
        }

        //todas las catas
        [HttpGet]
        public async Task<IActionResult> GetAllCatas()
        {
            var catas = await _cataService.GetAllCatasAsync();
            return Ok(catas);
        }
    }
}
