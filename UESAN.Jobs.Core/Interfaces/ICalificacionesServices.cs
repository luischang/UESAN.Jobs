using UESAN.Jobs.Core.DTOs;

namespace UESAN.Jobs.Core.Interfaces
{
    public interface ICalificacionesServices
    {
        Task<bool> delete(int idPostulante, int idEmpresa);
        Task<IEnumerable<CalificacionesDTO>> GetAll();
        Task<IEnumerable<CalificacionesDTO>> GetAllByIdEmpresa(int idEmpresa);
        Task<int> GetPormedioCalificacion(int idEmpresa);
        Task<bool> Insert(CalificacionesInsertDTO calificacionesInsertDTO);
    }
}