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
	public class PostulanteRepository : IPostulanteRepository
	{
		private readonly BolsaDeTrabajoContext _context;

		public PostulanteRepository(BolsaDeTrabajoContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Postulante>> GetAll()
		{
			return await _context.Postulante.ToListAsync();
		}

		public async Task<Postulante> GetById(int id)
		{
			return await _context.Postulante.Where(y => y.IdPostulante == id).FirstOrDefaultAsync();
		}

		public async Task<bool> Insert(Postulante postulante)
		{
			await _context.Postulante.AddAsync(postulante);
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<bool> update(Postulante postulante)
		{
			_context.Postulante.Update(postulante);
			int rows = _context.SaveChanges();
			return rows > 0;
		}


	}
}
