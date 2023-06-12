using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Core.Interfaces
{
	public interface ICalificacionRespository
	{
		Task<bool> delete(int idPostulante, int idEmpresa);
		Task<IEnumerable<Calificaciones>> GetAll();
		Task<IEnumerable<Calificaciones>> GetAllByIdEmpresa(int idempresa);
		Task<bool> Insert(Calificaciones calificaiones);
	}
}