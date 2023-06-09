﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;
using UESAN.Jobs.Core.DTOs;
using UESAN.Jobs.Core.Interfaces;
using UESAN.Jobs.Core.Services;
using System.IO.Compression;

namespace UESAN.Jobs.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArchivosController : ControllerBase
	{
		private readonly IArchivosService _services;

		public ArchivosController(IArchivosService services)
		{
			_services = services;
		}

		[HttpPost]
		public async Task<IActionResult> Insert([FromForm] GenerarArchivoDTO generarArchivo, IFormFile file)
		{
			try
			{
				if (file == null || file.Length == 0)
					return BadRequest(" No se proporcionó ningún archivo.");
				// Ruta de la carpeta donde se guardarán los archivos
				var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "files");
				// Si la carpeta no existe, se crea
				if (!Directory.Exists(folderPath))
					Directory.CreateDirectory(folderPath);
				// Generar un nombre único para el archivo
				var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
				// Ruta completa del archivo
				var filePath = Path.Combine(folderPath, fileName);
				// Copiar el archivo al servidor
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
				var archivo = new InsertArchivosDTO
				{
					NombreArchivo = fileName,
					IdPostulante = generarArchivo.IdPostulante,
					Tipo = generarArchivo.Tipo
				};

				var result = await _services.Insert(archivo);
				if (!result)
					return BadRequest(result);

				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		

		[HttpPost("mostrarCertificados")]
		public async Task<IActionResult> MostrarArchivos([FromBody] GetArchivosDTO archi)
		{
			var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "files");
			var nombresArchivos = await _services.GetNombresCertificados(archi);

			var zipMemoryStream = new MemoryStream();

			using (var zipArchive = new ZipArchive(zipMemoryStream, ZipArchiveMode.Create, true))
			{
				foreach (var nombreArchivo in nombresArchivos)
				{
					var filePath = Path.Combine(folderPath, nombreArchivo.NombreArchivo);

					if (System.IO.File.Exists(filePath))
					{
						var entryName = Path.GetFileName(filePath);
						zipArchive.CreateEntryFromFile(filePath, entryName);
					}
				}
			}

			zipMemoryStream.Seek(0, SeekOrigin.Begin);
			return File(zipMemoryStream, "application/zip", "certificados.zip");
		}




		[HttpDelete]
		public async Task<IActionResult> Delete(string nom)
		{
			var result = await _services.delete(nom);
			if (!result)
				return NotFound();
			return Ok(result);
		}

		[HttpPost("mostrarCV")]
		public async Task<IActionResult> MostrarCV(GetArchivosDTO archi)
		{
			var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "files");
			var nombresArchivos = await _services.GetNombreCV(archi);

				var filePath = Path.Combine(folderPath, nombresArchivos.NombreArchivo);
				var nombreArchivo = nombresArchivos.NombreArchivo;
				if (System.IO.File.Exists(filePath))
				{
					var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
					return File(fileStream, "application/octet-stream", nombreArchivo);
				}
			

			// En caso de que no se encuentre el archivo
			return NotFound();
		}





	}
}
