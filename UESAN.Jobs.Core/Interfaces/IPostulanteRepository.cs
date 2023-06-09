using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Infrastructure.Repositories
{
	public interface IPostulanteRepository
	{
		Task<IEnumerable<Postulante>> GetAll();
		Task<Postulante> GetById(int id);
		Task<bool> Insert(Postulante postulante);
		Task<bool> update(Postulante postulante);
		
		Task<int> GetIdUsuario(int id);

		Task<bool> delete(int id);

	}
}