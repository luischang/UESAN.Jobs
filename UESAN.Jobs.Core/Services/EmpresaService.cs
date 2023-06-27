using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Entities;
using UESAN.Jobs.Core.Interfaces;

namespace UESAN.Jobs.Core.Services
{
	public class EmpresaService :IEmpresaService
	{
		private readonly IEmpresaRepository _empresaRepository;
		private readonly UsuarioService _usuarioService;
		private readonly IUsuarioRepository _usuarioRepository;
		


		public EmpresaService(IEmpresaRepository empresaRepository, UsuarioService usuarioService, IUsuarioRepository usuarioRepository)
		{
			_empresaRepository = empresaRepository;
			_usuarioService = usuarioService;
			_usuarioRepository = usuarioRepository;
		}



		public async Task<IEnumerable<EmpresaUsuarioDTO>> GetAll()
		{
			var empresas = await _empresaRepository.GetAll();

			var empresaDTO = empresas.Select(e => new EmpresaUsuarioDTO
			{
				IdEmpresa = e.IdEmpresa,
				Nombre = e.Nombre,
				Ruc = e.Ruc,
				Direccion = e.Direccion,
				Telefono = e.Telefono,
				Usuario = new UsuarioDescripcionDTO()
				{
					IdUsuario = e.IdUsuarioNavigation.IdUsuario,
					Correo = e.IdUsuarioNavigation.Correo
				}

			});
			return empresaDTO;

		}

		public async Task<EmpresaUsuarioDTO> GetById(int id)
		{
			var empresa = await _empresaRepository.GetById(id);
			if (empresa == null)
				return null;
			var empresaDTO = new EmpresaUsuarioDTO()
			{
				IdEmpresa = empresa.IdEmpresa,
				Nombre = empresa.Nombre,
				Ruc = empresa.Ruc,
				Direccion = empresa.Direccion,
				Telefono = empresa.Telefono,
				Usuario = new UsuarioDescripcionDTO()
				{
					IdUsuario = empresa.IdUsuarioNavigation.IdUsuario,
					Correo = empresa.IdUsuarioNavigation.Correo
				}

			};
			return empresaDTO;
		}

		public async Task<bool> Insert(EmpresaInsertDTO empresaInsertDTO)
		{
			var usuarioI = new UsuarioAuthRequestDTO()
			{
				Correo = empresaInsertDTO.UsuarioInsert.Correo,
				Password = empresaInsertDTO.UsuarioInsert.Password,
				Tipo = "empresa"
			};

			var usu = await _usuarioService.register(usuarioI);
			//Traemos el objeto usuario creado
			var persona = await _usuarioService.GetUsuCreateByCorreo(usuarioI);

			if (usu)
			{
				var usuario = await _usuarioRepository.GetById(persona.IdUsuario);

				var empresa = new Empresa()
				{
					IdUsuario = usuario.IdUsuario,
					Nombre = empresaInsertDTO.Nombre,
					Ruc = empresaInsertDTO.Ruc,
					Direccion = empresaInsertDTO.Direccion,
					Telefono = empresaInsertDTO.Telefono,

				};
				return await _empresaRepository.InsertEmpresa(empresa);

			}
			return false;
		}

		public async Task<bool> Update(EmpresaUpdateDTO empresaDTO)
		{
			//modifico la empresa
			var empresa = new Empresa()
			{
				IdEmpresa = empresaDTO.IdEmpresa,
				Nombre = empresaDTO.Nombre,
				Ruc = empresaDTO.Ruc,
				Telefono = empresaDTO.Telefono,
				Direccion = empresaDTO.Direccion,
				IdUsuario = empresaDTO.UpdateUsuario.IdUsuario,
				
			};
			//modifico el usuario
			var usuario = new Usuario()
			{
				IdUsuario = empresaDTO.UpdateUsuario.IdUsuario,
				Correo = empresaDTO.UpdateUsuario.Correo,
				Password = empresaDTO.UpdateUsuario.Password,
				Tipo = "empresa",
				Estado = true,
		
			};
			
			return await _empresaRepository.Update(empresa) && await _usuarioRepository.update(usuario);
		}

		public async Task<bool> Delete(int id)
		{
			var idUsuario = await _empresaRepository.GetIdUsuario(id);
			return await _empresaRepository.delete(id);
		}


		


	}
}
