using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Infrastructure.Repositories
{
	public interface IOfertaRepository
	{
		Task<IEnumerable<Oferta>> GetAll();
		Task<Oferta> GetById(int id);
		Task<bool> Insert(Oferta oferta);
		Task<bool> Update(Oferta oferta);
	}
}