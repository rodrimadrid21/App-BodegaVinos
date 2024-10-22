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

        public WineController(WineService wineService)
        {
            _wineService = wineService; // Asigna el servicio de vinos
        }

        //Registrar uno
        [HttpPost("register")]
        public async Task<IActionResult> RegisterWine([FromBody] WineForCreationDTO wineDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var wine = await _wineService.AddWineAsync(wineDto);
            return CreatedAtAction(nameof(GetWineById), new { id = wine.Id }, wine);
        }

        //Todos los vinos
        [HttpGet("all")]
        public async Task<IActionResult> GetAllWines()
        {
            var wines = await _wineService.GetAllWinesAsync();
            return Ok(wines);
        }

        //conseguir por variedad
        [HttpGet("variety/{variety}")]
        public async Task<IActionResult> GetWinesByVariety(string variety)
        {
            var wines = await _wineService.GetWinesByVarietyAsync(variety);
            if (wines == null || wines.Count == 0)
            {
                return NotFound($"No se encontraron vinos de la variedad {variety}");
            }
            return Ok(wines);
        }
        //conseguir uno por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWineById(int id)
        {
            var wine = await _wineService.GetWineByIdAsync(id);
            if (wine == null)
            {
                return NotFound($"No se encontró vino con Id {id}");
            }
            return Ok(wine);
        }

        //editar stock
        [HttpPut("{id}/stock")]
        public async Task<IActionResult> UpdateWineStock(int id, [FromBody] int newStock)
        {
            // Verifica que el vino exista
            var wine = await _wineService.GetWineByIdAsync(id);
            if (wine == null)
            {
                return NotFound($"No se encontró vino con Id {id}");
            }

            // Actualiza el stock
            await _wineService.UpdateWineStockAsync(id, newStock);
            return Ok($"Stock del vino con Id {id} actualizado a {newStock}.");
        }
    }
}
