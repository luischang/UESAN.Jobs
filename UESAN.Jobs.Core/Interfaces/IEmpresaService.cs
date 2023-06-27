using UESAN.Jobs.Core.DTOs;

namespace UESAN.Jobs.Core.Interfaces
{
    public interface IEmpresaService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<EmpresaUsuarioDTO>> GetAll();
        Task<EmpresaUsuarioDTO> GetById(int id);
        Task<EmpresaUsuarioDTO> GetByIdUsuario(int id);
        Task<bool> Insert(EmpresaInsertDTO empresaInsertDTO);
        Task<bool> Update(EmpresaUpdateDTO empresaDTO);

	}
}