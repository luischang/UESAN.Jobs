using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Interfaces;
using UESAN.Jobs.Core.Services;

namespace UESAN.Jobs.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OfertaController : ControllerBase
	{
		private readonly IOfertaService _ofertaService;

		public OfertaController(IOfertaService oferta) 
		{
			_ofertaService = oferta;
		}

		[HttpPost("CreateOferta")]
		public async Task<IActionResult> Insert(OfertaInsert ofertaInsert)
		{
			var result = await _ofertaService.Insert(ofertaInsert);
			if (!result)
				return BadRequest(result);
			return Ok(result);
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAll()
		{
			var oferta = await _ofertaService.GetAll();
			return Ok(oferta);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _ofertaService.GetById(id);
			if (result == null)
				return NotFound();
			return Ok(result);
			
		}

		[HttpPut]
		public async Task<IActionResult> Update( OfertaUpdateDTO oferta)
		{
				var result = await _ofertaService.Update(oferta);
				return Ok(result);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _ofertaService.Delete(id);
			if (!result)
				return NotFound();
			return Ok(result);
		}


		[HttpGet("{id}/GetByEmpresa")]
		public async Task<IActionResult> GetOfertasByEmpresa(int id)
		{
			var result = await _ofertaService.GetAllOfertasByEmpresa(id);
			if (result == null)
				return NotFound("No hay ofertas creadas por la empresa");
			return Ok(result);
		}

	}
}
