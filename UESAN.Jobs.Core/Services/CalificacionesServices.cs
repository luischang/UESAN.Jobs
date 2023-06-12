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
    public class CalificacionesServices : ICalificacionesServices
	{
		private readonly ICalificacionRespository _calificaciones;

		public CalificacionesServices(ICalificacionRespository calificaciones)
		{
			_calificaciones = calificaciones;
		}

		public async Task<IEnumerable<CalificacionesDTO>> GetAll()
		{
			var calificaciones = await _calificaciones.GetAll();
			var calificacionesDTO = calificaciones.Select(x => new CalificacionesDTO
			{
				Calificacion = x.Calificacion,
				Empresa = new EmpresaDescDTO
				{
					IdEmpresa = x.IdEmpresa,
					Nombre = x.IdEmpresaNavigation.Nombre
				},
				Postulante = new PostulanteDescripcionDTO
				{
					IdPostulante = x.IdPostulante,
					Nombre = x.IdPostulanteNavigation.Nombre
				}
			});
			return calificacionesDTO;
		}

		public async Task<IEnumerable<CalificacionesDTO>> GetAllByIdEmpresa(int idEmpresa)
		{
			var calificaciones = await _calificaciones.GetAllByIdEmpresa(idEmpresa);
			var calificacionesDTO = calificaciones.Select(x => new CalificacionesDTO
			{
				Calificacion = x.Calificacion,
				Empresa = new EmpresaDescDTO
				{
					IdEmpresa = x.IdEmpresa,
					Nombre = x.IdEmpresaNavigation.Nombre
				},
				Postulante = new PostulanteDescripcionDTO
				{
					IdPostulante = x.IdPostulante,
					Nombre = x.IdPostulanteNavigation.Nombre
				}
			});
			return calificacionesDTO;
		}

		public async Task<bool> Insert(CalificacionesInsertDTO calificacionesInsertDTO)
		{
			if (calificacionesInsertDTO != null)
			{
				var calificacion = new Calificaciones
				{
					IdEmpresa = calificacionesInsertDTO.IdEmpresa,
					IdPostulante = calificacionesInsertDTO.IdPostulante,
					Calificacion = calificacionesInsertDTO.Calificacion,
					Estado = true
				};
				return await _calificaciones.Insert(calificacion);
			}
			return false;
		}

		public async Task<bool> delete(int idPostulante, int idEmpresa)
		{
			return await _calificaciones.delete(idPostulante, idEmpresa);
		}

		public async Task<int> GetPormedioCalificacion(int idEmpresa)
		{
			var contador = 0;
			var calificaciones = await _calificaciones.GetAllByIdEmpresa(idEmpresa);
			var acumCalificaciones = 0;
			if(calificaciones != null)
			{
				foreach (var item in calificaciones)
				{
					acumCalificaciones = (int)(acumCalificaciones + item.Calificacion);
					contador++;
				}
				return acumCalificaciones/contador;
			}
			return 0;
			
		}
	}
}
