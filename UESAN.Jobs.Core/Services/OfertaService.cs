using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Entities;
using UESAN.Jobs.Core.Interfaces;

namespace UESAN.Jobs.Core.Services
{
	public class OfertaService : IOfertaService
	{
		private readonly IOfertaRepository _ofertaRepository;
		private readonly IEmpresaRepository _empresaRepository;

		public OfertaService(IOfertaRepository ofertaRepository, IEmpresaRepository empresaRepository)
		{
			_ofertaRepository = ofertaRepository;
			_empresaRepository = empresaRepository;
		}

		public async Task<IEnumerable<OfertaEmpresaDTO>> GetAll()
		{
			var ofertas = await _ofertaRepository.GetAll();

			var ofertaDTO = ofertas.Select(e => new OfertaEmpresaDTO
			{
				IdOferta = e.IdOferta,
				Certificados = e.Certificados,
				Descripcion = e.Descripcion,
				Estado = e.Estado,
				FechaCreacion = e.FechaCreacion,
				Funciones = e.Funciones,
				Modalidad = e.Modalidad,
				Puesto = e.Puesto,
				Requisitos = e.Requisitos,
				Ubicacion = e.Ubicacion,
				Empresa = new EmpresaDescDTO()
				{
					IdEmpresa = e.IdEmpresaNavigation.IdEmpresa,
					Nombre = e.IdEmpresaNavigation.Nombre
				}

			});
			return ofertaDTO;

		}

		public async Task<OfertaEmpresaDTO> GetById(int id)
		{
			var oferta = await _ofertaRepository.GetById(id);
			if (oferta == null)
				return null;
			var ofertaDTO = new OfertaEmpresaDTO()
			{
				IdOferta = oferta.IdOferta,
				Descripcion = oferta.Descripcion,
				Funciones = oferta.Funciones,
				Modalidad = oferta.Modalidad,
				Certificados = oferta.Certificados,
				Estado = oferta.Estado,
				FechaCreacion = oferta.FechaCreacion,
				Puesto = oferta.Puesto,
				Requisitos = oferta.Requisitos,
				Ubicacion = oferta.Ubicacion,

				Empresa = new EmpresaDescDTO()
				{
					IdEmpresa = oferta.IdEmpresaNavigation.IdEmpresa,
					Nombre = oferta.IdEmpresaNavigation.Nombre
				}

			};
			return ofertaDTO;
		}

		public async Task<bool> Update(OfertaUpdateDTO ofertaUpdate)
		{


			var oferta = new Oferta()
			{
				IdEmpresa = ofertaUpdate.IdEmpresa,
				IdOferta = ofertaUpdate.IdOferta,
				Descripcion = ofertaUpdate.Descripcion,
				Funciones = ofertaUpdate.Funciones,
				Modalidad = ofertaUpdate.Modalidad,
				Certificados = ofertaUpdate.Certificados,
				Estado = ofertaUpdate.Estado,
				FechaCreacion = ofertaUpdate.FechaCreacion,
				Puesto = ofertaUpdate.Puesto,
				Requisitos = ofertaUpdate.Requisitos,
				Ubicacion = ofertaUpdate.Ubicacion,
			};
			return await _ofertaRepository.Update(oferta);
		}

		public async Task<bool> Delete(int id)
		{
			var idUsuario = await _ofertaRepository.GetById(id);
			return await _ofertaRepository.delete(id);
		}

		public async Task<bool> Insert(OfertaInsert ofertaInsert)
		{
			var emp = new EmpresaOfertaInsertDTO()
			{
				IdEmpresa = ofertaInsert.Empresa.IdEmpresa,
				Nombre = ofertaInsert.Empresa.Nombre,
			};

			var empresaId = await _empresaRepository.GetById(emp.IdEmpresa);

			if (empresaId!= null )
			{

				var oferta = new Oferta()
				{
					IdEmpresa = empresaId.IdEmpresa,
					Descripcion = ofertaInsert.Descripcion,
					Funciones = ofertaInsert.Funciones,
					Modalidad = ofertaInsert.Modalidad,
					Certificados = ofertaInsert.Certificados,
					FechaCreacion = ofertaInsert.FechaCreacion,
					Estado = true,
					Puesto = ofertaInsert.Puesto,
					Requisitos = ofertaInsert.Requisitos,
					Ubicacion = ofertaInsert.Ubicacion,

				};
				return await _ofertaRepository.Insert(oferta);

			}
			return false;
		}


	}
}
