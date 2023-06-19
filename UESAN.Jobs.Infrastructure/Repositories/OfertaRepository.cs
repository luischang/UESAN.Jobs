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
	public class OfertaRepository : IOfertaRepository
	{

		private readonly BolsaDeTrabajoContext _context;

		public OfertaRepository(BolsaDeTrabajoContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Oferta>> GetAll()
		{
			return await _context.Oferta.Where(x => x.Estado == true).Include(t => t.IdEmpresaNavigation).ToListAsync();
		}

		public async Task<Oferta> GetById(int id)
		{
			return await _context.Oferta.Where(x => x.IdOferta == id).Include(y => y.IdEmpresaNavigation).FirstOrDefaultAsync();
		}

		public async Task<int> Insert(Oferta oferta)
		{
			await _context.Oferta.AddAsync(oferta);
			int rows = await _context.SaveChangesAsync();
			if( rows > 0)
			{
				return oferta.IdOferta;
			}
			else
			{
				return 0;
			}
		}

		public async Task<bool> Update(Oferta oferta)
		{
			_context.Oferta.Update(oferta);
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<bool> delete(int id)
		{
			var oferta = await _context.Oferta.Where(x => x.IdOferta == id).FirstOrDefaultAsync();

			if (oferta == null)
			{
				return false;
			}
			oferta.Estado = false;
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<IEnumerable<Oferta>> GetAllOfertasByEmpresa(int id) //ofertas hechas por una empresa
		{
			var ofertas = await _context.Oferta.Where(x=> x.IdEmpresa == id && x.Estado == true).ToListAsync();
			if(ofertas.Any()) 
			{
				return ofertas;
			}
			return null;
		}

		public async Task<bool> incrementPostulantes(Oferta o)
		{
			o.NumeroPostulantes = o.NumeroPostulantes + 1;
			int rows =  await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<bool> DecrementarPostulantes(Oferta oferta)
		{
			oferta.NumeroPostulantes = oferta.NumeroPostulantes - 1;
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}
	}
}
