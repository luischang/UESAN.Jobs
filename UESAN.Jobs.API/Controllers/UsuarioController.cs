using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Interfaces;
using UESAN.Jobs.Infrastructure.Repositories;

namespace UESAN.Jobs.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioService _usuarioService;

		public UsuarioController(IUsuarioService usuarioService) 
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
		public async Task<IActionResult> SignUp(UsuarioAuthRequestDTO usuarioAuthRequestDTO)
		{
			var result = await _usuarioService.register(usuarioAuthRequestDTO);
			if (!result) { return BadRequest(); }
			else { return Ok(result); }
		}

		[HttpPost("SignUp/admin")]
		public async Task<IActionResult> SignUpAdmin(UsuarioPerfil up)
		{
			var result = await _usuarioService.CreateAdmin(up);
			if (!result) { 
				return BadRequest("No se ha creado el admin");
			}
			else { return Ok(result + " _ nuevo admin creado "); }
		}


	}


}
