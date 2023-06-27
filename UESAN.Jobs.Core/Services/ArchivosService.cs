using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Entities;
using UESAN.Jobs.Core.Interfaces;

namespace UESAN.Jobs.Core.Services
{
    public class ArchivosService : IArchivosService
	{
		private readonly IArchivosRepository _archivosRepository;

		public ArchivosService(IArchivosRepository archivosRepository)
		{
			_archivosRepository = archivosRepository;
		}

		public async Task<bool> Insert(InsertArchivosDTO insertArchivosDTO)
		{
			var archi = new Archivos
			{
				IdPostulante = insertArchivosDTO.IdPostulante,
				NombreArchivo = insertArchivosDTO.NombreArchivo,
				Estado = true,
				Tipo = insertArchivosDTO.Tipo,
			};

			return await _archivosRepository.Insert(archi);

		}
		//retorna el conjunto de nombres de certificados de un postulante
		public async Task<IEnumerable<NombresArchivosDTO>> GetNombresCertificados(GetArchivosDTO getArchivosDTO)
		{
			var archivos = await _archivosRepository.GetNombresByPostulante(getArchivosDTO);
			if (archivos.Count() > 0)
			{
				var nom = archivos.Select(e => new NombresArchivosDTO
				{
					NombreArchivo = e.NombreArchivo,
				});

				return nom;
			}
			return null;
		}
		//retorna el nombre del archivo cv del postulante
		public async Task<NombresArchivosDTO> GetNombreCV(GetArchivosDTO getArchivosDTO)
		{
			var archivo = await _archivosRepository.GetCV(getArchivosDTO);

			if (archivo != null)
			{
				var nom = new NombresArchivosDTO
				{
					NombreArchivo = archivo.NombreArchivo,
				};

				return nom;
			}

			return null;
		}

		public async Task<bool> delete(string nom)
		{
			return await _archivosRepository.delete(nom);
		}


	}
}
