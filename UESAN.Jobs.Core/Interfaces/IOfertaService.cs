﻿using UESAN.Jobs.Core.DTOs;

namespace UESAN.Jobs.Core.Interfaces
{
    public interface IOfertaService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<OfertaEmpresaDTO>> GetAll();
        Task<OfertaEmpresaDTO> GetById(int id);
        Task<bool> Update(OfertaUpdateDTO ofertaUpdate);
        Task<bool> Insert(OfertaInsert ofertaInsert);

	}
}