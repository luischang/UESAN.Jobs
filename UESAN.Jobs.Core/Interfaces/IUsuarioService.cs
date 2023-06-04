using UESAN.Jobs.Core.DTOs;

namespace UESAN.Jobs.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> register(UsuarioAuthRequestDTO usuDTO, string tipo);
        Task<UsuarioAuthResponseDTO> validate(string correo, string contra);
    }
}