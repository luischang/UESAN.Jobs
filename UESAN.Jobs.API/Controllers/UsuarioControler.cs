﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Interfaces;
using UESAN.Jobs.Infrastructure.Repositories;

namespace UESAN.Jobs.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioControler : ControllerBase
	{
		private readonly IUsuarioService _usuarioService;

		public UsuarioControler(IUsuarioService usuarioService) 
		{
			_usuarioService = usuarioService;
		}

		[HttpPost("SignIn")]

		public async Task<IActionResult> SigIn([FromBody] UsuarioAuthenticationDTO usuarioAuthenticationDTO) 
		{
			var result = await _usuarioService.validate(usuarioAuthenticationDTO.Correo, usuarioAuthenticationDTO.Password);

			if(result == null) { return NotFound(); }
			return Ok(result);
		}

		[HttpPost("SignUp")]
		public async Task<IActionResult> SignUp(UsuarioAuthRequestDTO usuarioAuthRequestDTO,string tipo)
		{
			var result = await _usuarioService.register(usuarioAuthRequestDTO, tipo);
			if (!result) { return BadRequest(); }
			return Ok(result);
		}
	}


}
