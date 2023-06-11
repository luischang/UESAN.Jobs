using UESAN.Jobs.Core.DTOs;

namespace UESAN.Jobs.Core.Interfaces
{
    public interface ICompetenciasOfertaService
    {
        Task<bool> delete(int idCompetencia, int idOferta);
        Task<IEnumerable<CompetenciasOfertaDTO>> GetAll();
        Task<IEnumerable<CompetenciasOfertaDTO>> GetAllByIdOferta(int idofert);
        Task<bool> Insert(CompetenciasOfertasInsertDTO competenciasOfertasInsertDTO);
    }
}