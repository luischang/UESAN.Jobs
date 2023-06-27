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
	public class PostulanteService : IPostulanteService
	{
		private readonly IPostulanteRepository _postulanteRepository;
		private readonly UsuarioService _usuarioService;
		private readonly IUsuarioRepository _usuarioRepository;



		public PostulanteService(IPostulanteRepository postulanteRepository, UsuarioService usuarioService, IUsuarioRepository usuarioRepository)
		{
			_postulanteRepository = postulanteRepository;
			_usuarioService = usuarioService;
			_usuarioRepository = usuarioRepository;
		}



		public async Task<IEnumerable<PostulanteUsuarioDTO>> GetAll()
		{
			var postulantes = await _postulanteRepository.GetAll();

			var posDTO = postulantes.Select( e => new PostulanteUsuarioDTO
			{
				IdPostulante = e.IdPostulante,
				Nombre = e.Nombre,
				Direccion = e.Direccion,
				Dni = e.Dni,
				Telefono = e.Telefono,
				Usuario = new UsuarioDescripcionDTO()
				{
					IdUsuario = e.IdUsuarioNavigation.IdUsuario,
					Correo = e.IdUsuarioNavigation.Correo,
				}
				 
			});
			return posDTO;

		}

		public async Task<PostulanteUsuarioDTO> GetById(int id)
		{
			var postulante = await _postulanteRepository.GetById(id);
			if (postulante == null)
				return null;
			var postulanteDTO = new PostulanteUsuarioDTO()
			{
				IdPostulante = postulante.IdPostulante,
				Nombre = postulante.Nombre,
				Direccion = postulante.Direccion,
				Telefono = postulante.Telefono,
				Dni = postulante.Dni,
				Usuario = new UsuarioDescripcionDTO()
				{
					IdUsuario = postulante.IdUsuarioNavigation.IdUsuario,
					Correo = postulante.IdUsuarioNavigation.Correo
				}

			};
			return postulanteDTO;
		}

		public async Task<int> Insert(PostulanteInsertDTO postulanteInsertDTO)
		{
			var usuarioI = new UsuarioAuthRequestDTO()
			{
				Correo = postulanteInsertDTO.UsuarioInsert.Correo,
				Password = postulanteInsertDTO.UsuarioInsert.Password,
				Tipo = "postulante"
			};

			var usu = await _usuarioService.register(usuarioI);
			//Traemos el objeto usuario creado
			var persona = await _usuarioService.GetUsuCreateByCorreo(usuarioI);

			if (usu)
			{
				var usuario = await _usuarioRepository.GetById(persona.IdUsuario);

				var postulante = new Postulante()
				{
					IdUsuario = usuario.IdUsuario,
					Nombre = postulanteInsertDTO?.Nombre,
					Direccion = postulanteInsertDTO.Direccion,
					Telefono = postulanteInsertDTO.Telefono,
					Dni = postulanteInsertDTO.Dni,
				};
				return await _postulanteRepository.Insert(postulante);

			}
			return 0;
		}

		public async Task<bool> Update(PostulanteUpdateDTO postulanteUpdateDTO)
		{
			//creamos el objeto postulante 
			var postulante = new Postulante()
			{
				IdPostulante = postulanteUpdateDTO.IdPostulante,
				Nombre = postulanteUpdateDTO.Nombre,
				Dni = postulanteUpdateDTO.Dni,
				Direccion = postulanteUpdateDTO.Direccion,
				Telefono = postulanteUpdateDTO.Telefono,
				IdUsuario = postulanteUpdateDTO.UpdateUsuario.IdUsuario,
			};
			var usuario = new Usuario()
			{
				IdUsuario = postulanteUpdateDTO.UpdateUsuario.IdUsuario,
				Correo = postulanteUpdateDTO.UpdateUsuario?.Correo,
				Password = postulanteUpdateDTO.UpdateUsuario.Password,
				Tipo = "postulante",
				Estado = true,
			};

			return await _postulanteRepository.update(postulante);
		}

		public async Task<bool> Delete(int id)
		{
			var idUsuario = await _postulanteRepository.GetIdUsuario(id);
			return await _postulanteRepository.delete(id);
		}

		
	}
}
