using commITM2.Models;
using Microsoft.AspNetCore.Mvc;

namespace commITM2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        // Arreglo en memoria simulando almacenamiento
        private static readonly List<Tarea> _tareas = new();
        private static int _nextId = 1;

        /// <summary>
        /// Obtiene todas las tareas.
        /// </summary>
        /// <returns>Lista de tareas.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Tarea>> GetAll()
        {
            return Ok(_tareas);
        }

        /// <summary>
        /// Obtiene una tarea por su ID.
        /// </summary>
        /// <param name="id">Id de la tarea.</param>
        /// <returns>Tarea encontrada.</returns>
        [HttpGet("{id}")]
        public ActionResult<Tarea> GetById(int id)
        {
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);
            if (tarea == null) return NotFound();
            return Ok(tarea);
        }

        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        /// <param name="tarea">Objeto tarea a crear.</param>
        /// <returns>Tarea creada.</returns>
        [HttpPost]
        public ActionResult<Tarea> Create(Tarea tarea)
        {
            tarea.Id = _nextId++;
            _tareas.Add(tarea);
            return CreatedAtAction(nameof(GetById), new { id = tarea.Id }, tarea);
        }

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="id">Id de la tarea a actualizar.</param>
        /// <param name="tarea">Objeto tarea con los nuevos valores.</param>
        /// <returns>Resultado de la actualización.</returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, Tarea tarea)
        {
            var existente = _tareas.FirstOrDefault(t => t.Id == id);
            if (existente == null) return NotFound();

            existente.Descripcion = tarea.Descripcion;
            existente.Completada = tarea.Completada;

            return NoContent();
        }

        /// <summary>
        /// Elimina una tarea por su ID.
        /// </summary>
        /// <param name="id">Id de la tarea a eliminar.</param>
        /// <returns>Resultado de la eliminación.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);
            if (tarea == null) return NotFound();

            _tareas.Remove(tarea);
            return NoContent();
        }
    }
}
