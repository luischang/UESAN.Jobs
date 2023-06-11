using UESAN.Jobs.Core.DTOs;

namespace UESAN.Jobs.Core.Interfaces
{
    public interface ICompetenciasService
    {
        Task<bool> delete(int id);
        Task<IEnumerable<CompetenciasDTO>> GetAll();
        Task<CompetenciasDTO> GetById(int id);
        Task<bool> Insert(CompetenciasInsertDTO competenciasInsert);
        Task<bool> Update(CompetenciasUpdateDTO competenciasUpdateDTO);
    }
}