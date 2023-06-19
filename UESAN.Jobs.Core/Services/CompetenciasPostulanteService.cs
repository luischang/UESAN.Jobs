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
    public class CompetenciasPostulanteService : ICompetenciasPostulanteService
	{
		private readonly ICompetenciasPostulanteRepository _cpr;

		public CompetenciasPostulanteService(ICompetenciasPostulanteRepository cpr)
		{
			_cpr = cpr;
		}

		public async Task<IEnumerable<CompetenciasPostulanteDTO>> GetAll()
		{
			var compePos = await _cpr.GetAll();
			var competenciasPostulanteDTO = compePos.Select(e => new CompetenciasPostulanteDTO
			{
				IdCompetencia = e.IdCompetencia,
				Postulante = new PostulanteDescripcionDTO
				{
					IdPostulante = e.IdPostulante,
					Nombre = e.IdPostulanteNavigation.Nombre,
				},
				Competencias = new CompetenciasDescripcionDTO
				{
					Descripcion = e.IdCompetenciaNavigation.Descripcion,
				},

			});
			return competenciasPostulanteDTO;

		}

		public async Task<IEnumerable<CompetenciasPostulanteDTO>> GetAllByIdPostulante(int idPos)
		{
			var compPos = await _cpr.GetAllByIdPostulante(idPos);
			var competenciasPostulanteDTO = compPos.Select(e => new CompetenciasPostulanteDTO
			{
				IdCompetencia = e.IdCompetencia,
				Postulante = new PostulanteDescripcionDTO
				{
					IdPostulante = e.IdPostulante,
					Nombre = e.IdPostulanteNavigation.Nombre,
				},
				Competencias = new CompetenciasDescripcionDTO
				{
					Descripcion = e.IdCompetenciaNavigation.Descripcion,
				},

			});
			return competenciasPostulanteDTO;
		}

		public async Task<bool> Insert(CompetenciasPostulanteInsertDTO competenciasPostulanteInsertDTO)
		{
			//Validare que un postulante no tenga competencias repetidas
			var competencias = await _cpr.GetAllByIdPostulante(competenciasPostulanteInsertDTO.IdPostulante);
			bool estado = true;
			if (competencias.Count() > 0)
			{
				foreach (var item in competencias)
				{
					if (competenciasPostulanteInsertDTO.IdCompetencia == item.IdCompetencia)
					{
						estado = false;
					}
				}
			}
				
            if (competenciasPostulanteInsertDTO != null && estado)
			{
				var com = new CompetenciasPostulante
				{
					IdCompetencia = competenciasPostulanteInsertDTO.IdCompetencia,
					IdPostulante = competenciasPostulanteInsertDTO.IdPostulante,
					Estado = true,
				};
				return await _cpr.Insert(com);
			}
			return false;
		}

		public async Task<bool> delete(int idCompetencia, int idPostulante)
		{
			return await _cpr.delete(idCompetencia, idPostulante);
		}
	}
}
