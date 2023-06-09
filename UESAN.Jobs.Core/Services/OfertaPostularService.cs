﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Entities;
using UESAN.Jobs.Core.Interfaces;

namespace UESAN.Jobs.Core.Services
{
	public class OfertaPostularService : IOfertaPostularService
	{
		private readonly IOfertaPostularRepository _ofertaPostularRepository;
		private readonly IOfertaRepository _ofertaRepository;
		private readonly IPostulanteRepository _postulanteRepository;

		public OfertaPostularService(IOfertaPostularRepository ofertaPostularRepository, IOfertaRepository ofertaRepository, IPostulanteRepository postulanteRepository)
		{
			_ofertaPostularRepository = ofertaPostularRepository;
			_ofertaRepository = ofertaRepository;
			_postulanteRepository = postulanteRepository;
		}

		public async Task<IEnumerable<OfertaPostularOfertaDTO>> GetAll()
		{
			var ofertasPostuladas = await _ofertaPostularRepository.GetAll();

			var ofertaDTO = ofertasPostuladas.Select(e => new OfertaPostularOfertaDTO
			{
				IdOfertaPostular = e.IdOfertaPostular,
				Fecha = e.Fecha,
				Estado = e.Estado,
				Oferta = new OfertaDescDTO
				{
					IdOferta = e.IdOfertaNavigation.IdOferta,
					Descripcion = e.IdOfertaNavigation.Descripcion
					
				},
				Postulante = new PostulanteDescripcionDTO
				{
					IdPostulante = (int)e.IdPostulante,
					Nombre = e.IdPostulanteNavigation.Nombre,
				}
				
			});
			return ofertaDTO;

		}

		public async Task<OfertaPostularOfertaDTO> GetById(int id)
		{
			var ofertaP = await _ofertaPostularRepository.GetById(id);
			if (ofertaP == null)
				return null;
			var ofertaDTO = new OfertaPostularOfertaDTO()
			{
				IdOfertaPostular = ofertaP.IdOfertaPostular,
				Fecha = ofertaP.Fecha,
				Estado = ofertaP.Estado,
				Oferta = new OfertaDescDTO
				{
					IdOferta = ofertaP.IdOfertaNavigation.IdOferta,
					Descripcion = ofertaP.IdOfertaNavigation.Descripcion
				},
				Postulante = new PostulanteDescripcionDTO
				{
					IdPostulante = (int)ofertaP.IdPostulante,
					Nombre = ofertaP.IdPostulanteNavigation.Nombre,
					
				}

			};
			return ofertaDTO;
		}

		public async Task<IEnumerable<OfertaPostularPostulanteDTO>> GetAllPostulanteByIdOferta(int idoferta) 
		{
			var ofertasP = await _ofertaPostularRepository.GetAllPostulantesByIdOferta(idoferta);
			if (ofertasP!=null)
			{
				var oppDTO = ofertasP.Select(x => new OfertaPostularPostulanteDTO
				{
					
					IdOfertaPostular = x.IdOfertaPostular,
					PostulanteDescripcion = new PostulanteDescripcionDTO
					{
						IdPostulante = x.IdPostulanteNavigation.IdPostulante,
						Nombre = x.IdPostulanteNavigation.Nombre,
					}
				});
				return oppDTO;
			}
			return null;
			
		}

		public async Task<IEnumerable<OfertaPostularOfertaDTO>> GetAllOfertasByIdPostulante(int idpos) 
		{
			var ofertasPostuladas = await _ofertaPostularRepository.GetAllOfertasByIdPostulante(idpos);
			if(ofertasPostuladas != null) 
			{
				var ofertaDTO = ofertasPostuladas.Select(e => new OfertaPostularOfertaDTO
				{
					IdOfertaPostular = e.IdOfertaPostular,
					Fecha = e.Fecha,
					Estado = e.Estado,
					
					Oferta = new OfertaDescDTO
					{
						IdOferta = e.IdOfertaNavigation.IdOferta,
						Descripcion = e.IdOfertaNavigation.Descripcion
						
					},
					Postulante = new PostulanteDescripcionDTO
					{
						IdPostulante = (int)e.IdPostulante,
						Nombre = e.IdPostulanteNavigation.Nombre,
						
				
					}

				});;
				return ofertaDTO;
			}
			return null;
		}

		public async Task<bool> Update(OfertaPostularUpdateDTO ofertaPostularUpdateDTO)
		{

			var ofertaP = new OfertaPostular()
			{
				IdOferta = ofertaPostularUpdateDTO.IdOferta,
				IdPostulante = ofertaPostularUpdateDTO.IdPostulante,
				IdOfertaPostular = ofertaPostularUpdateDTO.IdOfertaPostular,
				Estado = ofertaPostularUpdateDTO.Estado,
				Fecha = ofertaPostularUpdateDTO.Fecha
			};
			return await _ofertaPostularRepository.Update(ofertaP);
		}

		public async Task<bool> Delete(int id)
		{
			var ofertaPostular = await _ofertaPostularRepository.GetById(id);
			//Traigo la oferta:
			var oferta = await _ofertaRepository.GetById((int)ofertaPostular.IdOferta);
			//Disminuyo el numero de postulantes:
			if(ofertaPostular != null && oferta != null)
			{
				var disminucion = await _ofertaRepository.DecrementarPostulantes(oferta);

				return await _ofertaPostularRepository.delete(id) && disminucion;
			}
			return false;

		}

		public async Task<bool> Insert(OfertaPostularInsertDTO ofertaPostularInsertDTO)
		{
			var ofertaE = await _ofertaRepository
				.GetById(ofertaPostularInsertDTO.Oferta.IdOferta);  

			var postulanteE = await _postulanteRepository
				.GetById(ofertaPostularInsertDTO.Postulante.IdPostulante);
			//valido que el postulante no haga la postulacion a la misma oferta dos veces:
			var ofertasPostulares = await _ofertaPostularRepository.GetAllPostulantesByIdOferta(ofertaE.IdOferta);
			bool apto = true;
			if(postulanteE != null && ofertasPostulares != null)
			{
				foreach (var item in ofertasPostulares)
				{
					if (item.IdPostulante == postulanteE.IdPostulante)
					{
						apto = false;
						break;
					}
				}
			}
			//si el postulante no esta registrado en esta oferta, se procede a crear la oferta postular
            if (ofertaE != null && postulanteE != null && apto)
			{

				var ofertaPostular = new OfertaPostular()
				{
					IdPostulante = postulanteE.IdPostulante,
					IdOferta = ofertaE.IdOferta,
					Fecha = ofertaPostularInsertDTO.Fecha,
					Estado = true,
				};
				var insertarOfertaPostular =  await _ofertaPostularRepository.Insert(ofertaPostular);
				//modifico la oferta para registrar un nuevo postulante  en ella
				var updateOferta = await _ofertaRepository.incrementPostulantes(ofertaE); 
				return insertarOfertaPostular && updateOferta;
			}
			return false;
		}

	}
}
