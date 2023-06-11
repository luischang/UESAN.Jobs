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
	public class CompetenciasService : ICompetenciasService
	{
		private readonly ICompetenciasRepository _competenciasRepository;

		public CompetenciasService(ICompetenciasRepository competenciasRepository)
		{
			_competenciasRepository = competenciasRepository;
		}

		public async Task<IEnumerable<CompetenciasDTO>> GetAll()
		{
			var competencias = await _competenciasRepository.GetAll();
			var compe = competencias.Select(x => new CompetenciasDTO
			{
				IdCompetencia = x.IdCompetencia,
				Descripcion = x.Descripcion,
				Estado = x.Estado,
			});
			return compe;
		}

		public async Task<CompetenciasDTO> GetById(int id)
		{
			var competencia = await _competenciasRepository.GetById(id);
			var compe = new CompetenciasDTO
			{
				IdCompetencia = competencia.IdCompetencia,
				Descripcion = competencia.Descripcion,
				Estado = competencia.Estado,
			};
			return compe;
		}

		public async Task<bool> Insert(CompetenciasInsertDTO competenciasInsert)
		{
			if (competenciasInsert != null)
			{
				var compi = new Competencias
				{
					Descripcion = competenciasInsert.Descripcion,
					Estado = true
				};

				return await _competenciasRepository.Insert(compi);
			}
			return false;
		}

		public async Task<bool> Update(CompetenciasUpdateDTO competenciasUpdateDTO)
		{
			if (competenciasUpdateDTO != null)
			{
				var compi = new Competencias
				{
					IdCompetencia = competenciasUpdateDTO.IdCompetencia,
					Descripcion = competenciasUpdateDTO.Descripcion,
					Estado = true,
				};
				return await _competenciasRepository.update(compi);
			}
			return false;
		}

		public async Task<bool> delete(int id)
		{
			return await _competenciasRepository.delete(id);
		}

	}

}
