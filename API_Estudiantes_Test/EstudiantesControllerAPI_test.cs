using ControlEscolarCore.Controller;
using Microsoft.AspNetCore.Mvc;

namespace API_Estudiantes_Test
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesControllerAPI_test : ControllerBase
    {
        private readonly EstudiantesController _estudiantesController;
        private readonly ILogger<EstudiantesControllerAPI_test> _logger;

        //Este log no se guarda en ningun archivo, se muestra en la consola o terminal durante su ejecución
        //Nos funcionara mucho para ver si el controlador se esta ejecutando correctamente en la consola de RENDER
        public EstudiantesControllerAPI_test(EstudiantesController estudiantesController, ILogger<EstudiantesControllerAPI_test> logger)
        {
            _estudiantesController = estudiantesController;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los estudiantes con filtros opcionales
        /// </summary>
        /// <param name="soloActivos">Filtrar solo estudiantes activos</param>
        /// <param name="tipoFecha">1=Fecha nacimiento, 2=Fecha alta, 3=Fecha baja</param>
        /// <param name="fechaInicio">Fecha inicial del rango</param>
        /// <param name="fechaFin">Fecha final del rango</param>
        /// <returns>Lista de estudiantes</returns>
        [HttpGet("list_estudiantes")]  // Ahora tiene una ruta específica
        public IActionResult GetEstudiantes(
             [FromQuery] bool soloActivos = true,
             [FromQuery] int tipoFecha = 0,
             [FromQuery] DateTime? fechaInicio = null,
             [FromQuery] DateTime? fechaFin = null)
        {
            try
            {
                var estudiantes = _estudiantesController.ObtenerEstudiantes(
                    soloActivos,
                    tipoFecha,
                    fechaInicio,
                    fechaFin);

                return Ok(estudiantes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener estudiantes");
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }
    }
}
