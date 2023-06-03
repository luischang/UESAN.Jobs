using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Infrastructure.Repositories
{
	public interface IEmpresaRepository
	{
		Task<IEnumerable<Empresa>> GetAll();
		Task<Empresa> GetById(int id);
		Task<bool> InsertEmpresa(Empresa empresa);
		Task<bool> Update(Empresa empresa);
		Task<bool> delete(int id);
	}
}