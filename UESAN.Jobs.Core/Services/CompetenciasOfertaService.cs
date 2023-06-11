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
	public class CompetenciasOfertaService : ICompetenciasOfertaService
	{
		private readonly ICompetenciasOfertaRepository _competenciasOfertaRepository;

		public CompetenciasOfertaService(ICompetenciasOfertaRepository competenciasOfertaRepository)
		{
			_competenciasOfertaRepository = competenciasOfertaRepository;
		}

		public async Task<IEnumerable<CompetenciasOfertaDTO>> GetAll()
		{
			var compeOferts = await _competenciasOfertaRepository.GetAll();
			var competenciasOfertaDTO = compeOferts.Select(e => new CompetenciasOfertaDTO
			{
				IdCompetencia = e.IdCompetencia,
				IdOferta = e.IdOferta,
				Oferta = new OfertaDescripcionDTO
				{
					Descripcion = e.IdOfertaNavigation.Descripcion,
					Empresa = new EmpresaDescDTO
					{
						IdEmpresa = e.IdOfertaNavigation.IdEmpresaNavigation.IdEmpresa,
						Nombre = e.IdOfertaNavigation.IdEmpresaNavigation.Nombre
					}

				},
				Competencias = new CompetenciasDescripcionDTO
				{
					Descripcion = e.IdCompetenciaNavigation.Descripcion,
				},

			});
			return competenciasOfertaDTO;

		}

		public async Task<IEnumerable<CompetenciasOfertaDTO>> GetAllByIdOferta(int idofert)
		{
			var compeOfert = await _competenciasOfertaRepository.GetAllByIdOferta(idofert);
			var competenciasOfertaDTO = compeOfert.Select(e => new CompetenciasOfertaDTO
			{
				IdCompetencia = e.IdCompetencia,
				IdOferta = e.IdOferta,
				Oferta = new OfertaDescripcionDTO
				{
					Descripcion = e.IdOfertaNavigation.Descripcion,
					Empresa = new EmpresaDescDTO
					{
						IdEmpresa = e.IdOfertaNavigation.IdEmpresaNavigation.IdEmpresa,
						Nombre = e.IdOfertaNavigation.IdEmpresaNavigation.Nombre
					}

				},
				Competencias = new CompetenciasDescripcionDTO
				{
					Descripcion = e.IdCompetenciaNavigation.Descripcion,
				},

			});
			return competenciasOfertaDTO;
		}

		public async Task<bool> Insert(CompetenciasOfertasInsertDTO competenciasOfertasInsertDTO)
		{
			if (competenciasOfertasInsertDTO != null)
			{
				var com = new CompetenciasOferta
				{
					IdCompetencia = competenciasOfertasInsertDTO.IdCompetencia,
					IdOferta = competenciasOfertasInsertDTO.IdOferta,
					Estado = true,
				};
				return await _competenciasOfertaRepository.Insert(com);
			}
			return false;
		}

		public async Task<bool> delete(int idCompetencia, int idOferta)
		{
			return await _competenciasOfertaRepository.delete(idCompetencia, idOferta);
		}
	}
}
