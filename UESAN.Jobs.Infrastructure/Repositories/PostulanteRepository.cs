﻿using Microsoft.EntityFrameworkCore;
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
	public class PostulanteRepository : IPostulanteRepository
	{
		private readonly BolsaDeTrabajoContext _context;

		public PostulanteRepository(BolsaDeTrabajoContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Postulante>> GetAll()
		{
			return await _context.Postulante
				.Where(x => x.IdUsuarioNavigation.Estado == true)
				.Include(z => z.IdUsuarioNavigation)
				.ToListAsync();
		}

		public async Task<Postulante> GetById(int id)
		{
			return await _context.Postulante
				.Where(y => y.IdPostulante == id && y.IdUsuarioNavigation.Estado == true)
				.Include(x => x.IdUsuarioNavigation)
				.FirstOrDefaultAsync();
		}

		public async Task<int> Insert(Postulante postulante)
		{
			await _context.Postulante.AddAsync(postulante);
			int rows = await _context.SaveChangesAsync();
			if (rows > 0) {
				return postulante.IdPostulante;
			}
			else
			{
				return 0;
			}
		}

		public async Task<bool> update(Postulante postulante)
		{
			 _context.Postulante.Update(postulante);
			int rows = _context.SaveChanges();
			return rows > 0;
		}

		public async Task<int> GetIdUsuario(int id)
		{
			int idU = 0;
			var postulante = await _context.Postulante.Where(x => x.IdPostulante == id).FirstOrDefaultAsync();
			idU = (int)postulante.IdUsuario + idU;
			return idU;
		}

		public async Task<bool> delete(int id)
		{
			var emp = await _context.Postulante.Where(x => x.IdPostulante == id).Include(c => c.IdUsuarioNavigation).FirstOrDefaultAsync();

			if (emp == null)
			{
				return false;
			}
			emp.IdUsuarioNavigation.Estado = false;
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<Postulante> getPostulanteByUsuario(int id)
		{
			return await _context.Postulante.Where(x => x.IdUsuario == id).Include(z => z.IdUsuarioNavigation).FirstOrDefaultAsync();
		}



	}
}
