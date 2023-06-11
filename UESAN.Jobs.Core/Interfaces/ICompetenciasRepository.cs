using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Core.Interfaces
{
	public interface ICompetenciasRepository
	{
		Task<bool> delete(int id);
		Task<IEnumerable<Competencias>> GetAll();
		Task<Competencias> GetById(int id);
		Task<bool> Insert(Competencias competencias);
		Task<bool> update(Competencias competencias);
	}
}