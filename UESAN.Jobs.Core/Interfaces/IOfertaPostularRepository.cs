using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Infrastructure.Repositories
{
	public interface IOfertaPostularRepository
	{
		Task<IEnumerable<OfertaPostular>> GetAll();
		Task<OfertaPostular> GetById(int id);
		Task<bool> Insert(OfertaPostular ofertapostular);
		Task<bool> Update(OfertaPostular ofertaPostular);
		Task<bool> delete(int id);
	}
}