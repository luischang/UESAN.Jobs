using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Interfaces;
using UESAN.Jobs.Core.Services;

namespace UESAN.Jobs.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompetenciasController : ControllerBase
	{
		private readonly ICompetenciasService _competenciasService;

		public CompetenciasController(ICompetenciasService competenciasService)
		{
			_competenciasService = competenciasService;
		}

		[HttpPost("CreateCompetencia")]
		public async Task<IActionResult> Insert(CompetenciasInsertDTO competenciasInsert)
		{
			var result = await _competenciasService.Insert(competenciasInsert);
			if (!result)
				return BadRequest(result);
			return Ok(result);
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAll()
		{
			var empresa = await _competenciasService.GetAll();
			return Ok(empresa);
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _competenciasService.GetById(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update( CompetenciasUpdateDTO competenciasUpdate)
		{
			var result = await _competenciasService.Update(competenciasUpdate);
			return Ok(result);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _competenciasService.delete(id);
			if (!result)
				return NotFound();
			return Ok(result);
		}
	}
}
