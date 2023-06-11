using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Interfaces;
using UESAN.Jobs.Core.Services;

namespace UESAN.Jobs.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompetenciasOfertaController : ControllerBase
	{
		private readonly ICompetenciasOfertaService _cos;

		public CompetenciasOfertaController(ICompetenciasOfertaService cos)
		{
			_cos = cos;
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Insert(CompetenciasOfertasInsertDTO competenciasInsert)
		{
			var result = await _cos.Insert(competenciasInsert);
			if (!result)
				return BadRequest(result);
			return Ok(result);
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAll()
		{
			var competenciasOfertas = await _cos.GetAll();
			return Ok(competenciasOfertas);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _cos.GetAllByIdOferta(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int idCompetencia, int idOferta)
		{
			var result = await _cos.delete(idCompetencia,idOferta);
			if (!result)
				return NotFound();
			return Ok(result);
		}


	}
}
