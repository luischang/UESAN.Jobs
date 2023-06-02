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
	public class OfertaRepository
	{

		private readonly BolsaDeTrabajoContext _context;

		public OfertaRepository(BolsaDeTrabajoContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Oferta>> GetAll() 
		{
			return await _context.Oferta.ToListAsync();
		}

		public async Task <Oferta> GetById(int id) 
		{
			return await _context.Oferta.Where(x=> x.IdOferta == id).FirstOrDefaultAsync();
		}

		public async Task<bool > Insert(Oferta oferta) 
		{
			await _context.Oferta.AddAsync(oferta);
			int rows = await _context.SaveChangesAsync();
			return rows > 0;	
		}

		public async Task<bool> Update(Oferta oferta) 
		{
			_context.Oferta.Update(oferta);
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}
	}
}
