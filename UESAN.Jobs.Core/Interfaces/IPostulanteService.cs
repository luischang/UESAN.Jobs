using UESAN.Jobs.Core.DTOs;

namespace UESAN.Jobs.Core.Interfaces
{
    public interface IPostulanteService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<PostulanteUsuarioDTO>> GetAll();
        Task<PostulanteUsuarioDTO> GetById(int id);
        Task<bool> Insert(PostulanteInsertDTO postulanteInsertDTO);
        Task<bool> Update(PostulanteUpdateDTO postulanteUpdateDTO);
	}
}