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

        // Endpoint para registrar nuevos vinos
        [HttpPost]
        public IActionResult RegisterWine([FromBody] WineForCreationDTO wineDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var wine = _wineService.AddWine(wineDto);
            return CreatedAtAction(nameof(GetWine), new { name = wine.Name }, wine); // Cambié id por name
        }

        // Endpoint para consultar un vino por nombre
        [HttpGet("{name}")]
        public IActionResult GetWine(string name)
        {
            var wine = _wineService.GetWineByName(name);
            if (wine == null) return NotFound();

            return Ok(wine);
        }

        // Endpoint para actualizar el stock
        [HttpPut("{name}/stock")] // Cambié id por name
        public IActionResult UpdateStock(string name, [FromBody] int newStock) // Cambié el parámetro a string
        {
            var wine = _wineService.UpdateStock(name, newStock);
            if (wine == null)
                return NotFound();

            return Ok(wine);
        }

        // Endpoint para consultar todos los vinos en inventario
        [HttpGet]
        public IActionResult GetAllWines()
        {
            var wines = _wineService.GetAllWines(); // Asegúrate de que hay paréntesis aquí
            return Ok(wines);
        }
    }
}

