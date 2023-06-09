﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Entities;
using UESAN.Jobs.Core.Interfaces;

namespace UESAN.Jobs.Core.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUsuarioRepository _usuarioRepository;
		private int id = 1000;

		public UsuarioService(IUsuarioRepository usuarioRepository)
		{ 
			_usuarioRepository = usuarioRepository;
		}

		public async Task<UsuarioAuthResponseDTO> validate(string correo, string contra)
		{
			var usuario = await _usuarioRepository.SigIn(correo, contra);

			if (usuario == null) { return null; }

			var usuarioDTO = new UsuarioAuthResponseDTO()
			{
				IdUsuario = usuario.IdUsuario,
				Tipo = usuario.Tipo,
				Estado = usuario.Estado,

			};
			return usuarioDTO;
		}

		public async Task<bool> register(UsuarioAuthRequestDTO usuDTO)
		{
			var correoResult = await _usuarioRepository.IsEmailRegistered(usuDTO.Correo);

			if (correoResult) { return false; }
			//id = id + 1;
			var usuario = new Usuario()
			{
				//IdUsuario = id,
				Tipo = usuDTO.Tipo,
				Estado = true,
				Correo = usuDTO.Correo,
				Password = usuDTO.Password,

			};
			var result = await _usuarioRepository.SignUp(usuario);
			return result;

		}

		public async Task<bool> CreateAdmin(UsuarioPerfil usuDTO) 
		{
			var correoResult = await _usuarioRepository.IsEmailRegistered(usuDTO.Correo);

			if (correoResult) 
			{
				return false;
			}
			var usuario = new Usuario()
			{
				Tipo = "admin",
				Estado = true,
				Correo = usuDTO.Correo,
				Password = usuDTO.Password,

			};
			var result = await _usuarioRepository.SignUp(usuario);
			return result;
		}

		public async Task<Usuario> GetUsuCreateByCorreo(UsuarioAuthRequestDTO usuDTO) 
		{
			return  await _usuarioRepository.GetId(usuDTO.Correo);
		
		}

		public async Task<bool> validateLog(string correo, string contra)
		{
			var usuario = await _usuarioRepository.SigIn(correo, contra);

			if (usuario == null) { return false; }
			return true;
		}


	}
}
