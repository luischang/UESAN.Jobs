﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Interfaces;
using UESAN.Jobs.Core.Services;

namespace UESAN.Jobs.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmpresaController : ControllerBase
	{
		private readonly IEmpresaService _empresaServices;

		public EmpresaController(IEmpresaService empresaServices) 
		{
			_empresaServices = empresaServices;
		
		}

		[HttpPost("CreateEmpresa")]
		public async Task<IActionResult> Insert(EmpresaInsertDTO empresaInsertDTO)
		{
			if (empresaInsertDTO == null)			
				return BadRequest("Datos no válidos");
			if(empresaInsertDTO.Ruc.Length!=11)
				return BadRequest("El ruc debe tener 11 dígitos");

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

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _empresaServices.GetById(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

        [HttpGet("GetByUsuario/{id}")]
        public async Task<IActionResult> GetByIdUsuario(int id)
        {
            var result = await _empresaServices.GetByIdUsuario(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }


        [HttpPut]
		public async Task<IActionResult> Update( EmpresaUpdateDTO empresaUpdateDTO)
		{
				var result = await _empresaServices.Update(empresaUpdateDTO);
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
