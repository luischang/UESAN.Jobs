using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Jobs.Core.Entities;
using UESAN.Jobs.Core.Interfaces;
using UESAN.Jobs.Infrastructure.Models;

namespace UESAN.Jobs.Infrastructure.Repositories
{
	public class CompetenciasPostulanteRepository : ICompetenciasPostulanteRepository
	{
		private readonly BolsaDeTrabajoContext _context;

		public CompetenciasPostulanteRepository(BolsaDeTrabajoContext context)
		{ _context = context; }

		public async Task<IEnumerable<CompetenciasPostulante>> GetAll()
		{
			return await _context.CompetenciasPostulante
				.Where(x => x.Estado == true)
				.Include(y => y.IdCompetenciaNavigation)
				.Include(z => z.IdPostulanteNavigation)
				.ToListAsync();
		}

		public async Task<IEnumerable<CompetenciasPostulante>> GetAllByIdPostulante(int id)
		{
			return await _context.CompetenciasPostulante
				.Where(x => x.IdPostulante == id && x.Estado == true)
				.Include(y => y.IdCompetenciaNavigation)
				.Include(z => z.IdPostulanteNavigation)
				.ToListAsync();
		}

		public async Task<bool> update(CompetenciasPostulante competenciasPostulante)
		{
			_context.CompetenciasPostulante.Update(competenciasPostulante);
			var rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<bool> Insert(CompetenciasPostulante competencias)
		{
			await _context.CompetenciasPostulante.AddAsync(competencias);
			var rows = await _context.SaveChangesAsync();
			return rows > 0;

		}

		public async Task<bool> delete(int idCompi, int idPostulante)
		{
			var competencia = await _context.CompetenciasPostulante
				.Where(x => x.IdCompetencia == idCompi && x.IdPostulante == idPostulante)
				.FirstOrDefaultAsync();
			if (competencia == null) { return false; }
			competencia.Estado = false;
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}




	}
}
