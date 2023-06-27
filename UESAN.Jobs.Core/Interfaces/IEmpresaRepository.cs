using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Core.Interfaces
{
	public interface IEmpresaRepository
	{
		Task<IEnumerable<Empresa>> GetAll();
		Task<Empresa> GetById(int id);
		Task<Empresa> GetByIdUsuario(int id);
        Task<bool> InsertEmpresa(Empresa empresa);
		Task<bool> Update(Empresa empresa);
		Task<bool> delete(int id);
		Task<int> GetIdUsuario(int id);
		Task<Empresa> getEmpresaByUsuario(int id);
	}
}