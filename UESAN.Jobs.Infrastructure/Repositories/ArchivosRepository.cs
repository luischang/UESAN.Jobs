using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Entities;
using UESAN.Jobs.Core.Interfaces;
using UESAN.Jobs.Infrastructure.Models;

namespace UESAN.Jobs.Infrastructure.Repositories
{
	public class ArchivosRepository : IArchivosRepository
	{
		private readonly BolsaDeTrabajoContext _context;

		public ArchivosRepository(BolsaDeTrabajoContext context) { _context = context; }
		//esto retornara el cv del postulante
		public async Task<Archivos> GetCV(GetArchivosDTO getArchivosDTO)
		{
			return await _context.Archivos.Where(x => x.Estado == true &&
			x.IdPostulante == getArchivosDTO.IdPostulante && x.Tipo == "cv")
				.FirstOrDefaultAsync();
		}
		//Esto va a retornar todos los certificados del postulante
		public async Task<IEnumerable<Archivos>> GetNombresByPostulante(GetArchivosDTO getArchivosDTO)
		{
			return await _context.Archivos.Where(x => x.Estado == true
			&& x.IdPostulante == getArchivosDTO.IdPostulante
			&& x.Tipo == "certificados").ToListAsync();
		}
		//esto creara el registrara el nombre del archivo en la db :
		public async Task<bool> Insert(Archivos archivs)
		{
			await _context.Archivos.AddAsync(archivs);
			int fila = await _context.SaveChangesAsync();
			return fila > 0;

		}
		public async Task<bool> delete(string id)
		{
			var archivo = await _context.Archivos.Where(x => x.NombreArchivo == id).FirstOrDefaultAsync();

			if (archivo == null)
			{
				return false;
			}
			archivo.Estado = false;
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

	}
}
