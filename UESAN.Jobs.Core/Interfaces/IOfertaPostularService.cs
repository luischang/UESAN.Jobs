using UESAN.Jobs.Core.DTOs;

namespace UESAN.Jobs.Core.Interfaces
{
    public interface IOfertaPostularService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<OfertaPostularOfertaDTO>> GetAll();
        Task<OfertaPostularOfertaDTO> GetById(int id);
        Task<bool> Insert(OfertaPostularInsertDTO ofertaPostularInsertDTO);
        Task<bool> Update(OfertaPostularUpdateDTO ofertaPostularUpdateDTO);

        Task<IEnumerable<OfertaPostularPostulanteDTO>> GetAllPostulanteByIdOferta(int idoferta);

	}
}