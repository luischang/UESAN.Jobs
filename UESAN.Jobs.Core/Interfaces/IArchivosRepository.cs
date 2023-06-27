using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Core.Interfaces
{
	public interface IArchivosRepository
	{
		Task<bool> delete(string id);
		Task<Archivos> GetCV(GetArchivosDTO getArchivosDTO);
		Task<IEnumerable<Archivos>> GetNombresByPostulante(GetArchivosDTO getArchivosDTO);
		Task<bool> Insert(Archivos archivs);
	}
}