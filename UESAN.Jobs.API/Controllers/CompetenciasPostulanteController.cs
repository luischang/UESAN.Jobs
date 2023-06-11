using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Interfaces;

namespace UESAN.Jobs.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompetenciasPostulanteController : ControllerBase
	{
		private readonly ICompetenciasPostulanteService _service;

		public CompetenciasPostulanteController(ICompetenciasPostulanteService service)
		{
			_service = service;
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Insert(CompetenciasPostulanteInsertDTO competenciasInsert)
		{
			var result = await _service.Insert(competenciasInsert);
			if (!result)
				return BadRequest(result);
			return Ok(result);
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAll()
		{
			var competenciasPostulantes = await _service.GetAll();
			return Ok(competenciasPostulantes);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _service.GetAllByIdPostulante(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int idCompetencia, int idPostulante)
		{
			var result = await _service.delete(idCompetencia, idPostulante);
			if (!result)
				return NotFound();
			return Ok(result);
		}
	}
}
