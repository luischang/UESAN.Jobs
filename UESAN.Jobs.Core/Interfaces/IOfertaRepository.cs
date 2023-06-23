using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Core.Interfaces
{
	public interface IOfertaRepository
	{
		Task<IEnumerable<Oferta>> GetAll();
		Task<Oferta> GetById(int id);
		Task<int> Insert(Oferta oferta);
		Task<bool> Update(Oferta oferta);
		Task<bool> delete(int id);
		Task<IEnumerable<Oferta>> GetAllOfertasByEmpresa(int id);

		Task<bool> incrementPostulantes(Oferta o);
		Task<bool> DecrementarPostulantes(Oferta oferta);

		Task<IEnumerable<Oferta>> GetOfertasByUbicacionModalidad(string ubicacion);
		Task<IEnumerable<Oferta>> getOfertaByNombEmpresa(string nombre);

	}
}