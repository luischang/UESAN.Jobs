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
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly BolsaDeTrabajoContext _context;

		public UsuarioRepository(BolsaDeTrabajoContext context)
		{
			_context = context;
		}

		public async Task<Usuario> SigIn( string username, string password) 
		{
			return await _context.Usuario.Where(x => x.Correo == username && x.Password == password).FirstOrDefaultAsync();
		
		}

		public async Task<IEnumerable<Usuario>> GetAll()
		{
			return await _context.Usuario.Where(x => x.Estado.Equals(1)).ToListAsync();

		}

		public async Task<Usuario> GetById(int id)
		{
			return await _context.Usuario.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();
		}

		public async Task<Usuario> GetId(string correo) 
		{
			return await _context.Usuario.Where(x => x.Correo == correo).FirstOrDefaultAsync();
		
		}

		public async Task<bool> InsertU(Usuario usuario)
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
				return false;
			}
			usu.Estado = false;
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<bool> IsEmailRegistered(string email)
		{
			return await _context
				.Usuario
				.Where(x => x.Correo == email).AnyAsync();
		}

		public async Task<bool> SignUp(Usuario user)
		{
			await _context.Usuario.AddAsync(user);
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}










	}
}
