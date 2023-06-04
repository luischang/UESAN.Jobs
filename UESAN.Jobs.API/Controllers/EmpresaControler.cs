using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Interfaces;

namespace UESAN.Jobs.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmpresaControler : ControllerBase
	{
		private readonly IEmpresaService _empresaServices;

		public EmpresaControler(IEmpresaService empresaServices) 
		{
			_empresaServices = empresaServices;
		
		}

		[HttpPost("CreateEmpresa")]
		public async Task<IActionResult> Insert(EmpresaInsertDTO empresaInsertDTO)
		{
			var result = await _empresaServices.Insert(empresaInsertDTO);
			if (!result)
				return BadRequest(result);
			return Ok(result);
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAll() 
		{
			var empresa = await _empresaServices.GetAll();
			return Ok(empresa);
		}

		[HttpGet("{idEmpresa}")]
		public async Task<IActionResult> GetById(int id)
		{
			var product = await _empresaServices.GetById(id);
			if (product == null)
				return NotFound();
			return Ok(product);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, EmpresaDTO empresaDTO)
		{
			if (id != empresaDTO.IdEmpresa)
				return NotFound();
			var result = await _empresaServices.Update(empresaDTO);
			return Ok(result);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _empresaServices.Delete(id);
			if (!result)
				return NotFound();
			return Ok(result);
		}




	}
}
