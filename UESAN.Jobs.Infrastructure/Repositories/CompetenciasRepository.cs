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
	public class CompetenciasRepository : ICompetenciasRepository
	{
		private readonly BolsaDeTrabajoContext _context;

		public CompetenciasRepository(BolsaDeTrabajoContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Competencias>> GetAll()
		{
			return await _context.Competencias.ToListAsync();
		}

		public async Task<Competencias> GetById(int id)
		{
			return await _context.Competencias
				.Where(x => x.IdCompetencia == id)
				.FirstOrDefaultAsync();
		}

		public async Task<bool> update(Competencias competencias)
		{
			_context.Competencias.Update(competencias);
			var rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<bool> Insert(Competencias competencias)
		{
			await _context.Competencias.AddAsync(competencias);
			var rows = await _context.SaveChangesAsync();
			return rows > 0;

		}

		public async Task<bool> delete(int id)
		{
			var competencia = await _context.Competencias.Where(x => x.IdCompetencia == id).FirstOrDefaultAsync();
			if (competencia == null) { return false; }
			competencia.Estado = false;
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

	}
}
