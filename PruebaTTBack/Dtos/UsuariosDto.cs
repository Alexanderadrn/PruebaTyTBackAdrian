namespace PruebaTTBack.ViewModels
{
    public class UsuariosDto
    {
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Usuario { get; set; }
        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public int IdCargo { get; set; }
        public string NombreCargo { get; set; }
        public bool Estado { set; get; }
        public string Email { get; set; }
    }
    public class CrearUsuariosDto
    {        
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Usuario { get; set; }
        public int IdDepartamento { get; set; }        
        public int IdCargo { get; set; }       
        public bool Estado { set; get; }
        public string Email { get; set; }
    }
    public class ActualizarUsuariosDto
    {
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Usuario { get; set; }
        public int IdDepartamento { get; set; }
        public int IdCargo { get; set; }
        public bool Estado { set; get; }
        public string Email { get; set; }
    }
}