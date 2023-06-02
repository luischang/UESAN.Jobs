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
	public class EmpresaRepository
	{
		private readonly BolsaDeTrabajoContext _context;

		public EmpresaRepository(BolsaDeTrabajoContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Empresa>> GetAll() 
		{
			return await _context.Empresa.ToListAsync();
		}

		public async Task<Empresa> GetById(int id) 
		{
			return await _context.Empresa.Where(x => x.IdEmpresa == id).FirstOrDefaultAsync();
		
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


		



	}
}
