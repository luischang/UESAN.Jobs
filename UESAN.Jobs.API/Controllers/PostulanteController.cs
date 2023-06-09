﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Interfaces;
using UESAN.Jobs.Core.Services;

namespace UESAN.Jobs.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostulanteController : ControllerBase
	{
		private readonly IPostulanteService _postulanteService;

		public PostulanteController(IPostulanteService postulanteService) 
		{
			_postulanteService = postulanteService;
		}

		[HttpPost("CreatePostulante")]
		public async Task<IActionResult> Insert(PostulanteInsertDTO postulanteInsertDTO)
		{
			var result = await _postulanteService.Insert(postulanteInsertDTO);
			if (result == 0)
				return BadRequest(false);
			return Ok(result);
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAll()
		{
			var empresa = await _postulanteService.GetAll();
			return Ok(empresa);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _postulanteService.GetById(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update( PostulanteUpdateDTO postulanteUpdateDTO)
		{
			var result = await _postulanteService.Update(postulanteUpdateDTO);
			return Ok(result);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _postulanteService.Delete(id);
			if (!result)
				return NotFound();
			return Ok(result);
		}


	}
}
