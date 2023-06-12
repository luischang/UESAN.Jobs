using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Interfaces;

namespace UESAN.Jobs.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CalificacionesController : ControllerBase
	{
		private readonly ICalificacionesServices _calificacionesServices;

		public CalificacionesController(ICalificacionesServices calificacionesServices)
		{
			_calificacionesServices = calificacionesServices;
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Insert(CalificacionesInsertDTO calificaciones)
		{
			var result = await _calificacionesServices.Insert(calificaciones);
			if (!result)
				return BadRequest(result);
			return Ok(result);
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAll()
		{
			var competenciasOfertas = await _calificacionesServices.GetAll();
			return Ok(competenciasOfertas);
		}

		[HttpGet("{id}/GetCalificacionesEmpresa")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _calificacionesServices.GetAllByIdEmpresa(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}
		[HttpGet("{id}/GetPromedioCalificaciones")]
		public async Task<IActionResult> GetPromedioCalificacion(int id)
		{
			int result = await _calificacionesServices.GetPormedioCalificacion(id);
			return Ok(result);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int postulante, int empresa)
		{
			var result = await _calificacionesServices.delete(postulante, empresa);
			if (!result)
				return NotFound();
			return Ok(result);
		}

	}
}
