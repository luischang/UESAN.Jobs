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
	public  class EmpresaService
	{
		private readonly IEmpresaRepository _empresaRepository;
		private readonly UsuarioService _usuarioService;
		private readonly IUsuarioRepository _usuarioRepository;
		

		public EmpresaService (IEmpresaRepository empresaRepository, UsuarioService usuarioService, IUsuarioRepository usuarioRepository)
		{
			_empresaRepository = empresaRepository;
			_usuarioService = usuarioService;
			_usuarioRepository = usuarioRepository;
		}

		

		public async Task<IEnumerable<EmpresaUsuarioDTO>> GetAll() 
		{
			var empresas = await _empresaRepository.GetAll();

			var empresaDTO = empresas.Select(e=> new EmpresaUsuarioDTO
			{
				IdEmpresa = e.IdEmpresa,
				Nombre = e.Nombre,
				Ruc = e.Ruc,
				Direccion= e.Direccion,
				Telefono = e.Telefono,
				Usuario = new UsuarioDescripcionDTO()
				{ IdUsuario = e.IdUsuarioNavigation.IdUsuario , Correo = e.IdUsuarioNavigation.Correo
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
				{ IdUsuario = empresa.IdUsuarioNavigation.IdUsuario, Correo = empresa.IdUsuarioNavigation.Correo
				}
				
			};
			return empresaDTO;
		}

		public async Task<bool> Insert(EmpresaInsertDTO empresaInsertDTO, UsuarioAuthRequestDTO usuarioAuthRequestDTO)
		{
			var usu = await _usuarioService.register(usuarioAuthRequestDTO, "empresa");

			if (usu)
			{
				var usuario = await _usuarioRepository.GetById(usuarioAuthRequestDTO.IdUsuario);

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

		public async Task<bool> Update(EmpresaDTO empresaDTO)
		{
			var empresa = new Empresa()
			{
				IdEmpresa = empresaDTO.IdEmpresa,
				Nombre = empresaDTO.Nombre,
				Ruc = empresaDTO.Ruc,
				Telefono= empresaDTO.Telefono,
				Direccion = empresaDTO.Direccion,
				IdUsuario = empresaDTO.IdUsuario
			};
			return await _empresaRepository.Update(empresa);
		}

		public async Task<bool> Delete(int id)
		{
			return await _empresaRepository.delete(id);
		}


	}
}
