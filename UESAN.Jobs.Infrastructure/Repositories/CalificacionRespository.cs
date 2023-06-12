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
	public class CalificacionRespository : ICalificacionRespository
	{

		private readonly BolsaDeTrabajoContext _context;

		public CalificacionRespository(BolsaDeTrabajoContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Calificaciones>> GetAll()
		{
			return await _context.Calificaciones.Where(x => x.Estado == true)
				.Include(z => z.IdEmpresaNavigation)
				.Include(y => y.IdPostulanteNavigation)
				.ToListAsync();
		}

		public async Task<IEnumerable<Calificaciones>> GetAllByIdEmpresa(int idempresa)
		{
			return await _context.Calificaciones.Where(x => x.Estado == true && x.IdEmpresa == idempresa)
				.Include(z => z.IdEmpresaNavigation)
				.Include(y => y.IdPostulanteNavigation)
				.ToListAsync();
		}

		public async Task<bool> Insert(Calificaciones calificaiones)
		{
			await _context.Calificaciones.AddAsync(calificaiones);
			var rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<bool> delete(int idPostulante, int idEmpresa)
		{
			var calificacion = await _context.Calificaciones
				.Where(x => x.IdEmpresa == idEmpresa && x.IdPostulante == idPostulante)
				.FirstOrDefaultAsync();
			if (calificacion == null) { return false; }
			calificacion.Estado = false;
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}
	}
}
