using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Core.Interfaces
{
	public interface IOfertaRepository
	{
		Task<IEnumerable<Oferta>> GetAll();
		Task<Oferta> GetById(int id);
		Task<bool> Insert(Oferta oferta);
		Task<bool> Update(Oferta oferta);
		Task<bool> delete(int id);
	}
}