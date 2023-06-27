using UESAN.Jobs.Core.DTOs;

namespace UESAN.Jobs.Core.Interfaces
{
    public interface IArchivosService
    {
        Task<bool> delete(string nom);
        Task<NombresArchivosDTO> GetNombreCV(GetArchivosDTO getArchivosDTO);
        Task<IEnumerable<NombresArchivosDTO>> GetNombresCertificados(GetArchivosDTO getArchivosDTO);
        Task<bool> Insert(InsertArchivosDTO insertArchivosDTO);
    }
}