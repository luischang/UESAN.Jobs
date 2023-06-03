using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Jobs.Core.Entities;
using UESAN.Jobs.Infrastructure.Models;

namespace UESAN.Jobs.Infrastructure.Repositories
{
	public class OfertaPostularRepository : IOfertaPostularRepository
	{
		private readonly BolsaDeTrabajoContext _context;

		public OfertaPostularRepository(BolsaDeTrabajoContext context)
		{
			_context = context;

		}

		public async Task<IEnumerable<OfertaPostular>> GetAll()
		{
			return await _context.OfertaPostular.ToListAsync();
		}

		public async Task<OfertaPostular> GetById(int id)
		{
			return await _context.OfertaPostular.Where(x => x.IdOfertaPostular == id).FirstOrDefaultAsync();
		}

		public async Task<bool> Insert(OfertaPostular ofertapostular)
		{
			await _context.OfertaPostular.AddAsync(ofertapostular);
			int rows = await _context.SaveChangesAsync();
			return rows > 0;

		}

		public async Task<bool> Update(OfertaPostular ofertaPostular)
		{
			_context.OfertaPostular.Update(ofertaPostular);
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}


	}
}
