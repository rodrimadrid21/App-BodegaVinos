using BodegaVinos.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BodegaVinos.Models;
using BodegaVinos.Services;

namespace BodegaVinos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WineController : ControllerBase
    {
        private readonly WineService _wineService;

        public WineController(WineService wineService) => _wineService = wineService;

        [HttpPost("register")]
        public IActionResult RegisterWine([FromBody] WineForCreationDTO wineDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var wine = _wineService.AddWine(wineDto);
            return CreatedAtAction(nameof(GetWine), new { name = wine.Name }, wine);
        }

        //conseguir uno
        [HttpGet("{name}")]
        public IActionResult GetWine(string name)
        {
            var wine = _wineService.GetWineByName(name);
            if (wine == null) return NotFound();

            return Ok(wine);
        }

        //editar stock
        [HttpPut("{name}/stock")]
        public IActionResult UpdateStock(string name, [FromBody] int newStock)
        {
            var wine = _wineService.UpdateStock(name, newStock);
            if (wine == null)
                return NotFound();

            return Ok(wine);
        }

        //todos los vinos
        [HttpGet ("all")]
        public IActionResult GetAllWines()
        {
            var wines = _wineService.GetAllWines();
            return Ok(wines);
        }
    }
}

