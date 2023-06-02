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
	public  class UsuarioRepository
	{
		private readonly BolsaDeTrabajoContext _context;

		public UsuarioRepository(BolsaDeTrabajoContext context) 
		{
			_context = context;
		}

		public async Task<IEnumerable<Usuario>> GetAll() 
		{
			return await _context.Usuario.Where(x=>x.Estado.Equals(1)).ToListAsync();

		}

		public async Task<Usuario> GetById( int id) 
		{
			return  await  _context.Usuario.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();
			
			
		}

		public async Task <bool> InsertU(Usuario usuario) 
		{
			await _context.AddAsync(usuario);
			int fila = await _context.SaveChangesAsync();
			return fila > 0;

		}

		public async Task<bool> update(Usuario usuario) 
		{
			_context.Usuario.Update(usuario);
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<bool> delete(int id) 
		{
			var usu = await _context.Usuario.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();

			if (usu == null)
			{
				return false;//si se elimino
			}
			usu.Estado = false;
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}





		



	}
}
