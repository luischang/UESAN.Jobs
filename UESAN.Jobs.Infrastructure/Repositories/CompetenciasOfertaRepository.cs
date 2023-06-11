using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Jobs.Core.Entities;
using UESAN.Jobs.Infrastructure.Models;

namespace UESAN.Jobs.Infrastructure.Repositories
{
	public class CompetenciasOfertaRepository : ICompetenciasOfertaRepository
	{
		private readonly BolsaDeTrabajoContext _context;

		public CompetenciasOfertaRepository(BolsaDeTrabajoContext bolsaDeTrabajoContext)
		{
			_context = bolsaDeTrabajoContext;
		}

		public async Task<IEnumerable<CompetenciasOferta>> GetAll()
		{
			return await _context.CompetenciasOferta
				.Where(x => x.Estado == true)
				.Include(y => y.IdCompetenciaNavigation)
				.Include(z => z.IdOfertaNavigation)
				.ToListAsync();
		}

		public async Task<IEnumerable<CompetenciasOferta>> GetAllByIdOferta(int id)
		{
			return await _context.CompetenciasOferta
				.Where(x => x.IdOferta == id && x.Estado == true)
				.Include(y => y.IdCompetenciaNavigation)
				.Include(z => z.IdOfertaNavigation)
				.ToListAsync();
		}

		public async Task<bool> update(CompetenciasOferta competenciasOferta)
		{
			_context.CompetenciasOferta.Update(competenciasOferta);
			var rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<bool> Insert(CompetenciasOferta competencias)
		{
			await _context.CompetenciasOferta.AddAsync(competencias);
			var rows = await _context.SaveChangesAsync();
			return rows > 0;

		}

		public async Task<bool> delete(int idCompi, int idOfert)
		{
			var competencia = await _context.CompetenciasOferta.Where(x => x.IdCompetencia == idCompi && x.IdOferta == idOfert).FirstOrDefaultAsync();
			if (competencia == null) { return false; }
			competencia.Estado = false;
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

	}
}
