using Microsoft.EntityFrameworkCore;
using Application.Interface;
using Application.Main;
using Data.Agencia;
using Data.AgenciaDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AgenciaAutomoviles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly AgenciaContext _context;

        public FormController(AgenciaContext context)
        {
            _context = context;
        }
        [HttpGet("GetAutenticacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string usuario,string contrasena)
        {
            var result = await (from u in _context.Usuarios
                                join r in _context.Roles on u.RolID equals r.Id
                                where u.Users == usuario && u.Contraseña == contrasena
                                select new
                                {
                                    UsuarioID = u.Id,
                                    Users = u.Users,
                                    Contraseña = u.Contraseña,
                                    Email = u.Email,
                                    RolID = u.RolID,
                                    Rol=r.Nombre
                                }).ToListAsync();

            if (!result.Any())
                return NotFound();

            return Ok(result);

        }
        [HttpGet("GetVehiculos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get1()
        {
            var result = await (from v in _context.Vehiculos
                                join s in _context.Servicios on v.Id equals s.VehiculoID
                                join sr in _context.ServicioRefacciones on s.Id equals sr.Id
                                join r in _context.Refacciones on sr.RefaccionID equals r.Id
                                select new
                                {
                                   Folio=s.Folio,
                                   Marca=v.Marca,
                                  Modelo= v.Modelo,
                                   Ano = v.Año,
                                   Dueno = v.Dueño,
                                   ProximoServicio = v.ProximoServicio,
                                   FechaServicio = s.Fecha,
                                   Estatus = s.Estatus,
                                   Cantidad = sr.Cantidad,
                                   Nombre = r.Nombre,
                                   Descripcion = r.Descripcion,
                                   Precio = r.Precio,
                                   
                                }).ToListAsync();

            if (!result.Any())
                return NotFound();

            return Ok(result);

        }
        [HttpGet("GetUltimo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get2()
        {
            var result = await (from v in _context.Vehiculos
                                join s in _context.Servicios on v.Id equals s.VehiculoID
                                join sr in _context.ServicioRefacciones on s.Id equals sr.Id
                                join r in _context.Refacciones on sr.RefaccionID equals r.Id
                                select new
                                {
                                    Folio = s.Folio,
                                    Marca = v.Marca,
                                    Modelo = v.Modelo,
                                    Ano = v.Año,
                                    Dueno = v.Dueño,
                                    ProximoServicio = v.ProximoServicio,
                                    FechaServicio = s.Fecha,
                                    Estatus = s.Estatus,
                                    Cantidad = sr.Cantidad,
                                    Nombre = r.Nombre,
                                    Descripcion = r.Descripcion,
                                    Precio = r.Precio,
                                }).OrderBy(x => x.Folio).LastOrDefaultAsync();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //[HttpGet("GetARO/{ARO}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> Get(int ARO)
        //{
        //    var result = await (from f in _context.Formularios
        //                        join o in _context.Operacions on f.OperacionId equals o.Id
        //                        join e in _context.Equipos on o.EquipoId equals e.Id
        //                        join p in _context.Pools on e.PoolId equals p.Id
        //                        join a in _context.Areas on p.AreaId equals a.Id
        //                        join rfi in _context.RiesgoFormularioItems on f.Id equals rfi.FormularioId
        //                        join pel in _context.Peligros on rfi.PeligroId equals pel.Id
        //                        join cpel in _context.ClasificacionPeligros on pel.ClasificacionPeligroId equals cpel.Id
        //                        join prob in _context.Probabilidads on rfi.ProbabilidadId equals prob.Id
        //                        join s in _context.Severidads on rfi.SeveridadId equals s.Id
        //                        join n in _context.NivelRiesgos on rfi.NivelRiesgoId equals n.Id
        //                        where f.Id == ARO
        //                        select new
        //                        {
        //                            UserName = f.UserName,
        //                            Fecha = f.Fecha,
        //                            Operaciones = o.Nombre,
        //                            Equipo = e.Nombre,
        //                            Pool = p.Nombre,
        //                            Area = a.Nombre,
        //                            Riesgos = cpel.Siglas + " | " + pel.Nombre,
        //                            Peligro = pel.Nombre,
        //                            DescripcionRiesgo = rfi.DescripcionRiesgo,
        //                            PasoSWI = rfi.PasoSwi,
        //                            DescripcionPaso = rfi.DescripcionPaso,
        //                            MedidaControlActual = rfi.MedidaControlActual,
        //                            TipoControl = rfi.TipoControl,
        //                            ProbabilidadId = rfi.ProbabilidadId,
        //                            Probabilidad = prob.Nombre,
        //                            SeveridadId = rfi.SeveridadId,
        //                            Severidad = s.Nombre,
        //                            NivelRiesgo = n.Nombre,
        //                            ColorRiesgo = n.Color,
        //                            Evidencia = rfi.Evidencia
        //                        }).ToListAsync();


        //    if (result == null)
        //        return NotFound();

        //    return Ok(result);

        //}
        //[HttpGet("GetFirmas/{Firmas}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> Get4(int Firmas)
        //{
        //    var result = await (from firmaOfi in _context.FirmaOperadorFormularios
        //                        where firmaOfi.FormularioId == Firmas
        //                        select new
        //                        {
        //                            Firma = firmaOfi.NombreUsuario,
        //                            FechaSTR = firmaOfi.FechaStr

        //                        }).ToListAsync();
        //    var result2 = await (from firma in _context.FirmaFormularios
        //                         where firma.FormularioId == Firmas
        //                         select new
        //                         {
        //                             Firma = firma.NombreUsuario,
        //                             FechaSTR = firma.FechaStr

        //                         }).ToListAsync();

        //    if (result == null || result2 == null)
        //        return NotFound();

        //    var combinedResult = new
        //    {
        //        FirmaOperador = result,
        //        FirmaAprobador = result2
        //    };

        //    return Ok(combinedResult);
        //}
    }
}