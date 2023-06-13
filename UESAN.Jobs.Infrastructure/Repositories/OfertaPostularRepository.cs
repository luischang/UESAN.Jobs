using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Jobs.Core.Entities;
using UESAN.Jobs.Core.Interfaces;
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
			return await _context.OfertaPostular
				.Where(x => x.Estado == true)
				.Include(y => y.IdOfertaNavigation)
				.Include(z => z.IdPostulanteNavigation)
				.ToListAsync();
		}

		public async Task<OfertaPostular> GetById(int id)
		{
			return await _context.OfertaPostular
				.Where(x => x.IdOfertaPostular == id && x.Estado == true)
				.Include(y => y.IdOfertaNavigation)
				.Include(z => z.IdPostulanteNavigation)
				.FirstOrDefaultAsync();
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

		public async Task<bool> delete(int id)
		{
			var ofertaPostular = await _context.OfertaPostular.Where(x => x.IdOfertaPostular == id).FirstOrDefaultAsync();

			if (ofertaPostular == null)
			{
				return false;
			}
			ofertaPostular.Estado = false;
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<IEnumerable<OfertaPostular>> GetAllPostulantesByIdOferta(int idoferta) 
		{
			var ofertasPOs =  await _context.OfertaPostular
				.Where(x => x.IdOfertaNavigation.IdOferta == idoferta && x.Estado == true 
				&& x.IdOfertaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Estado == true
				&& x.IdOfertaNavigation.Estado == true)
				.Include(z=>z.IdPostulanteNavigation).Include(s => s.IdOfertaNavigation)
				.ToListAsync();

			if (ofertasPOs.Any())
			{
				return ofertasPOs;
			}
			return null;
		}

		public async Task<IEnumerable<OfertaPostular>> GetAllOfertasByIdPostulante(int idpostulante)
		{
			var ofertas = await _context.OfertaPostular.Where(x=> x.IdPostulanteNavigation.IdPostulante == idpostulante && x.Estado == true 
			&& x.IdPostulanteNavigation.IdUsuarioNavigation.Estado == true)
				.Include(z=> z.IdOfertaNavigation).Include(s=> s.IdPostulanteNavigation) .ToListAsync();
			if (ofertas.Any())
			{
				return ofertas;
			}
			return null;
		}


	}
}
