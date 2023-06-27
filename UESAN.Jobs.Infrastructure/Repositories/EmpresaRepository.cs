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
	public class EmpresaRepository : IEmpresaRepository
	{
		private readonly BolsaDeTrabajoContext _context;

		public EmpresaRepository(BolsaDeTrabajoContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Empresa>> GetAll()
		{
			return await _context.Empresa
				.Where(x=> x.IdEmpresa > 0 && x.IdUsuarioNavigation.Estado == true)
				.Include(z => z.IdUsuarioNavigation)
				.ToListAsync();
		}

		public async Task<Empresa> GetById(int id)
		{
			return await _context.Empresa
				.Where(x => x.IdEmpresa == id && x.IdUsuarioNavigation.Estado == true)
				.Include(z =>z.IdUsuarioNavigation)
				.FirstOrDefaultAsync();

		}

		public async Task<bool> InsertEmpresa(Empresa empresa)
		{
			await _context.Empresa.AddAsync(empresa);
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<bool> Update(Empresa empresa)
		{
			_context.Empresa.Update(empresa);
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<bool> delete(int id)
		{
			var emp = await _context.Empresa.Where(x => x.IdEmpresa == id).Include(c=>c.IdUsuarioNavigation).FirstOrDefaultAsync();

			if (emp == null)
			{
				return false;
			}
			emp.IdUsuarioNavigation.Estado = false;
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<int> GetIdUsuario(int id)
		{
			int idU = 0;
			var empresa = await _context.Empresa.Where(x=> x.IdEmpresa==id).FirstOrDefaultAsync();
			idU = (int)empresa.IdUsuario + idU;
			return idU;
		}

	}
}
