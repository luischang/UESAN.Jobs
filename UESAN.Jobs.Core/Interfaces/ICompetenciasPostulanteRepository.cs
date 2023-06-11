using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Core.Interfaces
{
	public interface ICompetenciasPostulanteRepository
	{
		Task<bool> delete(int idCompi, int idPostulante);
		Task<IEnumerable<CompetenciasPostulante>> GetAll();
		Task<IEnumerable<CompetenciasPostulante>> GetAllByIdPostulante(int id);
		Task<bool> Insert(CompetenciasPostulante competencias);
		Task<bool> update(CompetenciasPostulante competenciasPostulante);
	}
}