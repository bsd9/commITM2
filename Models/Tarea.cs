namespace commITM2.Models
{
    /// <summary>
    /// Representa una tarea.
    /// </summary>
    public class Tarea
    {
        /// <summary>
        /// Identificador único de la tarea.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descripción de la tarea.
        /// </summary>
        public string Descripcion { get; set; } = string.Empty;

        /// <summary>
        /// Indica si la tarea está completada.
        /// </summary>
        public bool Completada { get; set; }
    }
}
