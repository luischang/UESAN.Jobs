using UESAN.Jobs.Core.DTOs;

namespace UESAN.Jobs.Core.Interfaces
{
    public interface ICompetenciasPostulanteService
    {
        Task<bool> delete(int idCompetencia, int idPostulante);
        Task<IEnumerable<CompetenciasPostulanteDTO>> GetAll();
        Task<IEnumerable<CompetenciasPostulanteDTO>> GetAllByIdPostulante(int idPos);
        Task<bool> Insert(CompetenciasPostulanteInsertDTO competenciasPostulanteInsertDTO);
    }
}