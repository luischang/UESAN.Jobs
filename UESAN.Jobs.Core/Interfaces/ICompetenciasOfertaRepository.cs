using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Core.Interfaces
{
	public interface ICompetenciasOfertaRepository
	{
		Task<bool> delete(int idCompi, int idOfert);
		Task<IEnumerable<CompetenciasOferta>> GetAll();
		Task<IEnumerable<CompetenciasOferta>> GetAllByIdOferta(int id);
		Task<bool> Insert(CompetenciasOferta competencias);
		Task<bool> update(CompetenciasOferta competenciasOferta);
	}
}