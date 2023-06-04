using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Infrastructure.Repositories
{
	public interface IUsuarioRepository
	{
		Task<bool> delete(int id);
		Task<IEnumerable<Usuario>> GetAll();
		Task<Usuario> GetById(int id);
		Task<bool> InsertU(Usuario usuario);
		Task<bool> update(Usuario usuario);
		Task<Usuario> GetId(string correo);

		Task<Usuario> SigIn(string username, string password);

		Task<bool> IsEmailRegistered(string email);

		Task<bool> SignUp(Usuario user);
	}
}