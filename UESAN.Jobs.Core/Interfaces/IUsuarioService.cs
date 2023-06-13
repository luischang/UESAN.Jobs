using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> register(UsuarioAuthRequestDTO usuDTO);
        Task<UsuarioAuthResponseDTO> validate(string correo, string contra);

        Task<Usuario> GetUsuCreateByCorreo(UsuarioAuthRequestDTO usuDTO);
        Task<bool> CreateAdmin(UsuarioPerfil usuDTO);

	}
}