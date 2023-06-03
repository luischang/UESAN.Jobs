using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Entities;
using UESAN.Jobs.Infrastructure.Repositories;

namespace UESAN.Jobs.Core.Services
{
	public class UsuarioService
	{
		private readonly IUsuarioRepository _usuarioRepository;

		public UsuarioService (IUsuarioRepository usuarioRepository) 
		{
			_usuarioRepository = usuarioRepository;
		}

		public async Task<UsuarioAuthResponseDTO> validate(string correo, string contra) 
		{
			var usuario = await _usuarioRepository.SigIn(correo, contra);

			if(usuario == null) { return null; }

			var usuarioDTO = new UsuarioAuthResponseDTO()
			{
				IdUsuario = usuario.IdUsuario,
				Tipo = usuario.Tipo,
				Estado = usuario.Estado,
				Correo = usuario.Correo,
				Password = usuario.Password,
			
			};
			return usuarioDTO;
		}

		public async Task<bool> register(UsuarioAuthRequestDTO usuDTO, string tipo) 
		{
			var correoResult = await _usuarioRepository.IsEmailRegistered(usuDTO.Correo);

			if(correoResult) { return false; }

			var usuario = new Usuario()
			{
				Tipo = tipo,
				Estado = usuDTO.Estado,
				Correo = usuDTO.Correo,
				Password = usuDTO.Password,

			};
			var result = await _usuarioRepository.SignUp(usuario);
			return result;


		} 
		
	}
}
