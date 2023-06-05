using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Interfaces;
using UESAN.Jobs.Core.Services;

namespace UESAN.Jobs.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OfertaControler : ControllerBase
	{
		private readonly IOfertaService _ofertaService;

		public OfertaControler(IOfertaService oferta) 
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

		[HttpGet("{GetById}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _ofertaService.GetById(id);
			if (result == null)
				return NotFound();
			return Ok(result);
			
		}

		[HttpPut("{UpdateById}")]
		public async Task<IActionResult> Update(int id, OfertaUpdateDTO oferta, int postulantes)
		{
			if(postulantes <= 0) { //si hay como minimo 1 postulacion en la oferta, esta no se podra modificar
				var result = await _ofertaService.Update(oferta);
				return Ok(result);
			}
			return Ok("Tienes como minimo una postulacion, no puedes modificar esta oferta");

		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _ofertaService.Delete(id);
			if (!result)
				return NotFound();
			return Ok(result);
		}


	}
}
