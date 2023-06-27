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
		private readonly IPostulanteRepository _postulanteRepository;
		private readonly IEmpresaRepository _empresaRepository;

		public UsuarioController(IUsuarioService usuarioService, IPostulanteRepository postulanteRepository, IEmpresaRepository empresaRepository) 
		{
			_usuarioService = usuarioService;
			_empresaRepository = empresaRepository;
			_postulanteRepository = postulanteRepository;
		}

		[HttpPost("SignIn")]

		public async Task<IActionResult> SigIn([FromBody] UsuarioAuthenticationDTO usuarioAuthenticationDTO) 
		{
			var result = await _usuarioService.validate(usuarioAuthenticationDTO.Correo, usuarioAuthenticationDTO.Password);

			if(result == null) { return NotFound(); }

			if(result.Tipo == "postulante")
			{
				var postulante = await _postulanteRepository.getPostulanteByUsuario(result.IdUsuario);
				var postulan = new PostulanteValidacion
				{
					IdPostulante = postulante.IdPostulante,
					Usuario = new UsuarioValidacion
					{
						Estado = result.Estado,
						Tipo = result.Tipo,
					}

				};
				return Ok(postulan); ;
			}
			if(result.Tipo == "empresa")
			{
				var empresa = await _empresaRepository.getEmpresaByUsuario(result.IdUsuario);
				var emp = new EmpresaValidacion
				{
					IdEmpresa = empresa.IdEmpresa,
					Usuario = new UsuarioValidacion { 
						Estado= result.Estado,
						Tipo = result.Tipo,
					}
				};
				return Ok(emp);
			}
			else
			{
				return Ok(result);
			}
			
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
			else { return Ok(result + " _ nuevo admin creado  _ "); }
		}


	}


}
