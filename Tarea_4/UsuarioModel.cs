
namespace Tarea_4
{
    public class UsuarioModel
    {
        [ColumnSqlAttribute("Id")]
        public int Id { get; set; }
        [ColumnSqlAttribute("Nombre_Usuario")]
        public string Nombre_Usuario { get; set; }
        [ColumnSqlAttribute("Nombre")]
        public string Nombre { get; set; }
        [ColumnSqlAttribute("Apellido")]
        public string Apellido { get; set; }
        [ColumnSqlAttribute("Telefono")]
        public string Telefono { get; set; }
        [ColumnSqlAttribute("Correo")]
        public string Correo { get; set; }
        [ColumnSqlAttribute("Clave")]
        public string Clave { get; set; }
    }
}