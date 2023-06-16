using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Interfaces;
using UESAN.Jobs.Core.Services;

namespace UESAN.Jobs.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OfertaPostularController : ControllerBase
	{
		private readonly IOfertaPostularService _ofertaPostularService;

		public OfertaPostularController(IOfertaPostularService ofertaPostularService) 
		{
			_ofertaPostularService = ofertaPostularService;
		}

		[HttpPost("CreateOfertaPostular")]
		public async Task<IActionResult> Insert(OfertaPostularInsertDTO ofertaPostularInsertDTO)
		{
			var result = await _ofertaPostularService.Insert(ofertaPostularInsertDTO);
			if (!result)
				return BadRequest(result);
			return Ok(result);
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAll()
		{
			var oferta = await _ofertaPostularService.GetAll();
			return Ok(oferta);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _ofertaPostularService.GetById(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update( OfertaPostularUpdateDTO oferta)
		{
			var result = await _ofertaPostularService.Update(oferta);
			return Ok(result);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _ofertaPostularService.Delete(id);
			if (!result)
				return NotFound();
			return Ok(result + "Se Cancelo la ofertaPostulada relacionada al postulante");
		}

		[HttpGet("{id}/GetPostulantesByIdOferta")]
		public async Task<IActionResult> GetPostulantesByOferta(int id)
		{
			var result = await _ofertaPostularService.GetAllPostulanteByIdOferta(id);
			if (result == null)
				return NotFound("No hay postulantes para esta oferta");
			return Ok(result);
		}

		[HttpGet("{id}/GetOfertasByIdPostulante")]
		public async Task<IActionResult> GetOfertasByIdPostulante(int id)
		{
			var result = await _ofertaPostularService.GetAllOfertasByIdPostulante(id);
			if (result == null)
				return NotFound("Esta persona aun no postula ");
			return Ok(result);
		}





	}
}
